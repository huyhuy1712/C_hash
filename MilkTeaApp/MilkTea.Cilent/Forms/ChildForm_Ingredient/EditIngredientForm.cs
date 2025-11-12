using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
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
                textBox2.Text = nl.SoLuong.ToString();
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
                if (!int.TryParse(textBox2.Text, out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                    textBox2.SelectAll();
                    return;
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