using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class AddQuyenForm : Form, IBaseForm
    {
        private readonly ChucNangPresenter _chucNangPresenter;
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        private string _id;
        public AddQuyenForm(string id)
        {
            InitializeComponent();
            _chucNangPresenter = new ChucNangPresenter(this, new ChucNangService());
            _id = id;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddQuyenForm_Load(object sender, EventArgs e)
        {
            _chucNangPresenter.LoadDataAsync(_id);
        }

        private void txtbTenQuyen_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("hello");
            //_presenter.Search();
        }
    }
}
