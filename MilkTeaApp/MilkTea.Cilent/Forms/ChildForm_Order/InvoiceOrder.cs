using MilkTea.Client.Models;
using MilkTea.Client.Services;
using MilkTea.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class InvoiceOrder : Form
    {
        public string NhanVien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string MaMay { get; set; }
        public List<InvoiceItem> SanPhamDaMua { get; set; } = new List<InvoiceItem>();
        public decimal TongCong { get; set; }

        public event EventHandler ReloadRequested;


        public InvoiceOrder()
        {
            InitializeComponent();
            this.Load += InvoiceOrder_Load;
        }

        private void InvoiceOrder_Load(object sender, EventArgs e)
        {
            // ====== Gán dữ liệu tổng ======
            ten_thu_ngan_label.Text = NhanVien;
            pttt_label.Text = PhuongThucThanhToan;
            mamay_label.Text = MaMay;
            total_label.Text = $"{TongCong:N0} VND";
            // Ngày hiện tại
            order_date_label.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // ====== Tạo panel chứa từng hóa đơn (item_panel) ======
            var item_panel = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoScroll = false,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 0, 10),
                BackColor = Color.FromArgb(245, 245, 245) // nền sáng nhẹ, phân biệt với form
            };

            // ====== Tạo bảng chứa các dòng sản phẩm ======
            var tableLayout = new TableLayoutPanel
            {
                ColumnCount = 8,
                AutoSize = true,
                Dock = DockStyle.Top,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White
            };

            // ====== Định nghĩa tỉ lệ cột ======
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24)); // Tên SP
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6));  // Size
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6));  // SL
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26)); // Topping
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8));  // Tổng TP
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8));  // Đơn giá
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8));  // Tiền giảm
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14)); // Tổng tiền

            // ====== Style chung ======
            Font fontNormal = new Font("Segoe UI", 10, FontStyle.Regular);
            Font fontBold = new Font("Segoe UI", 10, FontStyle.Bold);
            Color textColor = Color.Black;
            Color grayText = Color.DimGray;

            // ====== Tạo dòng tiêu đề ======
            string[] headers = { "Tên SP", "Size", "SL", "Topping", "Tổng Tp", "Đ.Giá", "T.Giam", "Tổng Tiền" };
            for (int i = 0; i < headers.Length; i++)
            {
                var headerLabel = new Label
                {
                    Text = headers[i],
                    Font = fontBold,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(230, 230, 230)
                };
                tableLayout.Controls.Add(headerLabel, i, 0);
            }

            // ====== Tạo các dòng sản phẩm ======
            int rowIndex = 1;
            foreach (var item in SanPhamDaMua)
            {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // --- Tên SP ---
                var lblTenSP = new Label
                {
                    Text = item.TenSP,
                    Font = fontNormal,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(8, 0, 0, 0)
                };

                // --- Size ---
                var lblSize = new Label
                {
                    Text = item.Size,
                    Font = fontNormal,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // --- SL ---
                var lblSL = new Label
                {
                    Text = item.SoLuong.ToString(),
                    Font = fontNormal,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // --- Topping ---
                var lblTopping = new TextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = grayText,
                    BackColor = Color.White,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5, 3, 5, 3),
                    ScrollBars = ScrollBars.None,
                    TabStop = false,
                    Cursor = Cursors.Default,
                    ShortcutsEnabled = false,
                    WordWrap = true
                };
                lblTopping.GotFocus += (s, ev) => ((TextBox)s).Parent.Focus();

                lblTopping.Text = (item.Toppings != null && item.Toppings.Any())
                    ? string.Join(Environment.NewLine, item.Toppings.Select(t => $"{t.gia:N0} ({t.SL}%) {t.ten}"))
                    : "Không có";

                //  Đợi control render xong, rồi đo kích thước thật
                lblTopping.HandleCreated += (s, ev) =>
                {
                    var tb = (TextBox)s;

                    // Đếm số dòng thực tế trong topping
                    int soDong = tb.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

                    // Chiều cao = số dòng * (chiều cao dòng chữ) + padding
                    int lineHeight = TextRenderer.MeasureText("A", tb.Font).Height;
                    tb.Height = (soDong * lineHeight) + 8; // 8px padding tổng (trên + dưới)
                };



                // --- Tổng TP ---
                var lblTongTp = new Label
                {
                    Text = item.Toppings.Sum(t => t.gia).ToString("N0"),
                    Font = fontNormal,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 8, 0)
                };

                // --- Đơn giá ---
                var lblDonGia = new Label
                {
                    Text = item.DonGia.ToString("N0"),
                    Font = fontNormal,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 8, 0)
                };

                // --- Tiền giảm ---
                var lblTienGiam = new Label
                {
                    Text = item.TienGiam.ToString("N0"),
                    Font = fontNormal,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 8, 0)
                };

                // --- Tổng tiền ---
                var lblTongTien = new Label
                {
                    Text = item.TongTien.ToString("N0"),
                    Font = fontBold,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 8, 0),
                    ForeColor = Color.Black
                };

                // --- Thêm dòng vào bảng ---
                tableLayout.Controls.Add(lblTenSP, 0, rowIndex);
                tableLayout.Controls.Add(lblSize, 1, rowIndex);
                tableLayout.Controls.Add(lblSL, 2, rowIndex);
                tableLayout.Controls.Add(lblTopping, 3, rowIndex);
                tableLayout.Controls.Add(lblTongTp, 4, rowIndex);
                tableLayout.Controls.Add(lblDonGia, 5, rowIndex);
                tableLayout.Controls.Add(lblTienGiam, 6, rowIndex);
                tableLayout.Controls.Add(lblTongTien, 7, rowIndex);

                rowIndex++;
            }

            // ====== Add bảng vào panel và panel vào form ======
            item_panel.Controls.Add(tableLayout);
            order_detail_panel.Controls.Add(item_panel);
            item_panel.BringToFront();
        }
        private void InvoiceOrder_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void order_date_label_Click(object sender, EventArgs e)
        {

        }
        private async void import_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var donHangService = new DonHangService();
                var nhanVienService = new NhanVienService();
                var buzzerService = new buzzerService();
                var nguyenLieuService = new NguyenLieuService();
                var congThucService = new CTCongThucService(); 
                var phieuNhapService = new PhieuNhapService();
                var chiTietPhieuNhapService = new ChiTietPhieuNhapService();

                var nhanVienId = await nhanVienService.GetMaNVByTenAsync(ten_thu_ngan_label.Text);
                var buzzerID = await buzzerService.GetMaMayBySoHieuAsync(mamay_label.Text);

                var donHang = new DonHang
                {
                    MaNV = nhanVienId,
                    NgayLap = DateTime.Now,
                    GioLap = DateTime.Now.TimeOfDay,
                    TrangThai = 0,
                    MaBuzzer = buzzerID,
                    PhuongThucThanhToan = PhuongThucThanhToan == "Tiền mặt" ? 0 : 1,
                    TongGia = TongCong
                };

                await donHangService.AddDonHangAsync(donHang);
                var listDH = await donHangService.GetAllDonHangAsync();
                int maDH = listDH.Max(dh => dh.MaDH);


                foreach (var item in SanPhamDaMua)
                {
                    var chiTiet = new ChiTietDonHang
                    {
                        MaDH = maDH,
                        MaSP = item.MaSP,
                        MaSize = item.SizeId,
                        SoLuong = item.SoLuong,
                        GiaVon = item.DonGia,
                        TongGia = item.TongTien,
                        Toppings = item.Toppings.Select(tp => new ctdonhang_topping
                        {
                            MaNL = tp.MaNL,
                            SL = tp.SL
                        }).ToList()
                    };

                    await donHangService.AddChiTietDonHangAsync(chiTiet);

                    //  1. Trừ nguyên liệu chính theo công thức
                    var congThuc = await congThucService.GetChiTietCongThucTheoSPAsync(item.MaSP);
                    if (congThuc != null && congThuc.Count > 0)
                    {
                        int tongSLTopping = item.Toppings?.Sum(tp => tp.SL) ?? 0;

                        int soLuongCongThem = 0;
                        if (tongSLTopping >= 75)
                            soLuongCongThem = 10;
                        else if (tongSLTopping >= 50)
                            soLuongCongThem = 5;
                        else if (tongSLTopping >= 25)
                            soLuongCongThem = 3;

                        foreach (var nl in congThuc)
                        {
                            var listCTPN = await chiTietPhieuNhapService.GetByMaNLAsync(nl.MaNL);

                            // Kiểm tra danh sách rỗng trước khi truy cập
                            if (listCTPN.Any())
                            {
                                var ctpnCuoi = listCTPN.Last(); // hoặc .OrderBy(x => x.MaCTPN).Last() nếu cần sắp xếp
                                var maPN = ctpnCuoi.MaPN;

                                // Tìm phiếu nhập qua MaPN
                                var phieuNhapList = await phieuNhapService.SearchAsync("MaPN", maPN.ToString());

                                if (phieuNhapList.Any())
                                {
                                    var phieuNhap = phieuNhapList.First(); // lấy phiếu nhập đầu tiên (hoặc theo nhu cầu)
                                    DateTime? ngayNhap = phieuNhap.NgayNhap;
                                    if (ngayNhap.HasValue)
                                    {
                                        int thangHienTai = DateTime.Now.Month;
                                        int namHienTai = DateTime.Now.Year;

                                        if (!(ngayNhap.Value.Month == thangHienTai && ngayNhap.Value.Year == namHienTai))
                                        {
                                            MessageBox.Show($"Chưa nhập nguyên liệu '{nl.TenNguyenLieu}' để pha {item.TenSP}.",
                                                 "Thiếu nguyên liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Chưa nhập nguyên liệu '{nl.TenNguyenLieu}' để pha {item.TenSP}.",
                                                 "Thiếu nguyên liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                                int soLuongTru = (nl.SoLuongCanDung * item.SoLuong) + soLuongCongThem;

                            bool ok = await nguyenLieuService.TruNguyenLieuAsync(nl.MaNL, soLuongTru);
                            if (!ok)
                            {
                                MessageBox.Show($"Không đủ nguyên liệu '{nl.TenNguyenLieu}' để pha {item.TenSP}.",
                                                "Thiếu nguyên liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }


                    //  2. Trừ topping
                    if (item.Toppings != null && item.Toppings.Count > 0)
                    {
                        foreach (var tp in item.Toppings)
                        {
                            bool ok = await nguyenLieuService.TruNguyenLieuAsync(tp.MaNL, tp.SL);
                            if (!ok)
                            {
                                MessageBox.Show($"Thiếu topping '{tp.ten}'.",
                                                "Thiếu topping", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // 3. Cập nhật buzzer
                    await buzzerService.UpdateTrangThaiAsync(mamay_label.Text, 0);
                }

                MessageBox.Show(" Xuất đơn thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReloadRequested?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Lỗi khi xuất đơn: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

public class InvoiceItem
{
    public int MaSP { get; set; }      
    public int SizeId { get; set; }   
    public string TenSP { get; set; }
    public string Size { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal TienGiam { get; set; }
    public decimal TongTien { get; set; }
    public List<Topping> Toppings { get; set; } = new List<Topping>();
}
