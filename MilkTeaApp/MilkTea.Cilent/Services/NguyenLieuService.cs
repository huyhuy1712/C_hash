using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    internal class NguyenLieuService : ApiServiceBase
    {
        public async Task<List<NguyenLieu>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<NguyenLieu>>("/api/nguyenlieu");
        }

        public async Task<NguyenLieu> GetById(int maNL)
        {
            return await _http.GetFromJsonAsync<NguyenLieu>($"api/nguyenlieu/search/byid?maNL={maNL}");
        }

        public async Task<List<NguyenLieu>> GetByTen(string ten)
        {
            return await _http.GetFromJsonAsync<List<NguyenLieu>>($"api/nguyenlieu/search?ten={ten}");
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
        public async Task<List<NguyenLieu>> GetNguyenLieusAsync()
        {
            var response = await _http.GetAsync("/api/nguyenlieu");
            if (!response.IsSuccessStatusCode) return new List<NguyenLieu>();
            return await response.Content.ReadFromJsonAsync<List<NguyenLieu>>();
        }
        public async Task<bool> AddAsync(NguyenLieu nl)
        {
            var response = await _http.PostAsJsonAsync("/api/nguyenlieu", nl);
            return response.IsSuccessStatusCode;
        }
        public async Task<NguyenLieu> GetByIdAsync(int maNL)
        {
            var response = await _http.GetAsync($"/api/nguyenlieu/{maNL}");
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<NguyenLieu>();
        }

        public async Task<int> UpdateAsync(NguyenLieu nl)
        {
            try
            {
             
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                };

                // 📨 Gửi PUT request đúng chuẩn REST: /api/nguyenlieu/{id}
                var response = await _http.PutAsJsonAsync($"/api/nguyenlieu/{nl.MaNL}", nl, options);

                // 🧾 Ghi log phản hồi từ server
                Console.WriteLine($"[NguyenLieuService] PUT /api/nguyenlieu/{nl.MaNL} → {response.StatusCode}");

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[Response Body] {responseBody}");

                // ✅ Thành công → đọc lại entity trả về
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var updatedNl = JsonSerializer.Deserialize<NguyenLieu>(responseBody, options);
                        return updatedNl?.MaNL ?? nl.MaNL;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Deserialize Error] {ex.Message}");
                        // Vẫn trả về MaNL cũ vì backend đã OK
                        return nl.MaNL;
                    }
                }

                // ❌ Thất bại → log chi tiết
                Console.WriteLine($"[NguyenLieuService] Update thất bại - Status: {response.StatusCode}, Body: {responseBody}");
                return 0;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[HTTP Error] {ex.Message}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Service Update Error] {ex.Message}");
                return 0;
            }
        }
       

        public async Task<bool> SoftDeleteAsync(int maNL)
        {
            try
            {
                var response = await _http.DeleteAsync($"/api/nguyenlieu/{maNL}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SoftDeleteAsync failed: {ex.Message}");
                return false;
            }
        }

        public async Task<NguyenLieu?> GetByIdAsyncS(int maNL)
        {
            return await _http.GetFromJsonAsync<NguyenLieu>($"/api/nguyenlieu/search/byid?maNL={maNL}");
        }

        public async Task<bool> CapNhatGiaBanMoiNhatAsync(int maNL, decimal giaNhapMoi)
        {
            try
            {
                var nl = await GetByIdAsyncS(maNL);
                if (nl == null)
                {
                    Console.WriteLine($"Không tìm thấy nguyên liệu MaNL = {maNL}");
                    return false;
                }

                nl.GiaBan = giaNhapMoi;

                var response = await _http.PutAsJsonAsync($"/api/nguyenlieu/{maNL}", nl);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Cập nhật GiaBan thành công cho MaNL = {maNL}: {giaNhapMoi}");
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Cập nhật GiaBan thất bại: {response.StatusCode} - {error}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật GiaBan: {ex.Message}");
                return false;
            }
        }

    }
}
