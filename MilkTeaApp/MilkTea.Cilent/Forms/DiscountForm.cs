using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Forms.ChildForm_Discount;
using MilkTea.Client.Models;

namespace MilkTea.Client.Forms
{
    public partial class DiscountForm : Form
    {
        private List<CTKhuyenMai> _allDiscounts = new List<CTKhuyenMai>(); // Lưu danh sách gốc
        private bool _isLoading = false; // Flag cho loading state
        private System.Windows.Forms.Timer _searchTimer; // Timer cho debounce reload

        public DiscountForm()
        {
            InitializeComponent();
            // Khởi tạo timer debounce cho reload (500ms delay để tránh gọi API liên tục)
            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += SearchTimer_Tick;
            this.Load += DiscountForm_Load;
        }

        private async void DiscountForm_Load(object sender, EventArgs e)
        {
            
        }
        private async Task btnThemDiscount_ClickAsync(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();
            if (addDiscountForm.ShowDialog() == DialogResult.OK)
            {
                roundedComboBox2.Items.Clear();
                roundedComboBox2.Items.AddRange(new object[] { "Tất cả", "Đang hoạt động", "Hết hạn" });
            }
            roundedComboBox2.SelectedIndex = 0;

            roundedTextBox2.TextValue = "";
            roundedTextBox2.Placeholder = "Nhập mã hoặc tên khuyến mãi...";

            await LoadDiscountsAsync();
            roundedComboBox2.SelectedIndexChanged += roundedComboBox2_SelectedIndexChanged;
        }


        // 🔧 Helper: Clear card tĩnh từ designer (gọi nhiều lần để chắc)
        private void ClearStaticCards()
        {
            flowLayoutPanel1.Controls.Clear();
            // Nếu có panel7 tĩnh, remove cụ thể (dựa trên tên từ designer)
            for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = flowLayoutPanel1.Controls[i];
                if (ctrl.Name == "panel7" || (ctrl is Panel p && p.Controls.Count > 0 && p.Controls[0] is Label l && l.Text.Contains("Chương trình 8/8")))
                {
                    flowLayoutPanel1.Controls.RemoveAt(i);
                }
            }
            flowLayoutPanel1.Refresh();
        }

