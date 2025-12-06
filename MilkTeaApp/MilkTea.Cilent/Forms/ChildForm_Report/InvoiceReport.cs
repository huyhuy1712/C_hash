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

namespace MilkTea.Client.Forms.ChildForm_Report
{
    public partial class InvoiceReport : Form
    {
        private List<DoanhThu> _data;
        private SizeService _sizeService= new SizeService();

        public InvoiceReport(List<DoanhThu> ds)
        {
            InitializeComponent();
            _data = ds;
            _sizeService = new SizeService();
            LoadGrid();
        }

        private async void LoadGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in _data)
            {
                var size = await _sizeService.GetSizeByIdAsync(item.MaSize.Value);
                string tenSize = size?.TenSize ?? "Không xác định";

                dataGridView1.Rows.Add(
                    $"{item.Ngay}/{item.Thang}/{item.Nam} {item.Gio}",
                    item.MaDH,
                    tenSize,
                    item.SLBan,
                    item.TongChiPhi,
                    item.TongDoanhThu,
                    item.TongDoanhThu - item.TongChiPhi
                );
            }
        }
    }
}
