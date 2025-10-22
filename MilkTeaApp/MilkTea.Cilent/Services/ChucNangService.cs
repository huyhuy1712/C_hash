using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MilkTea.Client.Models;

namespace MilkTea.Client.Services
{
    public class ChucNangService : ApiServiceBase
    {
        public async Task<List<ChucNang>> GetChucNangsAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<ChucNang>>("/api/chucnang")
                       ?? new List<ChucNang>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[GetChucNangsAsync] Error: {ex.Message}");
                return new List<ChucNang>();
            }
        }

        public async Task<List<ChucNang>> GetChucNangsByMaQuyenAsync(int maQuyen)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<ChucNang>>($"/api/chucnang/{maQuyen}")
                       ?? new List<ChucNang>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[GetChucNangsByMaQuyenAsync] Error: {ex.Message}");
                return new List<ChucNang>();
            }
        }
    }
}
