using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MilkTea.Client.Services
{
    using System.Net;
    using System.Net.Http.Json;

    internal class buzzerService : ApiServiceBase
    {
        public async Task<List<Buzzer>> GetBuzzerByTrangThai(int trangthai)
        {
            return await _http.GetFromJsonAsync<List<Buzzer>>($"/api/buzzer/trangthai/{trangthai}");
        }

        // Lấy MaMay theo sohieu
        public class BuzzerResponse
        {
            public int MaBuzzer { get; set; }
        }

        public async Task<int?> GetMaMayBySoHieuAsync(string soHieu)
        {
            var encodedName = WebUtility.UrlEncode(soHieu);

            // Gọi API
            var response = await _http.GetAsync($"/api/buzzer/mamay-by-sohieu?sohieu={encodedName}");

            // Nếu không thành công => trả về null
            if (!response.IsSuccessStatusCode)
                return null;

            // Parse JSON trả về từ API
            var result = await response.Content.ReadFromJsonAsync<BuzzerResponse>();

            // Nếu có dữ liệu thì trả về MaMay, ngược lại null
            return result?.MaBuzzer;
        }


        public async Task<int> UpdateTrangThaiAsync(string sohieu, int trangthai)
        {
            var url = $"/api/buzzer/update/trangthai/{sohieu}/{trangthai}";

            // PutAsJsonAsync phải có body -> gửi object rỗng
            var response = await _http.PutAsJsonAsync(url, new { });

            if (response.IsSuccessStatusCode)
                return 1;

            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Không thể cập nhật trạng thái: {error}");
        }
        public async Task<Buzzer?> GetByMaMayAsync(int maMay)
        {
            try
            {
                var buzzer = await _http.GetFromJsonAsync<Buzzer>($"/api/buzzer/buzzer-by-mamay/{maMay}");
                return buzzer;
            }
            catch (Exception ex)
            {
                // Có thể in ra dialog hoặc ghi log
                Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                return null;
            }
        }

    }
}
