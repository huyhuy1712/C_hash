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
        private readonly SizeService _sizeService;

        public OrderForm()
        {
            InitializeComponent();
            _sanPhamService = new SanPhamService();
            _loaiService = new LoaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
            _sizeService = new SizeService();
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
                var allSizes = await _sizeService.GetAll();
                    

                // ============= Tạo sản phẩm order mới =============
                var orderItem = new product_item_order
                {
                    TenSP = $"{chiTiet.TenSP} ({chiTiet.Gia:N0} VND)",
                    Gia = chiTiet.Gia,
                    Anh = chiTiet.Anh,
                };


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

                // Hiển thị dữ liệu lên control
                orderItem.setData();

                // Thêm control vào danh sách order
                section_table_panel.Controls.Add(orderItem);
                orderItem.Dock = DockStyle.Top;
                orderItem.BringToFront();
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
        private void roundedButton2_Click_1(object sender, EventArgs e)
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
                "Bạn có chắc chắn muốn xóa toàn bộ danh sách order không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                // Xóa toàn bộ các sản phẩm trong danh sách
                section_table_panel.Controls.Clear();

                // Reset tổng tiền (nếu có label hiển thị tổng tiền)
                TongTien_label.Text = "0";

                // Thông báo cho người dùng
                MessageBox.Show("Đã xóa toàn bộ danh sách order!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==================== CÁC SỰ KIỆN KHÁC (để trống) ====================
        private void section_table_panel_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
        private void label25_Click(object sender, EventArgs e) { }
        private void label29_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }

    }
}
