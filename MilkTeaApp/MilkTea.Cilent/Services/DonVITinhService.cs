using MilkTea.Client.Models;
using MilkTea.Server.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows; // để dùng MessageBox (nếu bạn đang dùng WinForms/WPF)

namespace MilkTea.Client.Services
{
    public class DonViTinhService : ApiServiceBase
    {
        // 1. Lấy toàn bộ đơn vị tính
        public async Task<List<DonViTinh>> GetAllAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<DonViTinh>>("/api/donvitinh")
                       ?? new List<DonViTinh>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách đơn vị tính: {ex.Message}");
                return new List<DonViTinh>();
            }
        }

        // 2. Lấy đơn vị tính theo MaDVT
        public async Task<DonViTinh?> GetByIdAsync(int maDVT)
        {
            try
            {
                return await _http.GetFromJsonAsync<DonViTinh>($"/api/donvitinh/{maDVT}");
            }
            catch (HttpRequestException)
            {
                return null; // không tìm thấy hoặc lỗi mạng
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy đơn vị tính: {ex.Message}");
                return null;
            }
        }

        // 3. Thêm mới đơn vị tính
        public async Task<DonViTinh?> AddAsync(DonViTinh dvt)
        {
            if (string.IsNullOrWhiteSpace(dvt.TenDVT))
            {
                MessageBox.Show("Tên đơn vị tính không được để trống!");
                return null;
            }

            try
            {
                var response = await _http.PostAsJsonAsync("/api/donvitinh", dvt);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<DonViTinh>();
                }

                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Thêm thất bại: {response.StatusCode}\n{error}");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn vị tính: {ex.Message}");
                return null;
            }
        }

        // 4. Cập nhật đơn vị tính
        public async Task<bool> UpdateAsync(DonViTinh dvt)
        {
            if (dvt.MaDVT <= 0)
            {
                MessageBox.Show("Mã đơn vị tính không hợp lệ!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(dvt.TenDVT))
            {
                MessageBox.Show("Tên đơn vị tính không được để trống!");
                return false;
            }

            try
            {
                var response = await _http.PutAsJsonAsync("/api/donvitinh", dvt);
                if (response.IsSuccessStatusCode)
                    return true;

                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Cập nhật thất bại: {response.StatusCode}\n{error}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật đơn vị tính: {ex.Message}");
                return false;
            }
        }

        // 5. Xóa đơn vị tính (xóa cứng)
        public async Task<bool> DeleteAsync(int maDVT)
        {
            if (maDVT <= 0)
            {
                MessageBox.Show("Mã đơn vị tính không hợp lệ!");
                return false;
            }

            try
            {
                var response = await _http.DeleteAsync($"/api/donvitinh/{maDVT}");
                if (response.IsSuccessStatusCode)
                    return true;

                // Nếu bị lỗi do ràng buộc khóa ngoại (nguyên liệu đang dùng đơn vị này)
                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    MessageBox.Show("Không thể xóa vì đơn vị tính đang được sử dụng!");
                    return false;
                }

                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Xóa thất bại: {response.StatusCode}\n{error}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đơn vị tính: {ex.Message}");
                return false;
            }
        }
    }
}