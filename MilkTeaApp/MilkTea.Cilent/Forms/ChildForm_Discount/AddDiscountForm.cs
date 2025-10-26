using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Controls;
using MilkTea.Client.Models; // Giả sử models ở đây: SanPham, Loai, CTKhuyenMai, SanPhamKhuyenMai


namespace MilkTea.Client.Forms.ChildForm_Discount
{
    public partial class AddDiscountForm : Form
    {
        private List<SanPham> danhSachSanPham = new List<SanPham>();
        private List<Loai> danhSachLoai = new List<Loai>();
        private Dictionary<CheckBox, int> checkboxToMaSPMap = new Dictionary<CheckBox, int>(); // Map checkbox to MaSP cho selected
        private const string ApiBaseUrl = "http://localhost:5198"; // Port từ code của bạn

        public AddDiscountForm()
        {
            InitializeComponent();
        }

        private async void AddDiscountForm_Load(object sender, EventArgs e)
        {
            await LoadSanPhamAsync(); // Tải sản phẩm và populate UI dynamic
            await LoadLoaiAsync();    // Tải loại và populate roundedComboBox2

            // Gắn event search
            roundedTextBox1.TextChanged += roundedTextBox1_TextChanged;
        }

        private async Task LoadSanPhamAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);

                var response = await client.GetAsync("/api/sanpham");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    danhSachSanPham = JsonSerializer.Deserialize<List<SanPham>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SanPham>();

                    // Clear flowLayoutPanel1 và tạo dynamic cards cho tất cả sản phẩm
                    flowLayoutPanel1.Controls.Clear();
                    checkboxToMaSPMap.Clear();

