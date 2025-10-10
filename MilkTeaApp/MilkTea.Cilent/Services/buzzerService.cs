using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkTea.Client.Models;


namespace MilkTea.Client.Services
{
    using System.Net.Http.Json;

    internal class buzzerService : ApiServiceBase
    {
        public async Task<List<Buzzer>> GetBuzzerByTrangThai(int trangthai)
        {
            return await _http.GetFromJsonAsync<List<Buzzer>>($"/api/buzzer/trangthai/{trangthai}");
        }

        // Lấy MaMay theo sohieu
        public async Task<int?> GetMaMayBySoHieuAsync(string sohieu)
        {
            var response = await _http.GetAsync($"/api/buzzer/mamay-by-sohieu?sohieu={sohieu}");

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, int>>();
            if (result != null && result.ContainsKey("MaMay"))
                return result["MaMay"];

            return null;
        }
    }
}
