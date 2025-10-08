using MilkTea.Client.Forms.ChildForm_Account;
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

namespace MilkTea.Client.Forms
{
    public partial class AccountForm : Form
    {
        private readonly TaiKhoanService _taiKhoanService;
        private readonly NhanVienService _nhanVienService;
        public AccountForm()
        {
            InitializeComponent();
            _taiKhoanService = new();
            _nhanVienService = new();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellClick;
            LoadData();
        }

        private void btnThemAccount_Click(object sender, EventArgs e)
        {
            AddAccountForm themTaiKhoan = new AddAccountForm();
            themTaiKhoan.ShowDialog();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc dòng không hợp lệ
            if (e.RowIndex < 0) return;

            // Kiểm tra cột được click
            if (dataGridView1.Columns[e.ColumnIndex].Name == "sua")
            {
                // Lấy dữ liệu của dòng được chọn
                string id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value?.ToString();
                string taiKhoan = dataGridView1.Rows[e.RowIndex].Cells["taiKhoan"].Value?.ToString();

                // Mở form sửa (ví dụ FormEditAccount)
                using (var frm = new EditAccountForm())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi form con đóng và bấm OK thì refresh lại grid
                    }
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "chiTiet")
            {
                // Lấy dữ liệu của dòng được chọn
                string id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value?.ToString();
                string taiKhoan = dataGridView1.Rows[e.RowIndex].Cells["taiKhoan"].Value?.ToString();

                // Mở form xem
                using (var frm = new ViewAccountForm())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi form con đóng và bấm OK thì refresh lại grid
                    }
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "xoa")
            {
                // Lấy dữ liệu của dòng được chọn
                string id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value?.ToString();
                string taiKhoan = dataGridView1.Rows[e.RowIndex].Cells["taiKhoan"].Value?.ToString();

                // Confirm xoa
                if (MessageBox.Show("Bạn Có Thật Sự Muốn Xóa?", "Are You Sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    //Xu ly xoa account

                }
            }
        }

        private void btnDanhSachQuyen_Click(object sender, EventArgs e)
        {
            var frm = new DanhSachQuyenForm();
            frm.ShowDialog();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            // Code làm mới dữ liệu trong DataGridView
            dataGridView1.Rows.Clear();
            // Giả sử bạn có một phương thức LoadData() để tải lại dữ liệu
            await LoadData();
        }

        private async Task LoadData()
        {
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Text = "🔄 Đang tải dữ liệu...";

            try
            {
                var listTaiKhoan = await _taiKhoanService.GetAccountsAsync();
                var listNhanVien = await _nhanVienService.GetNhanVienAsync();

                if (listTaiKhoan != null && listTaiKhoan.Any())
                {
                    dataGridView1.Rows.Clear();

                    foreach (var tk in listTaiKhoan)
                    {
                        var nv = listNhanVien.FirstOrDefault(n => n.MaTK == tk.MaTK);
                        int rowIndex = dataGridView1.Rows.Add();

                        dataGridView1.Rows[rowIndex].Cells["ID"].Value = tk.MaTK;
                        dataGridView1.Rows[rowIndex].Cells["taiKhoan"].Value = tk.TenTaiKhoan;
                        dataGridView1.Rows[rowIndex].Cells["hoVaTen"].Value = nv?.TenNV ?? "Chưa có nhân viên";
                        dataGridView1.Rows[rowIndex].Cells["trangThai"].Value = tk.TrangThai == 1 ? "Hoạt động" : "Khóa";
                        dataGridView1.Rows[rowIndex].Cells["ngayTao"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                        dataGridView1.Rows[rowIndex].Cells["quyen"].Value = tk.MaQuyen;
                    }
                    lblStatus.ForeColor = Color.ForestGreen;
                    lblStatus.Text = $"✅ Đã tải {listTaiKhoan.Count} tài khoản.";
                }

                else
                {
                    dataGridView1.Rows.Clear();
                    lblStatus.ForeColor = Color.DarkOrange;
                    lblStatus.Text = "⚠️ Không có dữ liệu tài khoản để hiển thị.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
    }
}
