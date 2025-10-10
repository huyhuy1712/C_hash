namespace MilkTea.Client.Forms.ChildForm_Account
{
    partial class ViewAccountForm
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
            panel11 = new Panel();
            panel3 = new Panel();
            btnDong = new MilkTea.Client.Controls.RoundedButton();
            panel4 = new Panel();
            panel6 = new Panel();
            panel10 = new Panel();
            lblTrangThai = new Label();
            label9 = new Label();
            panel9 = new Panel();
            lblQuyen = new Label();
            label7 = new Label();
            panel8 = new Panel();
            lblHoTen = new Label();
            label4 = new Label();
            panel7 = new Panel();
            lblTaiKhoan = new Label();
            label2 = new Label();
            panel5 = new Panel();
            picAnh = new PictureBox();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel11.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 519);
            panel1.TabIndex = 2;
            // 
            // panel11
            // 
            panel11.BackColor = SystemColors.ScrollBar;
            panel11.Controls.Add(panel3);
            panel11.Controls.Add(panel4);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 80);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(20);
            panel11.Size = new Size(800, 439);
            panel11.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(btnDong);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(20, 249);
            panel3.Name = "panel3";
            panel3.Size = new Size(760, 170);
            panel3.TabIndex = 1;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.None;
            btnDong.BackColor = Color.Red;
            btnDong.BorderColor = Color.DodgerBlue;
            btnDong.BorderRadius = 20;
            btnDong.BorderSize = 0;
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDong.ForeColor = Color.Black;
            btnDong.Location = new Point(318, 70);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(125, 40);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(20, 20);
            panel4.Name = "panel4";
            panel4.Size = new Size(760, 200);
            panel4.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel10);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(panel8);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(170, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(590, 200);
            panel6.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Controls.Add(lblTrangThai);
            panel10.Controls.Add(label9);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 150);
            panel10.Name = "panel10";
            panel10.Size = new Size(590, 50);
            panel10.TabIndex = 3;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Dock = DockStyle.Fill;
            lblTrangThai.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTrangThai.Location = new Point(134, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(456, 50);
            lblTrangThai.TabIndex = 2;
            lblTrangThai.Text = "Đang hoạt Động";
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Left;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(134, 50);
            label9.TabIndex = 1;
            label9.Text = "Trạng Thái";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            panel9.Controls.Add(lblQuyen);
            panel9.Controls.Add(label7);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 100);
            panel9.Name = "panel9";
            panel9.Size = new Size(590, 50);
            panel9.TabIndex = 2;
            // 
            // lblQuyen
            // 
            lblQuyen.Dock = DockStyle.Fill;
            lblQuyen.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuyen.Location = new Point(134, 0);
            lblQuyen.Name = "lblQuyen";
            lblQuyen.Size = new Size(456, 50);
            lblQuyen.TabIndex = 2;
            lblQuyen.Text = "Nhân Viên";
            lblQuyen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(134, 50);
            label7.TabIndex = 1;
            label7.Text = "Quyền ";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Controls.Add(lblHoTen);
            panel8.Controls.Add(label4);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 50);
            panel8.Name = "panel8";
            panel8.Size = new Size(590, 50);
            panel8.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.Dock = DockStyle.Fill;
            lblHoTen.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHoTen.Location = new Point(134, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(456, 50);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Nguyễn Chí Phong";
            lblHoTen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(134, 50);
            label4.TabIndex = 1;
            label4.Text = "Họ Tên";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblTaiKhoan);
            panel7.Controls.Add(label2);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(590, 50);
            panel7.TabIndex = 0;
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.Dock = DockStyle.Fill;
            lblTaiKhoan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaiKhoan.Location = new Point(134, 0);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(456, 50);
            lblTaiKhoan.TabIndex = 1;
            lblTaiKhoan.Text = "0586785345";
            lblTaiKhoan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(134, 50);
            label2.TabIndex = 0;
            label2.Text = "Tài Khoản";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(picAnh);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10);
            panel5.Size = new Size(170, 200);
            panel5.TabIndex = 0;
            // 
            // picAnh
            // 
            picAnh.Dock = DockStyle.Fill;
            picAnh.Image = Properties.Resources.circle_user;
            picAnh.Location = new Point(10, 10);
            picAnh.Name = "picAnh";
            picAnh.Size = new Size(150, 180);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picAnh.TabIndex = 0;
            picAnh.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 80);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 80);
            label1.TabIndex = 0;
            label1.Text = "Thông Tin Tài Khoản";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ViewAccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 519);
            Controls.Add(panel1);
            Name = "ViewAccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewAccountForm";
            panel1.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private PictureBox picAnh;
        private Panel panel8;
        private Panel panel7;
        private Panel panel3;
        private Label label2;
        private Label lblTaiKhoan;
        private Label label4;
        private Panel panel10;
        private Label lblTrangThai;
        private Label label9;
        private Panel panel9;
        private Label lblQuyen;
        private Label label7;
        private Label lblHoTen;
        private Controls.RoundedButton btnDong;
        private Panel panel11;
    }
}