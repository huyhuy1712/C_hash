namespace MilkTea.Client.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            roundedTextBox_TenTK = new MilkTea.Client.Controls.RoundedTextBox();
            roundedButton_Register = new MilkTea.Client.Controls.RoundedButton();
            roundedTextBox_Password = new MilkTea.Client.Controls.RoundedTextBox();
            roundedTextBox_Email = new MilkTea.Client.Controls.RoundedTextBox();
            roundedTextBox_Phone = new MilkTea.Client.Controls.RoundedTextBox();
            roundedTextBox_Name = new MilkTea.Client.Controls.RoundedTextBox();
            label_register = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedTextBox_TenTK);
            panel1.Controls.Add(roundedButton_Register);
            panel1.Controls.Add(roundedTextBox_Password);
            panel1.Controls.Add(roundedTextBox_Email);
            panel1.Controls.Add(roundedTextBox_Phone);
            panel1.Controls.Add(roundedTextBox_Name);
            panel1.Controls.Add(label_register);
            panel1.Location = new Point(200, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 487);
            panel1.TabIndex = 0;
            // 
            // roundedTextBox_TenTK
            // 
            roundedTextBox_TenTK.BackColor = Color.White;
            roundedTextBox_TenTK.BorderColor = Color.Gray;
            roundedTextBox_TenTK.BorderRadius = 20;
            roundedTextBox_TenTK.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_TenTK.Location = new Point(35, 331);
            roundedTextBox_TenTK.Name = "roundedTextBox_TenTK";
            roundedTextBox_TenTK.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_TenTK.Placeholder = "Nhập tên tài khoản";
            roundedTextBox_TenTK.Size = new Size(330, 50);
            roundedTextBox_TenTK.TabIndex = 6;
            roundedTextBox_TenTK.TextValue = "";
            // 
            // roundedButton_Register
            // 
            roundedButton_Register.BackColor = Color.DodgerBlue;
            roundedButton_Register.BorderColor = Color.DodgerBlue;
            roundedButton_Register.BorderRadius = 20;
            roundedButton_Register.BorderSize = 0;
            roundedButton_Register.Cursor = Cursors.Hand;
            roundedButton_Register.FlatAppearance.BorderSize = 0;
            roundedButton_Register.FlatStyle = FlatStyle.Flat;
            roundedButton_Register.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            roundedButton_Register.ForeColor = Color.White;
            roundedButton_Register.Location = new Point(35, 401);
            roundedButton_Register.Name = "roundedButton_Register";
            roundedButton_Register.Size = new Size(330, 50);
            roundedButton_Register.TabIndex = 5;
            roundedButton_Register.Text = "ĐĂNG KÝ";
            roundedButton_Register.UseVisualStyleBackColor = false;
            roundedButton_Register.Click += roundedButton_Register_Click;
            // 
            // roundedTextBox_Password
            // 
            roundedTextBox_Password.BackColor = Color.White;
            roundedTextBox_Password.BorderColor = Color.Gray;
            roundedTextBox_Password.BorderRadius = 20;
            roundedTextBox_Password.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_Password.Location = new Point(35, 270);
            roundedTextBox_Password.Name = "roundedTextBox_Password";
            roundedTextBox_Password.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_Password.Placeholder = "Nhập mật khẩu";
            roundedTextBox_Password.Size = new Size(330, 50);
            roundedTextBox_Password.TabIndex = 4;
            roundedTextBox_Password.TextValue = "";
            // 
            // roundedTextBox_Email
            // 
            roundedTextBox_Email.BackColor = Color.White;
            roundedTextBox_Email.BorderColor = Color.Gray;
            roundedTextBox_Email.BorderRadius = 20;
            roundedTextBox_Email.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_Email.Location = new Point(35, 210);
            roundedTextBox_Email.Name = "roundedTextBox_Email";
            roundedTextBox_Email.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_Email.Placeholder = "Nhập email";
            roundedTextBox_Email.Size = new Size(330, 50);
            roundedTextBox_Email.TabIndex = 3;
            roundedTextBox_Email.TextValue = "";
            // 
            // roundedTextBox_Phone
            // 
            roundedTextBox_Phone.BackColor = Color.White;
            roundedTextBox_Phone.BorderColor = Color.Gray;
            roundedTextBox_Phone.BorderRadius = 20;
            roundedTextBox_Phone.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_Phone.Location = new Point(35, 150);
            roundedTextBox_Phone.Name = "roundedTextBox_Phone";
            roundedTextBox_Phone.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_Phone.Placeholder = "Nhập số điện thoại";
            roundedTextBox_Phone.Size = new Size(330, 50);
            roundedTextBox_Phone.TabIndex = 2;
            roundedTextBox_Phone.TextValue = "";
            // 
            // roundedTextBox_Name
            // 
            roundedTextBox_Name.BackColor = Color.White;
            roundedTextBox_Name.BorderColor = Color.Gray;
            roundedTextBox_Name.BorderRadius = 20;
            roundedTextBox_Name.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_Name.Location = new Point(35, 90);
            roundedTextBox_Name.Name = "roundedTextBox_Name";
            roundedTextBox_Name.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_Name.Placeholder = "Nhập tên nhân viên";
            roundedTextBox_Name.Size = new Size(330, 50);
            roundedTextBox_Name.TabIndex = 1;
            roundedTextBox_Name.TextValue = "";
            // 
            // label_register
            // 
            label_register.AutoSize = true;
            label_register.Font = new Font("Segoe UI Black", 19.8F, FontStyle.Bold);
            label_register.Location = new Point(90, 20);
            label_register.Name = "label_register";
            label_register.Size = new Size(243, 45);
            label_register.TabIndex = 0;
            label_register.Text = "Tạo tài khoản";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 549);
            Controls.Add(panel1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label_register;
        private Controls.RoundedTextBox roundedTextBox_Name;
        private Controls.RoundedTextBox roundedTextBox_Phone;
        private Controls.RoundedTextBox roundedTextBox_Email;
        private Controls.RoundedTextBox roundedTextBox_Password;
        private Controls.RoundedButton roundedButton_Register;
        private Controls.RoundedTextBox roundedTextBox_TenTK;
    }
}

