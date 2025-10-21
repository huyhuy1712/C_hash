using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using MilkTea.Client.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms
{
    public partial class InvoiceForm : Form
    {
        private readonly DonHangService _donHangService;

        public InvoiceForm()
        {
            InitializeComponent();
            _donHangService = new DonHangService(); // khởi tạo service

        }

        private async void InvoiceForm_Load(object sender, EventArgs e)
        {
            await LoadDonHangAsync();
        }

        private async Task LoadDonHangAsync()
        {
            // Lấy danh sách đơn hàng từ service
            var donHangList = await _donHangService.GetAllDonHangAsync();

            // Xóa panel cũ trước khi thêm mới
            flowLayoutPanel1.Controls.Clear(); // nếu dùng FlowLayoutPanel thì đổi tên



            foreach (var dh in donHangList)
            {
                var item = new DonHangItem();
                item.SetData(dh);
                //item.OnDonHangSelected += DonHangItem_OnDonHangSelected;
                item.Size = new System.Drawing.Size(210, 140); // đảm bảo đúng kích thước
                item.Margin = new Padding(10);
                if (item.trangThai == 0)
                {
                    flowLayoutPanel1.Controls.Add(item);
                }
                else if (item.trangThai == 1)
                {
                    flowLayoutPanel2.Controls.Add(item);
                }

                //flowLayoutPanel1.Controls.Add(item); // nếu dùng FlowLayoutPanel thì FlowLayoutPanel.Controls.Add(item)

            }
        }

        private void btn_danglam_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Hide();
            flowLayoutPanel1.Show();
        }

        private void btn_lamxong_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Hide();
            flowLayoutPanel2.Show();
        }
        // ==================== KHI CHỌN 1 đơn hàng ====================
        //private async void DonHangItem_OnDonHangSelected(object sender, ProductItem.SanPhamEventArgs e)
        //{


        //}
    }
}