using MilkTea.Client.Forms.ChildForm_Import;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;

namespace MilkTea.Client.Forms
{
    public partial class ImportForm : Form
    {
        private readonly PhieuNhapService _phieuNhapService;
        private readonly NhanVienService _nhanVienService;
        private readonly NhaCungCapService _nhaCungCapService;
        private List<NhanVien> _cachedNhanViens;
        private List<NhaCungCap> _cachedNhaCungCaps;

        public ImportForm()
        {
            InitializeComponent();
            _phieuNhapService = new PhieuNhapService();
            _nhanVienService = new NhanVienService();
            _nhaCungCapService = new NhaCungCapService();
            InitializeSearchComboBox();
        }

        private void InitializeSearchComboBox()
        {
            //Khởi tạo ComboBox với các cột tìm kiếm
            cbo_timkiemtheo_PN.Items.AddRange(new object[] { "Ngày Nhập", "Số Lượng", "Nhà Cung Cấp", "Tên Nhân Viên", "Tổng Tiền" });
            cbo_timkiemtheo_PN.SelectedIndex = 0; // Chọn mục đầu tiên làm mặc định
        }

        private void ApplySearchFilter()
        {
            txt_TimkiemPN_PN_TextChanged(txt_TimkiemPN_PN, EventArgs.Empty);
        }

        private async void ImportForm_Load(object sender, EventArgs e)
        {
            await LoadPhieuNhaps();

            //Bật tắt các nút theo quyền
            roundedButton1.Visible = Session.HasPermission("Thêm phiếu nhập");
            roundedButton2.Visible = Session.HasPermission("Nhập excel phiếu nhập");
            xoa_Tb_iPort.Visible = Session.HasPermission("Xóa phiếu nhập");
        }


