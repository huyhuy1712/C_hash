using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
                var response = await _http.GetAsync($"/api/sanphamkhuyenmai/sanpham/{MaSP}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;

                if (!response.IsSuccessStatusCode)
                {
                    var rawErr = await response.Content.ReadAsStringAsync();
                    // Log or debug if needed
                    return null;
                }

                var raw = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(raw) || raw.Trim() == "null" || raw.Trim() == "[]")
                    return null;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var trimmed = raw.Trim();

                try
                {
                    if (trimmed.StartsWith("["))
                    {
                        var list = JsonSerializer.Deserialize<List<CTKhuyenMai>>(trimmed, options);
                        return list?.FirstOrDefault();
                    }
                    else if (trimmed.StartsWith("{"))
                    {
                        // Try direct deserialize
                        var direct = JsonSerializer.Deserialize<CTKhuyenMai>(trimmed, options);
                        if (direct != null) return direct;

                        // If wrapper object, try to find nested property that contains the CTKhuyenMai
                        var root = JsonSerializer.Deserialize<JsonElement>(trimmed, options);
                        foreach (var prop in root.EnumerateObject())
                        {
                            if (prop.Value.ValueKind == JsonValueKind.Object)
                            {
                                try
                                {
                                    var nested = JsonSerializer.Deserialize<CTKhuyenMai>(prop.Value.GetRawText(), options);
                                    if (nested != null) return nested;
                                }
                                catch { /* ignore and continue */ }
                            }
                            else if (prop.Value.ValueKind == JsonValueKind.Array)
                            {
                                try
                                {
                                    var arr = JsonSerializer.Deserialize<List<CTKhuyenMai>>(prop.Value.GetRawText(), options);
                                    if (arr != null && arr.Count > 0) return arr.First();
                                }
                                catch { /* ignore and continue */ }
                            }
                        }
                    }
                }
                catch (JsonException) { /* fall through to return null */ }

                return null;
            }
            catch
            {
                return null;
            }
        }

        //  Lấy khuyến mãi theo ID khuyến mãi (sử dụng endpoint /api/ctkhuyenmai/{id})
        public async Task<CTKhuyenMai?> GetByIdRouteAsync(int id)
        {
            try
            {
                var response = await _http.GetAsync($"/api/ctkhuyenmai/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CTKhuyenMai>();
            }
            catch
            {
                return null;
            }
        }

        //  Lấy khuyến mãi theo ID (hiện dùng search endpoint)
        public async Task<CTKhuyenMai?> GetCTKhuyenMaiByIdAsync(int id)
        {
            var list = await _http.GetFromJsonAsync<List<CTKhuyenMai>>(
                $"/api/ctkhuyenmai/search?column=MaCTKhuyenMai&value={id}"
            );

            return list?.FirstOrDefault();
        }

        //  Lấy khuyến mãi và danh sách liên kết sản phẩm (nếu cần)
        public async Task<(CTKhuyenMai? Km, List<SanPhamKhuyenMai> Associations)> GetDiscountWithAssociationsAsync(int maCTKhuyenMai)
        {
            var km = await GetByIdRouteAsync(maCTKhuyenMai) ?? await GetCTKhuyenMaiByIdAsync(maCTKhuyenMai);
            var associations = new List<SanPhamKhuyenMai>();

            if (km != null)
            {
                var spkmService = new SanPhamKhuyenMaiService();
                associations = await spkmService.GetByMaCTKhuyenMaiAsync(maCTKhuyenMai);
            }

            return (km, associations);
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
