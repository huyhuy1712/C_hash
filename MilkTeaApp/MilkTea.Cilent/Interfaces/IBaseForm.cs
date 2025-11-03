namespace MilkTea.Client.Interfaces
{
    public interface IBaseForm
    {
        DataGridView Grid { get; }
        Label LblStatus { get; }
    }

    public interface ITextBox
    {
        TextBox Txtb { get; }
    }
}