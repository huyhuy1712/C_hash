using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;
using MilkTea.Client.Services;
using System;
using System.Windows.Forms;


namespace MilkTea.Client.Forms
{
    public partial class AccountForm : Form, ITaiKhoanForm
    {
        private readonly AccountPresenter _presenter;
        public DataGridView GridTaiKhoan => dataGridView1;
        public Label LblStatus => lblStatus;

        public AccountForm()
        {
            InitializeComponent();
            _presenter = new AccountPresenter(this, new TaiKhoanService());
        }

        private async void AccountForm_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellClick;
            await _presenter.LoadDataAsync();
        }

        private void btnThemAccount_Click(object sender, EventArgs e)
        {
            AddAccountForm themTaiKhoan = new AddAccountForm();
            themTaiKhoan.ShowDialog();
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
