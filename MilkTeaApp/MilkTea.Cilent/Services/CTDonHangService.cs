using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    internal class CTDonHangService : ApiServiceBase
    {
        public async Task<List<ChiTietDonHang>> GetAllAsync(int maDH)
        {
            return await _http.GetFromJsonAsync<List<ChiTietDonHang>>($"/api/chitietdonhang");
        }
    }
}
