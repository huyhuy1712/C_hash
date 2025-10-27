using MilkTea.Client.Controls;
using MilkTea.Client.Models; // Giả sử models ở đây: SanPham, Loai, CTKhuyenMai, SanPhamKhuyenMai
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Services;

namespace MilkTea.Client.Forms.ChildForm_Discount
{
    public partial class AddDiscountForm : Form
    {
        private List<SanPham> danhSachSanPham = new List<SanPham>();
        private List<Loai> _danhSachLoai;
        private Dictionary<CheckBox, int> checkboxToMaSPMap = new Dictionary<CheckBox, int>(); // Map checkbox to MaSP cho selected
        private const string ApiBaseUrl = "http://localhost:5198"; // Port từ code của bạn
        private LoaiService _loaiService;
        private SanPhamService _SanPhamService;
        private SanPhamKhuyenMaiService _sanPhamKhuyenMaiService;

        public AddDiscountForm()
        {
            InitializeComponent();
            _loaiService = new LoaiService();
            _SanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
        }

        private async void AddDiscountForm_Load(object sender, EventArgs e)
        {


            // Gắn event search
            roundedTextBox1.TextChanged += roundedTextBox1_TextChanged;

            // Gắn event cho checkBox6 (Chọn tất cả)
            checkBox6.CheckedChanged += checkBox6_CheckedChanged;



        }

        private async Task LoadSanPhamAsync()
        {
            try
            {
                // Sử dụng service tương tự như load Loai
                danhSachSanPham = await _SanPhamService.GetSanPhamsAsync() ?? new List<SanPham>();

                // Clear flowLayoutPanel1 và tạo dynamic cards cho tất cả sản phẩm
                flowLayoutPanel1.Controls.Clear();
                checkboxToMaSPMap.Clear();

                foreach (var sp in danhSachSanPham)
                {
                    var card = CreateProductCard(sp);
                    flowLayoutPanel1.Controls.Add(card);
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
                if (!string.IsNullOrEmpty(sp.Anh) && sp.Anh.StartsWith("data:image/"))
                {
                    // Nếu base64 với prefix (data:image/jpeg;base64,...), remove prefix và convert
                    string base64Data = sp.Anh.Split(',')[1]; // Lấy phần base64 sau ','
                    byte[] imageBytes = Convert.FromBase64String(base64Data);
                    using var ms = new MemoryStream(imageBytes);
                    pictureBox.Image = Image.FromStream(ms);
                }
                else if (!string.IsNullOrEmpty(sp.Anh))
                {
                    // Nếu Anh là filename, load từ file (giả sử folder Images trong project)
                    string imagePath = Path.Combine(Application.StartupPath, "images", sp.Anh);
                    if (File.Exists(imagePath))
                    {
                        pictureBox.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        // Fallback: Load từ Resources nếu có
                        pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("default");
                    }
                }
                else
                {
                    // Default image nếu null
                    pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("default");
                }
            }
            catch (Exception ex)
            {
                // Fallback nếu lỗi load
                System.Diagnostics.Debug.WriteLine("Lỗi load ảnh cho sản phẩm " + sp.MaSP + ": " + ex.Message);
                pictureBox.Image = null; // Hoặc default icon
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
                if (checkBox6.Checked && cb.Checked)
                {
                    cb.Checked = false;
                    MessageBox.Show("Vui lòng bỏ chọn 'Chọn tất cả' để chọn sản phẩm cụ thể.", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

   
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = !checkBox6.Checked;
            // Disable all product checkboxes (dynamic)
            foreach (var kvp in checkboxToMaSPMap)
            {
                kvp.Key.Enabled = enabled;
            }

            if (checkBox6.Checked)
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
        private async Task<bool> SaveSanPhamKhuyenMaiAsync(int maCTKhuyenMai, List<int> selectedSanPhamIds)
        {
            try
            {
                // Loop gọi service cho mỗi SanPhamKhuyenMai
                foreach (var maSP in selectedSanPhamIds)
                {
                    var item = new SanPhamKhuyenMai
                    {
                        MaSP = maSP,
                        MaCTKhuyenMai = maCTKhuyenMai
                    };

                    var success = await _sanPhamKhuyenMaiService.AddAsync(item);
                    if (!success)
                    {
                        MessageBox.Show($"Lỗi lưu liên kết sản phẩm {maSP}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnThoatDiscount_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void roundedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic nếu cần
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                int maLoai = cbo_loai_KM.SelectedValue is int ? (int)cbo_loai_KM.SelectedValue : 0; // Nếu chọn loại

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenCT))
                {
                    MessageBox.Show("Vui lòng nhập tên chương trình khuyến mãi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                if (ngayBatDau >= ngayKetThuc)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePicker2.Focus();
                    return;
                }

                // Kiểm tra sản phẩm đã chọn (nếu không chọn "Tất cả")
                List<int> selectedSanPhamIds = new List<int>();
                if (!checkBox6.Checked)
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

                // Gửi POST cho CTKhuyenMai (giữ nguyên HTTP call vì chưa có service cho CTKhuyenMai)
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
                        success = await SaveSanPhamKhuyenMaiAsync(maCTKhuyenMai, selectedSanPhamIds); // Cập nhật signature để không cần client
                    }

                    string msg = success ? "Thêm chương trình khuyến mãi thành công!" : "Thêm khuyến mãi thành công, nhưng lỗi khi liên kết sản phẩm!";
                    MessageBox.Show(msg, success ? "Thành công" : "Cảnh báo", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

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

        private async void AddDiscountForm_Load_1(object sender, EventArgs e)
        {
            _danhSachLoai = await _loaiService.GetLoaisAsync();
            cbo_loai_KM.DataSource = _danhSachLoai;
            cbo_loai_KM.DisplayMember = "TenLoai";
            cbo_loai_KM.ValueMember = "MaLoai";
            await LoadSanPhamAsync();

        }
    }
}