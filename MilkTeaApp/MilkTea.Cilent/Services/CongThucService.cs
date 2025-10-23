using MilkTea.Client.Models;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    public class CongThucService : ApiServiceBase
    {
        // POST api/congthuc
        public async Task<int> AddCongThucAsync(CongThuc ct)
        {
            var res = await _http.PostAsJsonAsync("/api/congthuc", ct);
            res.EnsureSuccessStatusCode();               // ném exception nếu 4xx/5xx

            var id = await res.Content.ReadFromJsonAsync<int>();
            return id;                                 
        }
    }



        //lớp để lưu công thức tạm khi thêm sản phẩm
        public static class RecipeCache
        {
            public static CongThuc CongThucHienTai { get; set; }
            public static List<ChiTietCongThuc> ChiTietCongThucs { get; set; } = new();

            public static Dictionary<int, int> NguyenLieuTam { get; set; } = new();

        }

}