        private async void roundedButton1_Click_1(object sender, EventArgs e)
        {
            using (var form = new ImportForm_Add(this))
            {
                if (form.ShowDialog() == DialogResult.OK && form.ResultPhieuNhap != null)
                {
                    var pn = form.ResultPhieuNhap;

                    // Lấy tên NV và NCC từ cache (nếu chưa có thì load 1 lần)
                    if (_cachedNhanViens == null) _cachedNhanViens = await _nhanVienService.GetNhanVienAsync();
                    if (_cachedNhaCungCaps == null) _cachedNhaCungCaps = await _nhaCungCapService.GetNhaCungCapAsync();

                    var nhanvien = _cachedNhanViens.Find(n => n.MaNV == pn.MaNV);
                    var nhacungcap = _cachedNhaCungCaps.Find(n => n.MaNCC == pn.MaNCC);

                    // Thêm trực tiếp vào Grid
                    int rowIndex = dGV_phieuNhap.Rows.Add();
                    dGV_phieuNhap.Rows[rowIndex].Cells["maPhieuNhap_Tb_iPort"].Value = pn.MaPN;
                    dGV_phieuNhap.Rows[rowIndex].Cells["ngayNhap_Tb_iPort"].Value = pn.NgayNhap?.ToString("dd/MM/yyyy");
                    dGV_phieuNhap.Rows[rowIndex].Cells["soLuong_Tb_iPort"].Value = pn.SoLuong;
                    dGV_phieuNhap.Rows[rowIndex].Cells["nhaCungCap_Tb_iPort"].Value = nhacungcap?.TenNCC ?? "N/A";
                    dGV_phieuNhap.Rows[rowIndex].Cells["tenNVN_Tb_iPort"].Value = nhanvien?.TenNV ?? "N/A";
                    dGV_phieuNhap.Rows[rowIndex].Cells["tongTien_Tb_iPort"].Value = pn.TongTien;

                    // Áp dụng bộ lọc tìm kiếm (nếu đang tìm)
                    ApplySearchFilter();
                }
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu hiển thị
            var visibleRows = dGV_phieuNhap.Rows.Cast<DataGridViewRow>().Where(r => r.Visible).ToList();
            if (!visibleRows.Any())
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Xuất danh sách phiếu nhập ra Excel";
                saveDialog.FileName = $"PhieuNhap_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add("Phiếu Nhập");

                        // === TIÊU ĐỀ CHÍNH ===
                        ws.Cell(1, 1).Value = "DANH SÁCH PHIẾU NHẬP";
                        var titleRange = ws.Range("A1:F1");
                        titleRange.Merge();

                        var style = titleRange.Style;
                        style.Font.SetBold();
                        style.Font.FontSize = 18;
                        style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                        style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(0, 102, 204);
                        style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                        style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Center;

                        ws.Row(1).Height = 40;
                        // === THÔNG TIN BỔ SUNG ===
                        ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                        ws.Cell(3, 1).Value = $"Người xuất: {Session.CurrentUser?.TenTaiKhoan ?? "Không xác định"}";
                        ws.Range("A2:A3").Style.Font.Italic = true;

                        // === TIÊU ĐỀ CỘT (dòng 5) ===
                        string[] headers = { "Mã Phiếu", "Ngày Nhập", "Số Lượng", "Nhà Cung Cấp", "Nhân Viên", "Tổng Tiền" };
                        for (int i = 0; i < headers.Length; i++)
                            ws.Cell(5, i + 1).Value = headers[i];

                        var headerRange = ws.Range("A5:F5");
                        headerRange.Style
                            .Font.SetBold()
                            .Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGray)
                            .Alignment.SetHorizontal(ClosedXML.Excel.XLAlignmentHorizontalValues.Center)
                            .Border.SetInsideBorder(ClosedXML.Excel.XLBorderStyleValues.Thin);

                        // === XUẤT DỮ LIỆU ===
                        int row = 6;
                        foreach (DataGridViewRow dgvRow in visibleRows)
                        {
                            ws.Cell(row, 1).Value = dgvRow.Cells["maPhieuNhap_Tb_iPort"].Value?.ToString();

                            var ngayNhapStr = dgvRow.Cells["ngayNhap_Tb_iPort"].Value?.ToString();
                            if (DateTime.TryParseExact(ngayNhapStr, "dd/MM/yyyy", null,
                                System.Globalization.DateTimeStyles.None, out DateTime ngayNhap))
                            {
                                ws.Cell(row, 2).Value = ngayNhap;
                                ws.Cell(row, 2).Style.DateFormat.Format = "dd/MM/yyyy";
                            }
                            else
                            {
                                ws.Cell(row, 2).Value = ngayNhapStr;
                            }

                            if (int.TryParse(dgvRow.Cells["soLuong_Tb_iPort"].Value?.ToString(), out int soLuong))
                                ws.Cell(row, 3).Value = soLuong;

                            ws.Cell(row, 4).Value = dgvRow.Cells["nhaCungCap_Tb_iPort"].Value?.ToString();
                            ws.Cell(row, 5).Value = dgvRow.Cells["tenNVN_Tb_iPort"].Value?.ToString();

                            if (decimal.TryParse(dgvRow.Cells["tongTien_Tb_iPort"].Value?.ToString(), out decimal tongTien))
                            {
                                ws.Cell(row, 6).Value = tongTien;
                                ws.Cell(row, 6).Style.NumberFormat.Format = "#,##0";
                            }

                            row++;
                        }

                        // === ĐỊNH DẠNG BẢNG DỮ LIỆU ===
                        var dataRange = ws.Range($"A5:F{row - 1}");
                        dataRange.Style
                            .Border.SetInsideBorder(ClosedXML.Excel.XLBorderStyleValues.Thin)
                            .Border.SetOutsideBorder(ClosedXML.Excel.XLBorderStyleValues.Medium);

                        // Căn chỉnh cột
                        ws.Column(3).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                        ws.Column(6).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Right;

                        // Tự động điều chỉnh cột
                        ws.Columns(1, 6).AdjustToContents();

                        // Cố định tiêu đề
                        ws.SheetView.FreezeRows(4);

                        // Lưu file
                        workbook.SaveAs(saveDialog.FileName);
                    }

