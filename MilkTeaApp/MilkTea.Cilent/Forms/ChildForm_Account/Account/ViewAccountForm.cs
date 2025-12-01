using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class ViewAccountForm : Form, IViewAccountForm
    {
        public Label LblId => lblId;
        public Label LblTaiKhoan => lblTaiKhoan;
        public Label LblSoDienThoai => lblSoDienThoai;
        public Label LblHoTen => lblHoTen;
        public Label LblQuyen => lblQuyen;
        public Label LblTrangThai => lblTrangThai;
        public Label LblStatus => lblStatus;
        public PictureBox PicAnh => picAnh;

        private readonly ViewAccountPresenter _presenter;

        private readonly string _id;

        public ViewAccountForm(string id)
        {
            InitializeComponent();
            _id = id;
            _presenter = new ViewAccountPresenter(this, _id);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ViewAccountForm_Load(object sender, EventArgs e)
        {
            await _presenter.LoadDataAsync();
        }
    }
}
