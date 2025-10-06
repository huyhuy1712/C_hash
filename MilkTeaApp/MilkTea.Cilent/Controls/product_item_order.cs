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
        public string Anh { get; set; }
        public string khuyenmai { get; set; }
        public decimal phantramgiam { get; set; }

        public product_item_order()
        {
            InitializeComponent();
            _sizeService = new SizeService();
            product_item_order_Load(this, EventArgs.Empty);
        }

        //  Hàm cập nhật hiển thị
        public async void setData()
        {
            //tên và số lượng sản phẩm
            lb.Text = TenSP;
            textBox1.Text = "1";

            //lấy dữ liệu size
            var sizes = await _sizeService.GetAll();
            size_comboBox1.DataSource = sizes;
            size_comboBox1.DisplayMember = "TenSize";
            size_comboBox1.ValueMember = "MaSize";

            //giá giảm và khuyến mãi
            SL_dc_label.Text = "10";
            label27.Text = khuyenmai.ToString();

            decimal tienGiam = (Gia * phantramgiam) / 100;
            label26.Text = tienGiam.ToString("N0");

            //thành tiền
            decimal thanhtien = Gia - tienGiam + 10000;
            label19.Text = thanhtien.ToString("N0");

            //ảnh sản phẩm
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

        private void product_item_order_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += (s, ev) => UpdateThanhTien();
            size_comboBox1.SelectedIndexChanged += (s, ev) => UpdateThanhTien();
        }

        //cập nhật thành tiền
        private void UpdateThanhTien()
        {
            try
            {
                // 1️ Lấy số lượng (mặc định 1 nếu rỗng hoặc <= 0)
                int soLuong = 1;
                if (!int.TryParse(textBox1.Text, out soLuong) || soLuong <= 0)
                    soLuong = 1;

                // 2️ Lấy giá phụ thu từ size
                decimal sizePhuThu = 0;
                if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selectedSize)
                {
                    sizePhuThu = selectedSize.PhuThu;
                }

                // 3️ Tính tiền giảm DỰA TRÊN SỐ LƯỢNG
                decimal tienGiamMotSP = (Gia * phantramgiam / 100);
                decimal tienGiamTong = tienGiamMotSP * soLuong;

                // 4️ Tính thành tiền cuối cùng
                decimal thanhTien = ((Gia + sizePhuThu) * soLuong) - tienGiamTong;

                // 5️ Cập nhật hiển thị
                label26.Text = tienGiamTong.ToString("N0"); // Tổng tiền giảm
                label19.Text = thanhTien.ToString("N0");    // Thành tiền cuối cùng
            }
            catch
            {
                label19.Text = Gia.ToString("N0");
            }
        }




    }

}
