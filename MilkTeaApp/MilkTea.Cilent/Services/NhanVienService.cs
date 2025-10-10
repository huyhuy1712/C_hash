using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    public class NhanVienService : ApiServiceBase
    {
        public async Task<NhanVien?> GetByMaNV(int? maNV)
        {
            return await _http.GetFromJsonAsync<NhanVien>($"/api/nhanvien/searchID/{maNV}");
        }
        public async Task<List<NhanVien>> GetNhanVienAsync()
        {
            return await _http.GetFromJsonAsync<List<NhanVien>>("/api/nhanvien") ?? new List<NhanVien>();
        }

        // Lấy MaNV theo tên nhân viên
        public async Task<int?> GetMaNVByTenAsync(string tenNV)
        {
            // Gọi API: /api/nhanvien/manv-by-ten?tenNV={tenNV}
            var response = await _http.GetAsync($"/api/nhanvien/manv-by-ten?tenNV={tenNV}");

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, int>>();
            if (result != null && result.ContainsKey("MaNV"))
                return result["MaNV"];

            return null;
        }


    }
}
