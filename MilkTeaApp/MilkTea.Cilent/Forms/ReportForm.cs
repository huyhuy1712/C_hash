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
        private List<SanPham> _allProducts = new List<SanPham>();


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
            dtThongKe.Columns.Add("thoiGian", typeof(string));
            dtThongKe.Columns.Add("sanPham", typeof(string));
            dtThongKe.Columns.Add("size1", typeof(string));

            dtThongKe.Columns.Add("soLuong", typeof(int));
            dtThongKe.Columns.Add("chiPhi", typeof(decimal));
            dtThongKe.Columns.Add("doanhThu", typeof(decimal));
            dtThongKe.Columns.Add("loiNhuan", typeof(decimal));

            // Gán datasource 1 lần duy nhất
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtThongKe;

            thoiGian.DataPropertyName = "thoiGian";
            sanPham.DataPropertyName = "sanPham";
            size1.DataPropertyName = "size1";
            soLuong.DataPropertyName = "soLuong";
            chiPhi.DataPropertyName = "chiPhi";
            doanhThu.DataPropertyName = "doanhThu";
            loiNhuan.DataPropertyName = "loiNhuan";
        }

        private async void ReportForm_Load(object sender, EventArgs e)
        {
            try
            {
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
                var sizes = await _sizeService.GetAll();
                sizes.Insert(0, new Models.Size
                {
                    MaSize = 0,
                    TenSize = "Tất cả"
                });
                cbbSize.DataSource = sizes;
                cbbSize.DisplayMember = "TenSize";
                cbbSize.ValueMember = "MaSize";

                // --- Gắn sự kiện cho combobox loại ---
                cbbLoai.SelectedIndexChanged += cbbLoai_SelectedIndexChanged;

                //load bảng
                TaoCauTrucBangThongKe();
                loadDataGridView();
                list = await _doanhThuService.GetDoanhThusAsync();
                allSP = await _SanPhamService.GetSanPhamsAsync();
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
            try
            {
                if (cbbLoai.SelectedValue == null) return;

                int selectedLoaiId = Convert.ToInt32(cbbLoai.SelectedValue);

                List<SanPham> filteredProducts;

                if (selectedLoaiId == 0)
                {
                    // Nếu chọn “Tất cả loại” → hiển thị toàn bộ sản phẩm + “Tất cả”
                    filteredProducts = new List<SanPham>(_allProducts);

                    filteredProducts.Insert(0, new SanPham
                    {
                        MaSP = 0,
                        TenSP = "Tất cả"
                    });
                }
                else
                {
                    // Nếu chọn 1 loại cụ thể → chỉ hiển thị sản phẩm thật, KHÔNG thêm “Tất cả”
                    filteredProducts = _allProducts
                        .Where(sp => sp.MaLoai == selectedLoaiId)
                        .ToList();
                }

                // Cập nhật lại ComboBox sản phẩm
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
                dataGridView1.DataSource = dtThongKe;
                dtThongKe.Rows.Clear();
                cbbLoc.SelectedItem = "Tất Cả";

                // Lấy ngày bắt đầu và kết thúc
                DateTime tuNgay = dateFrom.Value.Date;
                DateTime denNgay = dateTo.Value.Date;

                // Kiểm tra hợp lệ
                if (denNgay < tuNgay)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!");
                    return;
                }

                // Gọi API để lấy danh sách doanh thu


                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu doanh thu.");
                    return;
                }

                // --- Lọc theo loại, sản phẩm, size ---
                int selectedLoai = Convert.ToInt32(cbbLoai.SelectedValue);
                int selectedSP = Convert.ToInt32(cbbSP.SelectedValue);
                int selectedSize = Convert.ToInt32(cbbSize.SelectedValue);

                if (selectedLoai != 0)
                {
                    var spIdsTheoLoai = allSP
                        .Where(sp => sp.MaLoai == selectedLoai)
                        .Select(sp => sp.MaSP)
                        .ToList();

                    list = list.Where(x => x.MaSP.HasValue && spIdsTheoLoai.Contains(x.MaSP.Value)).ToList();
                }

                if (selectedSP != 0)
                {
                    list = list.Where(x => x.MaSP == selectedSP).ToList();
                }

                if (selectedSize != 0)
                {
                    list = list.Where(x => x.MaSize == selectedSize).ToList();
                }

                // --- Lọc theo thời gian ---
                list = list.Where(x =>
                {
                    DateTime ngayItem = new DateTime(x.Nam, x.Thang, x.Ngay);
                    return ngayItem >= tuNgay && ngayItem <= denNgay;
                }).ToList();

                if (list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu phù hợp với bộ lọc.");
                    return;
                }

                // --- Hiển thị dữ liệu ---
                foreach (var item in list)
                {
                    var sp = await _SanPhamService.GetSanPhamsByIdAsync(item.MaSP.Value);
                    string tenSP = sp?.TenSP ?? "Không xác định";

                    var size = await _sizeService.GetSizeByIdAsync(item.MaSize.Value);
                    string tenSize = size?.TenSize ?? "Không xác định";

                    DateTime date = new DateTime(item.Nam, item.Thang, item.Ngay);
                    string thoiGian = date.ToString("dd/MM/yyyy");


                    DataRow row = dtThongKe.NewRow();

                    row["thoiGian"] = thoiGian;
                    row["sanPham"] = tenSP;
                    row["size1"] = tenSize;
                    row["soLuong"] = item.SLBan;
                    row["chiPhi"] = item.TongChiPhi;
                    row["doanhThu"] = item.TongDoanhThu;
                    row["loiNhuan"] = item.TongDoanhThu - item.TongChiPhi;
                    dataGridView1.Columns["size1"].Visible = true;
                    dataGridView1.Columns["thoiGian"].Visible = true;



                    dtThongKe.Rows.Add(row);
                }

                decimal tongChiPhi = 0, tongDoanhThu = 0, tongLoiNhuan = 0;
                foreach (DataRow row in dtThongKe.AsEnumerable())
                {
                    tongChiPhi += row.Field<decimal>("chiPhi");
                    tongDoanhThu += row.Field<decimal>("doanhThu");
                    tongLoiNhuan += row.Field<decimal>("loiNhuan");
                }

                txtChiPhi.Text = tongChiPhi.ToString("N0");
                txtDoanhThu.Text = tongDoanhThu.ToString("N0");
                txtLoiNhuan.Text = tongLoiNhuan.ToString("N0");

                tableLayoutPanel2.ColumnStyles[1].SizeType = SizeType.Percent;
                tableLayoutPanel2.ColumnStyles[1].Width = 14.29f;

                tableLayoutPanel2.ColumnStyles[2].SizeType = SizeType.Percent;
                tableLayoutPanel2.ColumnStyles[2].Width = 14.29f;
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

            // --- Bước 1: Gộp dữ liệu theo sản phẩm ---
            var tongHop = dtThongKe.AsEnumerable()
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

            // --- Bước 2: Chuyển thành DataTable để hiển thị ---
            DataTable dtGop = new DataTable();

            dtGop.Columns.Add("thoiGian", typeof(string));
            dtGop.Columns.Add("sanPham", typeof(string));
            dtGop.Columns.Add("size1", typeof(string));
            dtGop.Columns.Add("soLuong", typeof(int));
            dtGop.Columns.Add("chiPhi", typeof(decimal));
            dtGop.Columns.Add("doanhThu", typeof(decimal));
            dtGop.Columns.Add("loiNhuan", typeof(decimal));
            dataGridView1.Columns["size1"].Visible = false;
            dataGridView1.Columns["thoiGian"].Visible = false;

            foreach (var item in tongHop)
            {
                dtGop.Rows.Add("", item.TenSP, "", item.TongSoLuong, item.TongChiPhi, item.TongDoanhThu, item.LoiNhuan);
            }

            // --- Bước 3: Tạo sortExpression dựa theo lựa chọn ---
            string sortExpression = "";
            string tieuChi = cbbLoc.SelectedItem?.ToString() ?? "";


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
                    loadDataGridView();
                    return;
            }

            // --- Bước 4: Áp dụng DataView để sắp xếp ---
            DataView dv = dtGop.DefaultView;
            dv.Sort = sortExpression;


            // --- Bước 5: Gán vào DataGridView ---
            dataGridView1.DataSource = dv.ToTable();
            decimal tongChiPhi = 0, tongDoanhThu = 0, tongLoiNhuan = 0;

            foreach (DataRow row in dv.ToTable().Rows)
            {
                tongChiPhi += row.Field<decimal>("chiPhi");
                tongDoanhThu += row.Field<decimal>("doanhThu");
                tongLoiNhuan += row.Field<decimal>("loiNhuan");
            }

            txtChiPhi.Text = tongChiPhi.ToString("N0");
            txtDoanhThu.Text = tongDoanhThu.ToString("N0");
            txtLoiNhuan.Text = tongLoiNhuan.ToString("N0");
            tableLayoutPanel2.ColumnStyles[1].Width = 0;
            tableLayoutPanel2.ColumnStyles[2].Width = 0;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbbSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
