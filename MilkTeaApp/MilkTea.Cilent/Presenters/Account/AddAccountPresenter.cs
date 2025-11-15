using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class AddAccountPresenter
    {
        private readonly IAddAccountForm _form;
        private readonly AccountService _service = new();
        private readonly QuyenService _quyenService = new();
        private readonly AccountService _accountService = new();

        public AddAccountPresenter(IAddAccountForm form)
        {
            _form = form;
        }
        public async Task AddAccountAsync()
        {
            var tk = _form.GetTaiKhoanInput();
            await _service.AddAccountsAsync(tk);
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


            if (!await Validate(tk))
            {
                return false;
            }

            try
            {
                await _accountService.AddAccountsAsync(tk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            MessageBox.Show("Đã thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if ((await _accountService.SearchAccountsAsync("TenTaiKhoan", tk.TenTaiKhoan)).Count() != 0)
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


            return true;
        }
    }
}
