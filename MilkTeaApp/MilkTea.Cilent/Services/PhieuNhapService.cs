using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkTea.Client.Models;

namespace MilkTea.Client.Services
{
    using System.Net.Http.Json;

    internal class PhieuNhapService : ApiServiceBase
    {
        public async Task<List<PhieuNhap>> GetPhieuNhapsAsync()
        {
            return await _http.GetFromJsonAsync<List<PhieuNhap>>("/api/phieunhap"); 
        }
        public async Task<List<PhieuNhap>> SearchAsync(string column, string value)
        {
            var query = $"/api/phieunhap/search?column={column}&value={Uri.EscapeDataString(value)}";
            return await _http.GetFromJsonAsync<List<PhieuNhap>>(query);
        }

        public async Task<int> AddPhieuNhapAsync(PhieuNhap pn)
        {
            var response = await _http.PostAsJsonAsync("/api/phieunhap", pn);
            if (response.IsSuccessStatusCode)
            {
                var addedPn = await response.Content.ReadFromJsonAsync<PhieuNhap>();
                return addedPn.MaPN;
            }
            throw new Exception("Không thể thêm phiếu nhập.");
        }
        public async Task<bool> SoftDeleteAsync(int maPN)
        {
            var response = await _http.DeleteAsync($"/api/phieunhap/{maPN}/soft");
            return response.IsSuccessStatusCode;
        }

    }
}
