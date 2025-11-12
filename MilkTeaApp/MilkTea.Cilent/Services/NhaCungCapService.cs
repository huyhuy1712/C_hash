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
    public class NhaCungCapService : ApiServiceBase
    {

        // Lấy danh sách tất cả nhà cung cấp
        public async Task<List<NhaCungCap>> GetNhaCungCapAsync()
        {
            return await _http.GetFromJsonAsync<List<NhaCungCap>>("/api/nhacungcap");
        }

        // Lấy thông tin nhà cung cấp theo mã
        public async Task<NhaCungCap?> GetByMaNCC(int? maNCC)
        {
            return await _http.GetFromJsonAsync<NhaCungCap>($"/api/nhacungcap/searchID/{maNCC}");
        }

        // Thêm nhà cung cấp mới
        public async Task<NhaCungCap?> AddAsync(NhaCungCap ncc)
        {
            if (ncc == null) throw new ArgumentNullException(nameof(ncc));
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
                throw new ArgumentException("Tên nhà cung cấp không được để trống.");

            try
            {
                var response = await _http.PostAsJsonAsync("/api/nhacungcap", ncc);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<NhaCungCap>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Thêm thất bại: {response.StatusCode} - {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Lỗi kết nối khi thêm nhà cung cấp.", ex);
            }
        }

        // Lấy MaNCC theo tên nhà cung cấp
        public class NhaCungCapResponse
        {
            public int MaNCC { get; set; }
        }

        public async Task<int> GetMaNCCByTenAsync(string tenNCC)
        {
            var encodedName = WebUtility.UrlEncode(tenNCC);
            var response = await _http.GetAsync($"/api/nhacungcap/mancc-by-ten?tenNCC={encodedName}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<NhaCungCapResponse>();
                return result.MaNCC;
            }
            return 0;
        }

        // Thêm vào class NhaCungCapService
        public async Task<bool> UpdateAsync(NhaCungCap ncc)
        {
            if (ncc == null) throw new ArgumentNullException(nameof(ncc));
            if (ncc.MaNCC <= 0) throw new ArgumentException("Mã NCC không hợp lệ.");
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
                throw new ArgumentException("Tên nhà cung cấp không được để trống.");

            try
            {
                var response = await _http.PutAsJsonAsync("/api/nhacungcap", ncc);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Lỗi kết nối khi cập nhật.", ex);
            }
        }

        public async Task<bool> SoftDeleteAsync(int maNCC)
        {
            var response = await _http.DeleteAsync($"/api/nhacungcap/{maNCC}/soft");
            return response.IsSuccessStatusCode;
        }
    }
}
