using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Discount
{
    public partial class AddDiscountForm : Form
    {
        private List<SanPham> danhSachSanPham = new List<SanPham>();
        private List<Loai> _danhSachLoai;
        private Dictionary<DataGridViewCheckBoxCell, int> checkboxToMaSPMap = new Dictionary<DataGridViewCheckBoxCell, int>(); // Map checkbox cell to MaSP
        private const string ApiBaseUrl = "http://localhost:5198";
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

        private async void AddDiscountForm_Load_1(object sender, EventArgs e)
        {
            await LoadSanPhamAsync(); // Load sản phẩm cho DataGridView
        }



        private async Task LoadSanPhamAsync()
        {
            try
            {
                var sanPhams = await _SanPhamService.GetSanPhamsAsync();
                var loais = await _loaiService.GetLoaisAsync();

                dGV_sp_KM_ADD.Rows.Clear();

                var sanPhamsActive = sanPhams?.Where(sp => sp.TrangThai == 1).ToList(); // Filter active nếu có TrangThai
                if (sanPhamsActive != null && sanPhamsActive.Any())
                {
                    foreach (var sp in sanPhamsActive)
                    {
                        var loai = loais.Find(l => l.MaLoai == sp.MaLoai); // Tìm loại tương ứng
                        int rowIndex = dGV_sp_KM_ADD.Rows.Add();
                        dGV_sp_KM_ADD.Rows[rowIndex].Cells["chon_add"].Value = false; // Checkbox mặc định false
                        dGV_sp_KM_ADD.Rows[rowIndex].Cells["tenSanPham_add"].Value = sp.TenSP;
                        dGV_sp_KM_ADD.Rows[rowIndex].Cells["loai_add"].Value = loai?.TenLoai ?? "Không xác định";
                        dGV_sp_KM_ADD.Rows[rowIndex].Cells["maSP_add"].Value = sp.MaSP;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_sp_KM_ADD_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dGV_sp_KM_ADD.IsCurrentCellInEditMode && dGV_sp_KM_ADD.CurrentCell.ColumnIndex == dGV_sp_KM_ADD.Columns["chon_add"].Index)
            {
                dGV_sp_KM_ADD.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DGV_sp_KM_ADD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dGV_sp_KM_ADD.Columns["chon_add"].Index && e.RowIndex >= 0)
            {
                var checkCell = dGV_sp_KM_ADD.Rows[e.RowIndex].Cells["chon_add"] as DataGridViewCheckBoxCell;
                bool isChecked = (bool)checkCell.Value;

                if (checkBox6.Checked && isChecked)
                {
                    checkCell.Value = false;
                    MessageBox.Show("Vui lòng bỏ chọn 'Chọn tất cả' để chọn sản phẩm cụ thể.", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = !checkBox6.Checked;
            foreach (DataGridViewRow row in dGV_sp_KM_ADD.Rows)
            {
                var checkCell = row.Cells["chon_add"] as DataGridViewCheckBoxCell;
                checkCell.ReadOnly = !enabled; // Disable if "Chọn tất cả" is checked
            }

            if (checkBox6.Checked)
            {
                // Uncheck all
                foreach (DataGridViewRow row in dGV_sp_KM_ADD.Rows)
                {
                    row.Cells["chon_add"].Value = false;
                }
            }
        }

        // Helper để lấy list MaSP đã chọn từ DataGridView checkboxes
        private List<int> GetSelectedSanPhamIds()
        {
            var selectedIds = new List<int>();

            foreach (DataGridViewRow row in dGV_sp_KM_ADD.Rows)
            {
                // safe access to the checkbox cell
                var checkCell = row.Cells["chon_add"] as DataGridViewCheckBoxCell;
                if (checkCell == null) continue;

                bool isChecked = false;
                if (checkCell.Value != null && bool.TryParse(checkCell.Value.ToString(), out var v))
                    isChecked = v;
                else if (checkCell.FormattedValue != null && bool.TryParse(checkCell.FormattedValue.ToString(), out v))
                    isChecked = v;

                if (!isChecked) continue;

                // Use the actual column name used when filling the grid ("maSP_add")
                var maCell = row.Cells["maSP_add"];
                if (maCell?.Value == null) continue;

                if (int.TryParse(maCell.Value.ToString(), out int maSP))
                    selectedIds.Add(maSP);
            }

            return selectedIds;
        }


        private void roundedTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = roundedTextBox1.TextValue?.Trim().ToLower() ?? "";
                string columnName = "tenSanPham_add"; // Tìm kiếm mặc định theo tên sản phẩm

                int visibleRowCount = 0;
                // Lọc các hàng trong DataGridView
                foreach (DataGridViewRow row in dGV_sp_KM_ADD.Rows)
                {
                    if (row.Cells[columnName].Value != null)
                    {
                        string cellValue = row.Cells[columnName].Value.ToString().ToLower();
                        // Hiển thị hàng nếu giá trị trong ô chứa chuỗi tìm kiếm
                        row.Visible = cellValue.Contains(searchValue);
                        if (row.Visible)
                        {
                            visibleRowCount++;
                        }
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }

                // Nếu không có kết quả, show MessageBox (chỉ khi searchValue không rỗng để tránh spam)
                if (visibleRowCount == 0 && !string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Gửi POST cho CTKhuyenMai
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);

                var json = JsonSerializer.Serialize(km);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/ctkhuyenmai", content);

                if (response.IsSuccessStatusCode)
                {
                    // Parse MaCTKhuyenMai mới từ response
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var addedKm = JsonSerializer.Deserialize<CTKhuyenMai>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    int maCTKhuyenMai = addedKm?.MaCTKhuyenMai ?? 0;

                    bool success = true;
                    if (maCTKhuyenMai > 0 && selectedSanPhamIds.Count > 0)
                    {
                        success = await SaveSanPhamKhuyenMaiAsync(maCTKhuyenMai, selectedSanPhamIds);
                    }

                    // Message tùy chỉnh cho sản phẩm khuyến mãi
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

        

        private void roundedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic nếu cần
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic nếu cần
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic nếu cần
        }

        private void roundedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            _ = LoadSanPhamAsync();
        }

        private void btnThoatDiscount_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}