using MilkTea.Client.Forms.ChildForm_Import;
using MilkTea.Client.Services;

namespace MilkTea.Client.Forms
{
    public partial class ImportForm : Form
    {
        private readonly PhieuNhapService _phieuNhapService;
        private readonly NhanVienService _nhanVienService;
        public ImportForm()
        {
            InitializeComponent();
            _phieuNhapService = new PhieuNhapService();
            _nhanVienService = new NhanVienService();
            InitializeSearchComboBox();
        }

        private void InitializeSearchComboBox()
        {
            //Khởi tạo ComboBox với các cột tìm kiếm
            cbo_timkiemtheo_PN.Items.AddRange(new object[] { "Ngày Nhập", "Số Lượng", "Tên Nhân Viên", "Tổng Tiền" });
            cbo_timkiemtheo_PN.SelectedIndex = 0; // Chọn mục đầu tiên làm mặc định
        }


        private async void ImportForm_Load(object sender, EventArgs e)
        {
            await LoadPhieuNhaps();
        }


        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            ImportForm_Add form = new ImportForm_Add(this);
            form.ShowDialog();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {

        }

        private void dGV_phieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dGV_phieuNhap.Columns[e.ColumnIndex].Name == "thongTin_Tb_iPort")
            {
                string maPN = dGV_phieuNhap.Rows[e.RowIndex].Cells["maPhieuNhap_Tb_iPort"].Value?.ToString();

                if (!string.IsNullOrEmpty(maPN) && int.TryParse(maPN, out int maPNValue))
                {
                    using (var frm = new ImportForm_Info(maPNValue))
                    {
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phiếu nhập hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task LoadPhieuNhaps()
        {
            try
            {
                var phieuNhaps = await _phieuNhapService.GetPhieuNhapsAsync();
                dGV_phieuNhap.Rows.Clear();
                if (phieuNhaps != null && phieuNhaps.Any())
                {
                    foreach (var pn in phieuNhaps)
                    {
                        var nhanvien = await _nhanVienService.GetByMaNV(pn.MaNV);
                        int rowIndex = dGV_phieuNhap.Rows.Add();
                        dGV_phieuNhap.Rows[rowIndex].Cells["maPhieuNhap_Tb_iPort"].Value = pn.MaPN;
                        dGV_phieuNhap.Rows[rowIndex].Cells["ngayNhap_Tb_iPort"].Value = pn.NgayNhap?.ToString("dd/MM/yyyy");
                        dGV_phieuNhap.Rows[rowIndex].Cells["soLuong_Tb_iPort"].Value = pn.SoLuong;
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
