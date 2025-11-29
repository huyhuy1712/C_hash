using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Presenters.Account;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Account.Account
{
    public partial class EditAccountForm : Form, IEditAccount
    {
        private TaiKhoan tk;
        private NhanVien nv;
        private int id;
        private List<Quyen> q;
        private readonly EditAccountPresenter _presenter;

        public ComboBox CbQuyen => cbQuyen;
        public TextBox TxtbTenTaiKhoan => txtbTenTaiKhoan;
        public TextBox TxtbDuongDanAnh => txtbDuongDanAnh;
        public TextBox TxtbTenNhanVien => txtbTenNhanVien;
        public TextBox TxtbSoDienThoai => txtbSoDienThoai;
        public PictureBox Pic => pictureBox1;
        public ErrorProvider Error => errorProvider1;

        public EditAccountForm(string id)
        {
            InitializeComponent();
            _presenter = new EditAccountPresenter(this);
            this.id = Convert.ToInt32(id);
        }

        public TaiKhoan GetTaiKhoanInput()
        {
            return new TaiKhoan
            {
                TenTaiKhoan = txtbTenTaiKhoan.Text,
                MaQuyen = int.Parse(cbQuyen.SelectedValue.ToString()),
                TrangThai = Convert.ToInt32(btnTrangThai.Checked),
                anh = txtbDuongDanAnh.Text
            };
        }

        public void setQuyen(List<Quyen> q)
        {
            this.q = q;
            cbQuyen.DisplayMember = "TenQuyen";
            cbQuyen.ValueMember = "MaQuyen";
            cbQuyen.DataSource = q;
            cbQuyen.SelectedValue = tk.MaQuyen;
        }

        public void setTaiKhoan(TaiKhoan tk)
        {
            this.tk = tk;
        }

        public void setNhanVien(NhanVien nv)
        {
            this.nv = nv;
        }

        private async void LoadDataAsync()
        {
            await _presenter.GetDataAsync(id);

            txtbTenTaiKhoan.Text = tk.TenTaiKhoan;
            txtbTenNhanVien.Text = nv.TenNV;
            txtbSoDienThoai.Text = nv.SDT;
            txtbDuongDanAnh.Text = tk.anh;
            btnTrangThai.Checked = Convert.ToBoolean(tk.TrangThai);
        }

        private void btnThoatTTK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnChonAnh_Click(object sender, EventArgs e)
        {
            _presenter.ChonAnh();
        }

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            _presenter.ThemQuyen();
            LoadDataAsync();
        }

        private void EditAccountForm_Load(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private async void btnXacNhanTTK_Click(object sender, EventArgs e)
        {
            if (await _presenter.SaveAsync())
            {
                MessageBox.Show("Đã sửa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
