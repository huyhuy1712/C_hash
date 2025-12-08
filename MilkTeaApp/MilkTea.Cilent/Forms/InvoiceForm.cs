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
        private Dictionary<string, string> columnMapping;

        public InvoiceForm()
        {
            InitializeComponent();
            _donHangService = new DonHangService();
        }

        private async void InvoiceForm_Load(object sender, EventArgs e)
        {
            columnMapping = new Dictionary<string, string>
            {
                { "Mã đơn hàng", "MaDH" },
                { "Mã nhân viên", "MaNV" },
                { "Mã Buzzer", "MaBuzzer" },
                { "Phương thức thanh toán", "PhuongThucThanhToan" }
            };

            roundedComboBox1.Items.AddRange(columnMapping.Keys.ToArray());
            roundedComboBox1.SelectedIndex = 0;

            roundedComboBox2.Items.Add("Đang làm");
            roundedComboBox2.Items.Add("Đã hoàn thành");

            roundedComboBox2.SelectedIndexChanged -= roundedComboBox2_SelectedIndexChanged;
            roundedComboBox2.SelectedIndex = 0;
            roundedComboBox2.SelectedIndexChanged += roundedComboBox2_SelectedIndexChanged;

            await FilterAllAsync();
        }

        private async void textboxTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                await FilterAllAsync();
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await FilterAllAsync();
        }

        private async void roundedComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            await FilterAllAsync();
        }

        private async Task FilterAllAsync()
        {
            string displayName = roundedComboBox1.SelectedItem.ToString();
            string column = columnMapping[displayName];
            string keyword = textboxTimKiem.Text.Trim();
            int trangThai = roundedComboBox2.SelectedIndex;
            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date;

            var list = await _donHangService.GetAllDonHangAsync();

            var ketQua = list.Where(dh => dh.TrangThai == trangThai);

            ketQua = ketQua.Where(dh =>
                dh.NgayLap.HasValue &&
                dh.NgayLap.Value.Date >= from &&
                dh.NgayLap.Value.Date <= to);

            if (!string.IsNullOrEmpty(keyword))
            {
                switch (column)
                {
                    case "MaDH":
                        ketQua = ketQua.Where(dh => dh.MaDH.ToString().Contains(keyword));
                        break;

                    case "MaNV":
                        ketQua = ketQua.Where(dh => dh.MaNV.HasValue &&
                                                    dh.MaNV.Value.ToString().Contains(keyword));
                        break;

                    case "MaBuzzer":
                        string raw = keyword.Trim().ToUpper();

                        // Nếu nhập BZ05 hoặc BZ5
                        if (raw.StartsWith("BZ"))
                            raw = raw.Substring(2);

                        // Nếu nhập 05 → chuyển thành 5
                        if (int.TryParse(raw, out int buzzerSearch))
                        {
                            ketQua = ketQua.Where(dh =>
                                dh.MaBuzzer.HasValue &&
                                dh.MaBuzzer.Value == buzzerSearch);
                        }
                        break;


                    case "PhuongThucThanhToan":
                        int? pt = null;
                        string kw = keyword.Trim().ToLower();

                        // Nếu người dùng nhập "tm" → 0
                        if (kw == "tm")
                            pt = 0;

                        // Nếu người dùng nhập "ck" → 1
                        else if (kw == "ck")
                            pt = 1;

                        // Ngược lại: thử xem người dùng có nhập số trực tiếp không
                        else if (int.TryParse(kw, out int so))
                            pt = so;

                        if (pt.HasValue)
                        {
                            ketQua = ketQua.Where(dh =>
                                dh.PhuongThucThanhToan.HasValue &&
                                dh.PhuongThucThanhToan.Value == pt.Value);
                        }
                        break;

                }
            }
            var resultList = ketQua.ToList(); // √ chỉ ToList ở cuối

            flowLayoutPanel1.Controls.Clear();

            foreach (var dh in resultList)
            {
                var item = new DonHangItem(dh);
                await item.SetData(dh);
                item.Size = new System.Drawing.Size(210, 140);
                item.Margin = new Padding(10);
                item.DonHangDaXoa += async (s, e) =>
                {
                    await FilterAllAsync();
                };
                flowLayoutPanel1.Controls.Add(item);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
