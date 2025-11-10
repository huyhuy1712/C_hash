using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MilkTea.Client.Models;

namespace MilkTea.Client.Services
{
    public class CTKhuyenMaiService : ApiServiceBase
    {
        //  Lấy tất cả khuyến mãi
        public async Task<List<CTKhuyenMai>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<CTKhuyenMai>>("/api/ctkhuyenmai");
        }

        //  Lấy khuyến mãi theo mã sản phẩm
        public async Task<CTKhuyenMai?> GetByMaSP(int? MaSP)
        {
            try
            {
                // Gọi đúng endpoint API khuyến mãi theo sản phẩm
                var response = await _http.GetAsync($"/api/sanphamkhuyenmai/ctkhuyenmai/{MaSP}");

                // Nếu không tìm thấy (404) → không có khuyến mãi → return null
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;

                // Ném lỗi nếu mã trạng thái không thành công khác
                response.EnsureSuccessStatusCode();

                // Đọc nội dung JSON
                var data = await response.Content.ReadFromJsonAsync<CTKhuyenMai>();
                return data;
            }
            catch
            {
                // Nếu lỗi parse JSON hoặc body rỗng → trả về null thay vì crash
                return null;
            }
        }

        //  Lấy khuyến mãi theo ID khuyến mãi
        public async Task<CTKhuyenMai?> GetCTKhuyenMaiByIdAsync(int id)
        {
            var list = await _http.GetFromJsonAsync<List<CTKhuyenMai>>(
                $"/api/ctkhuyenmai/search?column=MaCTKhuyenMai&value={id}"
            );

            // Trả về phần tử đầu tiên hoặc null
            return list?.FirstOrDefault();
        }

        //  Thêm mới khuyến mãi và lấy ID khuyến mãi vừa tạo
        public async Task<int> AddCTKhuyenMaiAsync(CTKhuyenMai km)
        {
            var response = await _http.PostAsJsonAsync("/api/ctkhuyenmai", km);
            if (response.IsSuccessStatusCode)
            {
                var addedKm = await response.Content.ReadFromJsonAsync<CTKhuyenMai>();
                return addedKm?.MaCTKhuyenMai ?? 0;
            }
            throw new Exception("Không thể thêm chương trình khuyến mãi!" + response);
        }
    }
}
