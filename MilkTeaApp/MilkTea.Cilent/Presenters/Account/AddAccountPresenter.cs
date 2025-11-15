using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;

namespace MilkTea.Client.Presenters
{
    public class AddAccountPresenter
    {
        private readonly IAddAccountForm _view;
        private readonly AccountService _service = new();
        private readonly NhanVienService _nhanVienService = new();
        private readonly QuyenService _quyenService = new();

        public AddAccountPresenter(IAddAccountForm view) 
        {
            _view = view;
        }
        public async Task AddAccountAsync()
        {
            var tk = _view.GetTaiKhoanInput();
            await _service.AddAccountsAsync(tk);
        }

        public async Task LoadDataAsync()
        {
            try
            {
                _view.setNhanVien(await _nhanVienService.GetNhanVienAsync());
                _view.setQuyen(await _quyenService.GetQuyensAsync());
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
    }
}
