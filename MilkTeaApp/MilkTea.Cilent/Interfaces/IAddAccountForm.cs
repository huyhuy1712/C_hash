using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
