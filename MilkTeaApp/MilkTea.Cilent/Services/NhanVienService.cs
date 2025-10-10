using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public class NhanVienResponse
        {
            public int MaNV { get; set; }
        }

        public async Task<int> GetMaNVByTenAsync(string tenNV)
        {
            var encodedName = WebUtility.UrlEncode(tenNV);
            var response = await _http.GetAsync($"/api/nhanvien/manv-by-ten?tenNV={encodedName}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<NhanVienResponse>();
                return result?.MaNV ?? 0;
            }

            return 0;
        }

    }
}
