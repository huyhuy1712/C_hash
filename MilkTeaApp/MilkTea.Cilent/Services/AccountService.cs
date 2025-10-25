using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    public class AccountService : ApiServiceBase
    {
        // Lấy tất cả tài khoản
        public async Task<List<TaiKhoan>?> GetAccountsAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<TaiKhoan>>("/api/taikhoan");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[GetAccountsAsync] Error: {ex.Message}");
                return null;
            }
        }

        // Lấy theo ID
        public async Task<TaiKhoan?> GetAccountsByIdAsync(int maTK)
        {
            try
            {
                return await _http.GetFromJsonAsync<TaiKhoan>($"/api/taikhoan/{maTK}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[GetAccountsByIdAsync] Error: {ex.Message}");
                return null;
            }
        }

        // Thêm tài khoản
        public async Task<HttpResponseMessage?> AddAccountsAsync(TaiKhoan tk)
        {
            try
            {
                return await _http.PostAsJsonAsync("/api/taikhoan", tk);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AddAccountsAsync] Error: {ex.Message}");
                return null;
            }
        }

        // Cập nhật tài khoản
        public async Task<HttpResponseMessage?> UpdateAccountsAsync(TaiKhoan tk)
        {
            try
            {
                return await _http.PutAsJsonAsync("/api/taikhoan", tk);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[UpdateAccountsAsync] Error: {ex.Message}");
                return null;
            }
        }

        // Xóa tài khoản
        public async Task<HttpResponseMessage?> DeleteAccountsAsync(int maTK)
        {
            try
            {
                return await _http.DeleteAsync($"/api/taikhoan/{maTK}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[DeleteAccountsAsync] Error: {ex.Message}");
                return null;
            }
        }

        // Tìm kiếm
        public async Task<List<TaiKhoan>?> SearchAccountsAsync(string column, string value)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<TaiKhoan>>(
                    $"/api/taikhoan/search?column={column}&value={value}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SearchAccountsAsync] Error: {ex.Message}");
                return null;
            }
        }
    }
}
