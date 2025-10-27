using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;
using MilkTea.Client.Services;
using System.Diagnostics;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class AddQuyenForm : Form, IBaseForm
    {
        private readonly AddQuyenPresenter _addQuyenPresenter;
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        public AddQuyenForm()
        {
            InitializeComponent();
            _addQuyenPresenter = new AddQuyenPresenter(this, new ChucNangService());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddQuyenForm_Load(object sender, EventArgs e)
        {
            _addQuyenPresenter.LoadDataAsync();
        }

        private void txtbTenQuyen_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("hello");
            //_presenter.Search();
        }
    }
}
