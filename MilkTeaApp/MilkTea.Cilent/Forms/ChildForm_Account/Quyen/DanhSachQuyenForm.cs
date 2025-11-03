using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Presenters;
using System.Diagnostics;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class DanhSachQuyenForm : Form, IBaseForm
    {
        private readonly QuyenPresenter _presenter;
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        public DanhSachQuyenForm()
        {
            InitializeComponent();
            _presenter = new QuyenPresenter(this);

            //Bật tắt các nút theo quyền
            sua.Visible = Session.HasPermission("Sửa quyền");
            xoa.Visible = Session.HasPermission("Xóa quyền");
            btnThemQuyen.Enabled = Session.HasPermission("Thêm quyền");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void DanhSachQuyenForm_Load(object sender, EventArgs e)
        {
            await _presenter.LoadDataAsync();
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // bỏ qua header

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value?.ToString();
            string tenQuyen = dataGridView1.Rows[e.RowIndex].Cells["tenQuyen"].Value?.ToString();

            switch (columnName)
            {
                case "sua":
                    _presenter.EditQuyen(id, tenQuyen);
                    break;

                case "xoa":
                    await _presenter.DeleteQuyen(id, tenQuyen);
                    break;
            }
            await _presenter.LoadDataAsync();
        }

        private async void btnThemQuyen_Click(object sender, EventArgs e)
        {
            _presenter.AddQuyen();
            await _presenter.LoadDataAsync();
        }

        private void txtbSearchQuyen_KeyUp(object sender, KeyEventArgs e)
        {
            _presenter.SearchQuyenTheoTen(txtbSearchQuyen.Text);
        }
    }
}
