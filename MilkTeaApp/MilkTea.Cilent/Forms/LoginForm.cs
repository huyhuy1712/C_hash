using Microsoft.VisualBasic.ApplicationServices;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AccountService _taiKhoanService;
        private readonly ChucNangService _chucNangService;
        public LoginForm()
        {
            InitializeComponent();
            _taiKhoanService = new AccountService();
            _chucNangService = new();
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void roundedButton_Login_Click(object sender, EventArgs e)

        {
            var username = roundedTextBox_TenTK.TextValue.Trim();
            var password = roundedTextBox_Password.TextValue.Trim();
            var phonePattern = @"^\d{10,11}$";

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tên tài khoản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                roundedTextBox_TenTK.Focus();
            }

            // Kiểm tra password
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                roundedTextBox_Password.Focus();
            }

            // Kiểm tra định dạng số điện thoại (10 hoặc 11 chữ số, có thể tùy chỉnh theo nhu cầu)
            else if (!Regex.IsMatch(password, phonePattern))
            {
                MessageBox.Show("Mật khẩu phải là số điện thoại hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                roundedTextBox_Password.Focus();
            }

            else
            {
                TaiKhoan account = await CheckLoginAsync(username, password);
                if (account == null)
                {
                    MessageBox.Show("Không có tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MainForm mainForm = new MainForm(account);
                    this.Hide();
                    // Lưu thông tin vào session
                    Session.AllowedFunctions = await _chucNangService.GetChucNangsByMaQuyenAsync(account.MaQuyen);
                    Session.CurrentUser = account;
                    mainForm.ShowDialog();
                    this.Show();
                }
            }
        }

        // Hàm kiểm tra đăng nhập
        public async Task<TaiKhoan?> CheckLoginAsync(string username, string password)
        {
            var list = await _taiKhoanService.GetAccountsAsync();

            if (list == null)
            {
                MessageBox.Show("Chưa mở BackEnd!!!\n Hoặc là chưa chỉnh password MySQL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            // Tìm tài khoản theo username và password
            var account = list.FirstOrDefault(tk => tk.TenTaiKhoan == username && tk.MatKhau == password && tk.TrangThai == 1);

            return account; // Nếu không tìm thấy thì trả về null
        }

    }
}