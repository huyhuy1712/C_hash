using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;
using MilkTea.Client.Services;
using System;
using System.Windows.Forms;


namespace MilkTea.Client.Forms
{
    public partial class AccountForm : Form, IBaseForm
    {
        private readonly AccountPresenter _presenter;
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;

        public AccountForm()
        {
            InitializeComponent();
            _presenter = new AccountPresenter(this, new TaiKhoanService(), new NhanVienService());
        }

        private async void AccountForm_Load(object sender, EventArgs e)
        {
            await _presenter.LoadDataAsync();
        }

        private void btnThemAccount_Click(object sender, EventArgs e)
        {
            using (var frm = new AddAccountForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _ = _presenter.LoadDataAsync(); // load lại danh sách sau khi thêm
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // bỏ qua header

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value?.ToString();

            switch (columnName)
            {
                case "sua":
                    _presenter.EditAccount(id);
                    break;

                case "chiTiet":
                    _presenter.ViewAccount(id);
                    break;

                case "xoa":
                    _presenter.DeleteAccount(id);
                    break;
            }
        }

        private void btnDanhSachQuyen_Click(object sender, EventArgs e)
        {
            var frm = new DanhSachQuyenForm();
            frm.ShowDialog();
        }
    }
}
