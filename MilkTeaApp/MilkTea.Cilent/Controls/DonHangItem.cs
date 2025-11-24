
using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MilkTea.Client.Controls.ProductItem;

namespace MilkTea.Client.Controls
{
    public partial class DonHangItem : UserControl
    {
        // Biến lưu sản phẩm hiện tại để khi click có thể dùng lại
        private DonHang? donHang; // Make donHang nullable
        private ChiTietDonHang? chiTietDonHang;
        private DoanhThu? doanhThu;
        private CTDonHangService CTDonHangService = new CTDonHangService();
        private DoanhThuService doanhThuService = new DoanhThuService();
        private SanPhamService SanPhamService = new SanPhamService();
        private CongThucService _congThucService = new CongThucService();
        private CTCongThucService _ctCongThucService = new CTCongThucService();
        private buzzerService _buzzerService = new buzzerService();
        private ChiTietPhieuNhapService _chiTietPhieuNhapService = new ChiTietPhieuNhapService();
        public int pttt;
        public int trangThai;
        // Thêm event
        public event EventHandler DonHangDaXoa;

        //public event EventHandler<DonHangEventArgs> OnDonHangSelected;
        public DonHangItem(DonHang dh)
        {
            InitializeComponent();
            donHang = dh;
        }
        // Gán dữ liệu đơn hàng vào UserControl

        // Nhận dữ liệu từ API và hiển thị lên giao diện
        public async Task SetData(DonHang dh)
        {
            donHang = dh;

            label_maDH.Text = dh.MaDH.ToString();
            label_NgayLap.Text = dh.NgayLap?.ToString("dd/MM/yyyy") ?? "N/A";
            label_GioLap.Text = dh.GioLap?.ToString(@"hh\:mm") ?? "N/A";
            label_TongGia.Text = dh.TongGia.ToString("N0") + " VND";
            //label_MaBuzzer.Text = dh.MaBuzzer?.ToString() ?? "N/A";
            //label_MaBuzzer.Text = dh.MaBuzzer.HasValue ? $"BZ{dh.MaBuzzer.Value:D2}" : "N/A";

            // --- Lấy số hiệu buzzer từ API ---
            if (dh.MaBuzzer != null)
            {
                var buzzer = await _buzzerService.GetByMaMayAsync(dh.MaBuzzer.Value);
                if (buzzer != null)
                {
                    label_MaBuzzer.Text = buzzer.SoHieu; // Hiển thị số hiệu thực sự
                }
                else
                {
                    label_MaBuzzer.Text = "N/A";
                }
            }
            else
            {
                label_MaBuzzer.Text = "N/A";
            }

            pttt = dh.PhuongThucThanhToan ?? 0;
            trangThai = dh.TrangThai;
            if (pttt == 0)
            {
                pictureBox1.Image = Properties.Resources.money;
            }
            else
                pictureBox1.Image = Properties.Resources.card;
            // các label khác tuỳ bạn thêm
            if (trangThai == 0)
            {
                pictureBox4.Image = Properties.Resources.order1;

            }
            else
            {
                pictureBox4.Image = Properties.Resources.hourglass;
                pictureBox4.Enabled = false;
                pictureBox4.Image = SetOpacity(Properties.Resources.hourglass, 0.9f);
                //pictureBox6.Enabled = false;
            }
        }
        public Image SetOpacity(Image img, float opacity)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);

            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = opacity; // độ mờ (1 = rõ, 0 = hoàn toàn mờ)

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            gfx.DrawImage(img,
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                0, 0, img.Width, img.Height,
                GraphicsUnit.Pixel,
                attributes);

