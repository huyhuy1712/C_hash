using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class EditProductForm : Form
    {

        private string _selectedImagePath = string.Empty; // lưu đường dẫn thật khi chọn file
        public event EventHandler SanPhamUpdated;



        private SanPham sp;
        private readonly LoaiService _loaiService = new LoaiService();
        private readonly SanPhamService _sanPhamService = new SanPhamService();

        public EditProductForm(SanPham sp)
        {
            InitializeComponent();
            this.sp = sp;
            loadDuLieu();
        }

        private void roundedComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public async void loadDuLieu()
        {
            ten_textbox.Text = sp.TenSP;
            gia_textbox.Text = sp.Gia.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));

            // Load danh sách loại sản phẩm vào combobox
            var loaiList = await _loaiService.GetLoaisAsync();
            loai_cbb.DataSource = loaiList;
            loai_cbb.DisplayMember = "TenLoai";
            loai_cbb.ValueMember = "MaLoai";

            //loại cũ
            loai_cbb.SelectedValue = sp.MaLoai;

            anh_txt.Text = sp.Anh.ToString();
        }
        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
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
                        anh_txt.Text = fileName; // chỉ hiển thị tên file
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi chọn ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void XacNhan_btn_Click(object sender, EventArgs e)
        {
            var ten = ten_textbox.Text.Trim();
            var gia = gia_textbox.Text.Trim();
            var maLoai = (int)loai_cbb.SelectedValue;
            var anh = anh_txt.Text.Trim();

            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ten_textbox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(gia))
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (string.IsNullOrEmpty(anh))
            {
                MessageBox.Show("Vui lòng chọn ảnh sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // === Nếu có chọn ảnh mới thì mới copy ===
            string fileNameToSave = this.sp.Anh; // mặc định giữ nguyên ảnh cũ

            if (!string.IsNullOrEmpty(_selectedImagePath))
            {
                try
                {
                    string fileName = Path.GetFileName(_selectedImagePath);

                    // 1️ Lưu tạm vào bin để load ngay
                    string binFolder = Path.Combine(Application.StartupPath, "images", "tra_sua");
                    Directory.CreateDirectory(binFolder);
                    string binPath = Path.Combine(binFolder, fileName);

                    using (FileStream sourceStream = new FileStream(_selectedImagePath, FileMode.Open, FileAccess.Read))
                    using (FileStream destStream = new FileStream(binPath, FileMode.Create, FileAccess.Write))
                    {
                        await sourceStream.CopyToAsync(destStream);
                    }

                    // 2️ Lưu vào folder images bên ngoài project để lưu lâu dài
                    string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                    string targetFolder = Path.Combine(projectRoot, "images", "tra_sua");
                    Directory.CreateDirectory(targetFolder);
                    string targetPath = Path.Combine(targetFolder, fileName);

                    if (!File.Exists(targetPath))
                    {
                        File.Copy(binPath, targetPath);
                    }

                    fileNameToSave = fileName; // chỉ cập nhật khi có ảnh mới
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }



            // === Cập nhật sản phẩm ===

            SanPham sp = new SanPham
            {
                MaSP = this.sp.MaSP,
                TenSP = ten_textbox.Text,
                Gia = giaValue,
                Anh = anh_txt.Text,
                SLDuKien = 0,
                TrangThai = 1, // Mặc định sản phẩm mới là 'Active'
                MaLoai = maLoai
            };

            try
            {
                // 3. Gọi Service để sửa sản phẩm
                var response = await _sanPhamService.UpdateSanPhamAsync(sp);

                // 4. Xử lý thành công
                MessageBox.Show($"Sửa sản phẩm '{sp.TenSP}' thành công!",
                                "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Gửi tín hiệu cho form cha biết là đã cập nhật
                SanPhamUpdated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                // 5. Xử lý lỗi
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gia_textbox_Load(object sender, EventArgs e)
        {

        }
    }
}
