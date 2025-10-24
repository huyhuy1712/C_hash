using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkTea.Client.Models;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    internal class CongThucService : ApiServiceBase
    {
        public async Task<List<Models.CongThuc>> GetAllCongThucAsync()
        {
            return await _http.GetFromJsonAsync<List<CongThuc>>("/api/congthuc");
        }
        public async Task<Models.CongThuc> GetCongThucByIdAsync(int maSP)
        {
            return await _http.GetFromJsonAsync<Models.CongThuc>($"/api/congthuc/{maSP}");
        }
    }
}
