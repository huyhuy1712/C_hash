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
    }
}
