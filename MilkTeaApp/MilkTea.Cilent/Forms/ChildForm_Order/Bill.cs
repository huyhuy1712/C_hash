using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class Bill : Form
    {
        private DonHang? donHang;
        private ChiTietDonHang? chiTietDonHang;
        //private Topping? topping;
        private CTDonHangService CTDonHangService = new CTDonHangService();
        private SanPhamService _SanPhamService = new SanPhamService();
        private SizeService _sizeService= new SizeService();
        private NhanVienService _nhanVienService = new NhanVienService();
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
            var ctDH = danhSachCTDH
                .Where(ct => ct.MaDH == donHang.MaDH)
                .ToList();
            dataGridView1.Rows.Clear();
            foreach (var ct in ctDH)
            {
                var masp = ct.MaSP;
                var sp = await _SanPhamService.GetSanPhamsByIdAsync(masp);
                string tenSP = sp?.TenSP ?? "Không xác định";
                  await CTDonHangService.GetToppingByMaCTDHAsync(ct.MaCTDH);
                var size = await _sizeService.GetSizeByIdAsync(ct.MaSize);
                string tenSize = size?.TenSize ?? "Không xác định";

                dataGridView1.Rows.Add(tenSP, tenSize, ct.GiaVon, ct.SoLuong, ct.TongGia);
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
    }
}
