using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<SanPham> danhSachSanPhamApDung = new List<SanPham>(); // Lưu list sản phẩm để dùng

        public DetailDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;

            // Gắn sự kiện load
            this.Load += DetailDiscountForm_Load;
        }

        private async void DetailDiscountForm_Load(object sender, EventArgs e)
        {
            await LoadDiscountDetailAsync();
        }

        private async Task LoadDiscountDetailAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5198"); // Đổi port nếu backend khác

                // Load chi tiết CTKhuyenMai
                var kmResponse = await client.GetAsync($"/api/ctkhuyenmai/{_maCTKhuyenMai}");
                CTKhuyenMai km = null;
                if (kmResponse.IsSuccessStatusCode)
                {
                    var kmJson = await kmResponse.Content.ReadAsStringAsync();
                    km = JsonSerializer.Deserialize<CTKhuyenMai>(kmJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }

                // Gán dữ liệu khuyến mãi vào labels
                if (km != null)
                {
                    label1.Text = km.TenCTKhuyenMai ?? "Chương trình khuyến mãi";
                    label3.Text = $"Hạn sử dụng: {km.NgayBatDau?.ToString("dd/MM/yyyy") ?? "?"} - {km.NgayKetThuc?.ToString("dd/MM/yyyy") ?? "?"}";
                    label4.Text = $"Giảm {(km.PhanTramKhuyenMai > 0 ? km.PhanTramKhuyenMai : 0)}% với các sản phẩm sau:";
                }
                else
                {
                    label1.Text = "Chương trình khuyến mãi";
                    label3.Text = "Hạn sử dụng: Không xác định";
                    label4.Text = "Giảm giá: Không xác định";
                }

                // Load danh sách sản phẩm từ sanpham_khuyenmai (JOIN với sanpham)
                var spResponse = await client.GetAsync($"/api/sanphamkhuyenmai/by-khuyenmai/{_maCTKhuyenMai}");
                if (spResponse.IsSuccessStatusCode)
                {
                    var spJson = await spResponse.Content.ReadAsStringAsync();
                    danhSachSanPhamApDung = JsonSerializer.Deserialize<List<SanPham>>(spJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<SanPham>();

                    // Hiển thị sản phẩm vào label5, label6, label7 (tối đa 3 sản phẩm)
                    HienThiSanPhamDonGian();
                }
                else
                {
                    // Nếu không có sản phẩm cụ thể, hiển thị "áp dụng tất cả"
                    HienThiApDungTatCa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết khuyến mãi:\n{ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method hiển thị sản phẩm đơn giản với label5,6,7 (tối đa 3)
        private void HienThiSanPhamDonGian()
        {
            if (danhSachSanPhamApDung.Any())
            {
                label5.Text = $"+ {danhSachSanPhamApDung[0].TenSP}";
                if (danhSachSanPhamApDung.Count > 1)
                    label6.Text = $"+ {danhSachSanPhamApDung[1].TenSP}";
                else
                    label6.Text = "";
                if (danhSachSanPhamApDung.Count > 2)
                {
                    int remaining = danhSachSanPhamApDung.Count - 2;
                    label7.Text = $"+ {danhSachSanPhamApDung[2].TenSP}{(remaining > 1 ? $" và {remaining - 1} sản phẩm khác" : "")}";
                }
                else
                    label7.Text = "";

                // Cập nhật label4 với số lượng
                label4.Text += $" ({danhSachSanPhamApDung.Count} sản phẩm)";
            }
            else
            {
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                label4.Text += " (Áp dụng cho tất cả sản phẩm)";
            }
        }

        // Xử lý nếu không có sản phẩm cụ thể (áp dụng tất cả)
        private void HienThiApDungTatCa()
        {
            label5.Text = "Áp dụng cho tất cả sản phẩm";
            label6.Text = "";
            label7.Text = "";
            label4.Text += " (Áp dụng cho tất cả sản phẩm)";
        }

        // Event cho label4 nếu cần (từ Designer)
        private void label4_Click(object sender, EventArgs e)
        {
            // Có thể thêm logic mở rộng nếu click (ví dụ: show all products in MessageBox)
            if (danhSachSanPhamApDung.Count > 3)
            {
                string allProducts = string.Join("\n", danhSachSanPhamApDung.Select(sp => $"+ {sp.TenSP}"));
                MessageBox.Show($"Danh sách đầy đủ:\n{allProducts}", "Tất cả sản phẩm áp dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event Paint cho panel3 nếu cần (từ Designer)
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // Không cần implement nếu chỉ là vẽ background
        }
    }
}