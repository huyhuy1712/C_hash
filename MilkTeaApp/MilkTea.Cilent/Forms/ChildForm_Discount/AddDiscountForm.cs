using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Discount
{
    public partial class AddDiscountForm : Form
    {
        public AddDiscountForm()
        {
            InitializeComponent();
        }

        private void AddDiscountForm_Load(object sender, EventArgs e)
        {
            // Khởi tạo dữ liệu mẫu cho các label sản phẩm
            label3.Text = "Trà Sữa Trân Châu";
            label4.Text = "Cà Phê Đen Đá";
            label10.Text = "Nước Ép Cam";
            label11.Text = "Bánh Mì Ngọt";
            label12.Text = "Trà Đào Cam Sả";

            // Tải hình ảnh mẫu cho PictureBox (thay đường dẫn bằng ảnh thực tế)
            try
            {
                pictureBox1.Image = Image.FromFile(@"C:\Images\tea.jpg");
                pictureBox2.Image = Image.FromFile(@"C:\Images\coffee.jpg");
                pictureBox3.Image = Image.FromFile(@"C:\Images\juice.jpg");
                pictureBox4.Image = Image.FromFile(@"C:\Images\bread.jpg");
                pictureBox5.Image = Image.FromFile(@"C:\Images\peach_tea.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải ảnh: " + ex.Message);
            }

            // Thiết lập CheckedListBox (nếu cần thêm sau)
            // checkedListBox1.Items.AddRange(new string[] { "Trà Sữa Trân Châu", "Cà Phê Đen Đá", "Nước Ép Cam", "Bánh Mì Ngọt" });
            // checkedListBox1.CheckOnClick = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Khi checkbox "Áp dụng cho tất cả" được bật/tắt, kích hoạt/tắt các checkbox sản phẩm
            bool enabled = !checkBox1.Checked;
            productCheckBox.Enabled = enabled;
            checkBox2.Enabled = enabled;
            checkBox3.Enabled = enabled;
            checkBox4.Enabled = enabled;
            checkBox5.Enabled = enabled;

            if (checkBox1.Checked)
            {
                // Bỏ chọn tất cả các checkbox sản phẩm
                productCheckBox.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void btnThemDiscount_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các điều khiển
            string title = textBox1.Text.Trim();
            string discount = roundedComboBox1.SelectedItem?.ToString() ?? "0%";
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            string description = textBox2.Text.Trim();

            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Vui lòng nhập tên chương trình khuyến mãi.", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (startDate >= endDate)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            // Lấy danh sách sản phẩm được chọn
            List<string> selectedProducts = new List<string>();
            if (!checkBox1.Checked)
            {
                if (productCheckBox.Checked) selectedProducts.Add(label3.Text); // Trà Sữa Trân Châu
                if (checkBox2.Checked) selectedProducts.Add(label4.Text); // Cà Phê Đen Đá
                if (checkBox3.Checked) selectedProducts.Add(label10.Text); // Nước Ép Cam
                if (checkBox4.Checked) selectedProducts.Add(label11.Text); // Bánh Mì Ngọt
                if (checkBox5.Checked) selectedProducts.Add(label12.Text); // Trà Đào Cam Sả

                if (selectedProducts.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm hoặc chọn 'Áp dụng cho tất cả'.", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }

            // Tạo thông báo xác nhận
            string productInfo = checkBox1.Checked ? "Tất cả sản phẩm" : string.Join(", ", selectedProducts);
            string message = $"Khuyến mãi '{title}' đã được thêm:\n" +
                            $"Giảm giá: {discount}\n" +
                            $"Ngày bắt đầu: {startDate.ToShortDateString()}\n" +
                            $"Ngày kết thúc: {endDate.ToShortDateString()}\n" +
                            $"Sản phẩm: {productInfo}\n" +
                            $"Mô tả: {description}";
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK);

            // Thêm thẻ vào flowLayoutPanel1 (giả lập)
            Panel newCard = new Panel
            {
                BackColor = Color.DarkTurquoise,
                Size = new Size(200, 100),
                Margin = new Padding(10)
            };
            Label cardLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = title,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            newCard.Controls.Add(cardLabel);
            flowLayoutPanel1.Controls.Add(newCard);

            // Đóng form sau khi thêm
            this.Close();
        }

        private void btnThoatDiscount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Logic khi click vào label sản phẩm (nếu cần)
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Logic khi click vào label sản phẩm (nếu cần)
        }

        private void Search_Load(object sender, EventArgs e)
        {
            // Sự kiện tải cho Search (nếu cần thêm logic)
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            // Logic vẽ nếu cần
        }
    }
}