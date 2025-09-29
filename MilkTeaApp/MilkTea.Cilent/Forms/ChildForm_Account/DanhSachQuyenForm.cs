using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class DanhSachQuyenForm : Form
    {
        public DanhSachQuyenForm()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DanhSachQuyenForm_Load(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc dòng không hợp lệ
            if (e.RowIndex < 0) return;

            // Kiểm tra cột được click
            if (dataGridView1.Columns[e.ColumnIndex].Name == "sua")
            {
                // Lấy dữ liệu của dòng được chọn

                // Mở form sua quyen
                using (var frm = new EditQuyenForm())
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

                // Confirm xoa
                if (MessageBox.Show("Bạn Có Thật Sự Muốn Xóa?", "Are You Sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    //Xu ly xoa account

                }
            }
        }

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            var frm = new AddQuyenForm();
            frm.ShowDialog();
        }
    }
}
