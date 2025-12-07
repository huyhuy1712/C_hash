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
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MilkTea.Client.Forms.ChildForm_Ingredient
{
    public partial class EditIngredientForm : Form
    {
        private NguyenLieuService _nguyenLieuService;
        private DonViTinhService _donViTinhService;
        private int _maNL;

        // keep loaded units to map selected index / name -> MaDVT
        private List<DonViTinh> _donViList = new List<DonViTinh>();

        public EditIngredientForm(int maNL)
        {
            InitializeComponent();
            _maNL = maNL;
            _nguyenLieuService = new NguyenLieuService();
            _donViTinhService = new DonViTinhService();
            this.Load += EditIngredientForm_Load;
            btnXacNhan.Click += btnXacNhan_Click;
            btnThoat.Click += btnThoat_Click;
            textBox2.KeyPress += textBox2_KeyPress;
            textBox3.KeyPress += textBox3_KeyPress;

            // Khóa ô số lượng và không cho tab vào (mặc định giống Add)
            textBox2.ReadOnly = true;
            textBox2.TabStop = false;
            textBox2.Text = "0";

            // Khóa giá bán và đặt mặc định = 0 (giống Add)
            textBox3.ReadOnly = true;
            textBox3.TabStop = false;
            textBox3.Text = "0";
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

                // Load units into combo (allow typing + suggestions)
                try
                {
                    var units = await _donViTinhService.GetAllAsync() ?? new List<DonViTinh>();
                    _donViList = units;

                    // Clear any previous bindings/items and add display strings so control shows names
                    textBox4.DataSource = null;
                    textBox4.Items.Clear();
                    foreach (var u in units)
                    {
                        textBox4.Items.Add(u?.TenDVT ?? string.Empty);
                    }

                    textBox4.DropDownStyle = ComboBoxStyle.DropDown;
                    textBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    var ac = new AutoCompleteStringCollection();
                    ac.AddRange(units.Where(u => !string.IsNullOrWhiteSpace(u.TenDVT))
                                    .Select(u => u.TenDVT.Trim())
                                    .Distinct(StringComparer.OrdinalIgnoreCase)
                                    .ToArray());
                    textBox4.AutoCompleteCustomSource = ac;
                }
                catch
                {
                    _donViList = new List<DonViTinh>();
                }

                textBox1.Text = nl.Ten ?? "";

                // Hiển thị số lượng nếu có, ngược lại giữ mặc định 0
                textBox2.Text = nl.SoLuong >= 0 ? nl.SoLuong.ToString() : "0";

                // Hiển thị giá bán; nếu null/0 thì giữ "0.00"
                textBox3.Text = nl.GiaBan.ToString("N2", CultureInfo.CurrentCulture);

                // Hiển thị tên đơn vị nếu có; nếu không có tên thì hiển thị mã đơn vị
                try
                {
                    var dvt = await _donViTinhService.GetByIdAsync(nl.maDVT);
                    textBox4.Text = dvt?.TenDVT ?? (nl.maDVT > 0 ? nl.maDVT.ToString() : string.Empty);
                }
                catch
                {
                    textBox4.Text = nl.maDVT > 0 ? nl.maDVT.ToString() : string.Empty;
                }
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

                // Lấy số lượng từ ô (đã bị khóa, vẫn parse được). Nếu không hợp lệ -> 0
                if (!int.TryParse(textBox2.Text, out int soLuong) || soLuong < 0)
                {
                    soLuong = 0;
                }

                // Giá bán là ô khoá — chấp nhận số >= 0
                if (!decimal.TryParse(textBox3.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal giaBan) || giaBan < 0)
                {
                    MessageBox.Show("Giá bán phải là số không âm hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                    textBox3.SelectAll();
                    return;
                }

                // Đơn vị từ textBox4 (Designer)
                string donVi = textBox4.Text?.Trim() ?? "";

                // Validate DonVi với regex (Unicode letters, digits, spaces and - / ( ) . , ; length 1..20)
                const string DonViPattern = @"^[\p{L}0-9\s\-/().,]{1,20}$";
                if (string.IsNullOrEmpty(donVi) || !Regex.IsMatch(donVi, DonViPattern, RegexOptions.Compiled | RegexOptions.CultureInvariant))
                {
                    MessageBox.Show("Đơn vị không hợp lệ. Chỉ cho phép chữ, số, khoảng trắng và ký tự - / ( ) . , (1-20 ký tự).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Focus();
                    return;
                }

                // Ensure unit exists in donvitinh table and get maDVT
                int maDVT = 0;
                try
                {
                    // 1) If user selected an existing item (SelectedIndex >= 0) map to loaded list
                    if (textBox4.SelectedIndex >= 0 && textBox4.SelectedIndex < _donViList.Count)
                    {
                        maDVT = _donViList[textBox4.SelectedIndex].MaDVT;
                    }
                    else
                    {
                        // 2) Try find by name
                        var allDvt = await _donViTinhService.GetAllAsync();
                        var found = allDvt.FirstOrDefault(d => string.Equals(d.TenDVT?.Trim(), donVi, StringComparison.OrdinalIgnoreCase));
                        if (found != null)
                        {
                            maDVT = found.MaDVT;
                        }
                        else
                        {
                            // 3) Create new DonViTinh
                            var created = await _donViTinhService.AddAsync(new DonViTinh { TenDVT = donVi });
                            if (created == null)
                            {
                                MessageBox.Show("Không thể tạo đơn vị tính. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            maDVT = created.MaDVT;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý đơn vị tính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nl = new NguyenLieu
                {
                    MaNL = _maNL,
                    Ten = tenNL,
                    SoLuong = soLuong,
                    GiaBan = giaBan,
                    maDVT = maDVT,
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