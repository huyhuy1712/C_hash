using MilkTea.Client.Controls;
using MilkTea.Client.Models;

namespace MilkTea.Client.Interfaces
{
    public interface IAddAccountForm
    {
        // Lấy dữ liệu người dùng nhập trên form
        TaiKhoan GetTaiKhoanInput();

        // Hiển thị kết quả thêm tài khoản
        //void ShowResult(string message, bool success);
        ComboBox CbQuyen { get; }
        ComboBox CbNhanVien { get; }
        void setQuyen(List<Quyen> q);
        ErrorProvider Error { get; }
        TextBox TxtbTenTaiKhoan { get; }
        TextBox TxtbMatKhau { get; }
        TextBox TxtbDuongDanAnh { get; }
        TextBox TxtbSoDienThoai { get; }
        TextBox TxtbTenNhanVien { get; }
        PictureBox Pic { get; }
    }
}