using Microsoft.Extensions.DependencyInjection;
using MilkTea.Client.Forms;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms
{
    public partial class MainForm : Form
    {
        private TaiKhoan _account;
        public MainForm(TaiKhoan account)
        {
            _account = account;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Hàm chung để load form con vào panelContent
        private void LoadForm(Form frm)
        {
            panelContent.Controls.Clear();          // Xóa control cũ
            frm.TopLevel = false;                   // Không phải form độc lập
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;              // Chiếm hết panelContent
            panelContent.Controls.Add(frm);         // Add vào panel
            frm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Mặc định load Trang Chủ khi mở form
            LoadForm(new OrderForm(_account));
            username.Text = _account.TenTaiKhoan;
            try
            {
                // Xác định đường dẫn ảnh nhân viên
                string basePath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                string imgPath = Path.Combine(basePath, "images", "nhan_vien", _account.anh ?? "");

                if (!string.IsNullOrEmpty(_account.anh) && File.Exists(imgPath))
                {
                    //  Load ảnh thật của nhân viên
                    avatarUser.Image = Image.FromFile(imgPath);
                }
                else
                {
                    //  Fallback: dùng ảnh mặc định trong Properties.Resources
                    avatarUser.Image = Properties.Resources.user;
                }
            }
            catch (Exception ex)
            {
                //  Nếu có lỗi bất ngờ (ví dụ ảnh bị lỗi định dạng)
                MessageBox.Show($"Không thể tải ảnh đại diện: {ex.Message}", "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                avatarUser.Image = Properties.Resources.user;
            }

            //Kiểm tra quyền để hiển thị button
            btnOrder.Enabled = Session.HasPermission("Vào đơn hàng");
            btnHoaDon.Enabled = Session.HasPermission("Vào hóa đơn");
            btnThongKe.Enabled = Session.HasPermission("Vào thống kê");
            btnKhuyenMai.Enabled = Session.HasPermission("Vào khuyến mãi");
            btnPhieuNhap.Enabled = Session.HasPermission("Vào nhập hàng");
            btnTaiKhoan.Enabled = Session.HasPermission("Vào tài khoản");
            btnNhaCungCap.Enabled = Session.HasPermission("Vào nhà cung cấp");
            btnNguyenLieu.Enabled = Session.HasPermission("Vào nguyên liệu");
        }


        // ================== Các sự kiện nút ==================

        private void btnOrder_Click(object sender, EventArgs e)
        {
            LoadForm(new OrderForm(_account));  // Form Order

        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            LoadForm(new InvoiceForm());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportForm());
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            LoadForm(new ImportForm());
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            LoadForm(new DiscountForm());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            LoadForm(new AccountForm());
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            LoadForm(new SupplierForm());
        }

        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {
            LoadForm(new IngredientForm());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Giải phóng các form con đang load trong panel
                panelContent.Controls.OfType<Form>().ToList().ForEach(f => f.Dispose());
                panelContent.Controls.Clear();

                _account = null;

                // Mở lại LoginForm
                var loginForm = new LoginForm();
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                loginForm.Show();

                // Đóng MainForm hiện tại
                this.Hide(); 
            }
        }

    }
}