            gfx.Dispose();
            return bmp;
        }

        private void pictureBox_PhuongThucThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private async void pictureBox6_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có muốn xóa đơn hàng không?", // nội dung thông báo
                "Xác nhận xóa",                    // tiêu đề hộp thoại
                MessageBoxButtons.YesNo,           // nút Yes/No
                MessageBoxIcon.Question            // biểu tượng câu hỏi
            );

            if (result == DialogResult.Yes)
            {
                // Người dùng chọn Yes -> thực hiện xóa đơn hàng
                // TODO: thêm code xóa đơn hàng ở đây
                donHang.TrangThai = 2; // Đã hoàn thành
                var trangThaiCapNhat = await new DonHangService().CapNhatTrangThaiDonHangAsync(donHang);
                var maBuzzer = donHang.MaBuzzer;
                var buzzer = await _buzzerService.GetByMaMayAsync(maBuzzer ?? -1);
                var soHieuBuzzer = buzzer?.SoHieu;
                await _buzzerService.UpdateTrangThaiAsync(soHieuBuzzer, 1); // Cập nhật trạng thái buzzer
                                                                            // Báo cho Form cha
                DonHangDaXoa?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Đơn hàng đã được xóa!");

            }
            else
            {
                // Người dùng chọn No -> không làm gì
                // có thể để trống
            }
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có muốn xác nhận đh đã hoàn thành ko?", // nội dung thông báo
                "Xác nhận",                    // tiêu đề hộp thoại
                MessageBoxButtons.YesNo,           // nút Yes/No
                MessageBoxIcon.Question            // biểu tượng câu hỏi
            );

            if (result == DialogResult.Yes)
            {
                // Người dùng chọn Yes -> thực hiện xóa đơn hàng
                // TODO: thêm code xóa đơn hàng ở đây
               

                //nhàn
                donHang.TrangThai = 1; // Đã hoàn thành
                var trangThaiCapNhat = await new DonHangService().CapNhatTrangThaiDonHangAsync(donHang);
                var maBuzzer = donHang.MaBuzzer;
                var buzzer = await _buzzerService.GetByMaMayAsync(maBuzzer ?? -1);
                var soHieuBuzzer = buzzer?.SoHieu;
                await _buzzerService.UpdateTrangThaiAsync(soHieuBuzzer, 1); // Cập nhật trạng thái buzzer

                //System.Windows.Forms.MessageBox.Show(donHang.MaBuzzer.ToString());
                int maDH = donHang.MaDH;

                int? nam = donHang.NgayLap?.Year;
                int? thang = donHang.NgayLap?.Month;
                int? ngayTrongThang = donHang.NgayLap?.Day;
                string gio = donHang.NgayLap?.ToString("HH:mm:ss");

                var danhSachCTDH = await CTDonHangService.GetAllAsync(maDH);
                var ctDH = danhSachCTDH
                    .Where(ct => ct.MaDH == donHang.MaDH)
                    .ToList();

                foreach (var item in ctDH)
                {
                    var maSP = item.MaSP;
                    var sp = await SanPhamService.SearchSanPhamAsync("MaSP", maSP.ToString());
                    var listNL = await _ctCongThucService.GetChiTietCongThucTheoSPAsync(maSP);
                    decimal tongChiPhi = 0m;
                    foreach (var nl in listNL)
                    {
                        int maNL = nl.MaNL;
                        decimal soLuongCanDung = nl.SoLuongCanDung;

                        // 3. Lấy chi tiết phiếu nhập của nguyên liệu
                        var chiTietPN = await _chiTietPhieuNhapService.GetByMaNLAsync(maNL); // lấy 1 bản ghi đầu tiên

                        if (chiTietPN.Count != 0 )
                        {
                            var last = chiTietPN[chiTietPN.Count - 1]; // phần tử cuối
                            decimal donGiaNhap = last.DonGiaNhap;

                            // 4. Nhân DonGiaNhap * SoLuongCanDung và cộng vào tổng
                            tongChiPhi += donGiaNhap * soLuongCanDung;
                        }
                        else tongChiPhi += 0.1m* soLuongCanDung; // nếu không có nguyên liệu trong kho thì lấy -1 làm đơn giá
                    }

                    var maSize = item.MaSize;
                    int maLoai = sp[0].MaLoai;
                    var soLuong = item.SoLuong;
                    var tongGia = item.TongGia;

                    var doanhThu = new DoanhThu
                    {
                        Ngay = ngayTrongThang ?? 0,
                        Thang = thang ?? 0,
                        Nam = nam ?? 0,
                        Gio = TimeSpan.Parse(gio ?? "00:00:00"),
                        SLBan = soLuong,
                        MaSP = maSP,
                        MaLoai = maLoai,
                        MaKM = 1, //TẠM THỜI BẰNG 1
                        MaSize = maSize,
                        TongChiPhi = tongChiPhi,
                        TongDoanhThu = tongGia,
                    };

                    await doanhThuService.ThemDoanhThuAsync(doanhThu);

                }
                MessageBox.Show("Cập nhật đơn hàng thành công!");
                DonHangDaXoa?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Người dùng chọn No -> không làm gì
                // có thể để trống
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // Hiển thị chi tiết đơn hàng
            if (donHang != null)
            {
                Bill billForm = new Bill(donHang);
                billForm.ShowDialog();
            }
        }
    }
}
