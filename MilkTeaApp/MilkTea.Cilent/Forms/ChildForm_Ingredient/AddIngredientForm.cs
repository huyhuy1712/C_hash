using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Import
{
    public partial class AddIngredientForm : Form
    {
        private NguyenLieuService _nguyenLieuService;

        public AddIngredientForm()
        {
            InitializeComponent();
            _nguyenLieuService = new NguyenLieuService(); // Khởi tạo service (giả sử service xử lý URL)
            this.Load += AddIngredientForm_Load;
        }

        // 🌀 Load form (nếu cần init controls)
        private void AddIngredientForm_Load(object sender, EventArgs e)
        {
            // Đặt giá trị mặc định cho số lượng và khóa ô số lượng
            textBox2.Text = "1";
            textBox2.ReadOnly = true;
            textBox2.TabStop = false;
        }

        // 💾 Xử lý nút Xác nhận (btnXacNhan_Click)
        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ controls
                string tenNL = textBox1.Text?.Trim() ?? "";
                if (string.IsNullOrEmpty(tenNL))
                {
                    MessageBox.Show("Vui lòng nhập tên nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                // Kiểm tra trùng tên (case-insensitive) bằng service
                var existing = await _nguyenLieuService.GetByTen(tenNL);
                if (existing != null && existing.Any(e => string.Equals(e.Ten?.Trim(), tenNL, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Tên nguyên liệu đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                // Số lượng cố định là 1 (đã khóa trên UI)
                int soLuong = 1;

                if (!decimal.TryParse(textBox3.Text, out decimal giaBan) || giaBan <= 0)
                {
                    MessageBox.Show("Giá bán phải là số dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                    return;
                }

                // Tạo object NguyenLieu
                var nl = new NguyenLieu
                {
                    Ten = tenNL,
                    SoLuong = 1 ,
                    GiaBan = giaBan,
                    TrangThai = 1  // Active mặc định
                };

                // Gửi POST qua service (giả sử service có AddAsync)
                bool success = await _nguyenLieuService.AddAsync(nl);

                if (success)
                {
                    MessageBox.Show("Thêm nguyên liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload parent form nếu có (IngredientForm)
                    if (this.Owner is IngredientForm parentForm)
                    {
                        await parentForm.LoadIngredientsAsync();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm nguyên liệu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🚪 Xử lý nút Hủy (btnThoat_Click)
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}