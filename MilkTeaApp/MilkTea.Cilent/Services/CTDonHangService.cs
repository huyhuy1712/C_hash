using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    internal class CTDonHangService : ApiServiceBase
    {
        public async Task<List<ChiTietDonHang>> GetAllAsync(int maDH)
        {
            return await _http.GetFromJsonAsync<List<ChiTietDonHang>>($"/api/chitietdonhang");
        }
        public async Task<List<ChiTietDonHang>> GetToppingByMaCTDHAsync(int maCTDH)
        {
            return await _http.GetFromJsonAsync<List<ChiTietDonHang>>($"/api/chitietdonhang/topping-by-mactdh/{maCTDH}");
        }
    }
}
