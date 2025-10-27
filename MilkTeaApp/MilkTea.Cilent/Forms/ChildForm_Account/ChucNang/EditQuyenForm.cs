using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;
using MilkTea.Client.Models;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class EditQuyenForm : Form, IBaseForm
    {
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        private string _id;
        private readonly EditQuyenPresenter _editQuyenPresenter;
        public EditQuyenForm(string id)
        {
            InitializeComponent();
            _editQuyenPresenter = new(this);
            _id = id;
        }

        private void EditQuyenForm_Load(object sender, EventArgs e)
        {
            _editQuyenPresenter.LoadDataAsync(_id);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            Quyen q = new();

            q.MaQuyen = Convert.ToInt32(_id);

            _editQuyenPresenter.UpdateRoleAsync(q);
        }
    }
}
