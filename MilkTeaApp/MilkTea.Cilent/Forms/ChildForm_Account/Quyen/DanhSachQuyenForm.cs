using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Presenters.Quyen;

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
            dataGridView1.CellClick += dataGridView1_CellClick;
            await _presenter.LoadDataAsync();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // bỏ qua header

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value?.ToString();

            switch (columnName)
            {
                case "sua":
                    _presenter.EditQuyen(id);
                    break;

                case "xoa":
                    _presenter.DeleteQuyen(id);
                    break;
            }
        }

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            var frm = new AddQuyenForm();
            frm.ShowDialog();
        }
    }
}
