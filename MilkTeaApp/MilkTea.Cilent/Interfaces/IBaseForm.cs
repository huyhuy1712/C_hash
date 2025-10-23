using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using System.Windows.Forms;

namespace MilkTea.Client.Interfaces
{
    public interface IBaseForm
    {
        DataGridView Grid { get; }
        Label LblStatus { get; }
    }

    public interface IDanhSachQuyenForm
    {
        TextBox Txtb { get; }
    }
}