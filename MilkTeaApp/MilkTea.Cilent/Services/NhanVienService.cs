using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    internal class NhanVienService : ApiServiceBase
    {
        public async Task<NhanVien?> GetByMaNV(int? maNV)
        {
            return await _http.GetFromJsonAsync<NhanVien>($"/api/nhanvien/searchID/{maNV}");
        }
    }
}
