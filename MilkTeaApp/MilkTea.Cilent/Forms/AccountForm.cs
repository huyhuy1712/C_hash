using DocumentFormat.OpenXml.Office2016.Drawing.Command;
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
        public ComboBox CbSearchFilter => cbSearchFilter;

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
            sua.Visible = Session.HasPermission("Sửa tài khoản");
            btnThemAccount.Visible = Session.HasPermission("Thêm tài khoản");
            chiTiet.Visible = Session.HasPermission("Xem tài khoản");

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
                case "khoa":
                    _presenter.LockAccount(id);
                    break;
            }
        }

        private void btnDanhSachQuyen_Click(object sender, EventArgs e)
        {
            using (var frm = new DanhSachQuyenForm())
                frm.ShowDialog();
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            _presenter.Search(cbSearchFilter.SelectedValue.ToString(), Search.Text.Trim().Replace("'", "''"));
        }

        private void cbSearchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.Search(cbSearchFilter.SelectedValue.ToString(), Search.Text.Trim().Replace("'", "''"));
        }
    }
}
