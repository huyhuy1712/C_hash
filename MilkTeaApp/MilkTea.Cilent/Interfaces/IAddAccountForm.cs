using MilkTea.Client.Models;

namespace MilkTea.Client.Interfaces
{
    public interface IAddAccountForm
    {
        // Lấy dữ liệu người dùng nhập trên form
        TaiKhoan GetTaiKhoanInput();

        // Hiển thị kết quả thêm tài khoản
        //void ShowResult(string message, bool success);
    }
}