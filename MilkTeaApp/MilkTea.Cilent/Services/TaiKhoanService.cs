using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    public class TaiKhoanService : ApiServiceBase
    {
        // Lấy danh sách tài khoản
        public async Task<List<TaiKhoan>> GetAccountsAsync()
        {
            return await _http.GetFromJsonAsync<List<TaiKhoan>>("/api/account");
        }
    }
}
