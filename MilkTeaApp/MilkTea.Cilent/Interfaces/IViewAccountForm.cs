using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Interfaces
{

    public interface IViewAccountForm
    {
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
