namespace MilkTea.Client.Models
{
    public static class Session
    {
        public static TaiKhoan CurrentUser { get; set; }
        public static List<ChucNang> AllowedFunctions { get; set; } = new List<ChucNang>();

        public static bool HasPermission(string tenChucNang)
        {
            return AllowedFunctions.Any(cn => cn.TenChucNang == tenChucNang);
        }
    }
}