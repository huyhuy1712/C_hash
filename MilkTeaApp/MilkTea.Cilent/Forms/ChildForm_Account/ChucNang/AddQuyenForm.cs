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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "chkChucNang")
            {
                // Consider only VISIBLE rows when deciding current checked state
                bool allChecked = true;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.Visible) 
                        continue;

                    var v = row.Cells["chkChucNang"].Value;
                    bool isChecked = v != null && (v.ToString() == "1" || v.ToString().ToLower() == "true");

                    if (!isChecked)
                    {
                        allChecked = false;
                        break;
                    }
                }

                bool newValue = !allChecked;

                // Apply new value only to VISIBLE rows so search-filtered items are unaffected
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Visible)
                        row.Cells["chkChucNang"].Value = newValue ? 1 : 0;
                }

                // Ensure UI refresh / commit if needed
                dataGridView1.Refresh();
            }
        }
    }
}
