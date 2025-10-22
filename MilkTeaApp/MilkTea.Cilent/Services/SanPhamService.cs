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

        // PUT: api/sanpham/5
        public async Task<bool> UpdateSanPhamAsync(SanPham sp)
        {
  
            string url = $"/api/sanpham/{sp.MaSP}";

            var response = await _http.PutAsJsonAsync(url, sp);

            // 3. Kiểm tra mã trạng thái trả về.
            if (response.IsSuccessStatusCode)
            {
                // API trả về 200 OK, cập nhật thành công.
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                // Xử lý lỗi 400 Bad Request (ví dụ: lỗi id không khớp, validation...)
                throw new Exception($"Lỗi 400 Bad Request: Dữ liệu sản phẩm không hợp lệ.");
            }
            else
            {
                // Xử lý các lỗi khác (ví dụ: 404 Not Found, 500 Internal Server Error...)
                throw new Exception($"Lỗi khi cập nhật sản phẩm {sp.MaSP}: {response.ReasonPhrase}");
            }
        }

        public async Task<List<SanPham>> SearchSanPhamAsync(string column, string value)
        {
            // Encode từ khóa để an toàn URL (ví dụ: "trà sữa" -> "%tr%C3%A0%20s%E1%BB%AFa")
            string encodedValue = Uri.EscapeDataString(value);

            var res = await _http.GetAsync($"/api/sanpham/search?column={column}&value={encodedValue}");
            res.EnsureSuccessStatusCode(); // Nếu lỗi 400 hoặc 500 => ném exception

            // Đọc danh sách JSON trả về từ API
            var list = await res.Content.ReadFromJsonAsync<List<SanPham>>();
            return list ?? new List<SanPham>();
        }


        public async Task<bool> DeleteSanPhamAsync(int id)
        {
            var res = await _http.DeleteAsync($"/api/sanpham/{id}");
            if (res.IsSuccessStatusCode)
            {
                // Xóa (hoặc đổi trạng thái) thành công
                return true;
            }

            // Nếu có lỗi, có thể đọc thêm message để hiển thị
            var error = await res.Content.ReadAsStringAsync();
            Console.WriteLine($"Lỗi khi xóa sản phẩm: {error}");
            return false;
        }



    }
}
