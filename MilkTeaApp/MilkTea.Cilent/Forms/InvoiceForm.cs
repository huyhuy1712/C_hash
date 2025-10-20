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
                item.Size = new System.Drawing.Size(210, 140); // đảm bảo đúng kích thước
                item.Margin = new Padding(10);

                flowLayoutPanel1.Controls.Add(item); // nếu dùng FlowLayoutPanel thì FlowLayoutPanel.Controls.Add(item)

            }
        }
        

    }
}
