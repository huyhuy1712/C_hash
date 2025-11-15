using MilkTea.Client.Models;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;
using System.Diagnostics;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class AddAccountForm : Form, IAddAccountForm
    {
        private readonly AddAccountPresenter _presenter;
        private List<Quyen> q;
        private List<NhanVien> nv;

        public ComboBox CbQuyen => cbQuyen;
        public ComboBox CbNhanVien => cbNhanVien;
        public TextBox TxtbTenTaiKhoan => txtbTenTaiKhoan;
        public TextBox TxtbMatKhau => txtbMatKhau;
        public TextBox TxtbDuongDanAnh => txtbDuongDanAnh;
        public ErrorProvider Error => errorProvider1;

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
                MaQuyen = int.Parse(cbQuyen.SelectedValue.ToString()),
                TrangThai = 1,
                anh = txtbDuongDanAnh.Text
            };
        }

        public void setQuyen(List<Quyen> q)
        {
            this.q = q;
            cbQuyen.DisplayMember = "TenQuyen";
            cbQuyen.ValueMember = "MaQuyen";
            cbQuyen.DataSource = q;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtbDuongDanAnh.Text = ofd.FileName; // hiện đường dẫn ảnh
                //pictureBox1.Image = Image.FromFile(ofd.FileName); // load ảnh xem trước
            }
        }

        private void btnThoatTTK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnThemTTK_Click(object sender, EventArgs e)
        {
            if (await _presenter.SaveAsync())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private async void btnThemQuyen_Click(object sender, EventArgs e)
        {
            _presenter.ThemQuyen();
        }

        private async void AddAccountForm_Load(object sender, EventArgs e)
        {
            await _presenter.LoadDataAsync();
        }

    }
}
