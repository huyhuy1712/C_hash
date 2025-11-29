using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Presenters;


namespace MilkTea.Client.Forms
{
    public partial class AccountForm : Form, IAccountForm
    {
        private readonly AccountPresenter _presenter;
        private List<TaiKhoan> tk;
        private List<Quyen> q;

        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;

        public AccountForm()
        {
            InitializeComponent();
            _presenter = new AccountPresenter(this);
        }

        public void setTaiKhoan(List<TaiKhoan> tk)
        {
            this.tk = tk;

        }
        public void setQuyen(List<Quyen> q)
        {
            this.q = q;
        }

        private async void AccountForm_Load(object sender, EventArgs e)
        {
            xoa.Visible = Session.HasPermission("Xóa tài khoản");
            sua.Visible = Session.HasPermission("Sửa tài khoản");
            btnThemAccount.Enabled = Session.HasPermission("Thêm tài khoản");


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
                    _presenter.EditAccount(Convert.ToInt32(id));
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
            using (var frm = new DanhSachQuyenForm())
                frm.ShowDialog();
        }

    }
}
