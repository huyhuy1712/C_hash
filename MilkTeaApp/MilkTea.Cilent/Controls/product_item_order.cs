using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;

namespace MilkTea.Client.Controls
{
    public partial class product_item_order : UserControl
    {
        private readonly SizeService _sizeService;


        // ===================== PROPERTY =====================
        public string TenSP { get; set; }
        public decimal Gia { get; set; }
        public string Anh { get; set; }
        public string khuyenmai { get; set; }
        public decimal phantramgiam { get; set; }

        public List<Topping> DSTopping { get; set; } = new List<Topping>();

        // ===================== CONSTRUCTOR =====================
        public product_item_order()
        {
            InitializeComponent();
            _sizeService = new SizeService();
            product_item_order_Load(this, EventArgs.Empty);
        }

        // ===================== SET DATA =====================
        public async void setData()
        {

            lb.Text = TenSP;
            textBox1.Text = "1";

            // Load size từ DB
            var sizes = await _sizeService.GetAll();
            size_comboBox1.DataSource = sizes;
            size_comboBox1.DisplayMember = "TenSize";
            size_comboBox1.ValueMember = "MaSize";


            // Khuyến mãi
            SL_dc_label.Text = "10";
            label27.Text = khuyenmai?.ToString() ?? "Không có";

            decimal tienGiam = (Gia * phantramgiam) / 100;
            label26.Text = tienGiam.ToString("N0");

            // Thành tiền ban đầu
            decimal thanhTien = Gia - tienGiam + 10000;
            label19.Text = thanhTien.ToString("N0");

            // Ảnh sản phẩm
            try
            {
                string imgPath = Path.Combine(Application.StartupPath, "images", "tra_sua", Anh ?? "");
                if (File.Exists(imgPath))
                    pictureBox9.Image = Image.FromFile(imgPath);
            }
            catch { }

        }

        // ===================== LOAD EVENT =====================
        private void product_item_order_Load(object sender, EventArgs e)
        {
            // Khi số lượng thay đổi
            textBox1.TextChanged += (s, ev) => UpdateThanhTien();

            // Khi người dùng đổi size
            size_comboBox1.SelectedIndexChanged += (s, ev) =>
            {

                UpdateThanhTien();
            };
        }

        // ===================== CẬP NHẬT THÀNH TIỀN =====================
        private void UpdateThanhTien()
        {
            try
            {
                // 1️ Lấy số lượng
                int soLuong = 1;
                if (!int.TryParse(textBox1.Text, out soLuong) || soLuong <= 0)
                    soLuong = 1;

                // 2️ Lấy giá phụ thu từ size
                decimal sizePhuThu = 0;
                if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selectedSize)
                    sizePhuThu = selectedSize.PhuThu;

                // 3️ Tính tiền giảm theo số lượng
                decimal tienGiamMotSP = (Gia * phantramgiam / 100);
                decimal tienGiamTong = tienGiamMotSP * soLuong;

                // 4️ Thành tiền
                decimal thanhTien = ((Gia + sizePhuThu) * soLuong) - tienGiamTong;

                // 5️ Cập nhật hiển thị
                label26.Text = tienGiamTong.ToString("N0");
                label19.Text = thanhTien.ToString("N0");
            }
            catch
            {
                label19.Text = Gia.ToString("N0");
            }
        }

        // ===================== CÁC NÚT KHÁC =====================
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
            // Chỉ cho phép nhập số
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
            ToppingForm tp = new ToppingForm(this);
            tp.ShowDialog();
        }
    }
}
