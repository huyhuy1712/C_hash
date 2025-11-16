using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class ViewAccountPresenter
    {
        private readonly IViewAccountForm _form;
        private readonly AccountService _taiKhoanService;
        private readonly NhanVienService _nhanVienService;
        private readonly QuyenService _quyenService;
        private readonly string _id;

        private TaiKhoan account;
        private NhanVien nhanVien;
        private Quyen quyen;

        public ViewAccountPresenter(IViewAccountForm form, string id)
        {
            _id = id;
            _form = form;
            _taiKhoanService = new();
            _nhanVienService = new();
            _quyenService = new();
        }

        public async Task LoadDataAsync()
        {
            await GetData();

            if (account != null || nhanVien != null || quyen != null)
            {
                _form.LblId.Text = _id;
                _form.LblTaiKhoan.Text = account.TenTaiKhoan.ToString();
                _form.LblHoTen.Text = nhanVien != null ? nhanVien.TenNV.ToString() : "Chưa có nhân viên";
                _form.LblQuyen.Text = quyen != null ? quyen.TenQuyen.ToString() : "Không tìm thấy quyền";

                if (account.TrangThai == 1)
                {
                    _form.LblTrangThai.Text = "Hoạt động";
                    _form.LblTrangThai.ForeColor = Color.Green;
                }
                else
                {
                    _form.LblTrangThai.Text = "Khóa";
                    _form.LblTrangThai.ForeColor = Color.Red;
                }

                // Load picture
                string duongDanAnh = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images\\nhan_vien", account.anh);
                if (File.Exists(duongDanAnh))
                {
                    using (var img = Image.FromFile(duongDanAnh))
                    {
                        _form.PicAnh.Image = new Bitmap(img); // clone để tránh file bị lock
                    }
                }
            }
        }

        private async Task GetData()
        {
            try
            {
                account = await _taiKhoanService.GetAccountsByIdAsync(int.Parse(_id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy chi tiết tài khoản");
            }

            try
            {
                nhanVien = await _nhanVienService.GetByMaTK(int.Parse(_id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin nhân viên");
            }

            try
            {
                quyen = await _quyenService.GetQuyenByIdAsync(account.MaQuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin quyền");
            }
        }
    }
}
