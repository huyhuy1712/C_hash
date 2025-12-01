using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class AddAccountPresenter
    {
        private readonly IAddAccountForm _form;
        private readonly QuyenService _quyenService = new();
        private readonly AccountService _accountService = new();
        private readonly NhanVienService _nhanVienService = new();

        public AddAccountPresenter(IAddAccountForm form)
        {
            _form = form;
        }

        public async Task LoadDataAsync()
        {
            try
            {
                _form.setQuyen(await _quyenService.GetQuyensAsync());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
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
            string duongDanNguon = tk.anh;


            if (!await Validate(tk))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(duongDanNguon))
            {
                tk.anh = CopyAnh(duongDanNguon);
            }

            int maTK;
            try
            {
                maTK = await _accountService.AddAccountsAsync(tk);
                if (await themNhanVien(maTK))
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            MessageBox.Show("Đã thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public async Task<bool> themNhanVien(int maTK)
        {
            NhanVien nv = new();
            nv.MaTK = maTK;
            nv.SDT = _form.TxtbSoDienThoai.Text;
            nv.NgayLam = DateTime.Now;
            nv.TenNV = _form.TxtbTenNhanVien.Text;

            var result = await _nhanVienService.AddNhanVienAsync(nv);
            return result.success;
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

        public async Task<bool> Validate(TaiKhoan tk)
        {
            _form.Error.Clear();

            if (string.IsNullOrWhiteSpace(tk.TenTaiKhoan))
            {
                _form.Error.SetError(_form.TxtbTenTaiKhoan, "Tên tài khoản không được để trống.");
                _form.TxtbTenTaiKhoan.Focus();
                return false;
            }

            if (await _accountService.CheckUsernameExistsAsync(tk.TenTaiKhoan))
            {
                _form.Error.SetError(_form.TxtbTenTaiKhoan, "Tên tài khoản đã tồn tại.");
                _form.TxtbTenTaiKhoan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tk.MatKhau))
            {
                _form.Error.SetError(_form.TxtbMatKhau, "Mật khẩu không được để trống.");
                _form.TxtbMatKhau.Focus();
                return false;
            }

            var phonePattern = @"^\d{10,11}$";
            if (!Regex.IsMatch(tk.MatKhau, phonePattern))
            {
                _form.Error.SetError(_form.TxtbMatKhau, "Mật khẩu phải là số điện thoại hợp lệ!");
                _form.TxtbMatKhau.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(tk.anh) && !File.Exists(tk.anh))
            {
                _form.Error.SetError(_form.TxtbDuongDanAnh, "Đường dẫn ảnh không hợp lệ!");
                _form.TxtbDuongDanAnh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(_form.TxtbTenNhanVien.Text))
            {
                _form.Error.SetError(_form.TxtbTenNhanVien, "Tên nhân viên không được để trống.");
                _form.TxtbTenNhanVien.Focus();
                return false;
            }

            if (!Regex.IsMatch(_form.TxtbSoDienThoai.Text, phonePattern))
            {
                _form.Error.SetError(_form.TxtbSoDienThoai, "Số điện thoại không hợp lệ!");
                _form.TxtbSoDienThoai.Focus();
                return false;
            }

            return true;
        }
    }
}
