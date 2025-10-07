using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    internal class NguyenLieuService : ApiServiceBase
    {
        public async Task<List<NguyenLieu>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<NguyenLieu>>("/api/nguyenlieu");
        }

    }
}
