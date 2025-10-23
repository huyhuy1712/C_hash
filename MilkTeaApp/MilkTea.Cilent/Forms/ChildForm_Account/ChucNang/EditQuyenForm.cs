using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters.ChucNang;
using System.Diagnostics;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class EditQuyenForm : Form, IBaseForm
    {
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        private String _id;
        private readonly EditQuyenPresenter _editQuyenPresenter;
        public EditQuyenForm(String id)
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
    }
}
