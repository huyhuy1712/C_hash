using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    internal class NguyenLieuService : ApiServiceBase
    {
        public async Task<List<NguyenLieu>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<NguyenLieu>>("/api/nguyenlieu");
        }

        public async Task<bool> TruNguyenLieuAsync(int maNL, int soLuong)
        {
            var response = await _http.PutAsync($"/api/nguyenlieu/tru/{maNL}/{soLuong}", null);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CongNguyenLieuAsync(int maNL, int soLuong)
        {
            var response = await _http.PutAsync($"/api/nguyenlieu/cong/{maNL}/{soLuong}", null);
            return response.IsSuccessStatusCode;
        }

        // Hàm cập nhật thay đổi số lượng nguyên liệu (âm: trừ, dương: cộng)
        public async Task<bool> CapNhatNguyenLieuAsync(int maNL, int soLuongThayDoi)
        {
            var response = await _http.PutAsJsonAsync($"/api/nguyenlieu/capnhatsoluong/{maNL}", soLuongThayDoi);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CapNhatNguyenLieuTheoToppingAsync(int maNL, decimal gram)
        {
            try
            {
                // Gọi API PUT /api/nguyenlieu/topping
                var response = await _http.PutAsJsonAsync("/api/nguyenlieu/topping", new
                {
                    MaNL = maNL,
                    Gram = gram
                });

                if (response.IsSuccessStatusCode)
                    return true;

                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[CapNhatNguyenLieuTheoToppingAsync] Lỗi: {error}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật topping: {ex.Message}");
                return false;
            }
        }

    }
}
