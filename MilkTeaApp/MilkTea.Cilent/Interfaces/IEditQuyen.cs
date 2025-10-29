namespace MilkTea.Client.Interfaces
{
    public interface IEditQuyen : IBaseForm
    {
        TextBox Txtb { get; }
        ErrorProvider Error { get; }
    }
}