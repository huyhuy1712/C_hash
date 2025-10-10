using System.Windows.Forms;

namespace MilkTea.Client.Interfaces
{
    public interface IBaseForm
    {
        DataGridView Grid { get; }
        Label LblStatus { get; }
    }
}