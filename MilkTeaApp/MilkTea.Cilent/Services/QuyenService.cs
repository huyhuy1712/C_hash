using MilkTea.Client.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace MilkTea.Client.Services
{
    public class QuyenService : ApiServiceBase
    {
        public async Task<List<Quyen>> GetQuyensAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Quyen>>("/api/quyen")
                       ?? new List<Quyen>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[GetQuyensAsync] Error: {ex.Message}");
                return new List<Quyen>();
            }
        }

        public async Task<Quyen?> GetQuyenByIdAsync(int maQuyen)
        {
            try
            {
                return await _http.GetFromJsonAsync<Quyen>($"/api/quyen/{maQuyen}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[GetQuyenByIdAsync] Error: {ex.Message}");
                return null;
            }
        }

        public async Task UpdateQuyenAsync(Quyen quyen)
        {
            var response = await _http.PutAsJsonAsync("/api/quyen", quyen);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Cập nhật quyền không thành công");
        }

        public async Task<int> AddQuyenAsync(Quyen q)
        {
            var response = await _http.PostAsJsonAsync("/api/quyen", q);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<JsonElement>();
                return data.GetProperty("newId").GetInt32();
            }
            throw new Exception("Không thể thêm quyền!" + response);
        }
    }
}