                    MessageBox.Show($"Xuất Excel thành công!\n{saveDialog.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Mở file Excel vừa xuất?", "Mở file",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất Excel:\n{ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dGV_phieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc chỉ số không hợp lệ
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dGV_phieuNhap.Columns[e.ColumnIndex].Name;

            try
            {
                // Lấy mã phiếu nhập từ cột ẩn hoặc cột mã
                var maPNCell = dGV_phieuNhap.Rows[e.RowIndex].Cells["maPhieuNhap_Tb_iPort"].Value;
                if (maPNCell == null || !int.TryParse(maPNCell.ToString(), out int maPN))
                {
                    MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Click vào cột "Thông Tin"
                if (columnName == "thongTin_Tb_iPort")
                {
                    using (var frm = new ImportForm_Info(maPN))
                    {
                        frm.ShowDialog();
                    }
                }

                // 2. Click vào cột "Xóa"
                else if (columnName == "xoa_Tb_iPort")
                {
                    var result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa phiếu nhập mã {maPN}?\n(Dữ liệu sẽ được ẩn và không thể hoàn tác dễ dàng)",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool success = await _phieuNhapService.SoftDeleteAsync(maPN);

                        if (success)
                        {
                            MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadPhieuNhaps(); 
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa phiếu nhập (có thể đã bị xóa trước đó).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task LoadPhieuNhaps()
        {
            try
            {
                var phieuNhaps = await _phieuNhapService.GetPhieuNhapsAsync();
                var nv = await _nhanVienService.GetNhanVienAsync();
                var ncc = await _nhaCungCapService.GetNhaCungCapAsync();

                dGV_phieuNhap.Rows.Clear();

                var phieuNhapsActive = phieuNhaps?.Where(pn => pn.TrangThai == 1).ToList();
                if (phieuNhapsActive != null && phieuNhapsActive.Any())
                {
                    foreach (var pn in phieuNhapsActive)
                    {
                        var nhanvien = nv.Find(n => n.MaNV == pn.MaNV);
                        var nhacungcap = ncc.Find(n => n.MaNCC == pn.MaNCC);
                        int rowIndex = dGV_phieuNhap.Rows.Add();
                        dGV_phieuNhap.Rows[rowIndex].Cells["maPhieuNhap_Tb_iPort"].Value = pn.MaPN;
                        dGV_phieuNhap.Rows[rowIndex].Cells["ngayNhap_Tb_iPort"].Value = pn.NgayNhap?.ToString("dd/MM/yyyy");
                        dGV_phieuNhap.Rows[rowIndex].Cells["soLuong_Tb_iPort"].Value = pn.SoLuong;
                        dGV_phieuNhap.Rows[rowIndex].Cells["nhaCungCap_Tb_iPort"].Value = nhacungcap.TenNCC;
                        dGV_phieuNhap.Rows[rowIndex].Cells["tenNVN_Tb_iPort"].Value = nhanvien.TenNV;
                        dGV_phieuNhap.Rows[rowIndex].Cells["tongTien_Tb_iPort"].Value = pn.TongTien;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phiếu nhập để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txt_TimkiemPN_PN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txt_TimkiemPN_PN.Text.Trim().ToLower();
                string selectedColumn = cbo_timkiemtheo_PN.SelectedItem?.ToString();

                // Xác định cột trong DataGridView để tìm kiếm
                string columnName;
                switch (selectedColumn)
                {
                    case "Ngày Nhập":
                        columnName = "ngayNhap_Tb_iPort";
                        break;
                    case "Số Lượng":
                        columnName = "soLuong_Tb_iPort";
                        break;
                    case "Tên Nhân Viên":
                        columnName = "tenNVN_Tb_iPort";
                        break;
                    case "Tổng Tiền":
                        columnName = "tongTien_Tb_iPort";
                        break;
                    case "Nhà Cung Cấp":
                        columnName = "NhaCungCap_Tb_iPort";
                        break;
                    default:
                        return;
                }

                int visibleRowCount = 0;
                // Lọc các hàng trong DataGridView

                foreach (DataGridViewRow row in dGV_phieuNhap.Rows)
                {
                    if (row.Cells[columnName].Value != null)
                    {
                        string cellValue = row.Cells[columnName].Value.ToString().ToLower();
                        // Hiển thị hàng nếu giá trị trong ô chứa chuỗi tìm kiếm
                        row.Visible = cellValue.Contains(searchValue);
                        if (row.Visible)
                        {
                            visibleRowCount++;
                        }
                    }
                    else
                    {
                        //row.Visible = false;
                        lblStatus_PN.ForeColor = Color.Red;
                        lblStatus_PN.Text = "Không tìm thấy kết quả phù hợp.";
                    }
                }
                if (visibleRowCount == 0)
                {
                    lblStatus_PN.ForeColor = Color.Red;
                    lblStatus_PN.Text = "Không tìm thấy kết quả tìm kiếm";
                }
                else
                {
                    lblStatus_PN.ForeColor = Color.Transparent;
                    lblStatus_PN.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
