using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Forms.ChildForm_Discount;
using MilkTea.Client.Models;
using MilkTea.Client.Services; // Giả sử có CTKhuyenMaiService nếu cần

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
            this.Load += DiscountForm_Load;
            // Khởi tạo timer debounce cho reload (500ms delay để tránh gọi API liên tục)
            _searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _searchTimer.Tick += SearchTimer_Tick;
        }

        private async void DiscountForm_Load(object sender, EventArgs e)
        {
            // Thêm "Tất cả" vào ComboBox trạng thái (nếu chưa có)
            if (roundedComboBox2.Items.Count == 0 || !roundedComboBox2.Items.Contains("Tất cả"))
            {
                roundedComboBox2.Items.Clear(); // Clear nếu có item cũ
                roundedComboBox2.Items.AddRange(new object[] { "Tất cả", "Đang hoạt động", "Hết hạn" }); // Thêm "Tất cả" làm item đầu tiên
            }
            roundedComboBox2.SelectedIndex = 0; // Chọn "Tất cả" mặc định

            // Clear search để tránh filter sai
            roundedTextBox2.TextValue = "";
            roundedTextBox2.Placeholder = "Nhập mã hoặc tên khuyến mãi..."; // Đảm bảo placeholder

            await LoadDiscountsAsync();

            // 🔍 Gắn sự kiện filter trạng thái (luôn attach, an toàn nếu đã có)
            roundedComboBox2.SelectedIndexChanged += roundedComboBox2_SelectedIndexChanged;
        }

        private async Task btnThemDiscount_ClickAsync(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();
            addDiscountForm.Owner = this;
            if (addDiscountForm.ShowDialog() == DialogResult.OK)
            {
                roundedComboBox2.Items.Clear();
                roundedComboBox2.Items.AddRange(new object[] { "Tất cả", "Đang hoạt động", "Hết hạn" });
                roundedComboBox2.SelectedIndex = 0;

                roundedTextBox2.TextValue = "";
                roundedTextBox2.Placeholder = "Nhập mã hoặc tên khuyến mãi...";

                await LoadDiscountsAsync();
            }
            roundedComboBox2.SelectedIndexChanged += roundedComboBox2_SelectedIndexChanged;
        }

        // 🌀 Hàm load danh sách khuyến mãi (từ API, không filter server-side)
        public async Task LoadDiscountsAsync()
        {
            if (_isLoading) return; // Tránh load trùng lặp

            _isLoading = true;
            ShowLoading(true); // Hiển thị loading indicator

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

            // Filter theo trạng thái: Dựa trên ngày (chỉ nếu KHÔNG phải "Tất cả") + Ẩn TrangThai = 0
            filtered = filtered.Where(d => d.TrangThai == 1); // Ẩn deleted (TrangThai = 0)

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

        // 🧩 Hàm hiển thị danh sách khuyến mãi (sử dụng DataGridView)
        private void DisplayDiscounts(List<CTKhuyenMai> discounts)
        {
            dGV_discounts.Rows.Clear();

            if (discounts == null || discounts.Count == 0)
            {
                dGV_discounts.Rows.Add(); // Thêm row rỗng
                dGV_discounts.Rows[0].Cells["tenKM_col"].Value = "Không có chương trình khuyến mãi nào phù hợp với tìm kiếm.";
                dGV_discounts.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
                dGV_discounts.Rows[0].DefaultCellStyle.Font = new Font(dGV_discounts.DefaultCellStyle.Font, FontStyle.Italic);
                return;
            }

            foreach (var discount in discounts)
            {
                int rowIndex = dGV_discounts.Rows.Add();

                // Store the ID in the row Tag so click handler can find it (don't rely on a removed action_col)
                dGV_discounts.Rows[rowIndex].Tag = discount.MaCTKhuyenMai;

                dGV_discounts.Rows[rowIndex].Cells["tenKM_col"].Value = discount.TenCTKhuyenMai;
                dGV_discounts.Rows[rowIndex].Cells["moTa_col"].Value = discount.MoTa;
                dGV_discounts.Rows[rowIndex].Cells["phanTram_col"].Value = discount.PhanTramKhuyenMai + "%";
                dGV_discounts.Rows[rowIndex].Cells["ngayBatDau_col"].Value = discount.NgayBatDau?.ToString("dd/MM/yyyy");
                dGV_discounts.Rows[rowIndex].Cells["ngayKetThuc_col"].Value = discount.NgayKetThuc?.ToString("dd/MM/yyyy");
                dGV_discounts.Rows[rowIndex].Cells["trangThai_col"].Value = GetStatusText(discount);

                // Action column: Set text "Edit | Delete"
            }

            dGV_discounts.Refresh(); // Force refresh UI
        }

        // 🔍 Trạng thái text (dựa trên ngày)
        private string GetStatusText(CTKhuyenMai discount)
        {
            if (discount.TrangThai != 1) return "Đã xóa";

            DateTime now = DateTime.Now.Date;
            bool isActive = false;
            if (discount.NgayBatDau.HasValue && discount.NgayKetThuc.HasValue)
            {
                isActive = discount.NgayBatDau.Value.Date <= now && now <= discount.NgayKetThuc.Value.Date;
            }
            else if (discount.NgayBatDau.HasValue && !discount.NgayKetThuc.HasValue)
            {
                isActive = discount.NgayBatDau.Value.Date <= now;
            }

            return isActive ? "Đang hoạt động" : "Hết hạn";
        }

        // 🔍 Tìm kiếm khuyến mãi (debounce với timer)
        private void roundedTextBox2_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start(); // Restart timer để debounce
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop(); // Dừng timer
            ApplyFilters(); // Áp dụng bộ lọc sau khi user dừng gõ
        }

        // 🔍 Filter theo trạng thái
        private void roundedComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private async Task SoftDeleteDiscountAsync(int maCTKhuyenMai)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa chương trình khuyến mãi này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5198") };

                // 1) Lấy object đầy đủ
                var getResponse = await client.GetAsync($"/api/ctkhuyenmai/{maCTKhuyenMai}");
                if (!getResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Không tìm thấy khuyến mãi để ẩn (ID: {maCTKhuyenMai})!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var json = await getResponse.Content.ReadAsStringAsync();
                var fullKm = JsonSerializer.Deserialize<CTKhuyenMai>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (fullKm == null)
                {
                    MessageBox.Show("Không thể đọc dữ liệu khuyến mãi để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2) Set trạng thái = 0 (soft delete)
                fullKm.TrangThai = 0;
                var updateJson = JsonSerializer.Serialize(fullKm);
                var updateContent = new StringContent(updateJson, Encoding.UTF8, "application/json");

                var putResponse = await client.PutAsync("/api/ctkhuyenmai", updateContent);
                var putRaw = await putResponse.Content.ReadAsStringAsync();

                if (!putResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Không thể cập nhật trạng thái khuyến mãi.\nStatus: {putResponse.StatusCode}\n{putRaw}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3) Xóa cứng các liên kết sản phẩm thuộc MaCT (nếu API hỗ trợ)
                try
                {
                    var deleteResponse = await client.DeleteAsync($"/api/sanphamkhuyenmai/khuyenmai/{maCTKhuyenMai}");
                    var deleteRaw = await deleteResponse.Content.ReadAsStringAsync();

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa chương trình khuyến mãi và các liên kết sản phẩm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Soft-delete thành công nhưng xóa liên kết thất bại -> cảnh báo
                        MessageBox.Show($"Đã đặt trạng thái khuyến mãi = 0, nhưng không thể xóa liên kết sản phẩm.\nStatus: {deleteResponse.StatusCode}\n{deleteRaw}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception exDel)
                {
                    MessageBox.Show($"Đã đặt trạng thái khuyến mãi = 0, nhưng lỗi khi xóa liên kết sản phẩm: {exDel.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // 4) Reload danh sách khuyến mãi
                await LoadDiscountsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa/ẩn khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🧩 Mở form thêm khuyến mãi
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            _ = btnThemDiscount_ClickAsync(sender, e); // Gọi async method
        }

        // 🛠 Nút chỉnh sửa (mở form sửa)
        private async void dGV_discounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var row = dGV_discounts.Rows[e.RowIndex];

            // Lấy MaCTKhuyenMai ưu tiên từ row.Tag, fallback parse từ tenKM_col nếu cần
            int maCTKhuyenMai;
            if (row.Tag is int id)
            {
                maCTKhuyenMai = id;
            }
            else if (row.Cells["tenKM_col"].Value != null && int.TryParse(row.Cells["tenKM_col"].Value.ToString(), out int parsed))
            {
                maCTKhuyenMai = parsed;
            }
            else
            {
                MessageBox.Show("Không thể xác định mã khuyến mãi cho hàng này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cols = dGV_discounts.Columns;

            // Chi tiết
            if (cols["chiTiet"] != null && e.ColumnIndex == cols["chiTiet"].Index)
            {
                var detailForm = new DetailDiscountForm(maCTKhuyenMai) { Owner = this };
                detailForm.ShowDialog();
                return;
            }

            // Sửa
            if (cols["sua"] != null && e.ColumnIndex == cols["sua"].Index)
            {
                var editForm = new EditDiscountForm(maCTKhuyenMai) { Owner = this };
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadDiscountsAsync();
                }
                return;
            }

            // Xóa (ẩn)
            if (cols["xoa"] != null && e.ColumnIndex == cols["xoa"].Index)
            {
                await SoftDeleteDiscountAsync(maCTKhuyenMai);
                return;
            }
        }

        // 🔄 Helper: Hiển thị/ẩn loading (cải tiến cho DataGridView)
        private void ShowLoading(bool show)
        {
            if (show)
            {
                dGV_discounts.Rows.Clear();
                int rowIndex = dGV_discounts.Rows.Add();
                dGV_discounts.Rows[rowIndex].Cells["tenKM_col"].Value = "Đang tải...";
                dGV_discounts.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                dGV_discounts.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_discounts.DefaultCellStyle.Font, FontStyle.Italic);
            }
            else
            {
                // Không cần clear, Load sẽ làm
            }
            dGV_discounts.Refresh();
        }

        private void roundedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _searchTimer.Stop();
                ApplyFilters(); // Tìm ngay khi Enter
            }
        }
    }
}