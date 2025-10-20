using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public partial class DonHangItem : UserControl
    {
        // Biến lưu sản phẩm hiện tại để khi click có thể dùng lại
        private DonHang? donHang; // Make donHang nullable

        public DonHangItem()
        {
            InitializeComponent();
        }
        // Gán dữ liệu đơn hàng vào UserControl

        // Nhận dữ liệu từ API và hiển thị lên giao diện
        public void SetData(DonHang dh)
        {
            donHang = dh;

            label_maDH.Text = dh.MaDH.ToString();
            label_NgayLap.Text = dh.NgayLap?.ToString("dd/MM/yyyy") ?? "N/A";
            pictureBox2.Text = dh.GioLap?.ToString(@"hh\:mm") ?? "N/A";
            label_TongGia.Text = dh.TongGia.ToString("N0") + " VND";
            label_MaBuzzer.Text = dh.MaBuzzer?.ToString() ?? "N/A";
            // các label khác tuỳ bạn thêm
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
    }
}
