using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkTea.Client.Models;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
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
    }

}
