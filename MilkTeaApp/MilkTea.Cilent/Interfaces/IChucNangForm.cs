using System.Windows.Forms;

namespace MilkTea.Client.Interfaces
{
    public interface IChucNangForm
    {
        DataGridView GridChucNang { get; }
        Label LblStatus { get; }
    }
}