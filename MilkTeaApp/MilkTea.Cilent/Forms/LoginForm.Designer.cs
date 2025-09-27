namespace MilkTea.Client.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label_TaoTaiKhoan = new Label();
            roundedButton_Login = new MilkTea.Client.Controls.RoundedButton();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            roundedTextBox_Password = new MilkTea.Client.Controls.RoundedTextBox();
            roundedTextBox_TenTK = new MilkTea.Client.Controls.RoundedTextBox();
            label_login = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label_TaoTaiKhoan);
            panel1.Controls.Add(roundedButton_Login);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(roundedTextBox_Password);
            panel1.Controls.Add(roundedTextBox_TenTK);
            panel1.Controls.Add(label_login);
            panel1.Location = new Point(212, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(379, 378);
            panel1.TabIndex = 0;
            // 
            // label_TaoTaiKhoan
            // 
            label_TaoTaiKhoan.AutoSize = true;
            label_TaoTaiKhoan.Cursor = Cursors.Hand;
            label_TaoTaiKhoan.Font = new Font("Bahnschrift Condensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TaoTaiKhoan.Location = new Point(134, 340);
            label_TaoTaiKhoan.Name = "label_TaoTaiKhoan";
            label_TaoTaiKhoan.Size = new Size(114, 28);
            label_TaoTaiKhoan.TabIndex = 6;
            label_TaoTaiKhoan.Text = "Tạo tài khoản";
            label_TaoTaiKhoan.Click += label_TaoTaiKhoan_Click;
            // 
            // roundedButton_Login
            // 
            roundedButton_Login.BackColor = Color.DodgerBlue;
            roundedButton_Login.BorderColor = Color.DodgerBlue;
            roundedButton_Login.BorderRadius = 20;
            roundedButton_Login.BorderSize = 0;
            roundedButton_Login.Cursor = Cursors.Hand;
            roundedButton_Login.FlatAppearance.BorderSize = 0;
            roundedButton_Login.FlatStyle = FlatStyle.Flat;
            roundedButton_Login.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            roundedButton_Login.ForeColor = Color.White;
            roundedButton_Login.Location = new Point(34, 240);
            roundedButton_Login.Name = "roundedButton_Login";
            roundedButton_Login.Size = new Size(327, 51);
            roundedButton_Login.TabIndex = 5;
            roundedButton_Login.Text = "LOGIN";
            roundedButton_Login.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.download1;
            pictureBox2.Location = new Point(51, 171);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.download1;
            pictureBox1.Location = new Point(51, 115);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 25);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // roundedTextBox_Password
            // 
            roundedTextBox_Password.BackColor = Color.White;
            roundedTextBox_Password.BorderColor = Color.Gray;
            roundedTextBox_Password.BorderRadius = 20;
            roundedTextBox_Password.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_Password.Location = new Point(34, 158);
            roundedTextBox_Password.Name = "roundedTextBox_Password";
            roundedTextBox_Password.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_Password.Placeholder = "  rk   Nhập mật khẩu";
            roundedTextBox_Password.Size = new Size(327, 51);
            roundedTextBox_Password.TabIndex = 2;
            roundedTextBox_Password.TextValue = "";
            roundedTextBox_Password.Load += roundedTextBox_Password_Load;
            roundedTextBox_Password.Enter += roundedTextBox_Password_Enter;
            roundedTextBox_Password.Leave += roundedTextBox_Password_Leave;
            // 
            // roundedTextBox_TenTK
            // 
            roundedTextBox_TenTK.BackColor = Color.White;
            roundedTextBox_TenTK.BorderColor = Color.Gray;
            roundedTextBox_TenTK.BorderRadius = 20;
            roundedTextBox_TenTK.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_TenTK.Location = new Point(34, 101);
            roundedTextBox_TenTK.Name = "roundedTextBox_TenTK";
            roundedTextBox_TenTK.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_TenTK.Placeholder = "  rk   Nhập tên tài khoản";
            roundedTextBox_TenTK.Size = new Size(327, 51);
            roundedTextBox_TenTK.TabIndex = 1;
            roundedTextBox_TenTK.TextValue = "";
            roundedTextBox_TenTK.Load += roundedTextBox_TenTK_Load;
            roundedTextBox_TenTK.Enter += roundedTextBox_TenTK_Enter;
            roundedTextBox_TenTK.Leave += roundedTextBox_TenTK_Leave;
            // 
            // label_login
            // 
            label_login.AutoSize = true;
            label_login.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_login.Location = new Point(96, 27);
            label_login.Name = "label_login";
            label_login.Size = new Size(200, 46);
            label_login.TabIndex = 0;
            label_login.Text = "Đăng nhập";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        protected Label label_login;
        private Controls.RoundedTextBox roundedTextBox_TenTK;
        private Controls.RoundedTextBox roundedTextBox_Password;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Controls.RoundedButton roundedButton_Login;
        protected Label label_TaoTaiKhoan;
    }
}