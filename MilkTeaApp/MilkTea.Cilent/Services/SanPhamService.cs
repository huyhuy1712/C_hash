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

        public async Task<SanPham> GetSanPhamsByIdAsync(int id)
        {
            var res = await _http.GetAsync($"/api/sanpham/{id}");
            res.EnsureSuccessStatusCode(); // Nếu 404 hoặc lỗi server => ném exception

            //  Đọc JSON trả về và convert sang đối tượng SanPham
            return await res.Content.ReadFromJsonAsync<SanPham>();
        }

        public async Task<int> AddSanPhamAsync(SanPham sp)
        {
            var response = await _http.PostAsJsonAsync("/api/sanpham", sp);

            if (response.IsSuccessStatusCode)
            {
                //  Đọc ID sản phẩm được trả về từ API
                return await response.Content.ReadFromJsonAsync<int>();
            }

            throw new Exception($"Lỗi khi thêm sản phẩm: {response.ReasonPhrase}");
        }


    }
}
