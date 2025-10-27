using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;

namespace MilkTea.Client.Presenters
{
    public interface IThemTaiKhoanView
    {
        TaiKhoan GetTaiKhoanInput();
    }
    public class AddAccountPresenter
    {
        private readonly IAddAccountForm _view;
        private readonly AccountService _service;
        public AddAccountPresenter(IAddAccountForm view) 
        {
            _view = view;
            _service = new();
        }
        public async Task<bool> AddAccountAsync()
        {
            var tk = _view.GetTaiKhoanInput();
            var result = await _service.AddAccountsAsync(tk);
            return result.IsSuccessStatusCode;
        }
    }
}
