namespace MilkTea.Client.Models
{
    public static class Session
    {
        public static TaiKhoan CurrentUser { get; set; }
        public static Task<List<ChucNang>> AllowedFunctions { get; set; }
    }
}