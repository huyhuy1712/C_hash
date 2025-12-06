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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            roundedButton_Login = new MilkTea.Client.Controls.RoundedButton();
            roundedTextBox_TenTK = new MilkTea.Client.Controls.RoundedTextBox();
            roundedTextBox_Password = new MilkTea.Client.Controls.RoundedTextBox();
            label_login = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Cyan;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(628, 245);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.logo2;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(288, 245);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(label_login);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(288, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(340, 245);
            panel2.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(roundedButton_Login, 0, 2);
            tableLayoutPanel1.Controls.Add(roundedTextBox_TenTK, 0, 0);
            tableLayoutPanel1.Controls.Add(roundedTextBox_Password, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 62);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(340, 183);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // roundedButton_Login
            // 
            roundedButton_Login.BackColor = Color.DodgerBlue;
            roundedButton_Login.BorderColor = Color.DodgerBlue;
            roundedButton_Login.BorderRadius = 20;
            roundedButton_Login.BorderSize = 0;
            roundedButton_Login.Cursor = Cursors.Hand;
            roundedButton_Login.Dock = DockStyle.Fill;
            roundedButton_Login.FlatAppearance.BorderSize = 0;
            roundedButton_Login.FlatStyle = FlatStyle.Flat;
            roundedButton_Login.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            roundedButton_Login.ForeColor = Color.White;
            roundedButton_Login.Location = new Point(13, 121);
            roundedButton_Login.Name = "roundedButton_Login";
            roundedButton_Login.Size = new Size(314, 49);
            roundedButton_Login.TabIndex = 3;
            roundedButton_Login.Text = "LOGIN";
            roundedButton_Login.UseVisualStyleBackColor = false;
            roundedButton_Login.Click += roundedButton_Login_Click;
            // 
            // roundedTextBox_TenTK
            // 
            roundedTextBox_TenTK.BackColor = Color.White;
            roundedTextBox_TenTK.BorderColor = Color.Gray;
            roundedTextBox_TenTK.BorderRadius = 20;
            roundedTextBox_TenTK.Dock = DockStyle.Fill;
            roundedTextBox_TenTK.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_TenTK.Location = new Point(13, 13);
            roundedTextBox_TenTK.Name = "roundedTextBox_TenTK";
            roundedTextBox_TenTK.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_TenTK.Placeholder = "Nhập tên tài khoản";
            roundedTextBox_TenTK.Size = new Size(314, 48);
            roundedTextBox_TenTK.TabIndex = 1;
            roundedTextBox_TenTK.TextValue = "Pham Thi F";
            // 
            // roundedTextBox_Password
            // 
            roundedTextBox_Password.BackColor = Color.White;
            roundedTextBox_Password.BorderColor = Color.Gray;
            roundedTextBox_Password.BorderRadius = 20;
            roundedTextBox_Password.Dock = DockStyle.Fill;
            roundedTextBox_Password.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox_Password.Location = new Point(13, 67);
            roundedTextBox_Password.Name = "roundedTextBox_Password";
            roundedTextBox_Password.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox_Password.Placeholder = " Nhập mật khẩu";
            roundedTextBox_Password.Size = new Size(314, 48);
            roundedTextBox_Password.TabIndex = 2;
            roundedTextBox_Password.TextValue = "0901234566";
            // 
            // label_login
            // 
            label_login.Dock = DockStyle.Top;
            label_login.Font = new Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_login.ForeColor = Color.DarkTurquoise;
            label_login.Location = new Point(0, 0);
            label_login.Name = "label_login";
            label_login.Size = new Size(340, 62);
            label_login.TabIndex = 0;
            label_login.Text = "User Login";
            label_login.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(211, 32);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 245);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        protected Label label_login;
        private Controls.RoundedTextBox roundedTextBox_TenTK;
        private Controls.RoundedTextBox roundedTextBox_Password;
        private Controls.RoundedButton roundedButton_Login;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenuStrip1;
    }
}