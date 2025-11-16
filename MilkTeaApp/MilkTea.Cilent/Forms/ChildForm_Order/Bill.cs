using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class Bill : Form
    {
        private DonHang? donHang;
        private ChiTietDonHang? chiTietDonHang;
        private Topping? toppingNL;
        private CTDonHangService CTDonHangService = new CTDonHangService();
        private SanPhamService _SanPhamService = new SanPhamService();
        private SizeService _sizeService = new SizeService();
        private NhanVienService _nhanVienService = new NhanVienService();
        private NguyenLieuService _nguyenLieuService = new NguyenLieuService();
        //private readonly ToppingService _toppingService;
        public Bill(DonHang dh)
        {
            InitializeComponent();
            donHang = dh;
            loadBill(this, EventArgs.Empty);
        }

        private async void loadBill(object sender, EventArgs e)
        {
            int maDH = donHang.MaDH;
            var danhSachCTDH = await CTDonHangService.GetAllAsync(maDH);
            var listctDH = danhSachCTDH
                .Where(ct => ct.MaDH == donHang.MaDH)
                .ToList();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns["topping"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (var ct in listctDH)
            {
                var masp = ct.MaSP;
                var sp = await _SanPhamService.GetSanPhamsByIdAsync(masp);
                string tenSP = sp?.TenSP ?? "Không xác định";
                var listTopping=  await CTDonHangService.GetToppingByMaCTDHAsync(ct.MaCTDH);

                // 2. Khởi tạo danh sách string để lưu tên + số lượng
                List<string> toppingStrings = new List<string>();

                foreach (var t in listTopping)
                {
                    // Lấy thông tin nguyên liệu theo MaNL
                    var nguyenLieu = await _nguyenLieuService.GetById(t.MaNL);

                    // Tạo chuỗi "Tên xSL"
                    toppingStrings.Add($"{nguyenLieu.Ten} x{t.SL}");
                }

                // 3. Nối tất cả topping thành chuỗi, mỗi topping 1 dòng
                string toppingText = string.Join("\n", toppingStrings);

                // 4. Gán vào TextBox
                var topping = toppingText; 
                var size = await _sizeService.GetSizeByIdAsync(ct.MaSize);
                string tenSize = size?.TenSize ?? "Không xác định";

                dataGridView1.Rows.Add(tenSP, topping, tenSize, ct.GiaVon, ct.SoLuong, ct.TongGia);
            }
            label2.Text = donHang.TongGia.ToString("N0") + " VND";
            int maNV = donHang.MaNV ?? 0;
            var nhanVien = await _nhanVienService.GetByMaNV(maNV);
            var tenNV = nhanVien?.TenNV ?? "Không xác định";
            ten_thu_ngan_label.Text = tenNV;
            DateTime date = donHang.NgayLap ?? DateTime.MinValue;
            string thoiGian = date.ToString("dd/MM/yyyy");
            tgian_label.Text = thoiGian;
            int phuongThuc = donHang.PhuongThucThanhToan ?? 0;
            switch (phuongThuc)
            {
                case 1:
                    label22.Text = "Tiền mặt";
                    break;
                case 2:
                    label22.Text = "Thẻ";
                    break;
                case 3:
                    label22.Text = "Ví điện tử";
                    break;
                default:
                    label22.Text = "Khác";
                    break;
            }
            label19.Text = donHang.MaBuzzer.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void order_detail_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InvoiceOrder_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
