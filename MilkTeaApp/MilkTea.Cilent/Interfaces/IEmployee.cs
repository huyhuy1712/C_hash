using MilkTea.Client.Models;

namespace MilkTea.Client.Interfaces
{
    public interface IEmployee : IBaseForm
    {
        void setTaiKhoan(List<TaiKhoan> tk);
        void setNhanVien(List<NhanVien> nv);
    }
}
