using Microsoft.VisualBasic.ApplicationServices;
using MilkTea.Client.Models;
using System.Net.Http.Json;

namespace MilkTea.Client.Services
{
    public class AuthService : ApiServiceBase
    {
        private readonly QuyenService _quyenService = new();
        private readonly ChucNangService _chucNangService = new();

        // Đăng nhập và load quyền động
        public void StoreUserSession(TaiKhoan _taiKhoan)
        {

            Session.CurrentUser = _taiKhoan;

            // Lấy quyền theo MaQuyen
            var quyen = _quyenService.GetQuyenByIdAsync(_taiKhoan.MaQuyen);

            // Lấy danh sách chức năng được phép
            var chucNangs = _chucNangService.GetChucNangsByMaQuyenAsync(_taiKhoan.MaQuyen);
            Session.AllowedFunctions = chucNangs;
        }

        public async Task<bool> HasPermissionAsync(string tenChucNang)
        {
            var allowedFunctions = await _chucNangService.GetChucNangsByMaQuyenAsync(Session.CurrentUser.MaQuyen);
            return allowedFunctions.Any(cn => cn.TenChucNang == tenChucNang);
        }
    }
}