﻿using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    internal class ChiTietPhieuNhapService : ApiServiceBase
    {
        public async Task<List<ChiTietPhieuNhap>> GetByMaPNAsync(int maPN)
        {
            return await _http.GetFromJsonAsync<List<ChiTietPhieuNhap>>($"api/chitietphieunhap/by-mapn?maPN={maPN}");
        }

        public async Task AddChiTietPhieuNhapAsync(ChiTietPhieuNhap ct)
        {
            var response = await _http.PostAsJsonAsync("/api/chitietphieunhap", ct);
            response.EnsureSuccessStatusCode();
        }
    }
}
