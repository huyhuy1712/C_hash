using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MilkTea.Client.Models;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    public class TaiKhoanService : ApiServiceBase
    {
        public async Task<List<TaiKhoan>> GetAccountsAsync()
        {
            return await _http.GetFromJsonAsync<List<TaiKhoan>>("/api/taikhoan") ?? new List<TaiKhoan>();
        }

        public async Task<TaiKhoan?> GetTaiKhoanByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<TaiKhoan>($"/api/taikhoan/{id}");
        }
    }
}
