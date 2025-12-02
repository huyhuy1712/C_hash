using MilkTea.Client.Models;
using MilkTea.Server.Models;
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
        public async Task<List<ctdonhang_topping>> GetToppingByMaCTDHAsync(int maCTDH)
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<ctdonhang_topping>>(
                    $"/api/chitietdonhang/topping-by-mactdh/{maCTDH}");

                // Nếu API trả về null (không tìm thấy), trả về danh sách rỗng
                return result ?? new List<ctdonhang_topping>();
            }
            catch
            {
                // Bất kỳ lỗi nào khi gọi API cũng trả về danh sách rỗng
                return new List<ctdonhang_topping>();
            }
        }

    }
}
