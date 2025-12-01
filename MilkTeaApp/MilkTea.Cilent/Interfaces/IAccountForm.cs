
using MilkTea.Client.Models;

namespace MilkTea.Client.Interfaces
{
    public interface IAccountForm : IBaseForm
    {
        void setTaiKhoan(List<TaiKhoan> tk);
        void setQuyen(List<Quyen> q);
        ComboBox CbSearchFilter { get; }
    }
}
