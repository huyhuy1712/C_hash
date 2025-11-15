using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Discount
{
    public partial class DetailDiscountForm : Form
    {
        private const string ApiBaseUrl = "http://localhost:5198";
        private LoaiService _loaiService;
        private SanPhamService _sanPhamService;
        private SanPhamKhuyenMaiService _sanPhamKhuyenMaiService;
        private CTKhuyenMaiService _ctKhuyenMaiService;
        private int _maCTKhuyenMai; // The ID of the discount to view details
        private List<Loai> _detailLoais;

        public DetailDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;
            _loaiService = new LoaiService();
            _sanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
            _detailLoais = new List<Loai>();
        }

        private async void DetailDiscountForm_Load(object sender, EventArgs e)
        {
            // Fallback initial UI to avoid blank form
            SetupFallbackUI();

            await LoadDiscountDetailsAsync();
            await LoadAssociatedProductsAsync();
        }

        // Fallback UI setup - Call before load to avoid blank
        private void SetupFallbackUI()
        {
            label1.Text = "Đang tải...";
            label5.Text = "0%";
            label6.Text = "Ngày không xác định";
            label7.Text = "Ngày không xác định";
        }

        // Load chi tiết chương trình khuyến mãi (tên, ngày, % giảm) - Set vào Labels theo design mới
        private async Task LoadDiscountDetailsAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                client.Timeout = TimeSpan.FromSeconds(30);
                string endpoint = $"/api/ctkhuyenmai/{_maCTKhuyenMai}";

                var response = await client.GetAsync(endpoint);
                var rawResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var km = JsonSerializer.Deserialize<CTKhuyenMai>(rawResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (km != null)
                    {
                        // Tên chương trình (label1)
                        label1.Text = km.TenCTKhuyenMai ?? "Không xác định";

                        // Ngày bắt đầu (label6) - Handle null
                        DateTime? ngayBatDauNullable = km.NgayBatDau;
                        string ngayBatDauStr = ngayBatDauNullable.HasValue ? ngayBatDauNullable.Value.ToString("dd/MM/yyyy") : "Không xác định";
                        label6.Text = ngayBatDauStr;

                        // Ngày kết thúc (label7) - Handle null
                        DateTime? ngayKetThucNullable = km.NgayKetThuc;
                        string ngayKetThucStr = ngayKetThucNullable.HasValue ? ngayKetThucNullable.Value.ToString("dd/MM/yyyy") : "Không xác định";
                        label7.Text = ngayKetThucStr;

                        // % khuyến mãi (label5) - Handle null/0
                        decimal? phanTramNullable = km.PhanTramKhuyenMai;
                        decimal phanTram = phanTramNullable ?? 0;
                        label5.Text = $"{phanTram}%";
                    }
                    else
                    {
                        SetupFallbackUI();
                        MessageBox.Show("Dữ liệu khuyến mãi không hợp lệ (deserialize fail).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    SetupFallbackUI();
                    string errMsg = response.StatusCode == System.Net.HttpStatusCode.NotFound
                        ? "Không tìm thấy chương trình khuyến mãi với ID này."
                        : $"Lỗi khi tải chi tiết khuyến mãi:\n{response.StatusCode}";
                    MessageBox.Show(errMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException httpEx)
            {
                SetupFallbackUI();
                MessageBox.Show("Lỗi kết nối API (server không chạy?). Kiểm tra localhost:5198.", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException jsonEx)
            {
                SetupFallbackUI();
                MessageBox.Show("Lỗi phân tích dữ liệu từ API (JSON invalid).", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SetupFallbackUI();
                MessageBox.Show($"Lỗi khi tải chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách sản phẩm liên kết - Chỉ load associated products, map Loai, display in grid (no checkbox)
        private async Task LoadAssociatedProductsAsync()
        {
            try
            {
                dGV_sp_KM_CT.Rows.Clear();
                // 1. Lấy associations từ service
                var associations = await _sanPhamKhuyenMaiService.GetByMaCTKhuyenMaiAsync(_maCTKhuyenMai);
                if (associations == null || !associations.Any())
                {
                    AddNoProductsRow("Chưa có sản phẩm nào được liên kết với chương trình này.");
                    return;
                }

                // 2. Lấy tất cả sản phẩm active và loại
                var sanPhams = await _sanPhamService.GetSanPhamsAsync();
                _detailLoais = await _loaiService.GetLoaisAsync();
                if (sanPhams == null || !sanPhams.Any() || _detailLoais == null || !_detailLoais.Any())
                {
                    MessageBox.Show("Không thể tải thông tin sản phẩm hoặc loại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddNoProductsRow("Không thể tải sản phẩm/loại.");
                    return;
                }

                // 3. Filter active products
                var activeSanPhams = sanPhams.Where(sp => sp.TrangThai == 1).ToList();

                // 4. Map associations to full SanPham and add to grid (no checkbox)
                int loadedCount = 0;
                foreach (var assoc in associations)
                {
                    var sp = activeSanPhams.FirstOrDefault(s => s.MaSP == assoc.MaSP);
                    if (sp != null)
                    {
                        var loai = _detailLoais.FirstOrDefault(l => l.MaLoai == sp.MaLoai);
                        int rowIndex = dGV_sp_KM_CT.Rows.Add();
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["maSP_ct"].Value = sp.MaSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["tenSanPham_ct"].Value = sp.TenSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["loai_ct"].Value = loai?.TenLoai ?? "Không xác định";
                        loadedCount++;
                    }
                    else
                    {
                        // Sản phẩm không active - add warning row
                        int rowIndex = dGV_sp_KM_CT.Rows.Add();
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["maSP_ct"].Value = assoc.MaSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["tenSanPham_ct"].Value = "Sản phẩm không active";
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["loai_ct"].Value = "-";
                        dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                        dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_CT.DefaultCellStyle.Font, FontStyle.Italic);
                    }
                }

                // 5. Nếu không có row nào, add message
                if (dGV_sp_KM_CT.Rows.Count == 0)
                {
                    AddNoProductsRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm liên kết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddNoProductsRow("Không thể tải sản phẩm liên kết.");
            }
        }

        // Helper để add row "không có sản phẩm"
        private void AddNoProductsRow(string message = "Chưa có sản phẩm nào được liên kết với chương trình này.")
        {
            dGV_sp_KM_CT.Rows.Clear(); // Clear trước
            int rowIndex = dGV_sp_KM_CT.Rows.Add();
            dGV_sp_KM_CT.Rows[rowIndex].Cells["tenSanPham_ct"].Value = message;
            dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
            dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_CT.DefaultCellStyle.Font, FontStyle.Italic);
        }

        // Event handlers (nếu cần)
        private void label4_Click(object sender, EventArgs e)
        {
            // Optional
        }
    }
}