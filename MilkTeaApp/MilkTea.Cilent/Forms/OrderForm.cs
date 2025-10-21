using MilkTea.Client.Controls;
using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms
{
    public partial class OrderForm : Form
    {
        private readonly SanPhamService _sanPhamService;
        private readonly LoaiService _loaiService;
        private readonly CTKhuyenMaiService _ctKhuyenMaiService;
        private readonly CTCongThucService _ctCongThucService;
        private readonly buzzerService _buzzerService;

        private TaiKhoan _current_account;

        //  Bộ nhớ tạm lưu nguyên liệu đã dùng (chỉ trong phiên order)
        private readonly Dictionary<int, decimal> _nguyenLieuDaDungTam = new();

        public OrderForm(TaiKhoan account)
        {
            InitializeComponent();
            _current_account = account;
            _sanPhamService = new SanPhamService();
            _loaiService = new LoaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
            _ctCongThucService = new CTCongThucService();
            _buzzerService = new buzzerService();
        }

        // ==================== LOAD FORM ====================
        private async void OrderForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

                    private async Task LoadDataAsync()
        {
            try
            {
                // 1️ Lấy danh sách sản phẩm
                var sanPhams = await _sanPhamService.GetSanPhamsAsync();

                // 2️ Ghi tên nhân viên hiện tại
                Ten_NV_Label.Text = _current_account.TenTaiKhoan;

                // 3️ Load loại sản phẩm vào combobox
                var loais = await _loaiService.GetLoaisAsync();
                comboBox3.DataSource = loais;
                comboBox3.DisplayMember = "TenLoai";
                comboBox3.ValueMember = "MaLoai";

                // 4️ Load buzzer còn hoạt động
                var buzzers = await _buzzerService.GetBuzzerByTrangThai(1);
                comboBox1.DataSource = buzzers;
                comboBox1.DisplayMember = "SoHieu";
                comboBox1.ValueMember = "MaBuzzer";

                // 5️ Làm mới danh sách sản phẩm hiển thị
                layout_product.Controls.Clear();

                foreach (var sp in sanPhams)
                {
                    if (sp.TrangThai == 1) // chỉ hiển thị sản phẩm đang hoạt động
                    {
                        var item = new ProductItem();
                        item.SetData(sp);
                        item.OnProductSelected += ProductItem_OnProductSelected;
                        layout_product.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải sản phẩm: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ==================== KHI CHỌN 1 SẢN PHẨM ====================
        private async void ProductItem_OnProductSelected(object sender, ProductItem.SanPhamEventArgs e)
        {
            try
            {
                var sp = e.SanPham;

                // Lấy chi tiết SP + KM + công thức
                var chiTiet = await _sanPhamService.GetSanPhamsByIdAsync(sp.MaSP);
                var ctkm = await _ctKhuyenMaiService.GetByMaSP(sp.MaSP);
                var dsCT = await _ctCongThucService.GetChiTietCongThucTheoSPAsync(sp.MaSP);


                // Lấy dictionary tạm
                var dict = _nguyenLieuDaDungTam;
                var nguyenLieuThieu = new List<string>();

                // ================== KIỂM TRA NGUYÊN LIỆU ==================
                foreach (var nl in dsCT)
                {
                    decimal daDung = dict.ContainsKey(nl.MaNL) ? dict[nl.MaNL] : 0;
                    decimal tonThucTe = nl.SoLuongTonKho - daDung;

                    if (tonThucTe < nl.SoLuongCanDung)
                    {
                        nguyenLieuThieu.Add($"- {nl.TenNguyenLieu} (cần {nl.SoLuongCanDung}, còn {tonThucTe})");
                    }
                }

                // Nếu thiếu nguyên liệu thì báo lỗi và dừng lại
                if (nguyenLieuThieu.Count > 0)
                {
                    string msg = $"Không đủ nguyên liệu để pha chế món '{sp.TenSP}'.\n\nThiếu:\n" +
                                 string.Join("\n", nguyenLieuThieu);

                    MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ================== TÍNH SL CÓ THỂ MUA (theo kho ảo) ==================
                var listSL = dsCT
                    .Where(x => x.SoLuongCanDung > 0)
                    .Select(x =>
                    {
                        decimal daDung = dict.ContainsKey(x.MaNL) ? dict[x.MaNL] : 0;
                        decimal tonThucTe = x.SoLuongTonKho - daDung;
                        return (int)Math.Floor(tonThucTe / x.SoLuongCanDung);
                    })
                    .ToList();

                int slMuaDuoc = listSL.Count == 0 ? 0 : listSL.Min();
                if (slMuaDuoc <= 0)
                {
                    MessageBox.Show(
                        $"Sản phẩm '{sp.TenSP}' đã hết nguyên liệu trong kho, không thể thêm vào order!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ================== TẠO ITEM ==================
                var orderItem = new product_item_order
                {
                    TenSP = $"{chiTiet.TenSP} ({chiTiet.Gia:N0} VND)",
                    Gia = chiTiet.Gia,
                    Anh = chiTiet.Anh,
                    SanPhamId = chiTiet.MaSP,
                    SLMuaDuoc = slMuaDuoc,
                    khuyenmai = ctkm?.TenCTKhuyenMai ?? "Không có",
                    phantramgiam = ctkm?.PhanTramKhuyenMai ?? 0
                };

                // ================== ĐĂNG KÝ SỰ KIỆN ==================
                orderItem.ThanhTienChanged += (s, ev) => CapNhatTongTien();
                orderItem.OnOrderUpdated += async (s, ev) =>
                {
                    await CapNhatLaiSLMuaDuocChoTatCaSanPham();
                };

                // ================== HIỂN THỊ VÀ THÊM ==================
                orderItem.setData();
                section_table_panel.Controls.Add(orderItem);
                orderItem.Dock = DockStyle.Top;
                orderItem.BringToFront();

                // ================== CẬP NHẬT NGUYÊN LIỆU TẠM ==================
                foreach (var ct in dsCT)
                {
                    if (dict.ContainsKey(ct.MaNL))
                        dict[ct.MaNL] += ct.SoLuongCanDung;
                    else
                        dict[ct.MaNL] = ct.SoLuongCanDung;
                }

                CapNhatTongTien();
                await CapNhatLaiSLMuaDuocChoTatCaSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== XUẤT ĐƠN (TRỪ THẬT) ====================
        private void xuatDon_btn_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các combobox
            string phuongThucThanhToan = comboBox_pttt.Text?.Trim();
            string maMay = comboBox1.Text?.Trim();

            // Kiểm tra bắt buộc
            if (string.IsNullOrEmpty(phuongThucThanhToan) || string.IsNullOrEmpty(maMay))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ phương thức thanh toán và mã máy trước khi xuất đơn!",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy danh sách sản phẩm hiện tại
            var sanPhamDaMua = section_table_panel.Controls
                .OfType<product_item_order>()
                .Select(item => new InvoiceItem
                {
                    MaSP = item.SanPhamId,
                    TenSP = item.TenSP,
                    Size = item.size_comboBox1.Text,
                    SizeId = Convert.ToInt32(item.size_comboBox1.SelectedValue),
                    SoLuong = int.TryParse(item.textBox1.Text, out int sl) ? sl : 1,
                    DonGia = item.Gia,
                    TienGiam = decimal.Parse(item.label26.Text),
                    TongTien = decimal.Parse(item.thanhtien_lb.Text),
                    Toppings = item.DSTopping
                })
                .ToList();

            // Tính tổng tiền toàn bộ
            decimal tongCong = sanPhamDaMua.Sum(x => x.TongTien);

            // ===== Kiểm tra có sản phẩm nào không =====
            if (sanPhamDaMua == null || sanPhamDaMua.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào được chọn để xuất đơn!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // Mở hóa đơn
            var invoice = new InvoiceOrder
            {
                NhanVien = Ten_NV_Label.Text,
                PhuongThucThanhToan = phuongThucThanhToan,

                MaMay = maMay,
                SanPhamDaMua = sanPhamDaMua,
                TongCong = tongCong
            };

            // Khi InvoiceOrder xác nhận -> reload lại combobox máy buzzer
            invoice.ReloadRequested += async (s, ev) =>
            {
                try
                {
                    var buzzers = await _buzzerService.GetBuzzerByTrangThai(1);
                    comboBox1.DataSource = null;
                    comboBox1.DataSource = buzzers;
                    comboBox1.DisplayMember = "SoHieu";
                    comboBox1.ValueMember = "MaBuzzer";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi reload máy buzzer: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            invoice.ShowDialog();
        }



        // ==================== XÓA TẤT CẢ ORDER ====================
        private async void roundedButton2_Click_1(object sender, EventArgs e)
        {
            if (section_table_panel.Controls.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Xóa toàn bộ order?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var ctService = new CTCongThucService();

                    // Duyệt qua tất cả sản phẩm trong danh sách
                    foreach (var ctrl in section_table_panel.Controls.OfType<product_item_order>())
                    {
                        int maSP = ctrl.SanPhamId;
                        var dsCongThuc = await ctService.GetChiTietCongThucTheoSPAsync(maSP);

                        //  Hoàn lại nguyên liệu trong RAM
                        foreach (var ct in dsCongThuc)
                        {
                            if (_nguyenLieuDaDungTam.ContainsKey(ct.MaNL))
                            {
                                _nguyenLieuDaDungTam[ct.MaNL] -= ct.SoLuongCanDung;
                                if (_nguyenLieuDaDungTam[ct.MaNL] <= 0)
                                    _nguyenLieuDaDungTam.Remove(ct.MaNL);
                            }
                        }
                    }

                    //  Xóa toàn bộ sản phẩm khỏi giao diện
                    section_table_panel.Controls.Clear();
                    TongTien_label.Text = "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hoàn nguyên nguyên liệu: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (var item in section_table_panel.Controls.OfType<product_item_order>())
            {
                if (decimal.TryParse(item.thanhtien_lb.Text.Replace(",", ""), out decimal thanhTien))
                    tong += thanhTien;
            }
            TongTien_label.Text = tong.ToString("N0");
        }

        private async Task CapNhatLaiSLMuaDuocChoTatCaSanPham()
        {
            var ctService = new CTCongThucService();

            foreach (var item in section_table_panel.Controls.OfType<product_item_order>())
            {
                var dsCT = await ctService.GetChiTietCongThucTheoSPAsync(item.SanPhamId);
                var listSL = dsCT
                    .Where(x => x.SoLuongCanDung > 0)
                    .Select(x =>
                    {
                        decimal tonKho = x.SoLuongTonKho;
                        if (_nguyenLieuDaDungTam.ContainsKey(x.MaNL))
                            tonKho -= _nguyenLieuDaDungTam[x.MaNL];
                        if (tonKho < 0) tonKho = 0;
                        return (int)Math.Floor(tonKho / x.SoLuongCanDung);
                    })
                    .ToList();

                int sl = listSL.Count == 0 ? 0 : listSL.Min();
                item.SL_dc_label.Text = sl.ToString();
                item.SLMuaDuoc = sl;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }

        // Cho phép product_item_order truy cập dictionary này
        public Dictionary<int, decimal> GetNguyenLieuDaDungTam() => _nguyenLieuDaDungTam;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();

            addProductForm.SanPhamAdded += async (s, args) =>
            {
                await LoadDataAsync(); // reload dữ liệu sau khi thêm
            };

            addProductForm.StartPosition = FormStartPosition.CenterScreen;
            addProductForm.ShowDialog();
        }



    }
}
