using MilkTea.Client.Forms.ChildForm_Account;
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
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.CellClick += dataGridView1_CellClick;
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
    }
}
