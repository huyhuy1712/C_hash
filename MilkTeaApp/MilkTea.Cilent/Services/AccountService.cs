using MilkTea.Client.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

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
        public async Task AddAccountsAsync(TaiKhoan tk)
        {
            var response = await _http.PostAsJsonAsync("/api/taikhoan", tk);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Thêm tài khoản không thành công");
        }

        // Cập nhật tài khoản
        public async Task UpdateAccountsAsync(TaiKhoan tk)
        {
            var response = await _http.PutAsJsonAsync("/api/taikhoan", tk);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Cập nhật tài khoản không thành công");
        }

        // Xóa tài khoản
        public async Task DeleteAccountsAsync(int maTK)
        {
            var response = await _http.DeleteAsync($"/api/taikhoan/{maTK}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Xóa tài khoản không thành công");
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

        // KIỂM TRA TÊN TÀI KHOẢN CÓ TỒN TẠI KHÔNG
        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            try
            {
                var res = await _http.GetFromJsonAsync<JsonElement>(
                    $"/api/taikhoan/check-username?username={username}");

                if (res.TryGetProperty("exists", out var existsProp))
                {
                    return existsProp.GetBoolean();
                }

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[CheckUsernameExistsAsync] Error: {ex.Message}");
                return false;
            }
        }
    }
}
