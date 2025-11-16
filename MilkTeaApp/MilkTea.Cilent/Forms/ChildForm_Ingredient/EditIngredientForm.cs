using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MilkTea.Client.Forms.ChildForm_Ingredient
{
    public partial class EditIngredientForm : Form
    {
        private NguyenLieuService _nguyenLieuService;
        private int _maNL;

        public EditIngredientForm(int maNL)
        {
            InitializeComponent();
            _maNL = maNL;
            _nguyenLieuService = new NguyenLieuService();
            this.Load += EditIngredientForm_Load;
            btnXacNhan.Click += btnXacNhan_Click;
            btnThoat.Click += btnThoat_Click;
            textBox2.KeyPress += textBox2_KeyPress;
            textBox3.KeyPress += textBox3_KeyPress;

            // Khóa ô số lượng và không cho tab vào
            textBox2.ReadOnly = true;
            textBox2.TabStop = false;
            // Giá trị mặc định tạm thời (sẽ được ghi đè khi load dữ liệu thật)
            textBox2.Text = "1";
        }

        private async void EditIngredientForm_Load(object sender, EventArgs e)
        {
            await LoadIngredientDataAsync();
        }

        private async Task LoadIngredientDataAsync()
        {
            try
            {
                var nl = await _nguyenLieuService.GetById(_maNL);
                if (nl == null)
                {
                    MessageBox.Show("Không tìm thấy nguyên liệu để chỉnh sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                textBox1.Text = nl.Ten ?? "";
                // Nếu dữ liệu tồn kho hợp lệ (>0) thì hiển thị, nếu không thì mặc định 1
                textBox2.Text = nl.SoLuong > 0 ? nl.SoLuong.ToString() : "1";
                textBox3.Text = nl.GiaBan.ToString("N2", CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nguyên liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNL = textBox1.Text?.Trim() ?? "";
                if (string.IsNullOrEmpty(tenNL))
                {
                    MessageBox.Show("Vui lòng nhập tên nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                // Kiểm tra trùng tên (bỏ qua chính bản ghi đang sửa)
                var existing = await _nguyenLieuService.GetByTen(tenNL);
                if (existing != null && existing.Any(x => x.MaNL != _maNL && string.Equals(x.Ten?.Trim(), tenNL, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Tên nguyên liệu đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    textBox1.SelectAll();
                    return;
                }

                // Lấy số lượng từ ô (đã bị khóa, nhưng vẫn đảm bảo parse được)
                if (!int.TryParse(textBox2.Text, out int soLuong) || soLuong <= 0)
                {
                    // Trong trường hợp bất thường (không parse được), dùng mặc định 1
                    soLuong = 1;
                }

                if (!decimal.TryParse(textBox3.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal giaBan) || giaBan <= 0)
                {
                    MessageBox.Show("Giá bán phải là số dương hợp lệ (ví dụ: 1000 hoặc 1000,50).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                    textBox3.SelectAll();
                    return;
                }
                var nl = new NguyenLieu
                {
                    MaNL = _maNL,
                    Ten = tenNL,
                    SoLuong = soLuong,
                    GiaBan = giaBan,
                    TrangThai = 1
                };

                int maNLUpdated = await _nguyenLieuService.UpdateAsync(nl);
                if (maNLUpdated == 0)
                {
                    MessageBox.Show("Không thể cập nhật nguyên liệu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Cập nhật nguyên liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this.Owner is IngredientForm parentForm)
                {
                    await parentForm.LoadIngredientsAsync();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            char decimalSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSep)
                {
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar == decimalSep && tb.Text.Contains(decimalSep))
                {
                    e.Handled = true;
                }
            }
        }
    }
}