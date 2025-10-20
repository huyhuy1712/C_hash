using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    using System.Collections;
    using System.Net.Http.Json;

    public class SanPhamService : ApiServiceBase
    {
        public async Task<List<SanPham>> GetSanPhamsAsync()
        {
            return await _http.GetFromJsonAsync<List<SanPham>>("/api/sanpham");
        }

        public async Task<SanPham?> GetSanPhamsByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<SanPham>($"/api/sanpham/{id}");
        }

        public async Task<bool> AddSanPhamAysync(SanPham sp)
        {
            var response = await _http.PostAsJsonAsync("/api/sanpham", sp);
            return response.IsSuccessStatusCode;
        }
    }
}
