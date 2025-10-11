using MilkTea.Client.Interfaces;
using MilkTea.Client.Services;
using System;

namespace MilkTea.Client.Presenters
{
    public class ViewAccountPresenter
    {
        private readonly IViewAccountForm _form;
        private readonly TaiKhoanService _taiKhoanService;
        private readonly NhanVienService _nhanVienService;
        private readonly QuyenService _quyenService;
        private readonly string _id;
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
            try
            {
                var account = await _taiKhoanService.GetAccountsByIdAsync(int.Parse(_id));
                try
                {
                    var nhanVien = await _nhanVienService.GetByMaNV(account.MaTK);
                    try
                    {
                        var quyen = await _quyenService.GetQuyenByIdAsync(account.MaQuyen);

                        if (account != null || nhanVien != null || quyen != null)
                        {
                            _form.LblTaiKhoan.Text = account.TenTaiKhoan.ToString();
                            _form.LblHoTen.Text = nhanVien.TenNV.ToString();
                            _form.LblQuyen.Text = quyen.TenQuyen.ToString();
                            _form.LblTrangThai.Text = account.TrangThai == 1 ? "Hoạt động" : "Khóa";
                        }
                    }
                    catch
                    {
                        _form.LblStatus.Text = "Không tìm thấy quyền.";
                        _form.LblStatus.ForeColor = Color.Red;
                    }
                }
                catch
                {
                    _form.LblStatus.Text = "Không tìm thấy nhân viên.";
                    _form.LblStatus.ForeColor = Color.Red;
                }
            }
            catch
            {
                _form.LblStatus.Text = "Không tìm thấy tài khoản.";
                _form.LblStatus.ForeColor = Color.Red;
            }
        }
    }
}
