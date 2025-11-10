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
        }

        private async void EditDiscountForm_Load(object sender, EventArgs e)
        {
            await LoadCTKhuyenMaiAsync(); // Load existing discount data
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
                var associatedSanPhams = await GetAssociatedSanPhamIdsAsync(); // Get currently associated MaSP

                if (sanPhams == null || !sanPhams.Any())
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _allSanPhams = sanPhams.Where(sp => sp.TrangThai == 1).ToList(); // Lưu gốc, chỉ active
                _currentSelectedSanPhams = new HashSet<int>(associatedSanPhams); // Initial selected

                // Áp dụng filter hiện tại (search) - ban đầu show all
                ApplyProductFilters();
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
                dGV_sp_KM_EDIT.Rows.Add(); // Thêm row rỗng
                dGV_sp_KM_EDIT.Rows[0].Cells["tenSanPham_edit"].Value = "Không có sản phẩm nào phù hợp với tìm kiếm.";
                dGV_sp_KM_EDIT.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_sp_KM_EDIT.Rows[0].DefaultCellStyle.Font = new Font(dGV_sp_KM_EDIT.DefaultCellStyle.Font, FontStyle.Italic);
                return;
            }

            foreach (var sp in products)
            {
                var loai = _loais.Find(l => l.MaLoai == sp.MaLoai); // Tìm loại tương ứng
                int rowIndex = dGV_sp_KM_EDIT.Rows.Add();

                var checkCell = dGV_sp_KM_EDIT.Rows[rowIndex].Cells["chon_edit"] as DataGridViewCheckBoxCell;
                checkCell.Value = _currentSelectedSanPhams.Contains(sp.MaSP); // Set based on persistent selected
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
                // Use direct API call since SanPhamKhuyenMaiService does not have GetByCTKhuyenMaiAsync
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);

                var response = await client.GetAsync($"/api/sanphamkhuyenmai/ctkhuyenmai/{_maCTKhuyenMai}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var associations = JsonSerializer.Deserialize<List<SanPhamKhuyenMai>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    associatedIds = associations?.Select(a => a.MaSP).ToList() ?? new List<int>();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi tải sản phẩm liên kết:\n{response.StatusCode}\n{err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm liên kết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return associatedIds;
        }

        private void DGV_sp_KM_EDIT_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dGV_sp_KM_EDIT.IsCurrentCellInEditMode && dGV_sp_KM_EDIT.CurrentCell.ColumnIndex == dGV_sp_KM_EDIT.Columns["chon_edit"].Index)
            {
                dGV_sp_KM_EDIT.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DGV_sp_KM_EDIT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dGV_sp_KM_EDIT.Columns["chon_edit"].Index && e.RowIndex >= 0)
            {
                var checkCell = dGV_sp_KM_EDIT.Rows[e.RowIndex].Cells["chon_edit"] as DataGridViewCheckBoxCell;
                bool isChecked = (bool)checkCell.Value;

                // Update persistent selected
                if (int.TryParse(dGV_sp_KM_EDIT.Rows[e.RowIndex].Cells["maSP_edit"].Value?.ToString(), out int maSP))
                {
                    if (isChecked)
                    {
                        _currentSelectedSanPhams.Add(maSP);
                    }
                    else
                    {
                        _currentSelectedSanPhams.Remove(maSP);
                    }
                }

                if (checkBox6.Checked && isChecked)
                {
                    checkCell.Value = false;
                    _currentSelectedSanPhams.Remove(maSP); // Sync back
                    MessageBox.Show("Vui lòng bỏ chọn 'Chọn tất cả' để chọn sản phẩm cụ thể.", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = !checkBox6.Checked;
            foreach (DataGridViewRow row in dGV_sp_KM_EDIT.Rows)
            {
                var checkCell = row.Cells["chon_edit"] as DataGridViewCheckBoxCell;
                checkCell.ReadOnly = !enabled; // Disable if "Chọn tất cả" is checked
            }

            if (checkBox6.Checked)
            {
                // Uncheck all (but keep _currentSelected as is for when switch back)
                foreach (DataGridViewRow row in dGV_sp_KM_EDIT.Rows)
                {
                    row.Cells["chon_edit"].Value = false;
                }
            }
            else
            {
                // Re-sync grid from persistent selected when enabling specific selection
                SyncGridFromSelected();
            }
        }

        // Helper để sync grid checkboxes from _currentSelectedSanPhams
        private void SyncGridFromSelected()
        {
            foreach (DataGridViewRow row in dGV_sp_KM_EDIT.Rows)
            {
                if (int.TryParse(row.Cells["maSP_edit"].Value?.ToString(), out int maSP))
                {
                    var checkCell = row.Cells["chon_edit"] as DataGridViewCheckBoxCell;
                    checkCell.Value = _currentSelectedSanPhams.Contains(maSP);
                }
            }
        }

        // Helper để lấy list MaSP đã chọn
        private List<int> GetSelectedSanPhamIds()
        {
            return checkBox6.Checked
                ? _allSanPhams.Select(sp => sp.MaSP).ToList() // All if "Tất cả"
                : _currentSelectedSanPhams.ToList(); // Persistent selected otherwise
        }

        private async Task<bool> ClearExistingAssociationsAsync()
        {
            try
            {
                // Use direct API call to delete all associations for this MaCTKhuyenMai
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);

                var response = await client.DeleteAsync($"/api/sanphamkhuyenmai/ctkhuyenmai/{_maCTKhuyenMai}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi xóa liên kết sản phẩm cũ:\n{response.StatusCode}\n{err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
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
                List<int> selectedSanPhamIds = new List<int>();
                if (!checkBox6.Checked)
                {
                    selectedSanPhamIds = GetSelectedSanPhamIds();
                    if (selectedSanPhamIds.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
                        assocSuccess = await SaveSanPhamKhuyenMaiAsync(_maCTKhuyenMai, selectedSanPhamIds);
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

        private async Task<bool> SaveSanPhamKhuyenMaiAsync(int maCTKhuyenMai, List<int> selectedSanPhamIds)
        {
            try
            {
                // Loop gọi service cho mỗi SanPhamKhuyenMai
                foreach (var maSP in selectedSanPhamIds)
                {
                    var item = new SanPhamKhuyenMai
                    {
                        MaSP = maSP,
                        MaCTKhuyenMai = maCTKhuyenMai
                    };

                    var success = await _sanPhamKhuyenMaiService.AddAsync(item);
                    if (!success)
                    {
                        MessageBox.Show($"Lỗi lưu liên kết sản phẩm {maSP}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu liên kết sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void roundedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic nếu cần
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic nếu cần
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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