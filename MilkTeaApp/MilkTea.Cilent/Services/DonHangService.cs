using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkTea.Client.Models;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    using System.Net.Http.Json;

    public class DonHangService : ApiServiceBase
    {
        public async Task<int> AddDonHangAsync(DonHang donHang)
        {
            var response = await _http.PostAsJsonAsync("/api/donhang", donHang);

            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Không thể thêm đơn hàng: {error}");
            }
        }

        //thêm chi tết đơn hàng
        public async Task<string> AddChiTietDonHangAsync(ChiTietDonHang CTDonHang)
        {
            var response = await _http.PostAsJsonAsync("/api/chitietdonhang", CTDonHang);

            if (response.IsSuccessStatusCode)
            {
                return "Thêm chi tiết đơn hàng thành công!";
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Không thể thêm chi tiết đơn hàng: {error}");
            }
        }

    }
}
