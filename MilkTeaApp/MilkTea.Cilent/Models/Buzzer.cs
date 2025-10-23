namespace MilkTea.Client.Models
{
    public class Buzzer
    {
        // Mã buzzer (khóa chính, tự tăng)
        public int MaBuzzer { get; set; }

        // Số hiệu buzzer (unique, không được null)
        public string SoHieu { get; set; } = string.Empty;

        // Trạng thái (mặc định = 1)
        // Có thể: 1 = hoạt động, 0 = không hoạt động
        public int TrangThai { get; set; } = 1;
        public override string ToString()
        {
            return SoHieu;
        }
    }
}
