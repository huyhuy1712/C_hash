using MilkTea.Client.Controls;
using MilkTea.Client.Forms.ChildForm_Import;
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
    public partial class ImportForm : Form
    {
        private readonly PhieuNhapService _phieuNhapService;
        private readonly NhanVienService _nhanVienService;
        public ImportForm()
        {
            InitializeComponent();
            _phieuNhapService = new PhieuNhapService();
            _nhanVienService = new NhanVienService();  
        }

        private async void ImportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách phiếu nhập từ service
                var phieuNhaps = await _phieuNhapService.GetPhieuNhapsAsync();

                // Kiểm tra nếu danh sách không rỗng
                if (phieuNhaps != null && phieuNhaps.Any())
                {
                    // Xóa hết hàng cũ trong DataGridView
                    dGV_phieuNhap.Rows.Clear();
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
                    // Xóa hết hàng nếu không có dữ liệu
                    dGV_phieuNhap.Rows.Clear();
                    MessageBox.Show("Không có dữ liệu phiếu nhập để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gọi API: " + ex.Message);
            }
        }

        private void add_Import_btn_Click(object sender, EventArgs e)
        {
            ImportForm_Add form = new ImportForm_Add();
            form.ShowDialog();
        }

        private void excel_Import_btn_Click(object sender, EventArgs e)
        {
            ImportForm_Info form = new ImportForm_Info();
            form.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc dòng không hợp lệ
            if (e.RowIndex < 0) return;

            // Kiểm tra cột được click
            if (dGV_phieuNhap.Columns[e.ColumnIndex].Name == "thongTin_Tb_iPort")
            {
                // Lấy dữ liệu của dòng được chọn
                string id = dGV_phieuNhap.Rows[e.RowIndex].Cells["maPhieuNhap_Tb_iPort"].Value?.ToString();
                // Mở form sửa (ví dụ FormEditAccount)
                using (var frm = new ImportForm_Info())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi form con đóng và bấm OK thì refresh lại grid
                    }
                }
            }
        }


        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            ImportForm_Add form = new ImportForm_Add();
            form.ShowDialog();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            ImportForm_Info form = new ImportForm_Info();
            form.ShowDialog();
        }
    }
}
