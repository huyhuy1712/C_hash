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
        public ErrorProvider error => errorProvider1;

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
            Quyen q = new();
            q.MaQuyen = Convert.ToInt32(_id);
            q.TenQuyen = txtbTenQuyen.Text;
            q.TrangThai = 1;
            q.Mota = "123";

            //Lấy tất cả các chức năng được chọn
            List<int> selected = new();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int isChecked = Convert.ToInt32(row.Cells["chkChucNang"].Value);

                if (isChecked == 1)
                {
                    selected.Add(Convert.ToInt32(row.Cells["id"].Value));
                }
            }

            //Cập nhật quyền và các chức năng được chọn
            if (await _editQuyenPresenter.UpdateRoleAsync(q, selected))
            {
                MessageBox.Show("Đã sửa quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
