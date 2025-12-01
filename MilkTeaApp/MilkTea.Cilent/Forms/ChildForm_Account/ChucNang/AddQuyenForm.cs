using MilkTea.Client.Controls;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;
using MilkTea.Client.Models;
using System.Diagnostics;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class AddQuyenForm : Form, IAddQuyen
    {
        private readonly AddQuyenPresenter _addQuyenPresenter;

        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        public ErrorProvider Error => errorProvider1;
        public RoundedTextBox Rtxtb => txtbTenQuyen;

        public AddQuyenForm()
        {
            InitializeComponent();
            _addQuyenPresenter = new(this);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddQuyenForm_Load(object sender, EventArgs e)
        {
            _addQuyenPresenter.LoadDataAsync();
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (await _addQuyenPresenter.SaveAsync(txtbTenQuyen.Text))
            {
                this.Close();
            }
        }

        private void txtbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            _addQuyenPresenter.SearchChucNangTheoTen("chucNang", txtbSearch.Text.Trim());
        }
    }
}
