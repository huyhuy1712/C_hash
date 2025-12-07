using MilkTea.Client.Controls;
using MilkTea.Client.Forms.ChildForm_Report;
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
        private List<SanPham> _allProducts = new List<SanPham>();
        private List<DoanhThu> chiTietDoanhThuDaLoc = new List<DoanhThu>();

        private readonly LoaiService _loaiService;
        private readonly SanPhamService _SanPhamService;
        private readonly SizeService _sizeService;
        private readonly DoanhThuService _doanhThuService;
        private readonly CTKhuyenMaiService _ctKhuyenMaiService;
        private readonly CongThucService _congThucService;
        private readonly CTCongThucService _ctCongThucService;
        private List<DoanhThu> list;
        private List<SanPham> allSP;
        DataTable dtThongKe = new DataTable();


        public ReportForm()
        {
            InitializeComponent();
            _loaiService = new LoaiService();
            _SanPhamService = new SanPhamService();
            _sizeService = new SizeService();
            _doanhThuService = new DoanhThuService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
            _congThucService = new CongThucService();
            _ctCongThucService = new CTCongThucService();


        }

        private void TaoCauTrucBangThongKe()
        {
            //dtThongKe.Columns.Add("thoiGian", typeof(string));
            dtThongKe.Columns.Add("sanPham", typeof(string));
            //dtThongKe.Columns.Add("size1", typeof(string));

            dtThongKe.Columns.Add("soLuong", typeof(int));
            dtThongKe.Columns.Add("chiPhi", typeof(decimal));
            dtThongKe.Columns.Add("doanhThu", typeof(decimal));
            dtThongKe.Columns.Add("loiNhuan", typeof(decimal));

            // Gán datasource 1 lần duy nhất
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtThongKe;

            //thoiGian.DataPropertyName = "thoiGian";
            sanPham.DataPropertyName = "sanPham";
            //size1.DataPropertyName = "size1";
            soLuong.DataPropertyName = "soLuong";
            chiPhi.DataPropertyName = "chiPhi";
            doanhThu.DataPropertyName = "doanhThu";
            loiNhuan.DataPropertyName = "loiNhuan";
        }

        private async void ReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                list = await _doanhThuService.GetDoanhThusAsync();
                allSP = await _SanPhamService.GetSanPhamsAsync();
                // --- Thiết lập ngày mặc định theo quý ---
                DateTime now = DateTime.Now;
                int quarter = (now.Month - 1) / 3 + 1; // tính quý hiện tại
                int startMonth = (quarter - 1) * 3 + 1; // tháng đầu quý
                int endMonth = startMonth + 2; // tháng cuối quý

                // Ngày đầu quý
                dateFrom.Value = new DateTime(now.Year, startMonth, 1);
                // Ngày cuối quý: lấy ngày cuối tháng cuối quý
                dateTo.Value = new DateTime(now.Year, endMonth, DateTime.DaysInMonth(now.Year, endMonth));

                // --- Load loại ---
                var loais = await _loaiService.GetLoaisAsync();
                loais.Insert(0, new Loai
                {
                    MaLoai = 0,
                    TenLoai = "Tất cả"
                });
                cbbLoai.DisplayMember = "TenLoai";
                cbbLoai.ValueMember = "MaLoai";
                cbbLoai.DataSource = loais;

                // --- Load sản phẩm ---
                _allProducts = await _SanPhamService.GetSanPhamsAsync(); // lưu toàn bộ sản phẩm
                var displayProducts = new List<SanPham>(_allProducts);
                displayProducts.Insert(0, new SanPham
                {
                    MaSP = 0,
                    TenSP = "Tất cả"
                });
                cbbSP.DataSource = displayProducts;
                cbbSP.DisplayMember = "TenSP";
                cbbSP.ValueMember = "MaSP";

                // --- Load size ---
                //var sizes = await _sizeService.GetAll();
                //sizes.Insert(0, new Models.Size
                //{
                //    MaSize = 0,
                //    TenSize = "Tất cả"
                //});
                //cbbSize.DataSource = sizes;
                //cbbSize.DisplayMember = "TenSize";
                //cbbSize.ValueMember = "MaSize";

                // --- Gắn sự kiện cho combobox loại ---
                cbbLoai.SelectedIndexChanged += cbbLoai_SelectedIndexChanged;

                //load bảng
                TaoCauTrucBangThongKe();
                loadDataGridView();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string tenSP = dataGridView1.Rows[e.RowIndex].Cells["sanPham"].Value.ToString();

            // Tìm mã SP
            var sp = allSP.FirstOrDefault(x => x.TenSP == tenSP);
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy mã sản phẩm.");
                return;
            }

            int maSP = sp.MaSP;

            // 👉 Lọc doanh thu chi tiết ĐÃ LỌC THEO THỜI GIAN
            var chiTiet = chiTietDoanhThuDaLoc
                            .Where(x => x.MaSP == maSP)
                            .ToList();

            if (chiTiet.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn cho sản phẩm này.");
                return;
            }

            // Truyền LIST DoanhThu vào InvoiceReport
            InvoiceReport frm = new InvoiceReport(chiTiet);
            frm.ShowDialog();
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
            try
            {
                if (cbbLoai.SelectedValue == null) return;

                int selectedLoaiId = Convert.ToInt32(cbbLoai.SelectedValue);

                List<SanPham> filteredProducts;

                if (selectedLoaiId == 0)
                {
                    // Nếu chọn "Tất cả loại" → hiện tất cả sản phẩm
                    filteredProducts = new List<SanPham>(_allProducts);
                }
                else
                {
                    // Nếu chọn 1 loại cụ thể → lọc sản phẩm thuộc loại đó
                    filteredProducts = _allProducts
                        .Where(sp => sp.MaLoai == selectedLoaiId)
                        .ToList();
                }

                // Thêm dòng "Tất cả" ở đầu — lúc nào cũng có
                filteredProducts.Insert(0, new SanPham
                {
                    MaSP = 0,
                    TenSP = "Tất cả"
                });

                // Gắn vào combobox
                cbbSP.DataSource = null;
                cbbSP.DataSource = filteredProducts;
                cbbSP.DisplayMember = "TenSP";
                cbbSP.ValueMember = "MaSP";
                cbbSP.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc sản phẩm: " + ex.Message);
            }
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
            loadDataGridView();
        }

        private async void loadDataGridView()
        {
            try
            {

                var temp = new List<DoanhThu>(list);
                dtThongKe.Rows.Clear();
                cbbLoc.SelectedItem = "Tất Cả";

                DateTime tuNgay = dateFrom.Value.Date;
                DateTime denNgay = dateTo.Value.Date;

                if (denNgay < tuNgay)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!");
                    return;
                }

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu doanh thu.");
                    return;
                }

                // --- Lọc theo loại, sản phẩm, size ---
                int selectedLoai = Convert.ToInt32(cbbLoai.SelectedValue);
                int selectedSP = Convert.ToInt32(cbbSP.SelectedValue);
                //int selectedSize = Convert.ToInt32(cbbSize.SelectedValue);

                if (selectedLoai != 0)
                {
                    var spIdsTheoLoai = allSP
                        .Where(sp => sp.MaLoai == selectedLoai)
                        .Select(sp => sp.MaSP)
                        .ToList();

                    temp = temp.Where(x => x.MaSP.HasValue && spIdsTheoLoai.Contains(x.MaSP.Value)).ToList();
                }

                if (selectedSP != 0)
                {
                    temp = temp.Where(x => x.MaSP == selectedSP).ToList();
                }

                //if (selectedSize != 0)
                //{
                //    temp = temp.Where(x => x.MaSize == selectedSize).ToList();
                //}

                // --- Lọc theo thời gian ---
                temp = temp.Where(x =>
                {
                    DateTime ngayItem = new DateTime(x.Nam, x.Thang, x.Ngay);
                    return ngayItem >= tuNgay && ngayItem <= denNgay;
                }).ToList();

                if (temp.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu phù hợp với bộ lọc.");
                    return;
                }
                chiTietDoanhThuDaLoc = temp;

                DataTable dtTam = dtThongKe.Clone();


                // --- HIỂN THỊ CHI TIẾT ---
                foreach (var item in temp)
                {
                    var sp = await _SanPhamService.GetSanPhamsByIdAsync(item.MaSP.Value);
                    string tenSP = sp?.TenSP ?? "Không xác định";

                    DataRow row = dtTam.NewRow();
                    row["sanPham"] = tenSP;
                    row["soLuong"] = item.SLBan;
                    row["chiPhi"] = item.TongChiPhi;
                    row["doanhThu"] = item.TongDoanhThu;
                    row["loiNhuan"] = item.TongDoanhThu - item.TongChiPhi;
                    dtTam.Rows.Add(row);
                }

                // --- TỔNG HỢP THEO SẢN PHẨM ---
                var tongHop = dtTam.AsEnumerable()
                    .GroupBy(row => row.Field<string>("sanPham"))
                    .Select(g => new
                    {
                        TenSP = g.Key,
                        TongSoLuong = g.Sum(r => r.Field<int>("soLuong")),
                        TongChiPhi = g.Sum(r => r.Field<decimal>("chiPhi")),
                        TongDoanhThu = g.Sum(r => r.Field<decimal>("doanhThu")),
                        LoiNhuan = g.Sum(r => r.Field<decimal>("doanhThu") - r.Field<decimal>("chiPhi"))
                    })
                    .ToList();

                // Xóa dtThongKe cũ để ghi bảng tổng hợp
                dtThongKe.Rows.Clear();

                // Đổ lại dữ liệu nhóm vào dtThongKe
                foreach (var item in tongHop)
                {
                    DataRow row = dtThongKe.NewRow();

                    row["sanPham"] = item.TenSP;
                    row["soLuong"] = item.TongSoLuong;
                    row["chiPhi"] = item.TongChiPhi;
                    row["doanhThu"] = item.TongDoanhThu;
                    row["loiNhuan"] = item.LoiNhuan;

                    dtThongKe.Rows.Add(row);
                }

                // Hiển thị lại
                dataGridView1.DataSource = dtThongKe;

                // Tổng cuối cùng
                txtSoLuong.Text = tongHop.Sum(x => x.TongSoLuong).ToString("N0");
                txtChiPhi.Text = tongHop.Sum(x => x.TongChiPhi).ToString("N0");
                txtDoanhThu.Text = tongHop.Sum(x => x.TongDoanhThu).ToString("N0");
                txtLoiNhuan.Text = tongHop.Sum(x => x.LoiNhuan).ToString("N0");
            }
            catch (Exception ex)
            {
                // In chi tiết lỗi ra Console (xem trong Output Window)
                Console.WriteLine("------ LỖI KHI LẤY DỮ LIỆU DOANH THU ------");
                Console.WriteLine("Message: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("InnerException: " + ex.InnerException.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);

                // Hiển thị lỗi đầy đủ trong MessageBox
                MessageBox.Show(
                    "Lỗi khi tải dữ liệu doanh thu:\n" +
                    ex.Message +
                    (ex.InnerException != null ? "\n\nChi tiết: " + ex.InnerException.Message : "") +
                    "\n\n" + ex.StackTrace,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cbbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtThongKe == null || dtThongKe.Rows.Count == 0)
                return;

            string tieuChi = cbbLoc.SelectedItem?.ToString() ?? "";
            string sortExpression = "";

            switch (tieuChi)
            {
                case "Doanh thu cao đến thấp":
                    sortExpression = "doanhThu DESC";
                    break;
                case "Doanh thu thấp đến cao":
                    sortExpression = "doanhThu ASC";
                    break;
                case "Số lượng cao đến thấp":
                    sortExpression = "soLuong DESC";
                    break;
                case "Số lượng thấp đến cao":
                    sortExpression = "soLuong ASC";
                    break;
                default:
                    // Trả về bảng ban đầu nếu chọn "Tất cả"
                    dataGridView1.DataSource = dtThongKe;
                    return;
            }

            // --- Sắp xếp ---
            DataView dv = dtThongKe.DefaultView;
            dv.Sort = sortExpression;

            DataTable dtSorted = dv.ToTable();

            // --- Gán lại vào DataGrid ---
            dataGridView1.DataSource = dtSorted;


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbbSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
