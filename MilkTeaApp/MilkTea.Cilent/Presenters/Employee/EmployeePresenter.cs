using MilkTea.Client.Interfaces;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MilkTea.Client.Presenters.Employee
{
    public class EmployeePresenter
    {
        private readonly AccountService _taiKhoanService = new();
        private readonly NhanVienService _nhanVienService = new();
        private readonly IEmployee _form;

        public EmployeePresenter(IEmployee form)
        {
            _form = form;
        }

        public async Task GetDataAsync()
        {
            var grid = _form.Grid;
            var lbl = _form.LblStatus;

            lbl.ForeColor = Color.Gray;
            lbl.Text = "🔄 Đang tải dữ liệu...";

            var dataGridView1 = _form.Grid;
            try
            {
                _form.setTaiKhoan(await _taiKhoanService.GetAccountsAsync());
                _form.setNhanVien(await _nhanVienService.GetNhanVienAsync());


            }
            catch (Exception ex)
            {
                lbl.ForeColor = Color.IndianRed;
                lbl.Text = "❌ Không thể tải dữ liệu. Vui lòng thử lại sau.";
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
    }
}