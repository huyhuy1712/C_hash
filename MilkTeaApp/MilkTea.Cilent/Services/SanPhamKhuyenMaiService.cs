using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Thêm service cho SanPhamKhuyenMai (tạo file SanPhamKhuyenMaiService.cs trong Services folder)
using System.Net.Http.Json;
using MilkTea.Client.Models;

namespace MilkTea.Client.Services
{
    internal class SanPhamKhuyenMaiService : ApiServiceBase
    {
        public async Task<bool> AddAsync(SanPhamKhuyenMai spkm)
        {
            var response = await _http.PostAsJsonAsync("/api/sanpham_khuyenmai", spkm);
            return response.IsSuccessStatusCode;
        }
    }
}