using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkTea.Client.Models;


namespace MilkTea.Client.Services
{
    using System.Net.Http.Json;

    internal class LoaiService : ApiServiceBase 
    {
        public async Task<List<Loai>> GetLoaisAsync()
        {
            return await _http.GetFromJsonAsync<List<Loai>>("/api/loai");
        }
    }
}
