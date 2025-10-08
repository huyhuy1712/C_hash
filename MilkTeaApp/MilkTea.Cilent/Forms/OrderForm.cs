using MilkTea.Client.Controls;
using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

                // Load danh sách loại (category)
                var loais = await _loaiService.GetLoaisAsync();
                comboBox3.DataSource = loais;
                comboBox3.DisplayMember = "TenLoai";
                comboBox3.ValueMember = "MaLoai";

                // Xóa control cũ trước khi thêm mới
                layout_product.Controls.Clear();

                // Tạo danh sách sản phẩm hiển thị
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
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== KHI CLICK CHỌN SẢN PHẨM ====================
        private async void ProductItem_OnProductSelected(object sender, ProductItem.SanPhamEventArgs e)
        {
            try
            {
                var sp = e.SanPham;

                // Lấy thông tin chi tiết sản phẩm và khuyến mãi
                var chiTiet = await _sanPhamService.GetSanPhamsByIdAsync(sp.MaSP);
                var ctkhuyenmai = await _ctKhuyenMaiService.GetByMaSP(sp.MaSP);

                //Tính số lượng có thể mua được
                var dscongthuc = await _ctCongThucService.GetChiTietCongThucTheoSPAsync(sp.MaSP);

                var nguyenLieuThieu = new List<string>();

                foreach (var nl in dscongthuc)
                {
                    if (nl.SoLuongTonKho < nl.SoLuongCanDung)
                    {
                        int thieu = nl.SoLuongCanDung - nl.SoLuongTonKho;
                        nguyenLieuThieu.Add($"- {nl.TenNguyenLieu} (cần {nl.SoLuongCanDung}, còn {nl.SoLuongTonKho})");
                    }
                }

                //  Nếu có nguyên liệu thiếu hoặc không có công thức
                if (nguyenLieuThieu.Count > 0 || dscongthuc.Count == 0)
                {
                    string message = $"Hiện tại không đủ nguyên liệu để pha chế món '{sp.TenSP}'.";
                    if (nguyenLieuThieu.Count > 0)
                    {
                        message += "\n\nNguyên liệu thiếu:\n" + string.Join("\n", nguyenLieuThieu);
                    }

                    MessageBox.Show(
                        message,
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return; // Không thêm vào danh sách order
                }

                // ============= Tạo sản phẩm order mới =============
                var slMuaDuoc = TinhSoLuongCoTheMua(dscongthuc);
                var orderItem = new product_item_order
                {
                    TenSP = $"{chiTiet.TenSP} ({chiTiet.Gia:N0} VND)",
                    Gia = chiTiet.Gia,
                    Anh = chiTiet.Anh,
                    SanPhamId = chiTiet.MaSP,
                };
                // Đăng ký sự kiện khi thành tiền thay đổi
                orderItem.ThanhTienChanged += (s, e) => CapNhatTongTien();

                // Thông tin khuyến mãi
                if (ctkhuyenmai == null)
                {
                    orderItem.khuyenmai = "Không có";
                    orderItem.phantramgiam = 0;
                }
                else
                {
                    orderItem.khuyenmai = ctkhuyenmai.TenCTKhuyenMai;
                    orderItem.phantramgiam = ctkhuyenmai.PhanTramKhuyenMai;
                }

                orderItem.SLMuaDuoc = slMuaDuoc; //số lượng mua được


                // Hiển thị dữ liệu lên control
                orderItem.setData();

                // Thêm control vào danh sách order
                section_table_panel.Controls.Add(orderItem);
                orderItem.Dock = DockStyle.Top;
                orderItem.BringToFront();

                // Trừ nguyên liệu trong kho
                foreach (var ct in dscongthuc)
                {
                    await _nguyenLieuService.TruNguyenLieuAsync(ct.MaNL, ct.SoLuongCanDung);
                }
                CapNhatTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm vào order: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== CÁC CHỨC NĂNG KHÁC ====================

        // Xuất đơn hàng
        private void btnXuatDon_Click(object sender, EventArgs e)
        {
            var invoiceForm = new InvoiceOrder();
            invoiceForm.ShowDialog();
        }

        // Nút thêm sản phẩm mới
        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            var addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        // ==================== NÚT XÓA DANH SÁCH ORDER ====================
        private async void roundedButton2_Click_1(object sender, EventArgs e)
        {
            // Nếu chưa có sản phẩm nào trong danh sách
            if (section_table_panel.Controls.Count == 0)
            {
                MessageBox.Show("Hiện tại chưa có sản phẩm nào trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hỏi xác nhận người dùng
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa toàn bộ danh sách order không? " +
                "Các nguyên liệu đã trừ sẽ được hoàn lại vào kho.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var ctService = new CTCongThucService();
                    var nlService = new NguyenLieuService();

                    // Duyệt qua từng sản phẩm trong danh sách
                    foreach (var ctrl in section_table_panel.Controls.OfType<product_item_order>())
                    {
                        int maSP = ctrl.SanPhamId; 
                        string tenSP = ctrl.TenSP;

                        // Lấy danh sách công thức của sản phẩm
                        var dsCongThuc = await ctService.GetChiTietCongThucTheoSPAsync(maSP);

                        if (dsCongThuc != null && dsCongThuc.Count > 0)
                        {
                            foreach (var ct in dsCongThuc)
                            {
                                await nlService.CongNguyenLieuAsync(ct.MaNL, ct.SoLuongCanDung);
                            }
                        }
                    }

                    // Sau khi hoàn nguyên xong, xóa danh sách
                    section_table_panel.Controls.Clear();
                    TongTien_label.Text = "0";

                    MessageBox.Show("Đã hoàn nguyên nguyên liệu và xóa toàn bộ danh sách order!",
                                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hoàn nguyên nguyên liệu: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== Hàm tính số lượng có thể mua ====================
        private int TinhSoLuongCoTheMua(List<CTCongThucSP> dsCongThuc)
        {
            if (dsCongThuc == null || dsCongThuc.Count == 0)
                return 0;

            var listSL = dsCongThuc
                .Where(x => x.SoLuongCanDung > 0)
                .Select(x => (int)Math.Floor((decimal)x.SoLuongTonKho / x.SoLuongCanDung))
                .ToList();

            if (listSL.Count == 0)
                return 0;

            return listSL.Min(); // lấy nguyên liệu giới hạn nhất
        }

        // ==================== Hàm cập nhật tổng tiền ====================
        public void CapNhatTongTien()
        {
            decimal tongTien = 0;

            // Duyệt qua tất cả các sản phẩm trong panel
            foreach (var item in section_table_panel.Controls.OfType<product_item_order>())
            {
                // Lấy label thành tiền trong product_item_order
                if (decimal.TryParse(item.thanhtien_lb.Text.Replace(",", "").Trim(), out decimal thanhTien))
                {
                    tongTien += thanhTien;
                }
            }

            TongTien_label.Text = tongTien.ToString("N0");
        }

        // ==================== CÁC SỰ KIỆN KHÁC (để trống) ====================
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }

    }
}
