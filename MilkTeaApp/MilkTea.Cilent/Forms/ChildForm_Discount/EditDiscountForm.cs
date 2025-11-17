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
        private List<SanPham> _allSanPhams = new List<SanPham>();
        private List<Loai> _loais = new List<Loai>();
        private HashSet<int> _currentSelectedSanPhams = new HashSet<int>();
        private const string ApiBaseUrl = "http://localhost:5198";
        private LoaiService _loaiService;
        private SanPhamService _SanPhamService;
        private SanPhamKhuyenMaiService _sanPhamKhuyenMaiService;
        private CTKhuyenMaiService _ctKhuyenMaiService;
        private int _maCTKhuyenMai;
        private System.Windows.Forms.Timer _searchTimer;
        private HashSet<int> _lockedSanPhamIds = new HashSet<int>();

        public EditDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;
            _loaiService = new LoaiService();
            _SanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
            // Initialize CTKhuyenMaiService to avoid NullReferenceException when querying discounts
            _ctKhuyenMaiService = new CTKhuyenMaiService();

            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += SearchTimer_Tick;
            dGV_sp_KM_EDIT.CurrentCellDirtyStateChanged += DGV_sp_KM_EDIT_CurrentCellDirtyStateChanged;
            dGV_sp_KM_EDIT.CellValueChanged += DGV_sp_KM_EDIT_CellValueChanged;
            roundedComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            roundedComboBox1.KeyDown += RoundedComboBox1_KeyDown;
            roundedComboBox1.Leave += RoundedComboBox1_Leave;
            dateTimePicker1.Enabled = false;
        }

        private async void EditDiscountForm_Load(object sender, EventArgs e)
        {
            await LoadCTKhuyenMaiAsync();
            await LoadSanPhamAsync();
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
                        else
                        {
                            roundedComboBox1.Text = phanTramText;
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

        private async Task LoadSanPhamAsync()
        {
            try
            {
                var sanPhams = await _SanPhamService.GetSanPhamsAsync();
                _loais = await _loaiService.GetLoaisAsync();
                if (sanPhams == null || !sanPhams.Any())
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _allSanPhams = sanPhams.Where(sp => sp.TrangThai == 1).ToList();
                var associatedProducts = await GetAssociatedSanPhamsAsync();
                _currentSelectedSanPhams = new HashSet<int>(associatedProducts.Select(sp => sp.MaSP));
                bool isAllSelectedInitially = associatedProducts.Count == _allSanPhams.Count;
                if (isAllSelectedInitially)
                {
                    checkBox6.Checked = true;
                    _currentSelectedSanPhams.Clear();
                    _currentSelectedSanPhams.UnionWith(_allSanPhams.Select(sp => sp.MaSP));
                }
                await ApplyProductFiltersAsync();
                if (!checkBox6.Checked)
                {
                    SyncGridFromSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ApplyProductFiltersAsync()
        {
            string searchKeyword = roundedTextBox1.TextValue?.Trim().ToLower() ?? "";
            var filtered = _allSanPhams.AsEnumerable();
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                filtered = filtered.Where(sp =>
                    (!string.IsNullOrEmpty(sp.TenSP) && sp.TenSP.ToLower().Contains(searchKeyword)) ||
                    sp.MaSP.ToString().Contains(searchKeyword)
                ).ToList();
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
            await DisplayProductsAsync(filtered.ToList());
        }

        private async Task DisplayProductsAsync(List<SanPham> products)
        {
            dGV_sp_KM_EDIT.Rows.Clear();
            _lockedSanPhamIds.Clear();
            if (products == null || products.Count == 0)
            {
                int rowIndex = dGV_sp_KM_EDIT.Rows.Add();
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["tenSanPham_edit"].Value = "Không có sản phẩm nào phù hợp với tìm kiếm.";
                dGV_sp_KM_EDIT.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_sp_KM_EDIT.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_EDIT.DefaultCellStyle.Font, FontStyle.Italic);
                dGV_sp_KM_EDIT.Rows[rowIndex].Tag = "dummy";
                return;
            }

            var checkTasks = products.Select(async sp =>
            {
                List<SanPhamKhuyenMai> associations = new List<SanPhamKhuyenMai>();
                CTKhuyenMai? activeKm = null;
                bool hasAnyPastKm = false;
                try
                {
                    associations = await _sanPhamKhuyenMaiService.GetByMaSPAsync(sp.MaSP);

                    foreach (var assoc in associations)
                    {
                        if (assoc.MaCTKhuyenMai == _maCTKhuyenMai) continue;

                        // Defensive: ensure _ctKhuyenMaiService is not null
                        CTKhuyenMai? km = null;
                        if (_ctKhuyenMaiService != null)
                        {
                            km = await _ctKhuyenMaiService.GetByIdRouteAsync(assoc.MaCTKhuyenMai)
                                 ?? await _ctKhuyenMaiService.GetCTKhuyenMaiByIdAsync(assoc.MaCTKhuyenMai);
                        }

                        if (km == null) continue;

                        bool isActive = km.TrangThai == 1;
                        bool notStarted = km.NgayBatDau.HasValue && km.NgayBatDau.Value.Date > DateTime.Today;
                        bool alreadyEnded = km.NgayKetThuc.HasValue && km.NgayKetThuc.Value.Date < DateTime.Today;
                        bool isOngoing = isActive && !notStarted && !alreadyEnded;

                        if (isOngoing)
                        {
                            activeKm = km;
                            break;
                        }
                        else if (isActive || associations.Count > 0)
                        {
                            hasAnyPastKm = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                return (sp, activeKm, hasAnyPastKm);
            }).ToArray();

            var results = await Task.WhenAll(checkTasks);
            foreach (var (sp, activeKm, hasAnyPastKm) in results)
            {
                var loai = _loais.Find(l => l.MaLoai == sp.MaLoai);
                int rowIndex = dGV_sp_KM_EDIT.Rows.Add();
                var checkCell = dGV_sp_KM_EDIT.Rows[rowIndex].Cells["chon_edit"] as DataGridViewCheckBoxCell;
                if (checkBox6.Checked)
                {
                    checkCell.Value = false;
                }
                else
                {
                    checkCell.Value = _currentSelectedSanPhams.Contains(sp.MaSP);
                }
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["tenSanPham_edit"].Value = sp.TenSP;
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["loai_edit"].Value = loai?.TenLoai ?? "Không xác định";
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["maSP_edit"].Value = sp.MaSP;

                bool isLocked = activeKm != null;
                string tooltip = "";
                if (isLocked)
                {
                    _lockedSanPhamIds.Add(sp.MaSP);
                    checkCell.ReadOnly = true;
                    checkCell.Value = false;
                    tooltip = $"Đã thuộc khuyến mãi active: {activeKm.TenCTKhuyenMai}";
                    dGV_sp_KM_EDIT.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                    dGV_sp_KM_EDIT.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_EDIT.DefaultCellStyle.Font, FontStyle.Italic);
                    dGV_sp_KM_EDIT.Rows[rowIndex].Tag = "locked";
                }
                else if (hasAnyPastKm)
                {
                    checkCell.ReadOnly = false;
                    tooltip = "Đã từng thuộc khuyến mãi (không áp dụng hiện tại)";
                    dGV_sp_KM_EDIT.Rows[rowIndex].Tag = null;
                }
                else
                {
                    checkCell.ReadOnly = false;
                    dGV_sp_KM_EDIT.Rows[rowIndex].Tag = null;
                }
                checkCell.ToolTipText = tooltip;
            }
            dGV_sp_KM_EDIT.Refresh();
        }

        private void RoundedComboBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyComboBoxValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void RoundedComboBox1_Leave(object? sender, EventArgs e)
        {
            ApplyComboBoxValue();
        }

        private void ApplyComboBoxValue()
        {
            var txt = roundedComboBox1.Text?.Trim();
            if (string.IsNullOrEmpty(txt)) return;
            if (txt.EndsWith("%")) txt = txt.Substring(0, txt.Length - 1).Trim();
            if (int.TryParse(txt, out int value))
            {
                value = Math.Clamp(value, 0, 100);
                var normalized = value + "%";
                roundedComboBox1.Text = normalized;
                if (!roundedComboBox1.Items.Contains(normalized))
                    roundedComboBox1.Items.Add(normalized);
                roundedComboBox1.SelectedItem = normalized;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập phần trăm hợp lệ (số từ 0 đến 100).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                roundedComboBox1.Text = "0%";
            }
        }

        private void roundedTextBox1_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _ = ApplyProductFiltersAsync();
        }

        private async Task<List<int>> GetAssociatedSanPhamIdsAsync()
        {
            var associatedIds = new List<int>();
            try
            {
                var associations = await _sanPhamKhuyenMaiService.GetByMaCTKhuyenMaiAsync(_maCTKhuyenMai);
                if (associations != null && associations.Any())
                {
                    associatedIds = associations.Select(a => a.MaSP).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                if (ex is JsonException)
                {
                    MessageBox.Show($"Lỗi parse dữ liệu liên kết: {ex.Message}\nKiểm tra API response.", "Debug Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return associatedIds;
        }

        private async Task<List<SanPham>> GetAssociatedSanPhamsAsync()
        {
            var associatedIds = await GetAssociatedSanPhamIdsAsync();
            var associatedProducts = _allSanPhams.Where(sp => associatedIds.Contains(sp.MaSP)).ToList();
            return associatedProducts;
        }

        private void DGV_sp_KM_EDIT_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dGV_sp_KM_EDIT.IsCurrentCellInEditMode && dGV_sp_KM_EDIT.CurrentCell.ColumnIndex == dGV_sp_KM_EDIT.Columns["chon_edit"].Index)
            {
                dGV_sp_KM_EDIT.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dGV_sp_KM_EDIT.EndEdit();
            }
        }

        private void DGV_sp_KM_EDIT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dGV_sp_KM_EDIT.Columns["chon_edit"].Index) return;
            var row = dGV_sp_KM_EDIT.Rows[e.RowIndex];
            if (row.Tag?.ToString() == "dummy") return;
            var checkCell = row.Cells["chon_edit"] as DataGridViewCheckBoxCell;
            if (checkCell == null) return;
            bool isChecked = checkCell.Value != null && (bool)checkCell.Value;
            var maSPValue = row.Cells["maSP_edit"]?.Value?.ToString();
            if (string.IsNullOrEmpty(maSPValue) || !int.TryParse(maSPValue, out int maSP))
            {
                return;
            }
            try
            {
                if (isChecked)
                {
                    _currentSelectedSanPhams.Add(maSP);
                }
                else
                {
                    _currentSelectedSanPhams.Remove(maSP);
                }
                if (checkBox6.Checked)
                {
                    if (isChecked)
                    {
                        checkCell.Value = false;
                        _currentSelectedSanPhams.Remove(maSP);
                        MessageBox.Show("Vui lòng bỏ chọn 'Chọn tất cả' để chọn sản phẩm cụ thể.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dGV_sp_KM_EDIT.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Đã bỏ chọn sản phẩm. Nếu muốn chọn cụ thể, hãy bỏ 'Chọn tất cả'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
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
                bool isExplicitlyLocked = (row.Tag as string) == "locked";
                if (isExplicitlyLocked)
                {
                    checkCell.ReadOnly = true;
                    checkCell.Value = false;
                }
                else
                {
                    checkCell.ReadOnly = !enabled;
                    if (isAllSelected)
                    {
                        checkCell.Value = false;
                    }
                }
            }
            if (isAllSelected)
            {
                _currentSelectedSanPhams.Clear();
                _currentSelectedSanPhams.UnionWith(_allSanPhams.Select(sp => sp.MaSP));
            }
            else
            {
                SyncGridFromSelected();
                dGV_sp_KM_EDIT.Refresh();
            }
        }

        private void SyncGridFromSelected()
        {
            if (checkBox6.Checked) return;
            foreach (DataGridViewRow row in dGV_sp_KM_EDIT.Rows)
            {
                if (row.Tag?.ToString() == "dummy") continue;
                if (int.TryParse(row.Cells["maSP_edit"].Value?.ToString(), out int maSP))
                {
                    var checkCell = row.Cells["chon_edit"] as DataGridViewCheckBoxCell;
                    bool isExplicitlyLocked = (row.Tag as string) == "locked";
                    if (isExplicitlyLocked)
                    {
                        checkCell.Value = false;
                    }
                    else
                    {
                        checkCell.Value = _currentSelectedSanPhams.Contains(maSP);
                    }
                }
            }
            dGV_sp_KM_EDIT.Refresh();
        }

        private List<int> GetSelectedSanPhamIds()
        {
            var allActiveIds = _allSanPhams.Select(sp => sp.MaSP).ToList();
            List<int> selected;
            if (checkBox6.Checked)
            {
                selected = allActiveIds.Where(id => !_lockedSanPhamIds.Contains(id)).ToList();
            }
            else
            {
                selected = _currentSelectedSanPhams.Where(id => allActiveIds.Contains(id) && !_lockedSanPhamIds.Contains(id)).ToList();
            }
            return selected;
        }

        private async Task<bool> ClearExistingAssociationsAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                client.Timeout = TimeSpan.FromSeconds(30);
                string endpoint = $"/api/sanphamkhuyenmai/khuyenmai/{_maCTKhuyenMai}";
                var response = await client.DeleteAsync(endpoint);
                var rawResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
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
                MessageBox.Show($"Lỗi khi xóa liên kết sản phẩm cũ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string tenCT = textBox1.Text.Trim();
                string discountText = roundedComboBox1.SelectedItem?.ToString()?.Replace("%", "") ?? roundedComboBox1.Text?.Replace("%", "") ?? "0";
                int phanTram = int.TryParse(discountText, out int val) ? val : 0;
                DateTime ngayBatDau = dateTimePicker1.Value;
                DateTime ngayKetThuc = dateTimePicker2.Value;
                string moTa = textBox2.Text.Trim();
                if (string.IsNullOrEmpty(tenCT))
                {
                    MessageBox.Show("Vui lòng nhập tên chương trình khuyến mãi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check duplicate name (exclude current promotion by MaCTKhuyenMai)
                try
                {
                    var allKms = await _ctKhuyenMaiService.GetAll();
                    if (allKms != null && allKms.Any(k => 
                        string.Equals(k.TenCTKhuyenMai?.Trim(), tenCT, StringComparison.OrdinalIgnoreCase)
                        && k.MaCTKhuyenMai != _maCTKhuyenMai))
                    {
                        MessageBox.Show("Tên chương trình khuyến mãi đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể kiểm tra trùng tên khuyến mãi: {ex.Message}\nVui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ngayBatDau >= ngayKetThuc)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<int> selectedSanPhamIds = GetSelectedSanPhamIds();
                if (!checkBox6.Checked && selectedSanPhamIds.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                client.BaseAddress = new Uri(ApiBaseUrl);
                var json = JsonSerializer.Serialize(km);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("/api/ctkhuyenmai", content);
                if (response.IsSuccessStatusCode)
                {
                    bool assocSuccess = await ClearExistingAssociationsAsync();
                    if (assocSuccess && selectedSanPhamIds.Count > 0)
                    {
                        var saveResult = await SaveSanPhamKhuyenMaiAsync(_maCTKhuyenMai, selectedSanPhamIds);
                        assocSuccess = saveResult.Success;
                    }
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
                    bool success = await _sanPhamKhuyenMaiService.AddAsync(item);
                    int rows = success ? 1 : 0;
                    if (!success)
                    {
                        MessageBox.Show($"Lỗi lưu liên kết sản phẩm MaSP={maSP}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return (false, totalRows);
                    }
                    totalRows += rows;
                }
                return (true, totalRows);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu liên kết sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false, 0);
            }
        }

        private void roundedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void roundedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _searchTimer.Stop();
                _ = ApplyProductFiltersAsync();
            }
        }

        private void btnThoatDiscount_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}