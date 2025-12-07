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
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MilkTea.Client.Forms.ChildForm_Import
{
    public partial class AddIngredientForm : Form
    {
        private NguyenLieuService _nguyenLieuService;
        private DonViTinhService _donViTinhService;

        // keep the loaded DonViTinh list so we can map SelectedIndex -> MaDVT
        private List<DonViTinh> _donViList = new List<DonViTinh>();

        public AddIngredientForm()
        {
            InitializeComponent();
            _nguyenLieuService = new NguyenLieuService(); // Khởi tạo service (giả sử service xử lý URL)
            _donViTinhService = new DonViTinhService();
            this.Load += AddIngredientForm_Load;
        }

        // 🌀 Load form (nếu cần init controls)
        private async void AddIngredientForm_Load(object sender, EventArgs e)
        {
            // Đặt giá trị mặc định cho số lượng và khóa ô số lượng
            textBox2.Text = "0";
            textBox2.ReadOnly = true;
            textBox2.TabStop = false;

            // Khóa giá bán và đặt mặc định = 0
            textBox3.Text = "0";
            textBox3.ReadOnly = true;
            textBox3.TabStop = false;

            // --- Load đơn vị tính vào combobox và cho phép nhập từ bàn phím ---
            try
            {
                var units = await _donViTinhService.GetAllAsync() ?? new List<DonViTinh>();
                _donViList = units;

                // Clear any existing items / bindings
                textBox4.DataSource = null;
                textBox4.Items.Clear();

                // Add display strings so owner-drawn combo shows real names
                foreach (var u in units)
                {
                    textBox4.Items.Add(u?.TenDVT ?? string.Empty);
                }

                // Allow typing + suggestions
                textBox4.DropDownStyle = ComboBoxStyle.DropDown;
                textBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;

                var ac = new AutoCompleteStringCollection();
                ac.AddRange(units.Where(u => !string.IsNullOrWhiteSpace(u.TenDVT))
                                .Select(u => u.TenDVT.Trim())
                                .Distinct(StringComparer.OrdinalIgnoreCase)
                                .ToArray());
                textBox4.AutoCompleteCustomSource = ac;

                if (textBox4.Items.Count > 0)
                    textBox4.SelectedIndex = 0;
            }
            catch
            {
                // if load fails, leave combobox editable with no items
                _donViList = new List<DonViTinh>();
                textBox4.DataSource = null;
                textBox4.Items.Clear();
                textBox4.DropDownStyle = ComboBoxStyle.DropDown;
                textBox4.AutoCompleteMode = AutoCompleteMode.None;
            }
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

                // Lấy đơn vị từ textBox4 (Designer) — combobox cho phép nhập
                string donVi = textBox4.Text?.Trim() ?? "";

                // Validate DonVi với regex
                // pattern: allow Unicode letters, digits, spaces and these punctuation: - / ( ) . , length 1..20
                const string DonViPattern = @"^[\p{L}0-9\s\-/().,]{1,20}$";
                if (string.IsNullOrEmpty(donVi) || !Regex.IsMatch(donVi, DonViPattern, RegexOptions.Compiled | RegexOptions.CultureInvariant))
                {
                    MessageBox.Show("Đơn vị không hợp lệ. Chỉ cho phép chữ, số, khoảng trắng và ký tự - / ( ) . , (1-20 ký tự).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Focus();
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

                // Số lượng mặc định = 0 (đã khóa trên UI)
                int soLuong = 0;
                // Giá bán khóa mặc định = 0, cho phép >= 0
                if (!decimal.TryParse(textBox3.Text, out decimal giaBan) || giaBan < 0)
                {
                    MessageBox.Show("Giá bán phải là số không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                    return;
                }

                // --- Ensure unit exists in donvitinh table and get maDVT ---
                int maDVT = 0;
                try
                {
                    // 1) If user picked existing item (SelectedIndex >= 0) map to loaded list
                    if (textBox4.SelectedIndex >= 0 && textBox4.SelectedIndex < _donViList.Count)
                    {
                        maDVT = _donViList[textBox4.SelectedIndex].MaDVT;
                    }
                    else
                    {
                        // 2) Try find by name
                        var found = _donViList.FirstOrDefault(d => string.Equals(d.TenDVT?.Trim(), donVi, StringComparison.OrdinalIgnoreCase));
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

                // Tạo object NguyenLieu
                var nl = new NguyenLieu
                {
                    Ten = tenNL,
                    SoLuong = soLuong,
                    GiaBan = giaBan,
                    TrangThai = 1,  // Active mặc định
                    maDVT = maDVT
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