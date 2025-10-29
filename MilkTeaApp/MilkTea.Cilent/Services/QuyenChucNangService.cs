using MilkTea.Client.Models;
using System;
using System.Diagnostics;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    public class QuyenChucNangService : ApiServiceBase
    {
        public async Task DeleteAllQuyenChucNangAsync(int maQuyen)
        {
            var response = await _http.DeleteAsync($"/api/quyenchucnang/{maQuyen}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Xoá quyền chức năng không thành công" + response.ToString);
        }
        public async Task AddQuyenChucNangAsync(Quyen_ChucNang q)
        {
            var response = await _http.PostAsJsonAsync($"/api/quyenchucnang", q);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Thêm quyền chức năng không thành công" + response.ToString);
        }

        public async Task<List<Quyen_ChucNang>?> GetQuyenChucNangById(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Quyen_ChucNang>>($"/api/quyenchucnang/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetQuyenChucNangById] Error: {ex}");
            }
        }
    }
}