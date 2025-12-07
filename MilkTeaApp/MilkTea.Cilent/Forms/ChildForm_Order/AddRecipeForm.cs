using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class AddRecipeForm : Form
    {

        private readonly NguyenLieuService _nguyenLieuService = new NguyenLieuService();
        private readonly DonViTinhService _donViTinhService = new DonViTinhService();
        public event EventHandler RecipeSaved;
        private string tenSP;

        public AddRecipeForm(string tenSP)
        {
            this.tenSP = tenSP;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadNguyenLieu();
        }


        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task LoadNguyenLieu()
        {
            List<DonViTinh> donViTinhs = await _donViTinhService.GetAllAsync();
            tenSP_lbl.Text = tenSP;
            txtTenCongThuc.Text = $"Công thức {tenSP}";

            try
            {
                var listNguyenLieu = await _nguyenLieuService.GetAll();

                // Xóa các control cũ trước khi load mới
                topping_table_panel.Controls.Clear();

                if (listNguyenLieu != null)
                {
                    foreach (var nl in listNguyenLieu)
                    {
                        var item = new Controls.nguyenlieu_congthuc_item();
                        item.SetData(nl, donViTinhs);
                        item.Dock = DockStyle.Top;
                        item.Margin = new Padding(0, 2, 0, 2);

                        // --- khôi phục trạng thái ---
                        if (RecipeCache.NguyenLieuTam.TryGetValue(nl.MaNL, out int sl))
                        {
                            item.IsChecked = true;
                            item.SoLuong = sl.ToString();
                        }

                        topping_table_panel.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải nguyên liệu: {ex.Message}");
            }
        }



        private async void txtSearch_NL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtSearch_NL.Text.Trim();

                try
                {
                    topping_table_panel.Controls.Clear();


                    if (string.IsNullOrEmpty(keyword))
                    {
                        // Trả về danh sách gốc
                        await LoadNguyenLieu();
                    }
                    else
                    {
                        // Gọi API tìm kiếm
                        var result = await _nguyenLieuService.GetByTen(keyword);

                        if (result != null && result.Any())
                        {
                            foreach (var nl in result)
                            {
                                var nlItem = new Controls.nguyenlieu_congthuc_item();
                                List<DonViTinh> donViTinhs = await _donViTinhService.GetAllAsync();
                                nlItem.SetData(nl, donViTinhs);
                                nlItem.Dock = DockStyle.Top;
                                nlItem.Margin = new Padding(0, 2, 0, 2);
                                topping_table_panel.Controls.Add(nlItem);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nguyên liệu phù hợp.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}");
                }

                e.Handled = true;
                e.SuppressKeyPress = true; // chặn tiếng "ding" khi ấn Enter
            }
        }

        private void XacNhan_btn_Click(object sender, EventArgs e)
        {
            // Lấy tên công thức
            string tenCT = txtTenCongThuc.Text.Trim();

            if (string.IsNullOrEmpty(tenCT))
            {
                MessageBox.Show("Vui lòng nhập tên công thức!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo mới đối tượng công thức
            var congThuc = new CongThuc
            {
                Ten = tenCT,
                MoTa = "",
                MaSP = 0 // sẽ gán sau khi lưu sản phẩm
            };

            var listCTCT = new List<ChiTietCongThuc>();

            // Duyệt qua tất cả usercontrol nguyên liệu
            foreach (Controls.nguyenlieu_congthuc_item item in topping_table_panel.Controls)
            {
                if (item.IsChecked) // chỉ lấy những nguyên liệu được tick
                {
                    // --- kiểm tra số lượng ---
                    if (!int.TryParse(item.SoLuong, out int soLuong))
                    {
                        MessageBox.Show($"Nguyên liệu '{item.TenNL}' có số lượng không hợp lệ! Vui lòng nhập số nguyên.",
                            "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (soLuong <= 0)
                    {
                        MessageBox.Show($"Số lượng cho '{item.TenNL}' phải lớn hơn 0!",
                            "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // --- thêm vào danh sách ---
                    listCTCT.Add(new ChiTietCongThuc
                    {
                        MaNL = item.MaNL,
                        SL = soLuong,
                        MaDVT = int.Parse(item.DonViTinh)
                    });
                }
            }

            if (listCTCT.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nguyên liệu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu tạm vào bộ nhớ
            RecipeCache.CongThucHienTai = congThuc;
            RecipeCache.ChiTietCongThucs = listCTCT;
            // Lưu tạm trạng thái nguyên liệu được chọn
            RecipeCache.NguyenLieuTam.Clear();
            foreach (Controls.nguyenlieu_congthuc_item item in topping_table_panel.Controls)
            {
                if (item.IsChecked)
                {
                    if (int.TryParse(item.SoLuong, out int sl))
                        RecipeCache.NguyenLieuTam[item.MaNL] = sl;
                }
            }
            MessageBox.Show("Đã lưu công thức", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Gọi event để form cha biết công thức đã được thêm
            RecipeSaved?.Invoke(this, EventArgs.Empty);

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
 
    }
}
