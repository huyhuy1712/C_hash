using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

        public async Task<Quyen?> GetQuyenByIdAsync(int? maQuyen)
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
    }
}
