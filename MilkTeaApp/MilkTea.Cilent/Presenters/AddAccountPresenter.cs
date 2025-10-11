using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public interface IThemTaiKhoanView
    {
        TaiKhoan GetTaiKhoanInput();
    }
    public class AddAccountPresenter : IAddAccountForm
    {
        private readonly IAddAccountForm _view;
        private readonly TaiKhoanService _service;
        public AddAccountPresenter(IAddAccountForm view) 
        {
            _view = view;
            _service = new TaiKhoanService();
        }

        public async Task<bool> AddAccountAsync()
        {
            var tk = _view.GetTaiKhoanInput();
            var result = await _service.AddAccountsAsync(tk);
            return result.IsSuccessStatusCode;
        }
    }
}
