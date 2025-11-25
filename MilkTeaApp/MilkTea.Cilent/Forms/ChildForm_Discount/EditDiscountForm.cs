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

        // Snapshot for change detection
        private HashSet<int> _initialSelectedSanPhams = new HashSet<int>();
        private string _initialTenCT = string.Empty;
        private string _initialMoTa = string.Empty;
        private DateTime? _initialNgayBatDau = null;
        private DateTime? _initialNgayKetThuc = null;
        private decimal _initialPhanTram = 0;

        // Select-all state (replaces checkBox6)
        private bool _isSelectAllActive = false;
        private bool _suppressSelectAll = false;

        public EditDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;
            _loaiService = new LoaiService();
            _SanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();

            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += SearchTimer_Tick;
            dGV_sp_KM_EDIT.CurrentCellDirtyStateChanged += DGV_sp_KM_EDIT_CurrentCellDirtyStateChanged;
            dGV_sp_KM_EDIT.CellValueChanged += DGV_sp_KM_EDIT_CellValueChanged;
            roundedComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            roundedComboBox1.KeyDown += RoundedComboBox1_KeyDown;
            roundedComboBox1.Leave += RoundedComboBox1_Leave;
            dateTimePicker1.Enabled = false;

            // wire the select-all button (ensure control name matches Designer: selectAll_button)
            selectAll_button.Click += SelectAll_button_Click;
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

                        _initialTenCT = km.TenCTKhuyenMai ?? string.Empty;
                        _initialMoTa = km.MoTa ?? string.Empty;
                        _initialNgayBatDau = km.NgayBatDau;
                        _initialNgayKetThuc = km.NgayKetThuc;
                        _initialPhanTram = km.PhanTramKhuyenMai;
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

                // Save initial selection snapshot for change detection
                _initialSelectedSanPhams = new HashSet<int>(_currentSelectedSanPhams);

                bool isAllSelectedInitially = associatedProducts.Count == _allSanPhams.Count;
                if (isAllSelectedInitially)
                {
                    _isSelectAllActive = true;
                    _currentSelectedSanPhams.Clear();
                    _currentSelectedSanPhams.UnionWith(_allSanPhams.Select(sp => sp.MaSP));
                    selectAll_button.Text = "Bỏ chọn tất cả";
                }
                else
                {
                    _isSelectAllActive = false;
                    selectAll_button.Text = "Chọn tất cả";
                }

                await ApplyProductFiltersAsync();
                SyncGridFromSelected();
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
                catch
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

                // If select-all state is active, check non-locked; otherwise reflect current selection
                if (_isSelectAllActive)
                {
                    bool isLocked = activeKm != null;
                    checkCell.Value = !isLocked;
                }
                else
                {
                    checkCell.Value = _currentSelectedSanPhams.Contains(sp.MaSP);
                }

                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["tenSanPham_edit"].Value = sp.TenSP;
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["loai_edit"].Value = loai?.TenLoai ?? "Không xác định";
                dGV_sp_KM_EDIT.Rows[rowIndex].Cells["maSP_edit"].Value = sp.MaSP;

                bool isLockedRow = activeKm != null;
                string tooltip = "";
                if (isLockedRow)
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
            try
            {
                var associations = await _sanPhamKhuyenMaiService.GetByMaCTKhuyenMaiAsync(_maCTKhuyenMai)
                                   ?? new List<SanPhamKhuyenMai>();

                if (!associations.Any() || _allSanPhams == null || !_allSanPhams.Any())
                    return new List<SanPham>();

                var associatedProducts = (from sp in _allSanPhams
                                          join a in associations on sp.MaSP equals a.MaSP
                                          select sp)
                                         .Distinct()
                                         .ToList();

                return associatedProducts;
            }
            catch (Exception ex)
            {
                if (ex is JsonException)
                {
                    MessageBox.Show($"Lỗi parse dữ liệu liên kết: {ex.Message}\nKiểm tra API response.", "Debug Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return new List<SanPham>();
            }
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

                // keep select-all state in sync (if user manually unchecked one item while select-all active)
                if (_isSelectAllActive && !_currentSelectedSanPhams.Any(id => !_lockedSanPhamIds.Contains(id) && !_currentSelectedSanPhams.Contains(id)))
                {
                    // still select-all if every selectable is selected
                }
                else if (_isSelectAllActive)
                {
                    // if user changes selection while select-all was active, turn off select-all mode
                    _isSelectAllActive = false;
                    selectAll_button.Text = "Chọn tất cả";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thay đổi lựa chọn sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // New handler: toggles selection of all selectable (non-locked) products
        private void SelectAll_button_Click(object? sender, EventArgs e)
        {
            if (_suppressSelectAll) return;
            _suppressSelectAll = true;
            try
            {
                var selectableIds = _allSanPhams
                    .Where(sp => !_lockedSanPhamIds.Contains(sp.MaSP))
                    .Select(sp => sp.MaSP)
                    .ToList();

                if (!selectableIds.Any())
                {
                    return;
                }

                bool allSelected = selectableIds.All(id => _currentSelectedSanPhams.Contains(id));

                if (!allSelected)
                {
                    _currentSelectedSanPhams.Clear();
                    _currentSelectedSanPhams.UnionWith(selectableIds);
                    _isSelectAllActive = true;
                    selectAll_button.Text = "Bỏ chọn tất cả";
                }
                else
                {
                    _currentSelectedSanPhams.Clear();
                    _isSelectAllActive = false;
                    selectAll_button.Text = "Chọn tất cả";
                }

                foreach (DataGridViewRow row in dGV_sp_KM_EDIT.Rows)
                {
                    if (row.Tag?.ToString() == "dummy") continue;

                    var checkCell = row.Cells["chon_edit"] as DataGridViewCheckBoxCell;
                    if (checkCell == null) continue;

                    if (!int.TryParse(row.Cells["maSP_edit"]?.Value?.ToString(), out int maSP))
                    {
                        checkCell.Value = false;
                        checkCell.ReadOnly = true;
                        continue;
                    }

                    bool isLocked = (row.Tag as string) == "locked" || _lockedSanPhamIds.Contains(maSP);
                    if (isLocked)
                    {
                        checkCell.ReadOnly = true;
                        checkCell.Value = false;
                    }
                    else
                    {
                        checkCell.ReadOnly = false;
                        checkCell.Value = _currentSelectedSanPhams.Contains(maSP);
                    }
                }

                dGV_sp_KM_EDIT.Refresh();
            }
            finally
            {
                _suppressSelectAll = false;
            }
        }

        private void SyncGridFromSelected()
        {
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

            if (_isSelectAllActive)
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

                var currentSelected = GetSelectedSanPhamIds();
                bool productsEqual = currentSelected.Count == _initialSelectedSanPhams.Count && currentSelected.All(id => _initialSelectedSanPhams.Contains(id));
                bool nameEqual = string.Equals(tenCT?.Trim() ?? string.Empty, _initialTenCT?.Trim() ?? string.Empty, StringComparison.OrdinalIgnoreCase);
                bool moTaEqual = string.Equals(moTa?.Trim() ?? string.Empty, _initialMoTa?.Trim() ?? string.Empty, StringComparison.OrdinalIgnoreCase);
                bool datesEqual = ((_initialNgayBatDau.HasValue && _initialNgayBatDau.Value.Date == ngayBatDau.Date) || (!_initialNgayBatDau.HasValue && false == false))
                                  && ((_initialNgayKetThuc.HasValue && _initialNgayKetThuc.Value.Date == ngayKetThuc.Date) || (!_initialNgayKetThuc.HasValue && false == false));
                bool phanTramEqual = (decimal)phanTram == _initialPhanTram;

                if (nameEqual && moTaEqual && datesEqual && phanTramEqual && productsEqual)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                if (string.IsNullOrEmpty(tenCT))
                {
                    MessageBox.Show("Vui lòng nhập tên chương trình khuyến mãi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                if (!_isSelectAllActive && selectedSanPhamIds.Count == 0)
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