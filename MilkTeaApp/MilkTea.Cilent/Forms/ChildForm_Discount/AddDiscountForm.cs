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
    public partial class AddDiscountForm : Form
    {
        private List<SanPham> _allSanPhams = new List<SanPham>();
        private List<Loai> _loais = new List<Loai>();
        private Dictionary<DataGridViewCheckBoxCell, int> checkboxToMaSPMap = new Dictionary<DataGridViewCheckBoxCell, int>();
        private const string ApiBaseUrl = "http://localhost:5198";
        private LoaiService _loaiService;
        private SanPhamService _SanPhamService;
        private SanPhamKhuyenMaiService _sanPhamKhuyenMaiService;
        private System.Windows.Forms.Timer _searchTimer;
        private CTKhuyenMaiService _ctKhuyenMaiService;
        private HashSet<int> _lockedSanPhamIds = new HashSet<int>();

        public AddDiscountForm()
        {
            InitializeComponent();
            _loaiService = new LoaiService();
            _SanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += SearchTimer_Tick;
            dGV_sp_KM_ADD.CurrentCellDirtyStateChanged += DGV_sp_KM_ADD_CurrentCellDirtyStateChanged;
            dGV_sp_KM_ADD.CellValueChanged += DGV_sp_KM_ADD_CellValueChanged;
            roundedComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            roundedComboBox1.KeyDown += RoundedComboBox1_KeyDown;
            roundedComboBox1.Leave += RoundedComboBox1_Leave;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _searchTimer?.Stop();
                _searchTimer?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private async void AddDiscountForm_Load_1(object sender, EventArgs e)
        {
            await LoadSanPhamAsync();
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
                await ApplyProductFiltersAsync();
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
            dGV_sp_KM_ADD.Rows.Clear();
            checkboxToMaSPMap.Clear();
            _lockedSanPhamIds.Clear();
            if (products == null || products.Count == 0)
            {
                int rowIndex = dGV_sp_KM_ADD.Rows.Add();
                dGV_sp_KM_ADD.Rows[rowIndex].Cells["tenSanPham_add"].Value = "Không có sản phẩm nào phù hợp với tìm kiếm.";
                dGV_sp_KM_ADD.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_sp_KM_ADD.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_ADD.DefaultCellStyle.Font, FontStyle.Italic);
                dGV_sp_KM_ADD.Rows[rowIndex].Tag = "dummy";
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

                    foreach (var assoc in associations ?? new List<SanPhamKhuyenMai>())
                    {
                        if (assoc == null) continue;

                        CTKhuyenMai? km = await _ctKhuyenMaiService.GetByIdRouteAsync(assoc.MaCTKhuyenMai)
                                     ?? await _ctKhuyenMaiService.GetCTKhuyenMaiByIdAsync(assoc.MaCTKhuyenMai);

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
                int rowIndex = dGV_sp_KM_ADD.Rows.Add();
                var checkCell = dGV_sp_KM_ADD.Rows[rowIndex].Cells["chon_add"] as DataGridViewCheckBoxCell;
                checkCell.Value = false;
                checkboxToMaSPMap[checkCell] = sp.MaSP;
                dGV_sp_KM_ADD.Rows[rowIndex].Cells["tenSanPham_add"].Value = sp.TenSP;
                dGV_sp_KM_ADD.Rows[rowIndex].Cells["loai_add"].Value = loai?.TenLoai ?? "Không xác định";
                dGV_sp_KM_ADD.Rows[rowIndex].Cells["maSP_add"].Value = sp.MaSP;

                bool isLocked = activeKm != null;
                string tooltip = "";
                if (isLocked)
                {
                    _lockedSanPhamIds.Add(sp.MaSP);
                    checkCell.ReadOnly = true;
                    checkCell.Value = false;
                    tooltip = $"Đã thuộc khuyến mãi active: {activeKm.TenCTKhuyenMai}";
                    dGV_sp_KM_ADD.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                    dGV_sp_KM_ADD.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_ADD.DefaultCellStyle.Font, FontStyle.Italic);
                    dGV_sp_KM_ADD.Rows[rowIndex].Tag = "locked";
                }
                else if (hasAnyPastKm)
                {
                    checkCell.ReadOnly = false;
                    tooltip = "Đã từng thuộc khuyến mãi (không áp dụng hiện tại)";
                    dGV_sp_KM_ADD.Rows[rowIndex].Tag = null;
                }
                else
                {
                    checkCell.ReadOnly = false;
                    dGV_sp_KM_ADD.Rows[rowIndex].Tag = null;
                }
                checkCell.ToolTipText = tooltip;
            }
            dGV_sp_KM_ADD.Refresh();
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

        private void DGV_sp_KM_ADD_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dGV_sp_KM_ADD.IsCurrentCellInEditMode && dGV_sp_KM_ADD.CurrentCell.ColumnIndex == dGV_sp_KM_ADD.Columns["chon_add"].Index)
            {
                dGV_sp_KM_ADD.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dGV_sp_KM_ADD.EndEdit();
            }
        }

        private void DGV_sp_KM_ADD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dGV_sp_KM_ADD.Columns["chon_add"].Index) return;
            var row = dGV_sp_KM_ADD.Rows[e.RowIndex];
            if (row.Tag?.ToString() == "dummy") return;
            var checkCell = row.Cells["chon_add"] as DataGridViewCheckBoxCell;
            if (checkCell == null) return;
            bool isChecked = checkCell.Value != null && (bool)checkCell.Value;
            var maSPValue = row.Cells["maSP_add"]?.Value?.ToString();
            if (string.IsNullOrEmpty(maSPValue) || !int.TryParse(maSPValue, out int maSP))
            {
                return;
            }
            try
            {
                if (isChecked)
                {
                    if (!_lockedSanPhamIds.Contains(maSP))
                    {
                        checkboxToMaSPMap[checkCell] = maSP;
                    }
                }
                else
                {
                    checkboxToMaSPMap.Remove(checkCell);
                }
                if (checkBox6.Checked)
                {
                    if (isChecked)
                    {
                        checkCell.Value = false;
                        MessageBox.Show("Vui lòng bỏ chọn 'Chọn tất cả' để chọn sản phẩm cụ thể.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dGV_sp_KM_ADD.Refresh();
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
            foreach (DataGridViewRow row in dGV_sp_KM_ADD.Rows)
            {
                if (row.Tag?.ToString() == "dummy") continue;
                var checkCell = row.Cells["chon_add"] as DataGridViewCheckBoxCell;
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
        }

        private List<int> GetSelectedSanPhamIds()
        {
            var selectedIds = new List<int>();
            foreach (DataGridViewRow row in dGV_sp_KM_ADD.Rows)
            {
                if (row.Tag?.ToString() == "dummy") continue;
                var checkCell = row.Cells["chon_add"] as DataGridViewCheckBoxCell;
                if (checkCell == null) continue;
                bool isChecked = checkCell.Value != null && (bool)checkCell.Value;
                if (!isChecked) continue;
                var maSPValue = row.Cells["maSP_add"]?.Value?.ToString();
                if (string.IsNullOrEmpty(maSPValue) || !int.TryParse(maSPValue, out int maSP))
                {
                    continue;
                }
                if (!_lockedSanPhamIds.Contains(maSP))
                {
                    selectedIds.Add(maSP);
                }
            }
            if (checkBox6.Checked)
            {
                selectedIds = _allSanPhams.Where(sp => !_lockedSanPhamIds.Contains(sp.MaSP)).Select(sp => sp.MaSP).ToList();
            }
            return selectedIds;
        }

        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string tenCT = textBox1.Text.Trim();
                string discountText = roundedComboBox1.SelectedItem?.ToString()?.Replace("%", "") ?? roundedComboBox1.Text?.Replace("%", "") ?? "0";
                if (!int.TryParse(discountText, out int phanTram) || phanTram < 0 || phanTram > 100)
                {
                    MessageBox.Show("Phần trăm khuyến mãi phải là số từ 0-100.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime ngayBatDau = dateTimePicker1.Value;
                DateTime ngayKetThuc = dateTimePicker2.Value;
                string moTa = textBox2.Text.Trim();
                if (string.IsNullOrEmpty(tenCT))
                {
                    MessageBox.Show("Vui lòng nhập tên chương trình khuyến mãi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check duplicate name (case-insensitive, trimmed)
                try
                {
                    var allKms = await _ctKhuyenMaiService.GetAll();
                    if (allKms != null && allKms.Any(k => string.Equals(k.TenCTKhuyenMai?.Trim(), tenCT, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Tên chương trình khuyến mãi đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    // If service fails, show a warning but allow continuing or decide to block.
                    MessageBox.Show($"Không thể kiểm tra trùng tên khuyến mãi: {ex.Message}\nVui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ngayBatDau >= ngayKetThuc)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<int> selectedSanPhamIds = GetSelectedSanPhamIds();
                if (checkBox6.Checked)
                {
                    if (selectedSanPhamIds.Count == 0)
                    {
                        MessageBox.Show("Không có sản phẩm nào hợp lệ để áp dụng (tất cả sản phẩm đều đang thuộc chương trình khác).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (selectedSanPhamIds.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                var km = new CTKhuyenMai
                {
                    TenCTKhuyenMai = tenCT,
                    MoTa = moTa,
                    NgayBatDau = ngayBatDau,
                    NgayKetThuc = ngayKetThuc,
                    PhanTramKhuyenMai = phanTram,
                    TrangThai = 1
                };
                int maCTKhuyenMai = await _ctKhuyenMaiService.AddCTKhuyenMaiAsync(km);
                if (maCTKhuyenMai == 0)
                {
                    MessageBox.Show("Không thể thêm chương trình khuyến mãi. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool success = true;
                if (selectedSanPhamIds.Count > 0)
                {
                    success = await SaveSanPhamKhuyenMaiAsync(maCTKhuyenMai, selectedSanPhamIds);
                }
                if (success)
                {
                    string productMsg = selectedSanPhamIds.Count > 0
                        ? $"Đã thêm {selectedSanPhamIds.Count} sản phẩm vào chương trình khuyến mãi '{tenCT}' thành công!"
                        : "Chương trình khuyến mãi đã được thêm thành công (áp dụng cho tất cả sản phẩm).";
                    MessageBox.Show(productMsg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm chương trình khuyến mãi thành công, nhưng có lỗi khi liên kết sản phẩm. Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (this.Owner is DiscountForm parentForm)
                {
                    await parentForm.LoadDiscountsAsync();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
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
                var addTasks = selectedSanPhamIds.Select(async maSP =>
                {
                    var item = new SanPhamKhuyenMai
                    {
                        MaSP = maSP,
                        MaCTKhuyenMai = maCTKhuyenMai
                    };
                    try
                    {
                        return await _sanPhamKhuyenMaiService.AddAsync(item) ? (maSP, true) : (maSP, false);
                    }
                    catch
                    {
                        return (maSP, false);
                    }
                }).ToArray();
                var results = await Task.WhenAll(addTasks);
                var failures = results.Where(r => !r.Item2).Select(r => r.maSP).ToList();
                if (failures.Any())
                {
                    MessageBox.Show($"Lỗi lưu liên kết cho {failures.Count} sản phẩm: {string.Join(", ", failures)}. Các sản phẩm khác đã lưu thành công.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
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