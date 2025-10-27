using MilkTea.Client.Models;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class AddAccountForm : Form, IAddAccountForm
    {
        private readonly AddAccountPresenter _presenter;
        public AddAccountForm()
        {
            InitializeComponent();
            _presenter = new AddAccountPresenter(this);
        }
        public TaiKhoan GetTaiKhoanInput()
        {
            return new TaiKhoan
            {
                TenTaiKhoan = txtbTenTaiKhoan.Text,
                MatKhau = txtbMatKhau.Text,
                MaQuyen = int.Parse(cbxQuyen.SelectedValue.ToString()),
                TrangThai = 1,
                anh = txtAnh.Text
            };
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAnh.Text = ofd.FileName; // hiện đường dẫn ảnh
                //pictureBox1.Image = Image.FromFile(ofd.FileName); // load ảnh xem trước
            }
        }

        private void btnThoatTTK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnThemTTK_Click(object sender, EventArgs e)
        {
            
        }
    }
}
