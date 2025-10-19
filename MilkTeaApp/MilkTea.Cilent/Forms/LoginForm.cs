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
        private readonly TaiKhoanService _taiKhoanService;
        private readonly ChucNangService _chucNangService;
        public LoginForm()
        {
            InitializeComponent();
            _taiKhoanService = new TaiKhoanService();
            _chucNangService = new();
            this.KeyPreview = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void roundedTextBox_TenTK_Enter(object sender, EventArgs e)
        {
            //roundedTextBox_Email.TextValue = "";
            pictureBox1.Visible = false;
        }

        private void roundedTextBox_TenTK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(roundedTextBox_TenTK.TextValue))
            {
                roundedTextBox_TenTK.Placeholder = "  rk   Nhập tên tài khoản";
                // Hiện lại icon nếu không nhập gì
                pictureBox1.Visible = true;
            }
            else
            {
                string tenTK = roundedTextBox_TenTK.TextValue;
                pictureBox1.Visible = false;
            }
        }

        private void roundedTextBox_Password_Enter(object sender, EventArgs e)
        {
            //roundedTextBox_Password.TextValue = "";
            pictureBox2.Visible = false;
        }

        private void roundedTextBox_Password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(roundedTextBox_Password.TextValue))
            {
                roundedTextBox_Password.Placeholder = "  rk   Nhập mật khẩu";
                // Hiện lại icon nếu không nhập gì
                pictureBox2.Visible = true;
            }
            else
            {
                string password = roundedTextBox_Password.TextValue;
                pictureBox2.Visible = false;
            }
        }



        private void roundedTextBox_TenTK_Load(object sender, EventArgs e)
        {

        }

        private void roundedTextBox_Password_Load(object sender, EventArgs e)
        {

        }

        private async void roundedButton_Login_Click(object sender, EventArgs e)

        {
            var username = roundedTextBox_TenTK.TextValue.Trim();
            var password = roundedTextBox_Password.TextValue.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tên tài khoản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra password
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số điện thoại (10 hoặc 11 chữ số, có thể tùy chỉnh theo nhu cầu)
            var phonePattern = @"^\d{10,11}$";
            if (!Regex.IsMatch(password, phonePattern))
            {
                MessageBox.Show("Mật khẩu phải là số điện thoại hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TaiKhoan account = await CheckLoginAsync(username, password);
            if (account == null)
            {
                MessageBox.Show("Không có tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm mainForm = new MainForm(account);

            // Lưu thông tin vào session
            Session.AllowedFunctions = await _chucNangService.GetChucNangsByMaQuyenAsync(account.MaQuyen);
            mainForm.ShowDialog();
        }

        // Hàm kiểm tra đăng nhập
        public async Task<TaiKhoan?> CheckLoginAsync(string username, string password)
        {
            var list = await _taiKhoanService.GetAccountsAsync();


            // Tìm tài khoản theo username và password
            var account = list.FirstOrDefault(tk => tk.TenTaiKhoan == username && tk.MatKhau == password);

            return account; // Nếu không tìm thấy thì trả về null
        }

        private void roundedTextBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                roundedButton_Login.PerformClick();
            }
        }
    }
}
