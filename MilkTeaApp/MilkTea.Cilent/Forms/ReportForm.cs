using MilkTea.Client.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MilkTea.Client.Forms
{

    public partial class ReportForm : Form
    {

        private readonly LoaiService _loaiService;
        private readonly SanPhamService _SanPhamService;
        private readonly SizeService _sizeService;
        private readonly DoanhThuService _doanhThuService;

        public ReportForm()
        {
            InitializeComponent();
            _loaiService = new LoaiService();
            _SanPhamService = new SanPhamService();
            _sizeService = new SizeService();
            _doanhThuService = new DoanhThuService();
        }


        private async void ReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                var loais = await _loaiService.GetLoaisAsync();
                loais.Insert(0, new Loai
                {
                    MaLoai = 0,
                    TenLoai = "Tất cả"
                });
                cbbLoai.DataSource = loais;
                cbbLoai.DisplayMember = "TenLoai";
                cbbLoai.ValueMember = "MaLoai";

                // Load danh sách sản phẩm
                var products = await _SanPhamService.GetSanPhamsAsync();
                products.Insert(0, new SanPham
                {
                    MaSP = 0,
                    TenSP = "Tất cả"
                });
                cbbSP.DataSource = products;
                cbbSP.DisplayMember = "TenSP";
                cbbSP.ValueMember = "MaSP";

                // Load size
                var sizes = await _sizeService.GetAll();
                cbbSize.DataSource = sizes;
                cbbSize.DisplayMember = "TenSize";
                cbbSize.ValueMember = "MaSize";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gọi API: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ReportPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Order_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void btnLayDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu cũ trong bảng
                dataGridView1.Rows.Clear();

                // Gọi API để lấy danh sách doanh thu
                var list = await _doanhThuService.GetDoanhThusAsync();

                // Kiểm tra nếu có dữ liệu
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu doanh thu.");
                    return;
                }

                // Hiển thị dữ liệu lên DataGridView
                foreach (var item in list)
                {
                    var sp = await _SanPhamService.GetSanPhamsByIdAsync(item.MaSP.Value);
                    string tenSP = sp?.TenSP ?? "Không xác định";
                    var size = await _sizeService.GetSizeByIdAsync(item.MaSize.Value);
                    string tenSize = size?.TenSize ?? "Không xác định";
                    DateTime date = new DateTime(item.Nam, item.Thang, item.Ngay);
                    string thoiGian = date.ToString("dd/MM/yyyy");
                    dataGridView1.Rows.Add(
                        thoiGian,
                        tenSP,
                        tenSize,
                        item.SLBan,
                        item.MaKM,
                        (10000).ToString("N0") + " ₫",
                        item.TongDoanhThu.ToString("N0") + " ₫",
                        (1000).ToString("N0") + " ₫"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Lỗi khi tải dữ liệu doanh thu: " + ex.Message);
            }
        }

    }
}
