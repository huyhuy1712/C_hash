using System.Windows.Forms;

namespace MilkTea.Client.Interfaces
{
    public interface IBaseForm
    {
        DataGridView Grid { get; }
        Label LblStatus { get; }
    }
    public interface IViewAccountForm
    {
        Label LblTaiKhoan { get; }
        Label LblHoTen { get; }
        Label LblQuyen { get; }
        Label LblTrangThai { get; }
        Label LblStatus { get; }
        PictureBox PicAnh { get; }
    }
}