using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    public class TaiKhoanService : ApiServiceBase
    {
        // Lấy tất cả tài khoản
        public async Task<List<TaiKhoan>> GetAccountsAsync()
            => await _http.GetFromJsonAsync<List<TaiKhoan>>("/api/taikhoan");

        // Lấy theo ID
        public async Task<TaiKhoan?> GetAccountsByIdAsync(int maTK)
            => await _http.GetFromJsonAsync<TaiKhoan>($"/api/taikhoan/{maTK}");

        // Thêm tài khoản
        public async Task<HttpResponseMessage> AddAccountsAsync(TaiKhoan tk)
            => await _http.PostAsJsonAsync("/api/taikhoan", tk);

        // Cập nhật tài khoản
        public async Task<HttpResponseMessage> UpdateAccountsAsync(TaiKhoan tk)
            => await _http.PutAsJsonAsync("/api/taikhoan", tk);

        // Xóa tài khoản
        public async Task<HttpResponseMessage> DeleteAccountsAsync(int maTK)
            => await _http.DeleteAsync($"/api/taikhoan/{maTK}");

        // Tìm kiếm
        public async Task<List<TaiKhoan>> SearchAccountsAsync(string column, string value)
            => await _http.GetFromJsonAsync<List<TaiKhoan>>($"/api/taikhoan/search?column={column}&value={value}");
    }
}
