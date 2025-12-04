
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

        public async Task<string> CapNhatTrangThaiDonHangAsync(DonHang dh)
        {
            try
            {
                var response = await _http.PutAsJsonAsync("/api/donhang", dh);

                if (response.IsSuccessStatusCode)
                {
                    // Đọc phản hồi dạng JSON { Message = "..." }
                    var result = await response.Content.ReadFromJsonAsync<dynamic>();
                    string message = result?.Message ?? "Cập nhật trạng thái đơn hàng thành công!";
                    return message;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return $"Không thể cập nhật trạng thái đơn hàng. Chi tiết: {error}";
                }
            }
            catch (Exception ex)
            {
                return $"Lỗi khi cập nhật trạng thái đơn hàng: {ex.Message}";
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
        public async Task<List<DonHang>> GetAllDonHangAsync()
        {
            var response = await _http.GetAsync("/api/donhang");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<DonHang>>() ?? new List<DonHang>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Không thể lấy danh sách đơn hàng: {error}");
            }
        }
        public async Task<DonHang?> GetDonHangByIdAsync(int maDH)
        {
            var response = await _http.GetAsync($"/api/donhang/{maDH}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<DonHang>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Không thể lấy thông tin đơn hàng: {error}");
            }
        }
        public async Task<List<DonHang>> SearchAsync(string column, string value)
        {
            // Mã hóa URL để tránh lỗi khi có ký tự đặc biệt
            string encodedColumn = Uri.EscapeDataString(column);
            string encodedValue = Uri.EscapeDataString(value);

            var response = await _http.GetAsync($"/api/donhang/search?column={encodedColumn}&value={encodedValue}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<DonHang>>() ?? new List<DonHang>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Không thể tìm kiếm đơn hàng: {error}");
            }
        }

        public async Task<List<DonHang>> FilterByDateAsync(DateTime from, DateTime to)
        {
            string url = $"/api/donhang/filter-date?from={from:yyyy-MM-dd}&to={to:yyyy-MM-dd}";
            return await _http.GetFromJsonAsync<List<DonHang>>(url)
                   ?? new List<DonHang>();
        }




    }
}
