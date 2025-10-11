namespace MilkTea.Client.Models
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal Gia { get; set; }
        public string Anh { get; set; }
        public int SLDuKien { get; set; }
        public int TrangThai { get; set; }
        public int MaLoai { get; set; }
        public override string ToString()
        {
            return TenSP;
        }
    }
}
