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
        public OrderForm()
        {
            InitializeComponent();
            _sanPhamService = new SanPhamService();
            _loaiService = new LoaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
        }


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

                // Xóa hết control cũ trong flowLayoutPanel 
                layout_product.Controls.Clear();

                foreach (var sp in sanPhams)
                {
                    // Tạo một ProductItem (UserControl đã làm)
                    var item = new Controls.ProductItem();

                    // Set data từ SanPham
                    item.SetData(sp);

                    // Gắn sự kiện click sản phẩm
                    item.OnProductSelected += ProductItem_OnProductSelected;

                    // Add vào flowLayoutPanel hiển thị menu
                    layout_product.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gọi API: " + ex.Message);
            }
        }


        private async void ProductItem_OnProductSelected(object sender, ProductItem.SanPhamEventArgs e)
        {
            try
            {
                // Lấy dữ liệu sản phẩm từ event args
                var sp = e.SanPham;

                //  Gọi lại API chi tiết sản phẩm theo ID vaf chương trình khuyến mãi của sản phẩm (nếu có)
                var chiTiet = await _sanPhamService.GetSanPhamsByIdAsync(sp.MaSP);
                var ctkhuyenmai = await _ctKhuyenMaiService.GetByMaSP(sp.MaSP);

                // Tạo control product_item_order mới
                var orderItem = new Controls.product_item_order();

                // Gán dữ liệu
                orderItem.TenSP = $"{chiTiet.TenSP} ({chiTiet.Gia:N0} VND)";
                orderItem.Gia = chiTiet.Gia;
                orderItem.SoLuong = 1;
                orderItem.Anh = chiTiet.Anh;

                //Kiểm tra xem sản phẩm có đang dc khuyến mãi không
                if(ctkhuyenmai == null)
                {
                    orderItem.khuyenmai = "Không có";
                    orderItem.phantramgiam = 0;
                }
                else
                {
                    orderItem.khuyenmai = ctkhuyenmai.TenCTKhuyenMai;
                    orderItem.phantramgiam = ctkhuyenmai.PhanTramKhuyenMai;
                }

                orderItem.setData();

                // Thêm control vào panel chứa danh sách order
                section_table_panel.Controls.Add(orderItem);

                // Đặt dock kiểu Top (để stack control từ trên xuống)
                orderItem.Dock = DockStyle.Top;
                orderItem.BringToFront(); // để control mới nằm trên cùng

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm vào order: " + ex.Message);
            }
        }




        private void label1_Click_1(object sender, EventArgs e)
        {

        }



        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatDon_Click(object sender, EventArgs e)
        {
            InvoiceOrder invoiceForm = new InvoiceOrder();
            invoiceForm.ShowDialog();

        }


        private void section_table_panel_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label29_Click(object sender, EventArgs e)
        {

        }



        private void popup_Opening(object sender, CancelEventArgs e)
        {

        }


        private void Topping_Click(object sender, EventArgs e)
        {
            ToppingForm toppingForm = new ToppingForm();
            toppingForm.ShowDialog();

        }

        private void product_edit_btn1_Click(object sender, EventArgs e)
        {
            EditProductForm editProductForm = new EditProductForm();
            editProductForm.ShowDialog();
        }

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
