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
                return result.MaNV;
            }
            return 0;
        }

        // lay nhan vien by matk
        public async Task<NhanVien?> GetByMaTK(int maTK)
        {
            var response = await _http.GetAsync($"/api/nhanvien/nhanvien-by-matk/{maTK}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // không tìm thấy nhân viên
            }

            response.EnsureSuccessStatusCode(); // ném exception nếu lỗi khác 500+
            return await response.Content.ReadFromJsonAsync<NhanVien>();
        }

        // Them Nhan Vien Moi
        public async Task<(bool success, string message)> AddNhanVienAsync(NhanVien nv)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/nhanvien", nv);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<dynamic>();
                    return (true, result?.Message ?? "");
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    return (false, err);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        // Xóa nhân viên theo MaTK
        public async Task<(bool success, string message)> DeleteByMaTKAsync(int maTK)
        {
            try
            {
                var response = await _http.DeleteAsync($"/api/nhanvien/delete-by-matk/{maTK}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<dynamic>();
                    return (true, result?.Message ?? "");
                }

                var err = await response.Content.ReadAsStringAsync();
                return (false, err);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
