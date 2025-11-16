using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Presenters.Employee;
using System.Diagnostics;

namespace MilkTea.Client.Forms.ChildForm_Account.NewFolder
{
    public partial class EmployeeForm : Form, IEmployee
    {
        private readonly EmployeePresenter _prenster;
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;

        private List<NhanVien> nv;
        private List<TaiKhoan> tk;

        public void setNhanVien(List<NhanVien> nv)
        {
            this.nv = nv;
        }
        public void setTaiKhoan(List<TaiKhoan> tk)
        {
            this.tk = tk;
        }

        public EmployeeForm()
        {
            InitializeComponent();
            _prenster = new EmployeePresenter(this);
        }

        private async void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await _prenster.GetDataAsync();

            dataGridView1.DataSource = nv;

        }
    }
}
