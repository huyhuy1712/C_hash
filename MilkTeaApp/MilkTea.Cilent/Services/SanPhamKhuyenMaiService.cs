using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using MilkTea.Client.Models;

namespace MilkTea.Client.Services
{
    internal class SanPhamKhuyenMaiService : ApiServiceBase
    {
        public async Task<bool> AddAsync(SanPhamKhuyenMai spkm)
        {
            var response = await _http.PostAsJsonAsync("/api/sanphamkhuyenmai", spkm);
            return response.IsSuccessStatusCode;
        }
    }
}