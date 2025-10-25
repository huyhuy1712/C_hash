using MilkTea.Client.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MilkTea.Client.Forms.ChildForm_Discount
{
    public partial class EditDiscountForm : Form
    {
        private readonly int _maCTKhuyenMai;

        public EditDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;
            this.Load += EditDiscountForm_Load;
        }

        private async void EditDiscountForm_Load(object sender, EventArgs e)
        {
            await LoadDiscountAsync();
        }

        private async Task LoadDiscountAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5198");

                var response = await client.GetAsync($"/api/ctkhuyenmai/{_maCTKhuyenMai}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không thể tải thông tin khuyến mãi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                var km = JsonSerializer.Deserialize<CTKhuyenMai>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (km != null)
                {
                    // Gán dữ liệu vào form
                    textBox1.Text = km.TenCTKhuyenMai;
                    textBox2.Text = km.MoTa;
                    roundedComboBox1.SelectedItem = km.PhanTramKhuyenMai + "%";
                    dateTimePicker1.Value = km.NgayBatDau ?? DateTime.Now;
                    dateTimePicker2.Value = km.NgayKetThuc ?? DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string tenCT = textBox1.Text.Trim();
                string moTa = textBox2.Text.Trim();
                string discountText = roundedComboBox1.SelectedItem?.ToString()?.Replace("%", "") ?? "0";
                int phanTram = int.TryParse(discountText, out int val) ? val : 0;
                DateTime ngayBatDau = dateTimePicker1.Value;
                DateTime ngayKetThuc = dateTimePicker2.Value;

                var km = new CTKhuyenMai
                {
                    MaCTKhuyenMai = _maCTKhuyenMai,
                    TenCTKhuyenMai = tenCT,
                    MoTa = moTa,
                    NgayBatDau = ngayBatDau,
                    NgayKetThuc = ngayKetThuc,
                    PhanTramKhuyenMai = phanTram,
                    TrangThai = 1
                };

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5198");

                var json = JsonSerializer.Serialize(km);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("/api/ctkhuyenmai", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới danh sách bên DiscountForm
                    if (Owner is DiscountForm discountForm)
                        await discountForm.LoadDiscountsAsync();

                    this.Close();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi cập nhật: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}");
            }
        }

        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // 📝 Lấy thông tin từ các control trên form
                string tenCT = textBox1.Text.Trim();
                string moTa = textBox2.Text.Trim();
                string discountText = roundedComboBox1.SelectedItem?.ToString()?.Replace("%", "") ?? "0";
                int phanTram = int.TryParse(discountText, out int val) ? val : 0;
                DateTime ngayBatDau = dateTimePicker1.Value;
                DateTime ngayKetThuc = dateTimePicker2.Value;

                // ✅ Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenCT))
                {
                    MessageBox.Show("Vui lòng nhập tên chương trình khuyến mãi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ngayBatDau >= ngayKetThuc)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (phanTram <= 0)
                {
                    MessageBox.Show("Phần trăm khuyến mãi phải lớn hơn 0%.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🧱 Tạo object khuyến mãi mới để gửi lên API
                var km = new MilkTea.Client.Models.CTKhuyenMai
                {
                    MaCTKhuyenMai = _maCTKhuyenMai, // ID đang chỉnh sửa
                    TenCTKhuyenMai = tenCT,
                    MoTa = moTa,
                    NgayBatDau = ngayBatDau,
                    NgayKetThuc = ngayKetThuc,
                    PhanTramKhuyenMai = phanTram,
                    TrangThai = 1
                };

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5198");

                var json = JsonSerializer.Serialize(km);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // 🚀 Gửi PUT request lên API
                var response = await client.PutAsync("/api/ctkhuyenmai", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật chương trình khuyến mãi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🔄 Làm mới lại danh sách trong DiscountForm
                    if (Owner is DiscountForm discountForm)
                        await discountForm.LoadDiscountsAsync();

                    this.Close();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi cập nhật: {response.StatusCode}\n{err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
