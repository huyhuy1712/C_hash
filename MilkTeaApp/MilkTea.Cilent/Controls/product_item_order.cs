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
using MilkTea.Client.Services;

namespace MilkTea.Client.Controls
{
    public partial class product_item_order : UserControl
    {
        private readonly SizeService _sizeService;
        private string _previousSize = string.Empty;  // Lưu size trước đó
        private bool _isInitializing = false;         // Chặn event khi đang load dữ liệu

        // ===================== PROPERTY =====================
        public string TenSP { get; set; }
        public decimal Gia { get; set; }
        public string Anh { get; set; }
        public string khuyenmai { get; set; }
        public decimal phantramgiam { get; set; }
        public string DefaultSelectedSize { get; set; }
        public string PreviousSize => _previousSize;

        // Lấy size hiện tại đang chọn
        public string SelectedSize
        {
            get
            {
                if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selected)
                    return selected.TenSize;
                return string.Empty;
            }
        }

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
            _isInitializing = true; // 🔒 Chặn sự kiện SelectedIndexChanged

            lb.Text = TenSP;
            textBox1.Text = "1";

            // Load size từ DB
            var sizes = await _sizeService.GetAll();
            size_comboBox1.DataSource = sizes;
            size_comboBox1.DisplayMember = "TenSize";
            size_comboBox1.ValueMember = "MaSize";

            // Nếu có size mặc định thì chọn nó
            if (!string.IsNullOrEmpty(DefaultSelectedSize))
            {
                int index = size_comboBox1.FindStringExact(DefaultSelectedSize);
                if (index >= 0)
                    size_comboBox1.SelectedIndex = index;
            }

            // Ghi nhớ size hiện tại
            if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selected)
                _previousSize = selected.TenSize;

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

            _isInitializing = false; // Cho phép event hoạt động lại
        }

        // ===================== LOAD EVENT =====================
        private void product_item_order_Load(object sender, EventArgs e)
        {
            // Khi số lượng thay đổi
            textBox1.TextChanged += (s, ev) => UpdateThanhTien();

            // Khi người dùng đổi size
            size_comboBox1.SelectedIndexChanged += (s, ev) =>
            {
                // Nếu đang load dữ liệu thì bỏ qua
                if (_isInitializing)
                    return;

                if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selectedSize)
                {
                    // Gửi sự kiện ra ngoài cho OrderForm
                    OnSizeChanged?.Invoke(TenSP, selectedSize.TenSize, this);
                    _previousSize = selectedSize.TenSize;
                }

                UpdateThanhTien();
            };
        }

        // ===================== CẬP NHẬT THÀNH TIỀN =====================
        private void UpdateThanhTien()
        {
            try
            {
                // 1️⃣ Lấy số lượng
                int soLuong = 1;
                if (!int.TryParse(textBox1.Text, out soLuong) || soLuong <= 0)
                    soLuong = 1;

                // 2️⃣ Lấy giá phụ thu từ size
                decimal sizePhuThu = 0;
                if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selectedSize)
                    sizePhuThu = selectedSize.PhuThu;

                // 3️⃣ Tính tiền giảm theo số lượng
                decimal tienGiamMotSP = (Gia * phantramgiam / 100);
                decimal tienGiamTong = tienGiamMotSP * soLuong;

                // 4️⃣ Thành tiền
                decimal thanhTien = ((Gia + sizePhuThu) * soLuong) - tienGiamTong;

                // 5️⃣ Cập nhật hiển thị
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

        // ===================== EVENT CALLBACK =====================
        // Sự kiện gửi ra ngoài (được OrderForm bắt để check trùng size)
        public event Action<string, string, product_item_order> OnSizeChanged;
    }
}
