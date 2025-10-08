using MilkTea.Client.Controls;
using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
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
        private readonly NguyenLieuService _nguyenLieuService;

        // 🧠 Bộ nhớ tạm lưu nguyên liệu đã dùng (chỉ trong phiên order)
        private readonly Dictionary<int, decimal> _nguyenLieuDaDungTam = new();

        public OrderForm()
        {
            InitializeComponent();
            _sanPhamService = new SanPhamService();
            _loaiService = new LoaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
            _ctCongThucService = new CTCongThucService();
            _nguyenLieuService = new NguyenLieuService();
        }

        // ==================== LOAD FORM ====================
        private async void OrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                var sanPhams = await _sanPhamService.GetSanPhamsAsync();

                var loais = await _loaiService.GetLoaisAsync();
                comboBox3.DataSource = loais;
                comboBox3.DisplayMember = "TenLoai";
                comboBox3.ValueMember = "MaLoai";

                layout_product.Controls.Clear();

                foreach (var sp in sanPhams)
                {
                    var item = new ProductItem();
                    item.SetData(sp);
                    item.OnProductSelected += ProductItem_OnProductSelected;
                    layout_product.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Kiểm tra nguyên liệu đủ không
                var nlThieu = new List<string>();
                foreach (var nl in dsCT)
                {
                    if (nl.SoLuongTonKho < nl.SoLuongCanDung)
                        nlThieu.Add($"- {nl.TenNguyenLieu} (cần {nl.SoLuongCanDung}, còn {nl.SoLuongTonKho})");
                }

                if (nlThieu.Count > 0 || dsCT.Count == 0)
                {
                    string msg = $"Không đủ nguyên liệu để pha chế món '{sp.TenSP}'.";
                    if (nlThieu.Count > 0)
                        msg += "\n\nThiếu:\n" + string.Join("\n", nlThieu);

                    MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính số lượng có thể mua
                int slMuaDuoc = TinhSoLuongCoTheMua(dsCT);

                // Tạo item
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

                // Đăng ký event cập nhật
                orderItem.ThanhTienChanged += (s, ev) => CapNhatTongTien();
                orderItem.OnOrderUpdated += async (s, ev) =>
                {
                    await CapNhatLaiSLMuaDuocChoTatCaSanPham();
                };

                orderItem.setData();
                section_table_panel.Controls.Add(orderItem);
                orderItem.Dock = DockStyle.Top;
                orderItem.BringToFront();

                // ✅ Cập nhật nguyên liệu đã dùng tạm (RAM)
                foreach (var ct in dsCT)
                {
                    if (_nguyenLieuDaDungTam.ContainsKey(ct.MaNL))
                        _nguyenLieuDaDungTam[ct.MaNL] += ct.SoLuongCanDung;
                    else
                        _nguyenLieuDaDungTam[ct.MaNL] = ct.SoLuongCanDung;
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
        private async void btnXuatDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (section_table_panel.Controls.Count == 0)
                {
                    MessageBox.Show("Không có sản phẩm để xuất đơn!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show("Bạn có chắc muốn xuất đơn và trừ nguyên liệu trong kho?",
                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var ctService = new CTCongThucService();
                var nlService = new NguyenLieuService();

                // Duyệt từng sản phẩm
                foreach (var item in section_table_panel.Controls.OfType<product_item_order>())
                {
                    var dsCT = await ctService.GetChiTietCongThucTheoSPAsync(item.SanPhamId);
                    int soLuong = int.TryParse(item.textBox1.Text, out var sl) ? sl : 1;

                    foreach (var ct in dsCT)
                    {
                        // Trừ thật trong DB
                        await nlService.TruNguyenLieuAsync(ct.MaNL, ct.SoLuongCanDung * soLuong);
                    }
                }

                // Sau khi xuất đơn: reset
                _nguyenLieuDaDungTam.Clear();
                section_table_panel.Controls.Clear();
                TongTien_label.Text = "0";

                MessageBox.Show("Xuất đơn thành công! Nguyên liệu đã được trừ thật trong kho.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất đơn: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== XÓA TẤT CẢ ORDER ====================
        private void roundedButton2_Click_1(object sender, EventArgs e)
        {
            if (section_table_panel.Controls.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Xóa toàn bộ order (nguyên liệu tạm sẽ được hoàn)?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                section_table_panel.Controls.Clear();
                _nguyenLieuDaDungTam.Clear();
                TongTien_label.Text = "0";
            }
        }

        // ==================== HÀM PHỤ ====================

        private int TinhSoLuongCoTheMua(List<CTCongThucSP> dsCT)
        {
            if (dsCT == null || dsCT.Count == 0) return 0;

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

            return listSL.Count == 0 ? 0 : listSL.Min();
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
    }
}
