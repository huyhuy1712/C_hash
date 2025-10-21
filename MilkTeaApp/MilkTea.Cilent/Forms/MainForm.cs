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
            string basePath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            string imgPath = Path.Combine(basePath, "images", "nhan_vien", _account.anh ?? "");



            if (!string.IsNullOrEmpty(_account.anh) && File.Exists(imgPath))
            {
                // Load ảnh từ file
                avatarUser.Image = Image.FromFile(imgPath);
            }
            else
            {
                // fallback ảnh mặc định nếu không tìm thấy
                //avatarUser.Image = Properties.Resources;
            }

            //Kiểm tra quyền để hiển thị button
            btnOrder.Enabled = Session.HasPermission("Vào đơn hàng");
            btnHoaDon.Enabled = Session.HasPermission("Vào hóa đơn");
            btnThongKe.Enabled = Session.HasPermission("Vào thống kê");
            btnKhuyenMai.Enabled = Session.HasPermission("Vào khuyến mãi");
            btnPhieuNhap.Enabled = Session.HasPermission("Vào nhập hàng");
            btnTaiKhoan.Enabled = Session.HasPermission("Vào tài khoản");
            if (Session.AllowedFunctions.Count == 0)
            {
                Debug.WriteLine("khong co quyen");
            }
            Session.AllowedFunctions.ForEach(cn => Debug.WriteLine(cn.TenChucNang));
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void signature_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
