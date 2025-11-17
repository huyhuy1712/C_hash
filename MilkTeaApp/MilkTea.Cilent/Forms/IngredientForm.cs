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
using MilkTea.Client.Forms.ChildForm_Ingredient;

namespace MilkTea.Client.Forms
{
    public partial class IngredientForm : Form
    {
        private List<NguyenLieu> _allIngredients = new List<NguyenLieu>(); // Lưu danh sách gốc nguyên liệu
        private const string ApiBaseUrl = "http://localhost:5198";
        private NguyenLieuService _nguyenLieuService; // Service cho CRUD nguyên liệu

        public IngredientForm()
        {
            InitializeComponent();
            this.Load += IngredientForm_Load;
            _nguyenLieuService = new NguyenLieuService(); // Khởi tạo service
        }

        private async void IngredientForm_Load(object sender, EventArgs e)
        {
            await LoadIngredientsAsync(); // Load danh sách nguyên liệu
        }

        // 🌀 Load danh sách nguyên liệu từ API
        public async Task LoadIngredientsAsync()
        {
            try
            {
                var ingredients = await _nguyenLieuService.GetNguyenLieusAsync(); // Sử dụng method từ service
                if (ingredients == null || !ingredients.Any())
                {
                    MessageBox.Show("Không có dữ liệu nguyên liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _allIngredients = ingredients.Where(nl => nl.TrangThai == 1).ToList(); // Chỉ active (TrangThai = 1)
                DisplayIngredients(_allIngredients); // Hiển thị ban đầu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nguyên liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🧩 Hiển thị danh sách nguyên liệu vào DataGridView
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
                // Icons for edit/delete (sử dụng text nếu resource chưa có, hoặc Bitmap nếu có)
               
                dGV_ingredients.Rows[rowIndex].Tag = nl.MaNL; // Store MaNL in Tag for easy access in events
            }
            dGV_ingredients.Refresh();
        }
        private void dGV_ingredients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dGV_ingredients.Columns["giaBan_col"].Index && e.Value != null)
            {
                // Format decimal thành string với " VNĐ"
                if (decimal.TryParse(e.Value.ToString(), out decimal giaBan))
                {
                    e.Value = $"{giaBan:N0} VNĐ";
                    e.FormattingApplied = true;  // Ngăn format default
                }
            }
        }

        // 🔍 Tìm kiếm nguyên liệu (client-side filter)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.TextValue?.Trim().ToLower() ?? "";
            if (string.IsNullOrEmpty(searchKeyword))
            {
                DisplayIngredients(_allIngredients); // Show all
                return;
            }
            var filtered = _allIngredients.Where(nl =>
                (!string.IsNullOrEmpty(nl.Ten) && nl.Ten.ToLower().Contains(searchKeyword)) ||
                nl.MaNL.ToString().Contains(searchKeyword)
            ).ToList();
            DisplayIngredients(filtered);
        }

        // Enter key to trigger search
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent beep
                txtSearch_TextChanged(sender, e); // Trigger search
            }
        }

        // Xử lý click vào nút Thêm
        private async void btnAddIngredient_Click(object sender, EventArgs e)
        {
            // TODO: Tạo AddIngredientForm nếu chưa có (modal dialog)
            using var addForm = new ChildForm_Import.AddIngredientForm(); // Uncomment khi có form
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadIngredientsAsync(); // Reload list after add
            }
            
        }

        // Xử lý click vào cell (edit/delete icons)
        private async void dGV_ingredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Skip headers
            var row = dGV_ingredients.Rows[e.RowIndex];
            if (row.Tag == null) return; // Skip dummy rows
            int maNL = (int)row.Tag;
            var column = dGV_ingredients.Columns[e.ColumnIndex];
            if (column.Name == "sua_col") // Edit column
            {
                // Find the NguyenLieu object from _allIngredients
                var nguyenLieu = _allIngredients.FirstOrDefault(nl => nl.MaNL == maNL);
                if (nguyenLieu == null)
                {
                    MessageBox.Show("Không tìm thấy nguyên liệu để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using var editForm = new EditIngredientForm(nguyenLieu.MaNL); // Pass MaNL (int) instead of NguyenLieu
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadIngredientsAsync(); // Reload after edit
                }
            }
            else if (column.Name == "xoa_col") // Delete column
            {
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa nguyên liệu '{row.Cells["tenNL_col"].Value}' không? ", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    bool hidden = await _nguyenLieuService.SoftDeleteAsync(maNL);
                    if (hidden)
                    {
                        MessageBox.Show("Đã xóa nguyên liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadIngredientsAsync(); // Reload để filter ẩn row này (chỉ show TrangThai=1)
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