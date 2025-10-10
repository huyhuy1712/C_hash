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

    public class CTCongThucService : ApiServiceBase
    {
        public async Task<List<CTCongThucSP>> GetChiTietCongThucTheoSPAsync(int maSP)
        {
            return await _http.GetFromJsonAsync<List<CTCongThucSP>>($"/api/chitietcongthuc/masp/{maSP}");

        }
    }
}
