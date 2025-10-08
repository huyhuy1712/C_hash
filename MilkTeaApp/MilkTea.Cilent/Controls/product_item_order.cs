using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;

namespace MilkTea.Client.Controls
{
    public partial class product_item_order : UserControl
    {
        private readonly SizeService _sizeService;

        public string TenSP { get; set; }
        public decimal Gia { get; set; }
        public string Anh { get; set; }
        public string khuyenmai { get; set; }
        public decimal phantramgiam { get; set; }
        public List<Topping> DSTopping { get; set; } = new List<Topping>();

        public product_item_order()
        {
            InitializeComponent();
            _sizeService = new SizeService();
            product_item_order_Load(this, EventArgs.Empty);
        }

        public async void setData()
        {
            lb.Text = TenSP;
            textBox1.Text = "1";

            var sizes = await _sizeService.GetAll();
            size_comboBox1.DataSource = sizes;
            size_comboBox1.DisplayMember = "TenSize";
            size_comboBox1.ValueMember = "MaSize";

            SL_dc_label.Text = "10";
            label27.Text = khuyenmai?.ToString() ?? "Không có";

            decimal tienGiam = (Gia * phantramgiam) / 100;
            label26.Text = tienGiam.ToString("N0");

            decimal thanhTien = Gia - tienGiam + 10000;
            label19.Text = thanhTien.ToString("N0");

            try
            {
                string imgPath = Path.Combine(Application.StartupPath, "images", "tra_sua", Anh ?? "");
                if (File.Exists(imgPath))
                    pictureBox9.Image = Image.FromFile(imgPath);
            }
            catch { }
        }

        private void product_item_order_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += (s, ev) => UpdateThanhTien();
            size_comboBox1.SelectedIndexChanged += (s, ev) => UpdateThanhTien();
        }

        private void UpdateThanhTien()
        {
            try
            {
                int soLuong = int.TryParse(textBox1.Text, out var sl) && sl > 0 ? sl : 1;

                decimal sizePhuThu = 0;
                if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selectedSize)
                    sizePhuThu = selectedSize.PhuThu;

                decimal tienGiamMotSP = Gia * phantramgiam / 100;
                decimal tienGiamTong = tienGiamMotSP * soLuong;
                decimal thanhTien = ((Gia + sizePhuThu) * soLuong) - tienGiamTong;

                label26.Text = tienGiamTong.ToString("N0");
                label19.Text = thanhTien.ToString("N0");
            }
            catch
            {
                label19.Text = Gia.ToString("N0");
            }
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == "0")
                textBox1.Text = "1";
        }

        private void Topping_Click(object sender, EventArgs e)
        {
            var tp = new ToppingForm(this);

            tp.OnToppingConfirmed += (s, toppings) =>
            {
                DSTopping = toppings;
                CapNhatThanhTienTheoTopping();
            };

            tp.ShowDialog();
        }

        private void CapNhatThanhTienTheoTopping()
        {
            decimal tongTopping = DSTopping.Sum(t => t.gia);

            decimal sizePhuThu = 0;
            if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selectedSize)
                sizePhuThu = selectedSize.PhuThu;

            int soLuong = int.TryParse(textBox1.Text, out var sl) ? sl : 1;
            decimal tienGiamMotSP = Gia * phantramgiam / 100;
            decimal tienGiamTong = tienGiamMotSP * soLuong;
            decimal thanhTien = ((Gia + sizePhuThu + tongTopping) * soLuong) - tienGiamTong;

            label19.Text = thanhTien.ToString("N0");
        }
    }
}
