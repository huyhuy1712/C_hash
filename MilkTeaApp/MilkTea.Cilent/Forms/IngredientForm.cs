using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Forms.ChildForm_Ingredient;
using System.Reflection;

namespace MilkTea.Client.Forms
{
    public partial class IngredientForm : Form
    {
        private List<NguyenLieu> _allIngredients = new List<NguyenLieu>();
        private NguyenLieuService _nguyenLieuService;
        private DonViTinhService _donViService;
        // map MaDVT -> TenDVT
        private Dictionary<int, string> _donViMap = new Dictionary<int, string>();

        public IngredientForm()
        {
            InitializeComponent();
            this.Load += IngredientForm_Load;
            _nguyenLieuService = new NguyenLieuService();
            _donViService = new DonViTinhService();
        }

        private async void IngredientForm_Load(object sender, EventArgs e)
        {
            await LoadIngredientsAsync();

            //Bật tắt các nút theo quyền
            btnAddIngredient.Visible = Session.HasPermission("Thêm nguyên liệu");
            sua_col.Visible = Session.HasPermission("Sửa nguyên liệu");
            xoa_col.Visible = Session.HasPermission("Xóa nguyên liệu");
        }

        public async Task LoadIngredientsAsync()
        {
            try
            {
                // show a simple loading row so user sees activity
                dGV_ingredients.Rows.Clear();
                int loadingRow = dGV_ingredients.Rows.Add();
                if (dGV_ingredients.Columns.Contains("tenNL_col"))
                    dGV_ingredients.Rows[loadingRow].Cells["tenNL_col"].Value = "Đang tải...";
                dGV_ingredients.Rows[loadingRow].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_ingredients.Refresh();

                // fetch units first and build map (robust with reflection to avoid tight coupling)
                try
                {
                    var units = await _donViService.GetAllAsync();
                    var map = new Dictionary<int, string>();
                    foreach (var u in units)
                    {
                        if (u == null) continue;
                        var tu = u.GetType();
                        // case-insensitive lookup for common property names
                        var keyProp = tu.GetProperty("MaDVT", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                                      ?? tu.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                                      ?? tu.GetProperty("Ma", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                        var nameProp = tu.GetProperty("TenDVT", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                                       ?? tu.GetProperty("Ten", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                                       ?? tu.GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                        if (keyProp == null || nameProp == null) continue;
                        var keyObj = keyProp.GetValue(u);
                        var nameObj = nameProp.GetValue(u);
                        if (keyObj != null && int.TryParse(keyObj.ToString(), out int key))
                        {
                            map[key] = nameObj?.ToString() ?? string.Empty;
                        }
                    }
                    _donViMap = map;
                }
                catch
                {
                    // ignore unit lookup errors, fallback to existing nl.DonVi
                    _donViMap = new Dictionary<int, string>();
                }

                // fetch raw data
                var ingredients = await _nguyenLieuService.GetNguyenLieusAsync() ?? new List<NguyenLieu>();

                // keep original list (even if empty) so search/filter works consistently
                _allIngredients = ingredients.Where(nl => nl != null && nl.TrangThai == 1)
                                             .OrderBy(nl => nl.Ten ?? string.Empty)
                                             .ThenBy(nl => nl.MaNL)
                                             .ToList();

                // display (DisplayIngredients handles empty list UI)
                DisplayIngredients(_allIngredients);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nguyên liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _allIngredients = new List<NguyenLieu>();
                DisplayIngredients(_allIngredients);
            }
        }

        private void DisplayIngredients(List<NguyenLieu> ingredients)
        {
            dGV_ingredients.Rows.Clear();
            if (ingredients == null || ingredients.Count == 0)
            {
                int rowIndex = dGV_ingredients.Rows.Add();
                if (dGV_ingredients.Columns.Contains("tenNL_col"))
                    dGV_ingredients.Rows[rowIndex].Cells["tenNL_col"].Value = "Không có nguyên liệu nào phù hợp.";
                dGV_ingredients.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_ingredients.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_ingredients.DefaultCellStyle.Font, FontStyle.Italic);
                return;
            }

            foreach (var nl in ingredients)
            {
                int rowIndex = dGV_ingredients.Rows.Add();

                if (dGV_ingredients.Columns.Contains("maNL_col"))
                    dGV_ingredients.Rows[rowIndex].Cells["maNL_col"].Value = nl.MaNL;

                if (dGV_ingredients.Columns.Contains("tenNL_col"))
                    dGV_ingredients.Rows[rowIndex].Cells["tenNL_col"].Value = nl.Ten ?? string.Empty;

                if (dGV_ingredients.Columns.Contains("soLuong_col"))
                    dGV_ingredients.Rows[rowIndex].Cells["soLuong_col"].Value = nl.SoLuong;

                // Determine displayed unit:
                string displayedDonVi = string.Empty;

                // 1) try to read maDVT property (case-insensitive) from model
                var t = nl.GetType();
                var maDvtProp = t.GetProperty("maDVT", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                               ?? t.GetProperty("MaDVT", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                               ?? t.GetProperty("MaDonVi", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (maDvtProp != null)
                {
                    var maObj = maDvtProp.GetValue(nl);
                    if (maObj != null && int.TryParse(maObj.ToString(), out int maDvt) && maDvt > 0)
                    {
                        if (_donViMap != null && _donViMap.TryGetValue(maDvt, out var tenDvt) && !string.IsNullOrWhiteSpace(tenDvt))
                        {
                            displayedDonVi = tenDvt;
                        }
                        else
                        {
                            // fallback to showing numeric id when no name found
                            displayedDonVi = maDvt.ToString();
                        }
                    }
                }

                // 2) fallback to existing string DonVi property if no MaDVT or lookup failed
                if (string.IsNullOrWhiteSpace(displayedDonVi))
                {
                    var donViProp = t.GetProperty("DonVi", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                                   ?? t.GetProperty("DonViTinh", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                                   ?? t.GetProperty("Unit", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    if (donViProp != null)
                    {
                        displayedDonVi = donViProp.GetValue(nl)?.ToString() ?? string.Empty;
                    }
                    else
                    {
                        displayedDonVi = string.Empty;
                    }
                }

                if (dGV_ingredients.Columns.Contains("donVi_col"))
                    dGV_ingredients.Rows[rowIndex].Cells["donVi_col"].Value = displayedDonVi;

                // store raw decimal value and let CellFormatting format it
                if (dGV_ingredients.Columns.Contains("giaBan_col"))
                    dGV_ingredients.Rows[rowIndex].Cells["giaBan_col"].Value = nl.GiaBan;

                dGV_ingredients.Rows[rowIndex].Tag = nl.MaNL;
            }
            dGV_ingredients.Refresh();
        }

        private void dGV_ingredients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dGV_ingredients.Columns.Contains("giaBan_col") && e.ColumnIndex == dGV_ingredients.Columns["giaBan_col"].Index && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal giaBan))
                {
                    e.Value = $"{giaBan:N0} VNĐ";
                    e.FormattingApplied = true;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.TextValue?.Trim().ToLower() ?? "";
            if (string.IsNullOrEmpty(searchKeyword))
            {
                DisplayIngredients(_allIngredients);
                return;
            }

            var filtered = _allIngredients.Where(nl =>
                (!string.IsNullOrEmpty(nl.Ten) && nl.Ten.ToLower().Contains(searchKeyword)) ||
                nl.MaNL.ToString().Contains(searchKeyword)
            ).ToList();

            DisplayIngredients(filtered);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtSearch_TextChanged(sender, e);
            }
        }

        private async void btnAddIngredient_Click(object sender, EventArgs e)
        {
            using var addForm = new ChildForm_Import.AddIngredientForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadIngredientsAsync();
            }
        }

        private async void dGV_ingredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var row = dGV_ingredients.Rows[e.RowIndex];
            if (row.Tag == null) return;
            int maNL = (int)row.Tag;
            var column = dGV_ingredients.Columns[e.ColumnIndex];

            if (column.Name == "sua_col")
            {
                var nguyenLieu = _allIngredients.FirstOrDefault(nl => nl.MaNL == maNL);
                if (nguyenLieu == null)
                {
                    MessageBox.Show("Không tìm thấy nguyên liệu để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using var editForm = new EditIngredientForm(nguyenLieu.MaNL);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadIngredientsAsync();
                }
            }
            else if (column.Name == "xoa_col")
            {
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa nguyên liệu '{row.Cells["tenNL_col"].Value}' không? ", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    bool hidden = await _nguyenLieuService.SoftDeleteAsync(maNL);
                    if (hidden)
                    {
                        MessageBox.Show("Đã xóa nguyên liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadIngredientsAsync();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nguyên liệu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}