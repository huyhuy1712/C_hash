using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Newtonsoft.Json;



namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class AddProductForm : Form
    {

        private string _selectedImagePath = string.Empty; // lưu đường dẫn thật khi chọn file


        private readonly LoaiService _loaiService = new LoaiService();
        private readonly SanPhamService _sanPhamService = new SanPhamService();
        private readonly CongThucService _congThucService = new CongThucService();
        private readonly CTCongThucService _chiTietCongThucService = new CTCongThucService();

        public event EventHandler SanPhamAdded;


        public AddProductForm()
        {
            InitializeComponent();
            LoadLoaiAsync();
        }

        private async void LoadLoaiAsync()
        {
            try
            {
                var loaiList = await _loaiService.GetLoaisAsync();

                if (loaiList != null && loaiList.Any())
                {
                    cboLoai.DataSource = loaiList;
                    cboLoai.DisplayMember = "TenLoai";  // hiển thị tên loại
                    cboLoai.ValueMember = "MaLoai";     // giá trị là mã loại

                    // Chọn mặc định loại có MaLoai = 1
                    var loaiMacDinh = loaiList.FirstOrDefault(l => l.MaLoai == 1);
                    if (loaiMacDinh != null)
                    {
                        cboLoai.SelectedValue = loaiMacDinh.MaLoai;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu loại sản phẩm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải loại sản phẩm: {ex.Message}");
            }
        }


        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            string tenSP = ten_textbox.Text.Trim();
            if (string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm trước khi thêm công thức.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ten_textbox.Focus();
                return;
            }
            AddRecipeForm addRecipeForm = new AddRecipeForm(tenSP);
            addRecipeForm.RecipeSaved += Frm_RecipeSaved;
            addRecipeForm.ShowDialog();
        }

        private void roundedTextBox2_Load(object sender, EventArgs e)
        {

        }

        private async void XacNhan_btn_Click(object sender, EventArgs e)
        {
            string ten = ten_textbox.Text.Trim();
            string gia = gia_textbox.Text.Trim();
            string loai = cboLoai.SelectedValue.ToString();
            string anh = txtFileDaChon.Text.Trim();

            // === Kiểm tra dữ liệu ===
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ten_textbox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(gia))
            {
                MessageBox.Show("Vui lòng nhập Giá sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gia_textbox.Focus();
                return;
            }

            var vi = new CultureInfo("vi-VN");
            if (!decimal.TryParse(gia, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, vi, out decimal giaValue) || giaValue <= 0)
            {
                MessageBox.Show("Giá sản phẩm phải là số hợp lệ và lớn hơn 0.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gia_textbox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(loai))
            {
                MessageBox.Show("Vui lòng chọn Loại sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoai.Focus();
                return;
            }

            if (string.IsNullOrEmpty(anh))
            {
                MessageBox.Show("Vui lòng chọn Ảnh sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!checkThemCongThuc.Checked)
            {
                MessageBox.Show("Vui lòng thêm công thức cho sản phẩm này.", "Thiếu công thức", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // === Tạo sản phẩm ===
            var sanPham = new SanPham
            {
                TenSP = ten,
                Gia = giaValue,
                SLDuKien = 0,
                MaLoai = ((Loai)cboLoai.SelectedItem).MaLoai,
                Anh = anh // chỉ lưu tên file
            };

            int savedProductId;
            try
            {
                //  Lưu sản phẩm và nhận ID thực tế từ server
                savedProductId = await _sanPhamService.AddSanPhamAsync(sanPham);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API thêm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // === Lưu ảnh vào thư mục images/tra_sua ===
            try
            {
                // Lấy đường dẫn đến thư mục gốc của project (ra khỏi bin\Debug)
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string targetFolder = Path.Combine(projectRoot, "images", "tra_sua");
                Directory.CreateDirectory(targetFolder);

                string fileName = Path.GetFileName(_selectedImagePath);
                string targetPath = Path.Combine(targetFolder, fileName);

                // Nếu file đích đã tồn tại thì xóa trước
                if (File.Exists(targetPath))
                    File.Delete(targetPath);

                // Copy file theo dạng stream để tránh lỗi GDI+
                using (FileStream sourceStream = new FileStream(_selectedImagePath, FileMode.Open, FileAccess.Read))
                using (FileStream destStream = new FileStream(targetPath, FileMode.CreateNew, FileAccess.Write))
                {
                    await sourceStream.CopyToAsync(destStream);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            // === Lưu công thức ===
            try
            {
                RecipeCache.CongThucHienTai.MaSP = savedProductId;

                int congThucId = await _congThucService.AddCongThucAsync(RecipeCache.CongThucHienTai);

                foreach (var ct in RecipeCache.ChiTietCongThucs)
                {
                    ct.MaCT = congThucId;
                    await _chiTietCongThucService.AddCTCongThucAsync(ct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm công thức: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Thêm sản phẩm và công thức thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // === Reset và báo cho form cha ===
            SanPhamAdded?.Invoke(this, EventArgs.Empty);
            RecipeCache.CongThucHienTai = null;
            RecipeCache.ChiTietCongThucs.Clear();
            this.Close();
        }


        private void Frm_RecipeSaved(object sender, EventArgs e)
        {
            checkThemCongThuc.Checked = true; // Tick tự động khi form con báo đã lưu
        }

        private void btn_chon_file_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh sản phẩm";
                openFileDialog.Filter = "Ảnh (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _selectedImagePath = openFileDialog.FileName; //  lưu đường dẫn gốc thật
                        string fileName = Path.GetFileName(_selectedImagePath);
                        txtFileDaChon.Text = fileName; // chỉ hiển thị tên file
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi chọn ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gia_textbox_Load(object sender, EventArgs e)
        {

        }
    }
}
