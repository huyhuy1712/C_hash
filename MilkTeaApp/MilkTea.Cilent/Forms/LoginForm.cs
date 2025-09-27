using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void roundedTextBox_TenTK_Load(object sender, EventArgs e)
        {

        }

        private void roundedTextBox_Password_Load(object sender, EventArgs e)
        {

        }

        private void label_TaoTaiKhoan_Click(object sender, EventArgs e)
        {

        }
    }
}
