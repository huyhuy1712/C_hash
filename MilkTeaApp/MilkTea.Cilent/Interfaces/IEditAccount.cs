using MilkTea.Client.Models;

namespace MilkTea.Client.Interfaces
{
    public interface IEditAccount
    {
        // Lấy dữ liệu người dùng nhập trên form
        TaiKhoan GetTaiKhoanInput();

        // Hiển thị kết quả thêm tài khoản
        //void ShowResult(string message, bool success);
        ComboBox CbQuyen { get; }
        void setQuyen(List<Quyen> q);
        void setTaiKhoan(TaiKhoan tk);
        void setNhanVien(NhanVien nv);
        ErrorProvider Error { get; }
        TextBox TxtbTenTaiKhoan { get; }
        TextBox TxtbDuongDanAnh { get; }
        TextBox TxtbSoDienThoai { get; }
        TextBox TxtbTenNhanVien { get; }
        PictureBox Pic { get; }
    }
}
