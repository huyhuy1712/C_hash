using MilkTea.Client.Controls;

namespace MilkTea.Client.Interfaces
{
    public interface IAddQuyen : IBaseForm
    {
        ErrorProvider Error { get; }
        RoundedTextBox Rtxtb { get; }
    }
}
