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
    }
}