                    foreach (var sp in danhSachSanPham)
                    {
                        var card = CreateProductCard(sp);
                        flowLayoutPanel1.Controls.Add(card);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi tải danh sách sản phẩm: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API sản phẩm: " + ex.Message);
            }
        }

        private Panel CreateProductCard(SanPham sp)
        {
            var panelOuter = new Panel
            {
                BackColor = Color.DarkTurquoise,
                Size = new System.Drawing.Size(275, 100),
                Margin = new Padding(10),
                Cursor = Cursors.SizeAll
            };

            // Panel ảnh
            var panelImage = new Panel { Dock = DockStyle.Left, Size = new System.Drawing.Size(99, 100) };
            var pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = sp.MaSP // Tag để identify
            };
            try
            {
                // Nếu Anh là filename, load từ file; nếu resource name, dùng Properties.Resources
                pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(sp.Anh ?? "default");
            }
            catch
            {
                // Fallback: Không set ảnh nếu lỗi
                pictureBox.Image = null; // Hoặc icon default
            }
            panelImage.Controls.Add(pictureBox);

            // Panel tên
            var panelName = new Panel { Dock = DockStyle.Left, Size = new System.Drawing.Size(148, 100) };
            var labelName = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Text = sp.TenSP,
                TextAlign = ContentAlignment.MiddleLeft,
                Tag = sp.MaSP
            };
            panelName.Controls.Add(labelName);

            // Panel checkbox
            var panelCheck = new Panel { Dock = DockStyle.Fill, Size = new System.Drawing.Size(28, 100) };
            var checkBox = new CheckBox
            {
                Dock = DockStyle.Top,
                Size = new System.Drawing.Size(28, 100),
                Tag = sp.MaSP
            };
            checkBox.CheckedChanged += ProductCheckBox_CheckedChanged; // Event chung cho tất cả checkbox
            panelCheck.Controls.Add(checkBox);

            // Add panels to outer
            panelOuter.Controls.Add(panelCheck);
            panelOuter.Controls.Add(panelName);
            panelOuter.Controls.Add(panelImage);

            // Map checkbox to MaSP
            checkboxToMaSPMap[checkBox] = sp.MaSP;

            return panelOuter;
        }

        private void ProductCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb && cb.Tag is int maSP)
            {
                if (checkBox1.Checked && cb.Checked)
                {
                    cb.Checked = false;
                    MessageBox.Show("Vui lòng bỏ chọn 'Chọn tất cả' để chọn sản phẩm cụ thể.", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private async Task LoadLoaiAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);

                var response = await client.GetAsync("/api/loai");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    danhSachLoai = JsonSerializer.Deserialize<List<Loai>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Loai>();

                    // Populate vào roundedComboBox2
                    roundedComboBox2.DataSource = null;
                    roundedComboBox2.DisplayMember = "TenLoai";
                    roundedComboBox2.ValueMember = "MaLoai";
                    roundedComboBox2.DataSource = danhSachLoai;
                    roundedComboBox2.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Lỗi tải danh sách loại: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API loại: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = !checkBox1.Checked;
            // Disable all product checkboxes (dynamic)
            foreach (var kvp in checkboxToMaSPMap)
            {
                kvp.Key.Enabled = enabled;
            }

            if (checkBox1.Checked)
            {
                // Uncheck all
                foreach (var kvp in checkboxToMaSPMap)
                {
                    kvp.Key.Checked = false;
                }
            }
        }

        // Helper để lấy list MaSP đã chọn từ các checkbox
        private List<int> GetSelectedSanPhamIds()
        {
            List<int> selectedIds = new List<int>();
            foreach (var kvp in checkboxToMaSPMap)
            {
                if (kvp.Key.Checked)
                {
                    selectedIds.Add(kvp.Value);
                }
            }
            return selectedIds;
        }

        // Event search: Filter dynamic cards
        private void roundedTextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = roundedTextBox1.TextValue?.ToLower() ?? "";
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Panel p && p.Controls.Count == 3)
                {
                    var labelName = p.Controls[1] as Label;
                    bool visible = string.IsNullOrEmpty(keyword) || (labelName?.Text?.ToLower().Contains(keyword) == true);
                    p.Visible = visible;
                }
            }
        }

        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các control
                string tenCT = textBox1.Text.Trim();
                string discountText = roundedComboBox1.SelectedItem?.ToString()?.Replace("%", "") ?? "0";
                int phanTram = int.TryParse(discountText, out int val) ? val : 0;
                DateTime ngayBatDau = dateTimePicker1.Value;
                DateTime ngayKetThuc = dateTimePicker2.Value;
                string moTa = textBox2.Text.Trim();
                int maLoai = roundedComboBox2.SelectedValue is int ? (int)roundedComboBox2.SelectedValue : 0; // Nếu chọn loại

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
                List<int> selectedSanPhamIds = new List<int>();
                if (!checkBox1.Checked)
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


                // Gửi POST cho CTKhuyenMai
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);

                var json = JsonSerializer.Serialize(km);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/ctkhuyenmai", content);

                if (response.IsSuccessStatusCode)
                {
                    // Parse MaCTKhuyenMai mới từ response (giả sử API trả object với ID)
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var addedKm = JsonSerializer.Deserialize<CTKhuyenMai>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    int maCTKhuyenMai = addedKm?.MaCTKhuyenMai ?? 0;

                    bool success = true;
                    if (maCTKhuyenMai > 0 && selectedSanPhamIds.Count > 0)
                    {
                        success = await SaveSanPhamKhuyenMaiAsync(client, maCTKhuyenMai, selectedSanPhamIds);
                    }

                    string msg = success ? "Thêm chương trình khuyến mãi thành công!" : "Thêm khuyến mãi thành công, nhưng lỗi khi liên kết sản phẩm!";
                    MessageBox.Show(msg, success ? "Thành công" : "Cảnh báo", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    // Reload parent form nếu có
                    if (this.Owner is DiscountForm parentForm)
                    {
                        await parentForm.LoadDiscountsAsync();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi thêm khuyến mãi:\n{response.StatusCode}\n{err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> SaveSanPhamKhuyenMaiAsync(HttpClient client, int maCTKhuyenMai, List<int> selectedSanPhamIds)
        {
            try
            {
                // Loop POST single cho mỗi SanPhamKhuyenMai (nếu không có batch endpoint)
                foreach (var maSP in selectedSanPhamIds)
                {
                    var item = new SanPhamKhuyenMai
                    {
                        MaSP = maSP,
                        MaCTKhuyenMai = maCTKhuyenMai
                    };

                    var itemJson = JsonSerializer.Serialize(item);
                    var itemContent = new StringContent(itemJson, Encoding.UTF8, "application/json");
                    var itemResponse = await client.PostAsync("/api/sanpham_khuyenmai", itemContent); // Endpoint single

                    if (!itemResponse.IsSuccessStatusCode)
                    {
                        var err = await itemResponse.Content.ReadAsStringAsync();
                        MessageBox.Show($"Lỗi lưu liên kết sản phẩm {maSP}:\n{itemResponse.StatusCode}\n{err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu liên kết sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void roundedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic nếu cần
        }

    }
}