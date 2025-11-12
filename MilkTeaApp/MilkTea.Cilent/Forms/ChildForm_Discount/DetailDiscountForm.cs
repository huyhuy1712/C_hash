using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private List<Loai> _loais;

        public DetailDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;
            _loaiService = new LoaiService();
            _sanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
            _loais = new List<Loai>();
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
            textBox1.Text = "0%";
            textBox2.Text = "Ngày không xác định";
            textBox3.Text = "Ngày không xác định";
        }

        // Load chi tiết chương trình khuyến mãi (tên, ngày, % giảm) - Giữ nguyên từ trước
        private async Task LoadDiscountDetailsAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                client.Timeout = TimeSpan.FromSeconds(30);
                string endpoint = $"/api/ctkhuyenmai/{_maCTKhuyenMai}";
                Debug.WriteLine($"[DEBUG] Loading discount details from: {ApiBaseUrl}{endpoint} for ID {_maCTKhuyenMai}");

                var response = await client.GetAsync(endpoint);
                var rawResponse = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[DEBUG] Response Status: {response.StatusCode}, Raw: {rawResponse}");

                if (response.IsSuccessStatusCode)
                {
                    var km = JsonSerializer.Deserialize<CTKhuyenMai>(rawResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (km != null)
                    {
                        // Tên chương trình (label1)
                        label1.Text = km.TenCTKhuyenMai ?? "Không xác định";
                        Debug.WriteLine($"[DEBUG] Loaded name: {label1.Text}");

                        // Ngày bắt đầu (textBox2) - Handle null
                        DateTime? ngayBatDauNullable = km.NgayBatDau;
                        string ngayBatDauStr = ngayBatDauNullable.HasValue ? ngayBatDauNullable.Value.ToString("dd/MM/yyyy") : "Không xác định";
                        textBox2.Text = ngayBatDauStr;
                        Debug.WriteLine($"[DEBUG] Loaded start date: {ngayBatDauStr}");

                        // Ngày kết thúc (textBox3) - Handle null
                        DateTime? ngayKetThucNullable = km.NgayKetThuc;
                        string ngayKetThucStr = ngayKetThucNullable.HasValue ? ngayKetThucNullable.Value.ToString("dd/MM/yyyy") : "Không xác định";
                        textBox3.Text = ngayKetThucStr;
                        Debug.WriteLine($"[DEBUG] Loaded end date: {ngayKetThucStr}");

                        // % khuyến mãi (textBox1) - Handle null/0
                        decimal? phanTramNullable = km.PhanTramKhuyenMai;
                        decimal phanTram = phanTramNullable ?? 0;
                        textBox1.Text = $"{phanTram}%";
                        Debug.WriteLine($"[DEBUG] Loaded discount %: {phanTram}%");
                    }
                    else
                    {
                        Debug.WriteLine("[DEBUG] Deserialized km is null - Check JSON structure vs model");
                        SetupFallbackUI();
                        MessageBox.Show("Dữ liệu khuyến mãi không hợp lệ (deserialize fail). Kiểm tra API response.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    Debug.WriteLine($"[ERROR] API Error: {response.StatusCode} - {rawResponse}");
                    SetupFallbackUI();
                    string errMsg = response.StatusCode == System.Net.HttpStatusCode.NotFound
                        ? "Không tìm thấy chương trình khuyến mãi với ID này."
                        : $"Lỗi khi tải chi tiết khuyến mãi:\n{response.StatusCode}\n{rawResponse}";
                    MessageBox.Show(errMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"[ERROR] HTTP Exception: {httpEx.Message} (Check server running on {ApiBaseUrl})");
                SetupFallbackUI();
                MessageBox.Show("Lỗi kết nối API (server không chạy?). Kiểm tra localhost:5198.", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException jsonEx)
            {
                Debug.WriteLine($"[ERROR] JSON Deserialize Exception: {jsonEx.Message}");
                SetupFallbackUI();
                MessageBox.Show("Lỗi phân tích dữ liệu từ API (JSON invalid).", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] LoadDiscountDetails General Exception: {ex.Message}");
                SetupFallbackUI();
                MessageBox.Show($"Lỗi khi tải chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách sản phẩm liên kết - Viết lại dựa trên Edit: Chỉ load associated products, map Loai, display in grid (no checkbox)
        private async Task LoadAssociatedProductsAsync()
        {
            try
            {
                dGV_sp_KM_CT.Rows.Clear();
                // 1. Lấy associations từ service (tương tự Edit's GetByMaCTKhuyenMaiAsync)
                var associations = await _sanPhamKhuyenMaiService.GetByMaCTKhuyenMaiAsync(_maCTKhuyenMai);
                Debug.WriteLine($"[DEBUG] Associations count = {associations?.Count ?? 0} for MaCT={_maCTKhuyenMai}");
                if (associations == null || !associations.Any())
                {
                    AddNoProductsRow("Chưa có sản phẩm nào được liên kết với chương trình này.");
                    return;
                }

                // 2. Lấy tất cả sản phẩm active và loại (tương tự Edit)
                var sanPhams = await _sanPhamService.GetSanPhamsAsync();
                _loais = await _loaiService.GetLoaisAsync();
                if (sanPhams == null || !sanPhams.Any() || _loais == null || !_loais.Any())
                {
                    Debug.WriteLine("[ERROR] SanPhams or Loais null/empty");
                    MessageBox.Show("Không thể tải thông tin sản phẩm hoặc loại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddNoProductsRow("Không thể tải thông tin sản phẩm/loại.");
                    return;
                }

                // 3. Filter active products (tương tự Edit)
                var activeSanPhams = sanPhams.Where(sp => sp.TrangThai == 1).ToList();
                Debug.WriteLine($"[DEBUG] Active SanPham count = {activeSanPhams.Count}");

                // 4. Map associations to full SanPham and add to grid (no checkbox, only display)
                int loadedCount = 0;
                foreach (var assoc in associations)
                {
                    var sp = activeSanPhams.FirstOrDefault(s => s.MaSP == assoc.MaSP);
                    if (sp != null)
                    {
                        var loai = _loais.FirstOrDefault(l => l.MaLoai == sp.MaLoai);
                        int rowIndex = dGV_sp_KM_CT.Rows.Add();
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["maSP_ct"].Value = sp.MaSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["tenSanPham_ct"].Value = sp.TenSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["loai_ct"].Value = loai?.TenLoai ?? "Không xác định";
                        loadedCount++;
                        Debug.WriteLine($"[DEBUG] Loaded associated product: MaSP={sp.MaSP}, TenSP={sp.TenSP}, Loai={loai?.TenLoai}");
                    }
                    else
                    {
                        // Sản phẩm không active - add warning row
                        Debug.WriteLine($"[DEBUG] Associated MaSP {assoc.MaSP} not active");
                        int rowIndex = dGV_sp_KM_CT.Rows.Add();
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["maSP_ct"].Value = assoc.MaSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["tenSanPham_ct"].Value = "Sản phẩm không active";
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["loai_ct"].Value = "-";
                        dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                        dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_CT.DefaultCellStyle.Font, FontStyle.Italic);
                    }
                }
                Debug.WriteLine($"[DEBUG] Loaded {loadedCount} associated products to grid");

                // 5. Nếu không có row nào (unlikely), add message
                if (dGV_sp_KM_CT.Rows.Count == 0)
                {
                    AddNoProductsRow();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] LoadAssociatedProducts Exception: {ex.Message}");
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