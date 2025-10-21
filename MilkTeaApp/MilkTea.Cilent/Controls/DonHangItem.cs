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
using static MilkTea.Client.Controls.ProductItem;

namespace MilkTea.Client.Controls
{
    public partial class DonHangItem : UserControl
    {
        // Biến lưu sản phẩm hiện tại để khi click có thể dùng lại
        private DonHang? donHang; // Make donHang nullable
        public int pttt;
        public int trangThai;
        //public event EventHandler<DonHangEventArgs> OnDonHangSelected;
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
            pttt = dh.PhuongThucThanhToan ?? 0;
            trangThai = dh.TrangThai;
            if (pttt == 0)
            {
                pictureBox1.Image = Properties.Resources.money;
            }
            else
                pictureBox1.Image = Properties.Resources.card;
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



        private void pictureBox6_Click(object sender, EventArgs e)
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
                MessageBox.Show("Đơn hàng đã được xóa!");
            }
            else
            {
                // Người dùng chọn No -> không làm gì
                // có thể để trống
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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
                MessageBox.Show("Cập nhật đơn hàng thành công!");
            }
            else
            {
                // Người dùng chọn No -> không làm gì
                // có thể để trống
            }
        }
    }
}
