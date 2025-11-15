using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using MilkTea.Client.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms
{
    public partial class InvoiceForm : Form
    {
        private readonly DonHangService _donHangService;
        private readonly CTDonHangService _CTdonHangService;
        private Dictionary<string, string> columnMapping;

        public InvoiceForm()
        {
            InitializeComponent();
            _donHangService = new DonHangService(); // khởi tạo service
        }

        // ========== LOAD FORM ==========
        private async void InvoiceForm_Load(object sender, EventArgs e)
        {
            // 1️⃣ Khởi tạo danh sách cột tìm kiếm
            columnMapping = new Dictionary<string, string>
            {
                { "Mã đơn hàng", "MaDH" },
                { "Mã nhân viên", "MaNV" },
                //{ "Tên nhân viên", "TenNV" },  // ✅ thêm dòng này
                //{ "Ngày lập", "NgayLap" },
                //{ "Giờ lập", "GioLap" },
                { "Mã Buzzer", "MaBuzzer" },
                { "pttt", "PhuongThucThanhToan" }
            };


            roundedComboBox1.Items.AddRange(columnMapping.Keys.ToArray());
            roundedComboBox1.SelectedIndex = 0;

            // 2️⃣ Tải toàn bộ đơn hàng khi mở form
            await LoadDonHangAsync();
        }

        // ========== LOAD TẤT CẢ ĐƠN HÀNG ==========
        private async Task LoadDonHangAsync()
        {
            var donHangList = await _donHangService.GetAllDonHangAsync();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            foreach (var dh in donHangList)
            {
                var item = new DonHangItem(dh);
                item.SetData(dh);
                item.Size = new System.Drawing.Size(210, 140);
                item.Margin = new Padding(10);

                // Đăng ký event
                item.DonHangDaXoa += Item_DonHangDaXoa;

                if (item.trangThai == 0)
                    flowLayoutPanel1.Controls.Add(item);
                else if (item.trangThai == 1)
                    flowLayoutPanel2.Controls.Add(item);
            }
        }
        private async void Item_DonHangDaXoa(object sender, EventArgs e)
        {
            await LoadDonHangAsync(); // reload danh sách đơn hàng
        }

        // ========== TÌM KIẾM ==========
        private async void textboxTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // tránh âm "ding"

                string displayName = roundedComboBox1.SelectedItem.ToString();
                string column = columnMapping[displayName];
                string value = textboxTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    await LoadDonHangAsync();
                    return;
                }

                // Nếu tìm kiếm theo buzzer và người dùng nhập dạng "BZ01"
                if (column == "MaBuzzer" && value.StartsWith("BZ", StringComparison.OrdinalIgnoreCase))
                {
                    value = value.Substring(2); // Lấy phần số phía sau "BZ"
                }
                try
                {
                    // Gọi service tìm kiếm
                    var list = await _donHangService.SearchAsync(column, value);

                    // Xóa kết quả cũ
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel2.Controls.Clear();

                    // Hiển thị danh sách kết quả
                    foreach (var dh in list)
                    {
                        var item = new DonHangItem(dh);
                        item.SetData(dh);
                        item.Size = new System.Drawing.Size(210, 140);
                        item.Margin = new Padding(10);

                        if (item.trangThai == 0)
                            flowLayoutPanel1.Controls.Add(item);
                        else if (item.trangThai == 1)
                            flowLayoutPanel2.Controls.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}");
                }
            }
        }

        // ========== CHUYỂN TAB ==========
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

       
    }
}