using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Presenters;
using System.Diagnostics;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class EditQuyenForm : Form, IEditQuyen
    {
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        public TextBox Txtb => txtbTenQuyen;
        public ErrorProvider Error => errorProvider1;

        private string _id;
        private string _tenQuyen;

        private readonly EditQuyenPresenter _editQuyenPresenter;
        public EditQuyenForm(string id, string tenQuyen)
        {
            InitializeComponent();
            _editQuyenPresenter = new(this);
            _id = id;
            _tenQuyen = tenQuyen;
        }

        private void EditQuyenForm_Load(object sender, EventArgs e)
        {
            _editQuyenPresenter.LoadDataAsync(_id, _tenQuyen);

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (await _editQuyenPresenter.UpdateRoleAsync(Convert.ToInt32(_id), txtbTenQuyen.Text))
            {
                this.Close();
            }
        }

        private void txtbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            _editQuyenPresenter.SearchChucNangTheoTen("tenChucNang", txtbSearch.Text.Trim());
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
