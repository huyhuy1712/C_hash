using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    internal class ChiTietPhieuNhapService : ApiServiceBase
    {
        public async Task<List<ChiTietPhieuNhap>> GetByMaPNAsync(int maPN)
        {
            return await _http.GetFromJsonAsync<List<ChiTietPhieuNhap>>($"api/chitietphieunhap/by-mapn?maPN={maPN}");
        }

        public async Task AddChiTietPhieuNhapAsync(ChiTietPhieuNhap ct)
        {
            var response = await _http.PostAsJsonAsync("/api/chitietphieunhap", ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ChiTietPhieuNhap>> GetByMaNLAsync(int maNL)
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<ChiTietPhieuNhap>>(
                    $"/api/chitietphieunhap/by-manl?maNL={maNL}");

                return result ?? new List<ChiTietPhieuNhap>();
            }
            catch
            {
                return new List<ChiTietPhieuNhap>();
            }
        }

        public async Task DeleteByMaPNAsync(int maPN)
        {
            await _http.DeleteAsync($"/api/chitietphieunhap/delete-by-mapn/{maPN}");
        }
    }
}
