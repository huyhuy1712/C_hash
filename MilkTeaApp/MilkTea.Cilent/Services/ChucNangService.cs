using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkTea.Client.Models;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    public class ChucNangService : ApiServiceBase
    {
        public async Task<List<ChucNang>> GetChucNangsAsync()
        {
            return await _http.GetFromJsonAsync<List<ChucNang>>("/api/chucnang") ?? new List<ChucNang>();
        }
    }
}
