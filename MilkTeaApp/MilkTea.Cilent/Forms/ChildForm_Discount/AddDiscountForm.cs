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
    public partial class AddDiscountForm : Form
    {
        private List<SanPham> _allSanPhams = new List<SanPham>(); // Lưu danh sách gốc sản phẩm
        private List<Loai> _loais = new List<Loai>(); // Lưu danh sách loại để map
        private Dictionary<DataGridViewCheckBoxCell, int> checkboxToMaSPMap = new Dictionary<DataGridViewCheckBoxCell, int>(); // Map checkbox cell to MaSP
        private const string ApiBaseUrl = "http://localhost:5198";
        private LoaiService _loaiService;
        private SanPhamService _SanPhamService;
        private SanPhamKhuyenMaiService _sanPhamKhuyenMaiService;
        private System.Windows.Forms.Timer _searchTimer; // Timer cho debounce search
        private CTKhuyenMaiService _ctKhuyenMaiService = new CTKhuyenMaiService();
        // New: set of product IDs that are already part of a promotion (locked)
        private HashSet<int> _lockedSanPhamIds = new HashSet<int>();

        public AddDiscountForm()
        {
            InitializeComponent();
            _loaiService = new LoaiService();
            _SanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
            // Khởi tạo timer debounce cho search (500ms delay)
            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += SearchTimer_Tick;
            // Allow typing into the combo box and wire handlers
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
            await LoadSanPhamAsync(); // Load sản phẩm cho DataGridView
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
                // Áp dụng filter hiện tại (search)
                await ApplyProductFiltersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔍 Áp dụng search filter (client-side)
        private async Task ApplyProductFiltersAsync()
        {
            string searchKeyword = roundedTextBox1.TextValue?.Trim().ToLower() ?? "";
            var filtered = _allSanPhams.AsEnumerable();
            // Filter theo search: Partial match trên TenSP và MaSP, ưu tiên exact cho mã
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                var partialMatches = filtered.Where(sp =>
                    (!string.IsNullOrEmpty(sp.TenSP) && sp.TenSP.ToLower().Contains(searchKeyword)) ||
                    sp.MaSP.ToString().Contains(searchKeyword)
                ).ToList();

                // Ưu tiên exact match cho mã (add to front if not already in partial)
                if (int.TryParse(searchKeyword, out int keywordAsInt))
                {
                    var exactMatch = _allSanPhams.FirstOrDefault(sp => sp.MaSP == keywordAsInt);
                    if (exactMatch != null)
                    {
                        filtered = partialMatches.Contains(exactMatch)
                            ? partialMatches.AsEnumerable()
                            : new[] { exactMatch }.Union(partialMatches).AsEnumerable();
                    }
                    else
                    {
                        filtered = partialMatches.AsEnumerable();
                    }
                }
                else
                {
                    filtered = partialMatches.AsEnumerable();
                }
            }
            await DisplayProductsAsync(filtered.ToList());
        }

        // Async version: hiển thị danh sách sản phẩm (sử dụng DataGridView) và đánh dấu sản phẩm đã thuộc chương trình khác
        private async Task DisplayProductsAsync(List<SanPham> products)
        {
            dGV_sp_KM_ADD.Rows.Clear();
            checkboxToMaSPMap.Clear();
            _lockedSanPhamIds.Clear();

            if (products == null || products.Count == 0)
            {
                dGV_sp_KM_ADD.Rows.Add();
                dGV_sp_KM_ADD.Rows[0].Cells["tenSanPham_add"].Value = "Không có sản phẩm nào phù hợp với tìm kiếm.";
                dGV_sp_KM_ADD.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_sp_KM_ADD.Rows[0].DefaultCellStyle.Font = new Font(dGV_sp_KM_ADD.DefaultCellStyle.Font, FontStyle.Italic);
                dGV_sp_KM_ADD.Rows[0].Tag = "dummy";
                return;
            }

            var checkTasks = products.Select(async sp =>
            {
                CTKhuyenMai? existingKm = null;
                try
                {
                    existingKm = await _ctKhuyenMaiService.GetByMaSP(sp.MaSP);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching KM for MaSP={sp.MaSP}: {ex.Message}");
                    existingKm = null;
                }
                return (sp, existingKm);
            }).ToArray();

            var results = await Task.WhenAll(checkTasks);

            foreach (var (sp, existingKm) in results)
            {
                var loai = _loais.Find(l => l.MaLoai == sp.MaLoai);
                int rowIndex = dGV_sp_KM_ADD.Rows.Add();

                var checkCell = dGV_sp_KM_ADD.Rows[rowIndex].Cells["chon_add"] as DataGridViewCheckBoxCell;
                if (checkCell != null)
                {
                    checkCell.Value = false;
                    // Map only when checkCell exists
                    checkboxToMaSPMap[checkCell] = sp.MaSP;
                }

                // Safe assignment of other cells
                var tenCell = dGV_sp_KM_ADD.Rows[rowIndex].Cells["tenSanPham_add"];
                if (tenCell != null) tenCell.Value = sp.TenSP;
                var loaiCell = dGV_sp_KM_ADD.Rows[rowIndex].Cells["loai_add"];
                if (loaiCell != null) loaiCell.Value = loai?.TenLoai ?? "Không xác định";
                var maCell = dGV_sp_KM_ADD.Rows[rowIndex].Cells["maSP_add"];
                if (maCell != null) maCell.Value = sp.MaSP;

                bool isLocked = false;
                string lockReason = "";

                if (existingKm != null)
                {
                    bool isActive = existingKm.TrangThai == 1;
                    // Defensive check for nullable NgayKetThuc
                    bool isNotExpired = existingKm.NgayKetThuc.HasValue && existingKm.NgayKetThuc.Value.Date >= DateTime.Today;
                    if (isActive && isNotExpired)
                    {
                        isLocked = true;
                        lockReason = $"Đã thuộc khuyến mãi active: {existingKm.TenCTKhuyenMai}";
                    }
                    else
                    {
                        lockReason = existingKm.TrangThai == 0 ? "Khuyến mãi inactive" : "Khuyến mãi đã hết hạn";
                    }
                }

                if (isLocked)
                {
                    _lockedSanPhamIds.Add(sp.MaSP);
                    if (checkCell != null)
                    {
                        checkCell.ReadOnly = true;
                        checkCell.Value = false;
                        checkCell.ToolTipText = lockReason;
                    }
                    dGV_sp_KM_ADD.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                    dGV_sp_KM_ADD.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_ADD.DefaultCellStyle.Font, FontStyle.Italic);
                    dGV_sp_KM_ADD.Rows[rowIndex].Tag = "locked";
                    Debug.WriteLine($"SP {sp.MaSP}: LOCKED - {lockReason}");
                }
                else
                {
                    dGV_sp_KM_ADD.Rows[rowIndex].Tag = null;
                    if (existingKm != null && checkCell != null)
                        checkCell.ToolTipText = lockReason + " - Có thể chọn cho khuyến mãi mới.";
                    Debug.WriteLine($"SP {sp.MaSP}: UNLOCKED - {lockReason}");
                }
            }

            dGV_sp_KM_ADD.Refresh();
            Debug.WriteLine("--- End DisplayProductsAsync ---");
        }

        // 🔍 Tìm kiếm sản phẩm (debounce với timer)
        private void roundedTextBox1_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start(); // Restart timer để debounce
        }

        private async void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop(); // Dừng timer
            await ApplyProductFiltersAsync(); // Áp dụng bộ lọc sau khi user dừng gõ
        }

        private void DGV_sp_KM_ADD_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dGV_sp_KM_ADD.IsCurrentCellInEditMode && dGV_sp_KM_ADD.CurrentCell.ColumnIndex == dGV_sp_KM_ADD.Columns["chon_add"].Index)
            {
                dGV_sp_KM_ADD.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DGV_sp_KM_ADD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dGV_sp_KM_ADD.Columns["chon_add"].Index && e.RowIndex >= 0)
            {
                var checkCell = dGV_sp_KM_ADD.Rows[e.RowIndex].Cells["chon_add"] as DataGridViewCheckBoxCell;
                bool isChecked = Convert.ToBoolean(checkCell?.EditedFormattedValue ?? false);
                if (checkBox6.Checked && isChecked)
                {
                    checkCell.Value = false;
                    MessageBox.Show("Vui lòng bỏ chọn 'Chọn tất cả' để chọn sản phẩm cụ thể.", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            bool isAllSelected = checkBox6.Checked;
            foreach (DataGridViewRow row in dGV_sp_KM_ADD.Rows)
            {
                var checkCell = row.Cells["chon_add"] as DataGridViewCheckBoxCell;
                bool isExplicitlyLocked = (row.Tag as string) == "locked";
                if (isExplicitlyLocked)
                {
                    checkCell.ReadOnly = true;
                    checkCell.Value = false; // Ensure locked stay false
                }
                else
                {
                    checkCell.ReadOnly = isAllSelected; // Disable if "Chọn tất cả" is checked
                    if (isAllSelected)
                    {
                        checkCell.Value = true; // Visually check non-locked
                    }
                    // When unchecking checkBox6, optionally uncheck all: checkCell.Value = false;
                }
            }
        }

        // Helper để lấy list MaSP đã chọn từ DataGridView checkboxes
        private List<int> GetSelectedSanPhamIds()
        {
            var selectedIds = new List<int>();
            foreach (DataGridViewRow row in dGV_sp_KM_ADD.Rows)
            {
                // safe access to the checkbox cell
                var checkCell = row.Cells["chon_add"] as DataGridViewCheckBoxCell;
                if (checkCell == null) continue;
                bool isChecked = Convert.ToBoolean(checkCell.EditedFormattedValue ?? false);
                if (!isChecked) continue;
                // Use the actual column name used when filling the grid ("maSP_add")
                var maCell = row.Cells["maSP_add"];
                if (maCell?.Value == null) continue;
                if (int.TryParse(maCell.Value.ToString(), out int maSP))
                    selectedIds.Add(maSP);
            }
            return selectedIds;
        }

        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các control
                string tenCT = textBox1.Text.Trim();
                string discountText = roundedComboBox1.SelectedItem?.ToString()?.Replace("%", "") ?? "0";
                if (!int.TryParse(discountText, out int phanTram) || phanTram < 0 || phanTram > 100)
                {
                    MessageBox.Show("Phần trăm khuyến mãi phải là số từ 0-100.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                List<int> selectedSanPhamIds;
                if (checkBox6.Checked)
                {
                    // Khi "Chọn tất cả" được check, lấy tất cả sản phẩm active đã tải (_allSanPhams)
                    // Exclude locked products that already belong to other promotions
                    selectedSanPhamIds = _allSanPhams.Where(sp => !_lockedSanPhamIds.Contains(sp.MaSP)).Select(sp => sp.MaSP).ToList();
                    if (selectedSanPhamIds.Count == 0)
                    {
                        MessageBox.Show("Không có sản phẩm nào hợp lệ để áp dụng (tất cả sản phẩm đều đang thuộc chương trình khác).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    selectedSanPhamIds = GetSelectedSanPhamIds();
                    if (selectedSanPhamIds.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Tạo object CTKhuyenMai
                var km = new CTKhuyenMai
                {
                    TenCTKhuyenMai = tenCT,
                    MoTa = moTa,
                    NgayBatDau = ngayBatDau,
                    NgayKetThuc = ngayKetThuc,
                    PhanTramKhuyenMai = phanTram,
                    TrangThai = 1
                };
                // Gọi service để thêm và lấy ID
                int maCTKhuyenMai = await _ctKhuyenMaiService.AddCTKhuyenMaiAsync(km);
                if (maCTKhuyenMai == 0)
                {
                    MessageBox.Show("Không thể thêm chương trình khuyến mãi. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Debug.WriteLine("Thêm khuyến mãi thành công với ID: " + maCTKhuyenMai);
                // Lưu liên kết sản phẩm (nếu có)
                bool success = true;
                if (selectedSanPhamIds.Count > 0)
                {
                    success = await SaveSanPhamKhuyenMaiAsync(maCTKhuyenMai, selectedSanPhamIds);
                }
                // Message tùy chỉnh cho sản phẩm khuyến mãi
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
                // Reload parent form nếu có
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
                // Parallelize adds for performance
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
            // Có thể thêm logic nếu cần
        }

        private void roundedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _searchTimer.Stop();
                // Fire-and-forget is acceptable for UI responsiveness; errors are handled internally
                _ = ApplyProductFiltersAsync();
            }
        }

        private void btnThoatDiscount_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Accept typed value when user presses Enter
        private void RoundedComboBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyComboBoxValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Also validate/normalize when focus leaves
        private void RoundedComboBox1_Leave(object? sender, EventArgs e)
        {
            ApplyComboBoxValue();
        }

        // Normalize text to "N%" and optionally add to Items / select it
        private void ApplyComboBoxValue()
        {
            var txt = roundedComboBox1.Text?.Trim();
            if (string.IsNullOrEmpty(txt)) return;
            // remove trailing % if present
            if (txt.EndsWith("%")) txt = txt.Substring(0, txt.Length - 1).Trim();
            if (int.TryParse(txt, out int value))
            {
                // clamp to 0..100
                value = Math.Clamp(value, 0, 100);
                var normalized = value + "%";
                // update combo box display and select item
                roundedComboBox1.Text = normalized;
                if (!roundedComboBox1.Items.Contains(normalized))
                    roundedComboBox1.Items.Add(normalized);
                roundedComboBox1.SelectedItem = normalized;
            }
            else
            {
                // invalid input -> reset or notify
                MessageBox.Show("Vui lòng nhập phần trăm hợp lệ (số từ 0 đến 100).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                roundedComboBox1.Text = "0%";
            }
        }
    }
}