using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MilkTea.Client.Services
{
    internal class SanPhamKhuyenMaiService : ApiServiceBase
    {
        public async Task<bool> AddAsync(SanPhamKhuyenMai spkm)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("/api/sanphamkhuyenmai", spkm);
                var rawContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[SERVICE] POST Add: Status={response.StatusCode}, Body={rawContent}");

                if (response.IsSuccessStatusCode)
                {
                    // Parse JSON response để lấy RowsAffected nếu có (hỗ trợ cả Add và Edit)
                    // Controller trả { Message: "...", RowsAffected: x } hoặc chỉ message cho Add cũ
                    int rowsAffected = 1; // Default fallback cho trường hợp không có RowsAffected
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(rawContent))
                        {
                            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                            if (rawContent.TrimStart().StartsWith("{"))
                            {
                                var resultObj = JsonSerializer.Deserialize<JsonElement>(rawContent, options);
                                if (resultObj.TryGetProperty("RowsAffected", out var rowsProp))
                                {
                                    rowsAffected = rowsProp.GetInt32();
                                }
                                // Nếu không có RowsAffected, giữ default 1 (giả sử success = 1 row)
                            }
                        }
                    }
                    catch (JsonException jsonEx)
                    {
                        Debug.WriteLine($"[SERVICE] JSON Parse for RowsAffected failed: {jsonEx.Message} - Fallback to 1");
                        // Không throw, fallback OK
                    }

                    Debug.WriteLine($"[SERVICE] Add Success with {rowsAffected} row(s) affected");
                    return true; // Success nếu 200 OK, bất kể rows (0 nếu duplicate, nhưng vẫn "success")
                }
                else
                {
                    Debug.WriteLine($"[SERVICE] POST Add Error: {response.StatusCode} - {rawContent}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SERVICE] AddAsync Exception: {ex.Message}");
                return false;
            }
        }
        public async Task<List<SanPhamKhuyenMai>> GetByMaCTKhuyenMaiAsync(int maCTKhuyenMai)
        {
            try
            {
                string endpoint = $"/api/sanphamkhuyenmai/ctkhuyenmai/{maCTKhuyenMai}";
                var response = await _http.GetAsync(endpoint);

                // Luôn đọc raw JSON trước để tránh exception ở ReadFromJsonAsync
                var rawJson = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[SERVICE] Raw JSON for MaCT={maCTKhuyenMai}: {rawJson}"); // Log raw để debug

                if (response.IsSuccessStatusCode)
                {
                    if (string.IsNullOrWhiteSpace(rawJson) || rawJson.Trim() == "[]" || rawJson.Trim() == "null")
                    {
                        Debug.WriteLine($"[SERVICE] Empty/Null associations for MaCT={maCTKhuyenMai}");
                        return new List<SanPhamKhuyenMai>();
                    }

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    // Kiểm tra format JSON và deserialize tương ứng
                    string trimmedJson = rawJson.Trim();
                    if (trimmedJson.StartsWith("["))
                    {
                        // Array: Deserialize trực tiếp thành List
                        var associations = JsonSerializer.Deserialize<List<SanPhamKhuyenMai>>(trimmedJson, options);
                        Debug.WriteLine($"[SERVICE] Deserialized array: {associations?.Count ?? 0} items");
                        return associations ?? new List<SanPhamKhuyenMai>();
                    }
                    else if (trimmedJson.StartsWith("{"))
                    {
                        // Single object: Wrap thành List
                        var single = JsonSerializer.Deserialize<SanPhamKhuyenMai>(trimmedJson, options);
                        Debug.WriteLine($"[SERVICE] Deserialized single object: MaSP={single?.MaSP}");
                        return single != null ? new List<SanPhamKhuyenMai> { single } : new List<SanPhamKhuyenMai>();
                    }
                    else
                    {
                        // Invalid/Unexpected (e.g., string message): Log và return empty
                        Debug.WriteLine($"[SERVICE] Unexpected JSON format for MaCT={maCTKhuyenMai}: {trimmedJson.Substring(0, Math.Min(100, trimmedJson.Length))}...");
                        return new List<SanPhamKhuyenMai>();
                    }
                }
                else
                {
                    Debug.WriteLine($"[SERVICE] API Error {response.StatusCode} for MaCT={maCTKhuyenMai}: {rawJson}");
                    return new List<SanPhamKhuyenMai>();
                }
            }
            catch (JsonException jsonEx)
            {
                Debug.WriteLine($"[SERVICE] JsonException in GetByMaCTKhuyenMaiAsync: {jsonEx.Message}");
                // Không throw, return empty
                return new List<SanPhamKhuyenMai>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SERVICE] General Exception in GetByMaCTKhuyenMaiAsync: {ex.Message}");
                return new List<SanPhamKhuyenMai>();
            }
        }
    }
}