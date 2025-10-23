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
    }
}
