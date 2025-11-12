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
    public partial class EditDiscountForm : Form
    {
        private List<SanPham> _allSanPhams = new List<SanPham>(); // Lưu danh sách gốc sản phẩm
        private List<Loai> _loais = new List<Loai>(); // Lưu danh sách loại để map
        private HashSet<int> _currentSelectedSanPhams = new HashSet<int>(); // Persistent selected MaSP across filters
        private const string ApiBaseUrl = "http://localhost:5198";
        private LoaiService _loaiService;
        private SanPhamService _SanPhamService;
        private SanPhamKhuyenMaiService _sanPhamKhuyenMaiService;
        private CTKhuyenMaiService _ctKhuyenMaiService; // Assuming this exists for update, but we'll use direct Http for consistency
        private int _maCTKhuyenMai; // The ID of the discount to edit
        private System.Windows.Forms.Timer _searchTimer; // Timer cho debounce search

        public EditDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;
            _loaiService = new LoaiService();
            _SanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
            // Khởi tạo timer debounce cho search (500ms delay)
            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += SearchTimer_Tick;

            dGV_sp_KM_EDIT.CurrentCellDirtyStateChanged += DGV_sp_KM_EDIT_CurrentCellDirtyStateChanged;  // Subscribe dirty state
            dGV_sp_KM_EDIT.CellValueChanged += DGV_sp_KM_EDIT_CellValueChanged;
        }

        private async void EditDiscountForm_Load(object sender, EventArgs e)
        {
            await LoadCTKhuyenMaiAsync(); // Load existing discount data
            Debug.WriteLine($"[DEBUG] Loaded MaCTKhuyenMai: {_maCTKhuyenMai}");
            await LoadSanPhamAsync(); // Load products with pre-checked associations
        }

        private async Task LoadCTKhuyenMaiAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                var response = await client.GetAsync($"/api/ctkhuyenmai/{_maCTKhuyenMai}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var km = JsonSerializer.Deserialize<CTKhuyenMai>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (km != null)
                    {
                        textBox1.Text = km.TenCTKhuyenMai ?? "";
                        textBox2.Text = km.MoTa ?? "";
                        dateTimePicker1.Value = km.NgayBatDau ?? DateTime.Now;
                        dateTimePicker2.Value = km.NgayKetThuc ?? DateTime.Now.AddDays(1);
                        string phanTramText = $"{km.PhanTramKhuyenMai}%";
                        if (roundedComboBox1.Items.Contains(phanTramText))
                        {
                            roundedComboBox1.SelectedItem = phanTramText;
                        }
                    }
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi tải dữ liệu khuyến mãi:\n{response.StatusCode}\n{err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🌀 Hàm load danh sách sản phẩm (từ API, không filter server-side)
        private async Task LoadSanPhamAsync()
        {
            try
            {
                var sanPhams = await _SanPhamService.GetSanPhamsAsync();
                _loais = await _loaiService.GetLoaisAsync(); // Lưu loais để map
                if (sanPhams == null || !sanPhams.Any())
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _allSanPhams = sanPhams.Where(sp => sp.TrangThai == 1).ToList(); // Lưu gốc, chỉ active

                // Lấy đầy đủ sản phẩm đã chọn từ bảng SanPhamKhuyenMai
                var associatedProducts = await GetAssociatedSanPhamsAsync();
                _currentSelectedSanPhams = new HashSet<int>(associatedProducts.Select(sp => sp.MaSP)); // Set persistent từ full list

                // Detect nếu selected == all active để auto-check "Select All"
                bool isAllSelectedInitially = associatedProducts.Count == _allSanPhams.Count;
                if (isAllSelectedInitially)
                {
                    checkBox6.Checked = true; // Auto-check Select All nếu existing là all
                    _currentSelectedSanPhams.Clear();
                    _currentSelectedSanPhams.UnionWith(_allSanPhams.Select(sp => sp.MaSP)); // Ensure persistent all
                }

                // Áp dụng filter hiện tại (search) - ban đầu show all
                ApplyProductFilters();

                // Force sync UI sau display để đảm bảo tick đúng (dựa trên associatedProducts)
                if (!checkBox6.Checked)
                {
                    SyncGridFromSelected();
                }

                // Optional: Debug log để check (xóa sau khi test)
                Debug.WriteLine($"Loaded {associatedProducts.Count} associated products: {string.Join(", ", associatedProducts.Select(sp => sp.MaSP))}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔍 Áp dụng search filter (client-side)
        private void ApplyProductFilters()
        {
            string searchKeyword = roundedTextBox1.TextValue?.Trim().ToLower() ?? "";
            var filtered = _allSanPhams.AsEnumerable();
            // Filter theo search: Partial match trên TenSP và MaSP, ưu tiên exact cho mã
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                filtered = filtered.Where(sp =>
                    (!string.IsNullOrEmpty(sp.TenSP) && sp.TenSP.ToLower().Contains(searchKeyword)) ||
                    sp.MaSP.ToString().Contains(searchKeyword)
                ).ToList();
                // Ưu tiên exact match cho mã
                if (int.TryParse(searchKeyword, out int keywordAsInt))
                {
                    var exactMatch = _allSanPhams.FirstOrDefault(sp => sp.MaSP == keywordAsInt);
                    if (exactMatch != null && !filtered.Contains(exactMatch))
                    {
                        var tempList = new List<SanPham> { exactMatch };
                        tempList.AddRange(filtered);
                        filtered = tempList.AsEnumerable();
                    }
                }
            }
            DisplayProducts(filtered.ToList());
        }

        // 🧩 Hàm hiển thị danh sách sản phẩm (sử dụng DataGridView)
        private void DisplayProducts(List<SanPham> products)
        {
            dGV_sp_KM_EDIT.Rows.Clear();
            if (products == null || products.Count == 0)
            {
                int rowIndex = dGV_sp_KM_EDIT.Rows.Add(); // Thêm row rỗng
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["tenSanPham_edit"].Value = "Không có sản phẩm nào phù hợp với tìm kiếm.";
                dGV_sp_KM_EDIT.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_sp_KM_EDIT.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_EDIT.DefaultCellStyle.Font, FontStyle.Italic);
                dGV_sp_KM_EDIT.Rows[rowIndex].Tag = "dummy"; // Mark as dummy row
                return;
            }
            foreach (var sp in products)
            {
                var loai = _loais.Find(l => l.MaLoai == sp.MaLoai); // Tìm loại tương ứng
                int rowIndex = dGV_sp_KM_EDIT.Rows.Add();
                var checkCell = dGV_sp_KM_EDIT.Rows[rowIndex].Cells["chon_edit"] as DataGridViewCheckBoxCell;

                // Set checkbox based on mode: Fix để handle Select All UI consistency
                if (checkBox6.Checked)
                {
                    checkCell.Value = false; // UI: Unchecked khi Select All (nhưng persistent vẫn all)
                }
                else
                {
                    checkCell.Value = _currentSelectedSanPhams.Contains(sp.MaSP); // Tick nếu existing selected
                }

                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["tenSanPham_edit"].Value = sp.TenSP;
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["loai_edit"].Value = loai?.TenLoai ?? "Không xác định";
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["maSP_edit"].Value = sp.MaSP;
            }
            dGV_sp_KM_EDIT.Refresh(); // Force refresh UI
        }

        // 🔍 Tìm kiếm sản phẩm (debounce với timer)
        private void roundedTextBox1_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start(); // Restart timer để debounce
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop(); // Dừng timer
            ApplyProductFilters(); // Áp dụng bộ lọc sau khi user dừng gõ
        }

        private async Task<List<int>> GetAssociatedSanPhamIdsAsync()
        {
            var associatedIds = new List<int>();
            try
            {
                // Sử dụng service để get list SanPhamKhuyenMai by MaCTKhuyenMai
                // Giả sử service có method GetByMaCTKhuyenMaiAsync(int maCT) -> List<SanPhamKhuyenMai>
                // Nếu chưa có, implement trong SanPhamKhuyenMaiService (xem note dưới)
                var associations = await _sanPhamKhuyenMaiService.GetByMaCTKhuyenMaiAsync(_maCTKhuyenMai);

                if (associations != null && associations.Any())
                {
                    associatedIds = associations.Select(a => a.MaSP).Distinct().ToList();
                    Debug.WriteLine($"[DEBUG] Service loaded {associatedIds.Count} unique MaSP: [{string.Join(", ", associatedIds)}]");
                }
                else
                {
                    Debug.WriteLine("[DEBUG] Service returned empty associations (normal if no links).");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[DEBUG] Service Error for associations: {ex.Message}");
                // Không crash load, chỉ log
                if (ex is JsonException || ex.Message.Contains("JSON"))
                {
                    MessageBox.Show($"Lỗi parse dữ liệu liên kết: {ex.Message}\nKiểm tra API response.", "Debug Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return associatedIds;
        }
        private async Task<List<SanPham>> GetAssociatedSanPhamsAsync()
        {
            var associatedIds = await GetAssociatedSanPhamIdsAsync(); // Reuse existing để lấy IDs
                                                                      // Filter từ _allSanPhams để lấy full objects (chỉ active)
            var associatedProducts = _allSanPhams.Where(sp => associatedIds.Contains(sp.MaSP)).ToList();
            return associatedProducts;
        }

        private void DGV_sp_KM_EDIT_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dGV_sp_KM_EDIT.IsCurrentCellInEditMode && dGV_sp_KM_EDIT.CurrentCell.ColumnIndex == dGV_sp_KM_EDIT.Columns["chon_edit"].Index)
            {
                dGV_sp_KM_EDIT.CommitEdit(DataGridViewDataErrorContexts.Commit); // Force commit ngay
                dGV_sp_KM_EDIT.EndEdit(); // End edit mode để fire ValueChanged
                Debug.WriteLine("[DEBUG] Checkbox commit forced for current cell");
            }
        }

        private void DGV_sp_KM_EDIT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dGV_sp_KM_EDIT.Columns["chon_edit"].Index) return; // Skip header hoặc cột khác

            var row = dGV_sp_KM_EDIT.Rows[e.RowIndex];
            if (row.Tag?.ToString() == "dummy") return; // Skip dummy row

            var checkCell = row.Cells["chon_edit"] as DataGridViewCheckBoxCell;
            if (checkCell == null) return; // Validate cell tồn tại

            bool isChecked = checkCell.Value != null && (bool)checkCell.Value;

            // Validate MaSP cell trước khi parse
            var maSPValue = row.Cells["maSP_edit"]?.Value?.ToString();
            if (string.IsNullOrEmpty(maSPValue) || !int.TryParse(maSPValue, out int maSP))
            {
                Debug.WriteLine($"[ERROR] Invalid MaSP in row {e.RowIndex}: {maSPValue}"); // Log để debug
                return; // Skip nếu MaSP invalid, không crash
            }

            try
            {
                // Update persistent selected
                if (isChecked)
                {
                    _currentSelectedSanPhams.Add(maSP);
                }
                else
                {
                    _currentSelectedSanPhams.Remove(maSP);
                }

                // Fix: Handle "Select All" mode - Chỉ warn nếu cố check individual khi all selected
                if (checkBox6.Checked)
                {
                    if (isChecked) // Chỉ khi cố check (không phải uncheck)
                    {
                        // Force uncheck và warn (nhưng chỉ 1 lần, tránh spam)
                        checkCell.Value = false;
                        _currentSelectedSanPhams.Remove(maSP); // Sync back
                        MessageBox.Show("Vui lòng bỏ chọn 'Chọn tất cả' để chọn sản phẩm cụ thể.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dGV_sp_KM_EDIT.Refresh(); // Force UI update
                    }
                    // Nếu uncheck trong all mode: Allow, nhưng warn nhẹ (optional)
                    else
                    {
                        MessageBox.Show("Đã bỏ chọn sản phẩm. Nếu muốn chọn cụ thể, hãy bỏ 'Chọn tất cả'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                Debug.WriteLine($"[DEBUG] Checkbox changed: Row {e.RowIndex}, MaSP {maSP} = {isChecked}"); // Log để check
            }
            catch (Exception ex)
            {
                // Catch bất kỳ error nào (e.g., index error, null ref)
                Debug.WriteLine($"[ERROR] CellValueChanged exception: {ex.Message} | Stack: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khi thay đổi lựa chọn sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            bool isAllSelected = checkBox6.Checked;
            bool enabled = !isAllSelected;
            foreach (DataGridViewRow row in dGV_sp_KM_EDIT.Rows)
            {
                if (row.Tag?.ToString() == "dummy") continue;
                var checkCell = row.Cells["chon_edit"] as DataGridViewCheckBoxCell;
                if (checkCell != null)
                {
                    checkCell.ReadOnly = !enabled;
                }
            }
            if (isAllSelected)
            {
                _currentSelectedSanPhams.Clear();
                _currentSelectedSanPhams.UnionWith(_allSanPhams.Select(sp => sp.MaSP));
                // Uncheck UI individuals
                foreach (DataGridViewRow row in dGV_sp_KM_EDIT.Rows)
                {
                    if (row.Tag?.ToString() == "dummy") continue;
                    row.Cells["chon_edit"].Value = false;
                }
            }
            else
            {
                SyncGridFromSelected(); // Force sync tick từ persistent ngay
                dGV_sp_KM_EDIT.Refresh(); // UI update mượt
            }
        }

        // Helper để sync grid checkboxes from _currentSelectedSanPhams
        private void SyncGridFromSelected()
        {
            if (checkBox6.Checked) return; // Không sync nếu Select All (UI giữ unchecked)

            foreach (DataGridViewRow row in dGV_sp_KM_EDIT.Rows)
            {
                // Skip dummy row
                if (row.Tag?.ToString() == "dummy") continue;
                if (int.TryParse(row.Cells["maSP_edit"].Value?.ToString(), out int maSP))
                {
                    var checkCell = row.Cells["chon_edit"] as DataGridViewCheckBoxCell;
                    checkCell.Value = _currentSelectedSanPhams.Contains(maSP); // Force tick nếu selected
                }
            }
            dGV_sp_KM_EDIT.Refresh(); // Đảm bảo UI update
        }

        // Helper để lấy list MaSP đã chọn từ DataGridView checkboxes
        private List<int> GetSelectedSanPhamIds()
        {
            var allActiveIds = _allSanPhams.Select(sp => sp.MaSP).ToList();
            List<int> selected;
            if (checkBox6.Checked)
            {
                selected = allActiveIds; // All active
                Debug.WriteLine($"[DEBUG] GetSelected: All mode - {selected.Count} products");
            }
            else
            {
                selected = _currentSelectedSanPhams.Where(id => allActiveIds.Contains(id)).ToList(); // Chỉ active
                Debug.WriteLine($"[DEBUG] GetSelected: Manual mode - {selected.Count} products, IDs: [{string.Join(", ", selected)}]");
            }
            return selected;
        }

        private async Task<bool> ClearExistingAssociationsAsync()
        {
            try
            {
                // Fix: Sử dụng route đúng từ controller: /khuyenmai/{id}
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                client.Timeout = TimeSpan.FromSeconds(30);
                string endpoint = $"/api/sanphamkhuyenmai/khuyenmai/{_maCTKhuyenMai}"; // Match [HttpDelete("khuyenmai/{maCTKM}")]
                Debug.WriteLine($"[DEBUG] Calling DELETE: {ApiBaseUrl}{endpoint}"); // Log để check

                var response = await client.DeleteAsync(endpoint);
                var rawResponse = await response.Content.ReadAsStringAsync(); // Luôn đọc để log
                Debug.WriteLine($"[DEBUG] DELETE Response: {response.StatusCode} - {rawResponse}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Handle 405/404 cụ thể
                    if (response.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed)
                    {
                        MessageBox.Show($"Lỗi route DELETE: Endpoint không hỗ trợ method. Kiểm tra API.\nStatus: {response.StatusCode}\nResponse: {rawResponse}", "Debug API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi xóa liên kết sản phẩm cũ:\n{response.StatusCode}\n{rawResponse}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] ClearAssociations Exception: {ex.Message}");
                MessageBox.Show($"Lỗi khi xóa liên kết sản phẩm cũ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các control
                string tenCT = textBox1.Text.Trim();
                string discountText = roundedComboBox1.SelectedItem?.ToString()?.Replace("%", "") ?? "0";
                int phanTram = int.TryParse(discountText, out int val) ? val : 0;
                DateTime ngayBatDau = dateTimePicker1.Value;
                DateTime ngayKetThuc = dateTimePicker2.Value;
                string moTa = textBox2.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
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

                // Kiểm tra sản phẩm đã chọn (nếu không chọn "Tất cả")
                List<int> selectedSanPhamIds = GetSelectedSanPhamIds(); // Updated để handle "tất cả"
                if (!checkBox6.Checked && selectedSanPhamIds.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo object CTKhuyenMai với MaCTKhuyenMai
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

                // Gửi PUT cho CTKhuyenMai
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                var json = JsonSerializer.Serialize(km);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("/api/ctkhuyenmai", content); // Assuming PUT endpoint is /api/ctkhuyenmai
                if (response.IsSuccessStatusCode)
                {
                    // Xử lý associations: Xóa cũ và thêm mới
                    bool assocSuccess = await ClearExistingAssociationsAsync();
                    if (assocSuccess && selectedSanPhamIds.Count > 0)
                    {
                        var saveResult = await SaveSanPhamKhuyenMaiAsync(_maCTKhuyenMai, selectedSanPhamIds);
                        assocSuccess = saveResult.Success;
                    }

                    // Message tùy chỉnh cho sản phẩm khuyến mãi
                    if (assocSuccess)
                    {
                        string productMsg = selectedSanPhamIds.Count > 0
                            ? $"Đã cập nhật {selectedSanPhamIds.Count} sản phẩm cho chương trình khuyến mãi '{tenCT}' thành công!"
                            : "Chương trình khuyến mãi đã được cập nhật thành công (áp dụng cho tất cả sản phẩm).";
                        MessageBox.Show(productMsg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chương trình khuyến mãi thành công, nhưng có lỗi khi liên kết sản phẩm. Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Reload parent form nếu có
                    if (this.Owner is DiscountForm parentForm)
                    {
                        await parentForm.LoadDiscountsAsync();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi cập nhật khuyến mãi:\n{response.StatusCode}\n{err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<(bool Success, int TotalRows)> SaveSanPhamKhuyenMaiAsync(int maCTKhuyenMai, List<int> selectedSanPhamIds)
        {
            int totalRows = 0;
            try
            {
                foreach (var maSP in selectedSanPhamIds)
                {
                    var item = new SanPhamKhuyenMai
                    {
                        MaSP = maSP,
                        MaCTKhuyenMai = maCTKhuyenMai
                    };
                    // Fix: Deconstruct to a single bool since AddAsync returns Task<bool>
                    bool success = await _sanPhamKhuyenMaiService.AddAsync(item); // Match new service
                    int rows = success ? 1 : 0;
                    if (!success)
                    {
                        Debug.WriteLine($"[ERROR] AddAsync failed for MaSP={maSP}");
                        MessageBox.Show($"Lỗi lưu liên kết sản phẩm MaSP={maSP}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return (false, totalRows);
                    }
                    totalRows += rows;
                    Debug.WriteLine($"[DEBUG] Added {rows} row(s): MaSP={maSP} to MaCT={maCTKhuyenMai}");
                }
                return (true, totalRows);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] SaveSanPhamKhuyenMai Exception: {ex.Message}");
                MessageBox.Show($"Lỗi khi lưu liên kết sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false, 0);
            }
        }

        private void roundedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic nếu cần
        }

        private void roundedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _searchTimer.Stop();
                ApplyProductFilters(); // Tìm ngay khi Enter
            }
        }

        private void btnThoatDiscount_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}