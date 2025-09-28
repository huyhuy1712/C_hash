using MilkTea.Client.Forms.ChildForm_Import;
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
    public partial class ImportForm : Form
    {
        public ImportForm()
        {
            InitializeComponent();
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.Add();


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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "thongTin_Tb_iPort")
            {
                // Lấy dữ liệu của dòng được chọn
                string id = dataGridView1.Rows[e.RowIndex].Cells["maPhieuNhap_Tb_iPort"].Value?.ToString();
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

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            ImportForm_Add importForm_Add = new ImportForm_Add();
            importForm_Add.ShowDialog();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            ImportForm_Info importForm_Info = new ImportForm_Info();    
            importForm_Info.ShowDialog();
        }
    }
}