        // 🌀 Hàm load danh sách khuyến mãi (từ API, không filter server-side)
        public async Task LoadDiscountsAsync()
        {
            if (_isLoading) return; // Tránh load trùng lặp

            _isLoading = true;
            ShowLoading(true); // Hiển thị loading indicator

            // Clear LẠI trước khi load để loại bỏ mọi thứ cũ (kể cả tĩnh)
            ClearStaticCards();

            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5198");

                var response = await client.GetAsync("/api/ctkhuyenmai");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không thể tải danh sách khuyến mãi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                _allDiscounts = JsonSerializer.Deserialize<List<CTKhuyenMai>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<CTKhuyenMai>();

                // Áp dụng filter hiện tại (search + status) - Force "Tất cả" nếu cần
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Fallback: Hiển thị rỗng
                DisplayDiscounts(new List<CTKhuyenMai>());
            }
            finally
            {
                _isLoading = false;
                ShowLoading(false);
            }
        }

        // 🔍 Áp dụng cả search và status filter (client-side)
        private void ApplyFilters()
        {
            string searchKeyword = roundedTextBox2.TextValue?.Trim().ToLower() ?? "";
            string statusFilter = roundedComboBox2.SelectedItem?.ToString() ?? "Tất cả"; // Default "Tất cả"

            var filtered = _allDiscounts.AsEnumerable();

            // Filter theo search: Cải tiến với partial match và exact ưu tiên
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                filtered = filtered.Where(d =>
                    (!string.IsNullOrEmpty(d.TenCTKhuyenMai) && d.TenCTKhuyenMai.ToLower().Contains(searchKeyword)) ||
                    d.MaCTKhuyenMai.ToString().Contains(searchKeyword)
                ).ToList();

                // Ưu tiên exact match cho mã
                if (int.TryParse(searchKeyword, out int keywordAsInt))
                {
                    var exactMatch = _allDiscounts.FirstOrDefault(d => d.MaCTKhuyenMai == keywordAsInt);
                    if (exactMatch != null && !filtered.Contains(exactMatch))
                    {
                        var tempList = new List<CTKhuyenMai> { exactMatch };
                        tempList.AddRange(filtered);
                        filtered = tempList.AsEnumerable();
                    }
                }
            }

            // Filter theo trạng thái: Dựa trên ngày (chỉ nếu KHÔNG phải "Tất cả")
            if (statusFilter != "Tất cả")
            {
                filtered = filtered.Where(d =>
                {
                    DateTime now = DateTime.Now.Date; // Sử dụng Date để ignore giờ/phút
                    bool isActive = false;
                    if (d.NgayBatDau.HasValue && d.NgayKetThuc.HasValue)
                    {
                        isActive = d.NgayBatDau.Value.Date <= now && now <= d.NgayKetThuc.Value.Date;
                    }
                    else if (d.NgayBatDau.HasValue && !d.NgayKetThuc.HasValue)
                    {
                        isActive = d.NgayBatDau.Value.Date <= now; // Không kết thúc = vĩnh viễn
                    }
                    // Nếu null, coi như hết hạn
                    return (statusFilter == "Đang hoạt động" && isActive) ||
                           (statusFilter == "Hết hạn" && !isActive);
                });
            }

            DisplayDiscounts(filtered.ToList());
        }

        // 🧩 Hàm hiển thị danh sách khuyến mãi
        private void DisplayDiscounts(List<CTKhuyenMai> discounts)
        {
            // Clear CUỐI CÙNG trước khi add mới
            flowLayoutPanel1.Controls.Clear();

            if (discounts == null || discounts.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "Không có chương trình khuyến mãi nào phù hợp với tìm kiếm.",
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Height = 50,
                    Margin = new Padding(20)
                };
                flowLayoutPanel1.Controls.Add(lbl);
                return;
            }

            foreach (var discount in discounts)
            {
                var cardPanel = CreateDiscountCard(discount);
                flowLayoutPanel1.Controls.Add(cardPanel);
            }

            flowLayoutPanel1.Refresh(); // Force refresh UI
        }

        // 🧩 Tạo card động (extracted cho dễ maintain)
        private Panel CreateDiscountCard(CTKhuyenMai discount)
        {
            var panelOuter = new Panel
            {
                Width = 200,
                Height = 100,
                BackColor = SystemColors.ButtonHighlight,
                Margin = new Padding(10)
            };

            var panelTitle = new Panel { Dock = DockStyle.Top, Height = 72 };

            var labelTitle = new Label
            {
                Text = $"{discount.MaCTKhuyenMai} - {discount.TenCTKhuyenMai}",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14.25F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            // Mở form chi tiết - KHÔNG reload tự động để tránh loop, chỉ reload nếu cần
            labelTitle.Click += (s, e) =>
            {
                var detailForm = new DetailDiscountForm(discount.MaCTKhuyenMai);
                if (detailForm.ShowDialog() == DialogResult.OK) // Chỉ reload nếu có thay đổi
                {
                    _ = LoadDiscountsAsync();
                }
            };

            panelTitle.Controls.Add(labelTitle);

            var panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 28,
                BackColor = SystemColors.ActiveCaption
            };

            // 🖋 Nút chỉnh sửa
            var picEdit = new PictureBox
            {
                Image = Properties.Resources.edit,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Left,
                Width = 24,
                Cursor = Cursors.Hand,
                Tag = discount.MaCTKhuyenMai
            };
            picEdit.Click += product_edit_btn1_Click;

            // 🗑 Nút xóa
            var picDelete = new PictureBox
            {
                Image = Properties.Resources.trash,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Right,
                Width = 35,
                Cursor = Cursors.Hand,
                Tag = discount.MaCTKhuyenMai
            };
            picDelete.Click += async (s, e) => await DeleteDiscountAsync((int)((PictureBox)s).Tag);

            panelButtons.Controls.Add(picEdit);
            panelButtons.Controls.Add(picDelete);
            panelOuter.Controls.Add(panelTitle);
            panelOuter.Controls.Add(panelButtons);

            return panelOuter;
        }

        // 🔍 Tìm kiếm khuyến mãi (immediate, không debounce)
        private void roundedTextBox2_TextChanged(object sender, EventArgs e)
        {
            // Tự động load lại (gọi LoadDiscountsAsync để fetch fresh data từ API)
            _ = LoadDiscountsAsync(); // Async fire-and-forget để reload ngay khi gõ
        }

        // 🔍 Filter theo trạng thái
        private void roundedComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // 🗑 Hàm xóa khuyến mãi bằng API
        private async Task DeleteDiscountAsync(int maCTKhuyenMai)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này không?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5198");

                var response = await client.DeleteAsync($"/api/ctkhuyenmai/{maCTKhuyenMai}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa khuyến mãi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDiscountsAsync(); // Làm mới
                }
                else
                {
                    string err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Không thể xóa khuyến mãi!\n{response.StatusCode}\n{err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🧩 Mở form thêm khuyến mãi
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            var addForm = new AddDiscountForm();
            addForm.Owner = this;
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _ = LoadDiscountsAsync(); // Làm mới sau khi thêm
            }
        }

        // 🛠 Nút chỉnh sửa (mở form sửa)
        private void product_edit_btn1_Click(object sender, EventArgs e)
        {
            var pic = sender as PictureBox;
            if (pic?.Tag is int id)
            {
                var editForm = new EditDiscountForm(id);
                editForm.Owner = this;
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadDiscountsAsync(); // Làm mới sau khi sửa
                }
            }
        }
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop(); // Dừng timer để tránh gọi lặp
            ApplyFilters(); // Áp dụng bộ lọc sau khi user dừng gõ
        }

        // 🔄 Helper: Hiển thị/ẩn loading (cải tiến để tránh chồng loading)
        private void ShowLoading(bool show)
        {
            // Remove loading cũ nếu có (sử dụng for loop thay vì ToArray để tránh lỗi)
            for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = flowLayoutPanel1.Controls[i];
                if (ctrl is Label l && l.Text == "Đang tải...")
                {
                    flowLayoutPanel1.Controls.RemoveAt(i);
                    break;
                }
            }

            if (show)
            {
                var loadingLabel = new Label
                {
                    Text = "Đang tải...",
                    AutoSize = true,
                    ForeColor = Color.Blue,
                    Location = new Point(flowLayoutPanel1.Width / 2 - 30, flowLayoutPanel1.Height / 2 - 10), // Center
                    Anchor = AnchorStyles.None
                };
                flowLayoutPanel1.Controls.Add(loadingLabel);
            }
            flowLayoutPanel1.Refresh();
        }

        private void roundedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            _ = LoadDiscountsAsync();
        }
    }
}