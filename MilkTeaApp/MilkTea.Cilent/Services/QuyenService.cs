using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    public class QuyenService : ApiServiceBase
    {
        public async Task<List<Quyen>> GetQuyensAsync()
        {
            return await _http.GetFromJsonAsync<List<Quyen>>("/api/quyen") ?? new List<Quyen>();
        }

    }
}
