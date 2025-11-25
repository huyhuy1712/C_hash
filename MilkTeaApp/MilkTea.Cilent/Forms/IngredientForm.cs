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

namespace MilkTea.Client.Forms
{
    public partial class IngredientForm : Form
    {
        private List<NguyenLieu> _allIngredients = new List<NguyenLieu>();
        private NguyenLieuService _nguyenLieuService;

        public IngredientForm()
        {
            InitializeComponent();
            this.Load += IngredientForm_Load;
            _nguyenLieuService = new NguyenLieuService();
        }

        private async void IngredientForm_Load(object sender, EventArgs e)
        {
            await LoadIngredientsAsync();
        }

        public async Task LoadIngredientsAsync()
        {
            try
            {
                var ingredients = await _nguyenLieuService.GetNguyenLieusAsync() ?? new List<NguyenLieu>();

                var activeIngredients = (
                    from nl in ingredients
                    where nl.TrangThai == 1
                    orderby nl.Ten, nl.MaNL
                    select nl
                ).ToList();

                if (activeIngredients == null || activeIngredients.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nguyên liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _allIngredients = new List<NguyenLieu>();
                    DisplayIngredients(_allIngredients);
                    return;
                }

                _allIngredients = activeIngredients;
                DisplayIngredients(_allIngredients);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nguyên liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayIngredients(List<NguyenLieu> ingredients)
        {
            dGV_ingredients.Rows.Clear();
            if (ingredients == null || ingredients.Count == 0)
            {
                int rowIndex = dGV_ingredients.Rows.Add();
                dGV_ingredients.Rows[rowIndex].Cells["tenNL_col"].Value = "Không có nguyên liệu nào phù hợp.";
                dGV_ingredients.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_ingredients.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_ingredients.DefaultCellStyle.Font, FontStyle.Italic);
                return;
            }

            foreach (var nl in ingredients)
            {
                int rowIndex = dGV_ingredients.Rows.Add();
                dGV_ingredients.Rows[rowIndex].Cells["maNL_col"].Value = nl.MaNL;
                dGV_ingredients.Rows[rowIndex].Cells["tenNL_col"].Value = nl.Ten;
                dGV_ingredients.Rows[rowIndex].Cells["soLuong_col"].Value = $"{nl.SoLuong} (đơn vị)";
                dGV_ingredients.Rows[rowIndex].Cells["giaBan_col"].Value = $"{nl.GiaBan:N0} VNĐ";
                dGV_ingredients.Rows[rowIndex].Tag = nl.MaNL;
            }
            dGV_ingredients.Refresh();
        }

        private void dGV_ingredients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dGV_ingredients.Columns["giaBan_col"].Index && e.Value != null)
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