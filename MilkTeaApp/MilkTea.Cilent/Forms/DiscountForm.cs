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
        private List<CTKhuyenMai> _allDiscounts = new List<CTKhuyenMai>(); // lưu danh sách gốc

        public DiscountForm()
        {
            InitializeComponent();
            this.Load += DiscountForm_Load;
        }

        private async void DiscountForm_Load(object sender, EventArgs e)
        {
            await LoadDiscountsAsync();

            // 🔍 Gắn sự kiện tìm kiếm cho ô nhập
            roundedTextBox2.TextChanged += roundedTextBox2_TextChanged;
        }

        // 🌀 Hàm load danh sách khuyến mãi
        public async Task LoadDiscountsAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5021");

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

                DisplayDiscounts(_allDiscounts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khuyến mãi: {ex.Message}");
            }
        }

        // 🧩 Hàm hiển thị danh sách khuyến mãi
        private void DisplayDiscounts(List<CTKhuyenMai> discounts)
        {
            flowLayoutPanel1.Controls.Clear();

            if (discounts == null || discounts.Count == 0)
            {
                Label lbl = new Label()
                {
                    Text = "Không có chương trình khuyến mãi nào.",
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Height = 50
                };
                flowLayoutPanel1.Controls.Add(lbl);
                return;
            }

            foreach (var discount in discounts)
            {
                var panelOuter = new Panel
                {
                    Width = 200,
                    Height = 100,
                    BackColor = SystemColors.ButtonHighlight,
                    Margin = new Padding(10)
                };

                var panelTitle = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 72
                };

                var labelTitle = new Label
                {
                    Text = $"{discount.MaCTKhuyenMai} - {discount.TenCTKhuyenMai}",
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 14.25F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };

                // Mở form chi tiết
                labelTitle.Click += (s, e) =>
                {
                    var detailForm = new DetailDiscountForm(discount.MaCTKhuyenMai);
                    detailForm.ShowDialog();
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
                picDelete.Click += async (s, e) =>
                {
                    await DeleteDiscountAsync((int)((PictureBox)s).Tag);
                };

                panelButtons.Controls.Add(picEdit);
                panelButtons.Controls.Add(picDelete);
                panelOuter.Controls.Add(panelTitle);
                panelOuter.Controls.Add(panelButtons);
                flowLayoutPanel1.Controls.Add(panelOuter);
            }
        }

        // 🔍 Tìm kiếm khuyến mãi (lọc tại client, không cần gọi API)
        private void roundedTextBox2_TextChanged(object sender, EventArgs e)
        {
            string keyword = roundedTextBox2.TextValue?.Trim().ToLower() ?? "";

            if (string.IsNullOrEmpty(keyword))
            {
                DisplayDiscounts(_allDiscounts);
                return;
            }

            var filtered = _allDiscounts.Where(d =>
                d.TenCTKhuyenMai.ToLower().Contains(keyword) ||
                d.MaCTKhuyenMai.ToString().Contains(keyword)
            ).ToList();

            DisplayDiscounts(filtered);
        }

        // 🗑 Hàm xóa khuyến mãi bằng API
        private async Task DeleteDiscountAsync(int maCTKhuyenMai)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này không?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5021");

                var response = await client.DeleteAsync($"/api/ctkhuyenmai/{maCTKhuyenMai}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa khuyến mãi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDiscountsAsync(); // làm mới
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
            addForm.ShowDialog();
            _ = LoadDiscountsAsync(); // làm mới sau khi thêm
        }

        // 🛠 Nút chỉnh sửa (mở form sửa)
        private void product_edit_btn1_Click(object sender, EventArgs e)
        {
            var pic = sender as PictureBox;
            if (pic?.Tag is int id)
            {
                var editForm = new EditDiscountForm(id);
                editForm.ShowDialog();
                _ = LoadDiscountsAsync(); // làm mới sau khi sửa
            }
        }
    }
}
