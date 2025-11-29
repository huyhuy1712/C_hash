using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MilkTea.Client.Presenters.Account
{
    public class EditAccountPresenter
    {
        private IEditAccount _form;
        private readonly QuyenService _quyenService = new();
        private readonly AccountService _accountService = new();
        private readonly NhanVienService _nhanVienService = new();

        private TaiKhoan tk;

        public EditAccountPresenter(IEditAccount _form)
        {
            this._form = _form;
        }

        public async Task GetDataAsync(int id)
        {
            try
            {
                tk = await _accountService.GetAccountsByIdAsync(id);
                _form.setTaiKhoan(tk);
                _form.setQuyen(await _quyenService.GetQuyensAsync());
                _form.setNhanVien(await _nhanVienService.GetByMaTK(id));

                // Load picture
                string duongDanAnh = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images\\nhan_vien", tk.anh);
                if (File.Exists(duongDanAnh))
                {
                    using (var img = Image.FromFile(duongDanAnh))
                    {
                        _form.Pic.Image = new Bitmap(img); // clone để tránh file bị lock
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void ChonAnh()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _form.TxtbDuongDanAnh.Text = ofd.FileName; // hiện đường dẫn ảnh
                _form.Pic.Image = Image.FromFile(ofd.FileName); // load ảnh xem trước
            }
        }

        public void ThemQuyen()
        {
            using (var frm = new AddQuyenForm())
                frm.ShowDialog();
        }

        public async Task<bool> SaveAsync()
        {
            var tk = _form.GetTaiKhoanInput();
            tk.MatKhau = this.tk.MatKhau;
            tk.MaTK = this.tk.MaTK;

            string duongDanNguon = tk.anh;

            if (!await Validate(tk))
            {
                return false;
            }

            if (this.tk.anh != tk.anh)
            {
                if (!string.IsNullOrEmpty(duongDanNguon))
                {
                    tk.anh = CopyAnh(duongDanNguon);
                }
            }

            try
            {
                await _accountService.UpdateAccountsAsync(tk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public async Task<bool> Validate(TaiKhoan tk)
        {
            _form.Error.Clear();

            if (string.IsNullOrWhiteSpace(tk.TenTaiKhoan))
            {
                _form.Error.SetError(_form.TxtbTenTaiKhoan, "Tên tài khoản không được để trống.");
                _form.TxtbTenTaiKhoan.Focus();
                return false;
            }

            if (this.tk.TenTaiKhoan != tk.TenTaiKhoan)
            {
                if (await _accountService.CheckUsernameExistsAsync(tk.TenTaiKhoan))
                {
                    _form.Error.SetError(_form.TxtbTenTaiKhoan, "Tên tài khoản đã tồn tại.");
                    _form.TxtbTenTaiKhoan.Focus();
                    return false;
                }
            }

            if (this.tk.anh != tk.anh)
            {
                if (!string.IsNullOrEmpty(tk.anh) && !File.Exists(tk.anh))
                {
                    _form.Error.SetError(_form.TxtbDuongDanAnh, "Đường dẫn ảnh không hợp lệ!");
                    _form.TxtbDuongDanAnh.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(_form.TxtbTenNhanVien.Text))
            {
                _form.Error.SetError(_form.TxtbTenNhanVien, "Tên nhân viên không được để trống.");
                _form.TxtbTenNhanVien.Focus();
                return false;
            }

            var phonePattern = @"^\d{10,11}$";
            if (!Regex.IsMatch(_form.TxtbSoDienThoai.Text, phonePattern))
            {
                _form.Error.SetError(_form.TxtbSoDienThoai, "Số điện thoại không hợp lệ!");
                _form.TxtbSoDienThoai.Focus();
                return false;
            }

            return true;
        }

        public string CopyAnh(string duongDanNguon)
        {
            // Lấy tên ảnh
            string tenAnh = Path.GetFileName(duongDanNguon);

            // Thư mục đích tương đối
            string thuMucDich = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"images\nhan_vien"
            );

            if (!Directory.Exists(thuMucDich))
            {
                Directory.CreateDirectory(thuMucDich);
            }

            // Copy ảnh vào thư mục dự án
            string duongDanDich = Path.Combine(thuMucDich, tenAnh);
            File.Copy(duongDanNguon, duongDanDich, true);

            return tenAnh;
        }
    }
}
