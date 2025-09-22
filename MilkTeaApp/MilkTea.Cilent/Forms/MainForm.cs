using MilkTea.Client.Forms;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Mặc định load Trang Chủ khi mở form
            LoadForm(new OrderForm());
        }


        // ================== Các sự kiện nút ==================

        private void btnOrder_Click(object sender, EventArgs e)
        {
            LoadForm(new OrderForm());  // Form Order

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
    }
}
