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
        private readonly QuyenService _quyenService = new();
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

        private async void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();

            var accounts = await _taiKhoanService.GetAccountsAsync();

            if (accounts == null || accounts.Count == 0)
            {
                return;
            }

            // Group accounts by role id (MaQuyen)
            var groups = accounts
                .GroupBy(a => a.MaQuyen)
                .OrderBy(g => g.Key);

            foreach (var grp in groups)
            {
                // Make local copies for lambdas
                int maQuyen = grp.Key;
                var accountsInGroup = grp.ToList();

                // Default role text
                string roleText = $"Quyền {maQuyen}";

                // Try to fetch descriptive names from chuc nang service (best-effort)
                try
                {
                    // Try to get descriptive role name from QuyenService first
                    var quyen = await _quyenService.GetQuyenByIdAsync(maQuyen);
                    if (quyen != null && !string.IsNullOrWhiteSpace(quyen.TenQuyen))
                    {
                        roleText = quyen.TenQuyen;
                    }
                    else
                    {
                        // Fallback: join distinct TenChucNang values to show as the role label
                        var chucNangs = await _chucNangService.GetChucNangsByMaQuyenAsync(maQuyen);
                        if (chucNangs != null && chucNangs.Count > 0)
                        {
                            var names = chucNangs
                                .Select(cn => cn.TenChucNang)
                                .Where(n => !string.IsNullOrWhiteSpace(n))
                                .Distinct()
                                .ToList();

                            if (names.Count > 0)
                            {
                                roleText = string.Join(", ", names);
                            }
                        }
                    }
                }
                catch
                {
                    // Ignore errors fetching metadata; keep default label
                }

                var roleItem = new ToolStripMenuItem(roleText);

                // Populate account list for this role when the mouse enters the role item
                roleItem.MouseEnter += async (s, ev) =>
                {
                    try
                    {
                        // If already populated, skip
                        if (roleItem.DropDownItems.Count > 0)
                            return;

                        roleItem.DropDownItems.Clear();

                        foreach (var acc in accountsInGroup)
                        {
                            var accCopy = acc; // local copy for closure safety
                            var accItem = new ToolStripMenuItem(accCopy.TenTaiKhoan);
                            accItem.Click += (s2, ev2) =>
                            {
                                // Fill username and password fields
                                try
                                {
                                    roundedTextBox_TenTK.TextValue = accCopy.TenTaiKhoan;
                                    roundedTextBox_Password.TextValue = accCopy.MatKhau;
                                    roundedTextBox_Password.Focus();
                                }
                                catch
                                {
                                    // Swallow UI errors silently
                                }
                            };
                            roleItem.DropDownItems.Add(accItem);
                        }
                    }
                    catch
                    {
                        // Ignore UI population errors to keep context menu usable
                    }
                };

                contextMenuStrip1.Items.Add(roleItem);
            }
        }
    }
}