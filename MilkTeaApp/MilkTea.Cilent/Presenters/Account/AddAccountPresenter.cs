using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters.Account
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
