using MilkTea.Client.Models;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    public class CongThucService : ApiServiceBase
    {
        // POST api/congthuc
        public async Task<bool> AddCongThucAsync(CongThuc ct)
        {
            var response = await _http.PostAsJsonAsync("/api/congthuc", ct);
            return response.IsSuccessStatusCode;
        }
    }
}
