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
            roundedButton_Login = new MilkTea.Client.Controls.RoundedButton();
            roundedTextBox_Password = new MilkTea.Client.Controls.RoundedTextBox();
            roundedTextBox_TenTK = new MilkTea.Client.Controls.RoundedTextBox();
            label_login = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedButton_Login);
            panel1.Controls.Add(roundedTextBox_Password);
            panel1.Controls.Add(roundedTextBox_TenTK);
            panel1.Controls.Add(label_login);
            panel1.Location = new Point(212, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(379, 378);
            panel1.TabIndex = 0;
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
            roundedButton_Login.Click += roundedButton_Login_Click;
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
            roundedTextBox_Password.Placeholder = " Nhập mật khẩu";
            roundedTextBox_Password.Size = new Size(327, 51);
            roundedTextBox_Password.TabIndex = 2;
            roundedTextBox_Password.TextValue = "0901234566";
            roundedTextBox_Password.Load += roundedTextBox_Password_Load;
            roundedTextBox_Password.Enter += roundedTextBox_Password_Enter;
            roundedTextBox_Password.KeyDown += roundedTextBox_Password_KeyDown;
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
            roundedTextBox_TenTK.Placeholder = "Nhập tên tài khoản";
            roundedTextBox_TenTK.Size = new Size(327, 51);
            roundedTextBox_TenTK.TabIndex = 1;
            roundedTextBox_TenTK.TextValue = "Pham Thi F";
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        protected Label label_login;
        private Controls.RoundedTextBox roundedTextBox_TenTK;
        private Controls.RoundedTextBox roundedTextBox_Password;
        private Controls.RoundedButton roundedButton_Login;
    }
}