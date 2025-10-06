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

    public class CTKhuyenMaiService : ApiServiceBase
    {
        public async Task<List<CTKhuyenMai>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<CTKhuyenMai>>("/api/ctkhuyenmai");
        }

        public async Task<CTKhuyenMai> GetByMaSP(int? MaSP)
        {
            return await _http.GetFromJsonAsync<CTKhuyenMai>($"/api/sanphamkhuyenmai/ctkhuyenmai/{MaSP}");
        }
    }

}
