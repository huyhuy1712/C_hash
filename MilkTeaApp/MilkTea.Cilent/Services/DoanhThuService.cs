using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkTea.Client.Models;

namespace MilkTea.Client.Services
{
    using System.Net.Http.Json;
    internal class DoanhThuService : ApiServiceBase
    {
        public async Task<List<DoanhThu>> GetDoanhThusAsync()
        {
            return await _http.GetFromJsonAsync<List<DoanhThu>>("/api/doanhthu") ?? new List<DoanhThu>();
        }
        public async Task<bool> ThemDoanhThuAsync(DoanhThu dt)
        {
            var response = await _http.PostAsJsonAsync("/api/doanhthu", dt);
            return response.IsSuccessStatusCode;
        }
    }
}
