using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Models;

namespace MilkTea.Client.Forms.ChildForm_Discount
{
    public partial class DetailDiscountForm : Form
    {
        private readonly int _maCTKhuyenMai;

        public DetailDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;

            // Gắn sự kiện load nếu chưa có trong Designer
            this.Load += DetailDiscountForm_Load;
        }

        private async void DetailDiscountForm_Load(object? sender, EventArgs e)
        {
            await LoadDiscountDetailAsync();
        }

        private async Task LoadDiscountDetailAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5021"); 

                var response = await client.GetAsync($"/api/ctkhuyenmai/{_maCTKhuyenMai}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Không thể tải chi tiết khuyến mãi (Mã: {_maCTKhuyenMai})!\nMã lỗi: {response.StatusCode}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                var km = JsonSerializer.Deserialize<CTKhuyenMai>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (km == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ✅ Gán dữ liệu thật vào giao diện
                label1.Text = km.TenCTKhuyenMai ?? "Chương trình khuyến mãi";
                label3.Text = $"Hạn sử dụng: {km.NgayBatDau?.ToString("dd/MM/yyyy") ?? "?"} - {km.NgayKetThuc?.ToString("dd/MM/yyyy") ?? "?"}";
                label4.Text = $"Giảm {(km.PhanTramKhuyenMai > 0 ? km.PhanTramKhuyenMai : 0)}% với các sản phẩm sau:";

                // ✅ Giả lập danh sách sản phẩm áp dụng (sẽ thay bằng dữ liệu thật sau)
                label5.Text = "+ Trà sữa truyền thống";
                label6.Text = "+ Trà đào cam sả";
                label7.Text = "+ Cà phê sữa đá";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết khuyến mãi:\n{ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
