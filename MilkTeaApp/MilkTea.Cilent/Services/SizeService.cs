using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    using MilkTea.Client.Models;
    using System.Net.Http.Json;

    public class SizeService : ApiServiceBase
    {
        public async Task<List<Size>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<Size>>("/api/size");
        }

        public async Task<Size> GetSizeByTenAsync(string TenSize)
        {
            return await _http.GetFromJsonAsync<Size>($"/api/size/ten/{TenSize}");
        }
        public async Task<Size> GetSizeByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Size>($"/api/size/{id}");
        }
    }
}
