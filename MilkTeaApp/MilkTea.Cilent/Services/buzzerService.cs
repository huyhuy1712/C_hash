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
    }
}
