using System.Windows.Forms;

namespace MilkTea.Client.Interfaces
{
    public interface IAccountForm
    {
        DataGridView GridTaiKhoan { get; }
        Label LblStatus { get; }
    }

    public interface IBaseForm
    {
        DataGridView Grid { get; }
        Label StatusLabel { get; }
    }
}