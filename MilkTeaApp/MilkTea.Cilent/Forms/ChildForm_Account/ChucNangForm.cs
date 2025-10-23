using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class ChucNangForm : Form, IBaseForm
    {
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        private readonly IBaseForm _form;
        private String _id;
        private readonly EditQuyenPresenter _editQuyenPresenter;
        public ChucNangForm(String id)
        {
            InitializeComponent();
            _editQuyenPresenter = new(_form);
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
