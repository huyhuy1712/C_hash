namespace MilkTea.Client.Interfaces
{

    public interface IViewAccountForm
    {
        Label LblId { get; }
        Label LblTaiKhoan { get; }
        Label LblHoTen { get; }
        Label LblQuyen { get; }
        Label LblTrangThai { get; }
        Label LblStatus { get; }
        PictureBox PicAnh { get; }
        // Presenter gọi hàm này để đổ danh sách tài khoản ra UI
        //void ShowTaiKhoanList(List<TaiKhoan> danhSach);

        // Thông báo lỗi, loading, v.v.
        //void ShowError(string message);
    }
}
