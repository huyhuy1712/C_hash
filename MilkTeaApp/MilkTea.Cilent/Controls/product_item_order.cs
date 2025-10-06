using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Services;

namespace MilkTea.Client.Controls
{
    public partial class product_item_order : UserControl
    {
        private readonly SizeService _sizeService;

        // Các property để nhận dữ liệu từ form OrderForm
        public string TenSP { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string Anh { get; set; }
        public string khuyenmai { get; set; }
        public decimal phantramgiam { get; set; }

        public product_item_order()
        {
            InitializeComponent();
            _sizeService = new SizeService();
        }

        //  Hàm cập nhật hiển thị
        public async void setData()
        {
            lb.Text = TenSP;
            textBox1.Text = SoLuong.ToString();

            var sizes = await _sizeService.GetAll();
            size_comboBox1.DataSource = sizes;
            size_comboBox1.DisplayMember = "TenSize";
            size_comboBox1.ValueMember = "MaSize";

            SL_dc_label.Text = "10";
            label27.Text = khuyenmai.ToString();

            decimal tienGiam = (Gia * phantramgiam) / 100;
            label26.Text = tienGiam.ToString("N0");

            label19.Text = "30.000";
            try
            {
                string imgPath = Path.Combine(Application.StartupPath, "images", "tra_sua", Anh ?? "");
                if (File.Exists(imgPath))
                    pictureBox9.Image = Image.FromFile(imgPath);
            }
            catch { }
        }

        private void three_dots_label_Click(object sender, EventArgs e)
        {
            popup.Show(three_dots_label, new Point(0, three_dots_label.Height));
        }

        private void huy_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }

        private void size_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số (0–9) và phím Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn ký tự không hợp lệ
            }
        }

        private void textBox1_leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == "0")
            {
                textBox1.Text = "1"; // Giá trị mặc định
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

   
    }

}
