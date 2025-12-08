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
        private readonly ChiTietPhieuNhapService _chiTietPhieuNhapService;
        private readonly NguyenLieuService _nguyenLieuService;
        private List<NhanVien> _cachedNhanViens;
        private List<NhaCungCap> _cachedNhaCungCaps;

        public ImportForm()
        {
            InitializeComponent();
            _phieuNhapService = new PhieuNhapService();
            _nhanVienService = new NhanVienService();
            _nhaCungCapService = new NhaCungCapService();
            _chiTietPhieuNhapService = new ChiTietPhieuNhapService();
            _nguyenLieuService = new NguyenLieuService();
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
                    dGV_phieuNhap.Rows[rowIndex].Cells["trangThaiNhap_Tb_iPort"].Value = false;

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
                else if (columnName == "sua_Tb_iPort")
                {
                    var trangThaiCell = dGV_phieuNhap.Rows[e.RowIndex].Cells["trangThaiNhap_Tb_iPort"];
                    if (trangThaiCell is DataGridViewCheckBoxCell checkCell && (bool)checkCell.Value)
                    {
                        MessageBox.Show("Chỉ có thể sửa phiếu nhập khi chưa nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (var form = new ImportForm_Update(maPN))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            await LoadPhieuNhaps();
                        }
                    }
                }
                else if (columnName == "trangThaiNhap_Tb_iPort" && e.ColumnIndex == dGV_phieuNhap.Columns["trangThaiNhap_Tb_iPort"].Index)
                {
                    var checkCell = dGV_phieuNhap.Rows[e.RowIndex].Cells["trangThaiNhap_Tb_iPort"] as DataGridViewCheckBoxCell;
                    bool isChecked = checkCell.Value is true;

                    var editButtonCell = dGV_phieuNhap.Rows[e.RowIndex].Cells["sua_Tb_iPort"] as DataGridViewImageCell;
                    editButtonCell.ReadOnly = !isChecked;
                    dGV_phieuNhap.InvalidateCell(editButtonCell);
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

                // Chỉ hiển thị phiếu chưa xóa (TrangThai = 1 hoặc 2)
                var activePhieuNhaps = phieuNhaps?
                    .Where(p => p.TrangThai == 1 || p.TrangThai == 2)
                    .ToList();

                if (activePhieuNhaps == null || !activePhieuNhaps.Any())
                {
                    MessageBox.Show("Không có phiếu nhập nào đang hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var pn in activePhieuNhaps)
                {
                    var nhanvien = nv.Find(n => n.MaNV == pn.MaNV);
                    var nhacungcap = ncc.Find(n => n.MaNCC == pn.MaNCC);

                    int rowIndex = dGV_phieuNhap.Rows.Add();
                    var row = dGV_phieuNhap.Rows[rowIndex];

                    row.Cells["maPhieuNhap_Tb_iPort"].Value = pn.MaPN;
                    row.Cells["ngayNhap_Tb_iPort"].Value = pn.NgayNhap?.ToString("dd/MM/yyyy");
                    row.Cells["soLuong_Tb_iPort"].Value = pn.SoLuong;
                    row.Cells["nhaCungCap_Tb_iPort"].Value = nhacungcap?.TenNCC ?? "N/A";
                    row.Cells["tenNVN_Tb_iPort"].Value = nhanvien?.TenNV ?? "N/A";
                    row.Cells["tongTien_Tb_iPort"].Value = pn.TongTien;

                    bool daNhap = pn.TrangThai == 1;
                    row.Cells["trangThaiNhap_Tb_iPort"].Value = daNhap;
                }

                ApplySearchFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                foreach (DataGridViewRow row in dGV_phieuNhap.Rows)
                {
                    if (row.Cells[columnName].Value != null)
                    {
                        string cellValue = row.Cells[columnName].Value.ToString().ToLower();
                        row.Visible = cellValue.Contains(searchValue);
                        if (row.Visible)
                        {
                            visibleRowCount++;
                        }
                    }
                    else
                    {
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

        private async void dGV_phieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dGV_phieuNhap.Columns[e.ColumnIndex].Name != "trangThaiNhap_Tb_iPort") return;

            dGV_phieuNhap.EndEdit();
            var checkCell = dGV_phieuNhap.Rows[e.RowIndex].Cells["trangThaiNhap_Tb_iPort"] as DataGridViewCheckBoxCell;
            bool isChecked = (bool)checkCell.Value;
            int maPN = Convert.ToInt32(dGV_phieuNhap.Rows[e.RowIndex].Cells["maPhieuNhap_Tb_iPort"].Value);

            if (isChecked)
            {
                var confirm = MessageBox.Show(
                    $"Xác nhận ĐÃ NHẬN HÀNG cho phiếu nhập mã {maPN}?\n\n" +
                    "Sau khi xác nhận:\n" +
                    "• Không thể sửa phiếu nhập nữa\n" +
                    "• Tồn kho sẽ được cập nhật ngay lập tức",
                    "Xác nhận nhập kho",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                {
                    checkCell.Value = false;
                    dGV_phieuNhap.InvalidateCell(checkCell);
                    return;
                }

                try
                {
                    // Lấy chi tiết phiếu nhập
                    var chiTiets = await _chiTietPhieuNhapService.GetByMaPNAsync(maPN);
                    bool allSuccess = true;

                    foreach (var ct in chiTiets)
                    {
                        if(ct.DonViTinh == "Kg")
                        {
                            ct.SoLuong = ct.SoLuong * 1000;
                            ct.DonGiaNhap = ct.DonGiaNhap / 1000;
                        }
                        if(ct.DonViTinh == "Lít")
                        {
                            ct.SoLuong = ct.SoLuong * 1000;
                            ct.DonGiaNhap = ct.DonGiaNhap / 1000;
                        }

                        var nguyenLieu = await _nguyenLieuService.GetAll();
                        var nl = nguyenLieu.Where(x => x.MaNL == ct.MaNguyenLieu).Single();
                        

                        var giaMoi = (nl.GiaBan * nl.SoLuong + ct.DonGiaNhap * ct.SoLuong) / (nl.SoLuong + ct.SoLuong);

                        // Cộng tồn kho
                        var congSuccess = await _nguyenLieuService.CongNguyenLieuAsync(ct.MaNguyenLieu, ct.SoLuong);
                        // Cập nhật giá bán mới nhất
                        var giaSuccess = await _nguyenLieuService.CapNhatGiaBanMoiNhatAsync(ct.MaNguyenLieu, giaMoi);

                        if (!congSuccess || !giaSuccess)
                            allSuccess = false;
                    }

                    if (allSuccess)
                    {
                        // Cập nhật trạng thái phiếu nhập = 1 (Đã nhập)
                        await _phieuNhapService.CapNhatTrangThaiAsync(maPN, 1);
                        MessageBox.Show("Xác nhận nhập hàng thành công! Tồn kho đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        checkCell.Value = false;
                        MessageBox.Show("Có lỗi khi cập nhật tồn kho. Đã hủy xác nhận.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    checkCell.Value = false;
                    dGV_phieuNhap.InvalidateCell(checkCell);
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu bỏ tick (rất hiếm khi dùng) → có thể thêm cảnh báo không cho bỏ
                MessageBox.Show("Không thể bỏ xác nhận nhập hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkCell.Value = true;
            }

            dGV_phieuNhap.InvalidateCell(checkCell);
        }
    }
}
