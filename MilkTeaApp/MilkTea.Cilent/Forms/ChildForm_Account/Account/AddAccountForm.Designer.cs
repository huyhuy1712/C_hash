namespace MilkTea.Client.Forms.ChildForm_Account
{
    partial class AddAccountForm
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
            panel1 = new Panel();
            button = new Panel();
            btnXacNhanTTK = new MilkTea.Client.Controls.RoundedButton();
            panel14 = new Panel();
            btnThoatTTK = new MilkTea.Client.Controls.RoundedButton();
            middle = new Panel();
            left = new Panel();
            panel13 = new Panel();
            panel16 = new Panel();
            txtbDuongDanAnh = new TextBox();
            panel17 = new Panel();
            label6 = new Label();
            panel10 = new Panel();
            panel11 = new Panel();
            btnThemNhanVien = new MilkTea.Client.Controls.RoundedButton();
            cbNhanVien = new ComboBox();
            panel12 = new Panel();
            label5 = new Label();
            panel7 = new Panel();
            panel8 = new Panel();
            btnThemQuyen = new MilkTea.Client.Controls.RoundedButton();
            cbQuyen = new ComboBox();
            panel9 = new Panel();
            label4 = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            txtbMatKhau = new TextBox();
            panel6 = new Panel();
            label3 = new Label();
            field = new Panel();
            panel4 = new Panel();
            txtbTenTaiKhoan = new TextBox();
            panel3 = new Panel();
            label2 = new Label();
            right = new Panel();
            panel18 = new Panel();
            pictureBox1 = new PictureBox();
            panel15 = new Panel();
            btnChonAnh = new MilkTea.Client.Controls.RoundedButton();
            title = new Panel();
            label1 = new Label();
            imageList1 = new ImageList(components);
            errorProvider1 = new ErrorProvider(components);
            panel19 = new Panel();
            panel1.SuspendLayout();
            button.SuspendLayout();
            panel14.SuspendLayout();
            middle.SuspendLayout();
            left.SuspendLayout();
            panel13.SuspendLayout();
            panel16.SuspendLayout();
            panel17.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            field.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            right.SuspendLayout();
            panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel15.SuspendLayout();
            title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button);
            panel1.Controls.Add(middle);
            panel1.Controls.Add(title);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 640);
            panel1.TabIndex = 0;
            // 
            // button
            // 
            button.Controls.Add(btnXacNhanTTK);
            button.Controls.Add(panel14);
            button.Dock = DockStyle.Bottom;
            button.Location = new Point(0, 590);
            button.Name = "button";
            button.Padding = new Padding(0, 10, 0, 0);
            button.Size = new Size(780, 50);
            button.TabIndex = 9;
            // 
            // btnXacNhanTTK
            // 
            btnXacNhanTTK.BackColor = Color.Lime;
            btnXacNhanTTK.BorderColor = Color.DodgerBlue;
            btnXacNhanTTK.BorderRadius = 20;
            btnXacNhanTTK.BorderSize = 0;
            btnXacNhanTTK.Dock = DockStyle.Right;
            btnXacNhanTTK.FlatAppearance.BorderSize = 0;
            btnXacNhanTTK.FlatStyle = FlatStyle.Flat;
            btnXacNhanTTK.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnXacNhanTTK.ForeColor = Color.Black;
            btnXacNhanTTK.Location = new Point(510, 10);
            btnXacNhanTTK.Margin = new Padding(30);
            btnXacNhanTTK.Name = "btnXacNhanTTK";
            btnXacNhanTTK.Size = new Size(125, 40);
            btnXacNhanTTK.TabIndex = 1;
            btnXacNhanTTK.Text = "+ Thêm";
            btnXacNhanTTK.UseVisualStyleBackColor = false;
            btnXacNhanTTK.Click += btnThemTTK_Click;
            // 
            // panel14
            // 
            panel14.Controls.Add(btnThoatTTK);
            panel14.Dock = DockStyle.Right;
            panel14.Location = new Point(635, 10);
            panel14.Name = "panel14";
            panel14.Size = new Size(145, 40);
            panel14.TabIndex = 2;
            // 
            // btnThoatTTK
            // 
            btnThoatTTK.BackColor = Color.Red;
            btnThoatTTK.BorderColor = Color.DodgerBlue;
            btnThoatTTK.BorderRadius = 20;
            btnThoatTTK.BorderSize = 0;
            btnThoatTTK.Dock = DockStyle.Right;
            btnThoatTTK.FlatAppearance.BorderSize = 0;
            btnThoatTTK.FlatStyle = FlatStyle.Flat;
            btnThoatTTK.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThoatTTK.ForeColor = Color.White;
            btnThoatTTK.Location = new Point(20, 0);
            btnThoatTTK.Name = "btnThoatTTK";
            btnThoatTTK.Size = new Size(125, 40);
            btnThoatTTK.TabIndex = 0;
            btnThoatTTK.Text = "Thoát";
            btnThoatTTK.UseVisualStyleBackColor = false;
            btnThoatTTK.Click += btnThoatTTK_Click;
            // 
            // middle
            // 
            middle.BackColor = SystemColors.ScrollBar;
            middle.Controls.Add(left);
            middle.Controls.Add(right);
            middle.Dock = DockStyle.Top;
            middle.Location = new Point(0, 80);
            middle.Name = "middle";
            middle.Size = new Size(780, 460);
            middle.TabIndex = 1;
            // 
            // left
            // 
            left.Controls.Add(panel13);
            left.Controls.Add(panel10);
            left.Controls.Add(panel7);
            left.Controls.Add(panel2);
            left.Controls.Add(field);
            left.Dock = DockStyle.Left;
            left.Location = new Point(0, 0);
            left.Name = "left";
            left.Size = new Size(568, 460);
            left.TabIndex = 12;
            // 
            // panel13
            // 
            panel13.Controls.Add(panel16);
            panel13.Controls.Add(panel17);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 360);
            panel13.Name = "panel13";
            panel13.Padding = new Padding(10, 0, 0, 0);
            panel13.Size = new Size(568, 90);
            panel13.TabIndex = 5;
            // 
            // panel16
            // 
            panel16.Controls.Add(txtbDuongDanAnh);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(10, 50);
            panel16.Name = "panel16";
            panel16.Size = new Size(558, 40);
            panel16.TabIndex = 3;
            // 
            // txtbDuongDanAnh
            // 
            txtbDuongDanAnh.Dock = DockStyle.Fill;
            txtbDuongDanAnh.Font = new Font("Segoe UI", 14F);
            txtbDuongDanAnh.Location = new Point(0, 0);
            txtbDuongDanAnh.Name = "txtbDuongDanAnh";
            txtbDuongDanAnh.Size = new Size(558, 39);
            txtbDuongDanAnh.TabIndex = 0;
            // 
            // panel17
            // 
            panel17.Controls.Add(label6);
            panel17.Dock = DockStyle.Top;
            panel17.Location = new Point(10, 0);
            panel17.Name = "panel17";
            panel17.Size = new Size(558, 50);
            panel17.TabIndex = 2;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(558, 50);
            label6.TabIndex = 0;
            label6.Text = "Đường dẫn ảnh";
            label6.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panel10
            // 
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(panel12);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 270);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(10, 0, 0, 0);
            panel10.Size = new Size(568, 90);
            panel10.TabIndex = 4;
            // 
            // panel11
            // 
            panel11.Controls.Add(btnThemNhanVien);
            panel11.Controls.Add(cbNhanVien);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(10, 50);
            panel11.Name = "panel11";
            panel11.Size = new Size(558, 40);
            panel11.TabIndex = 3;
            // 
            // btnThemNhanVien
            // 
            btnThemNhanVien.BackColor = Color.DodgerBlue;
            btnThemNhanVien.BorderColor = Color.DodgerBlue;
            btnThemNhanVien.BorderRadius = 20;
            btnThemNhanVien.BorderSize = 0;
            btnThemNhanVien.Dock = DockStyle.Right;
            btnThemNhanVien.FlatAppearance.BorderSize = 0;
            btnThemNhanVien.FlatStyle = FlatStyle.Flat;
            btnThemNhanVien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThemNhanVien.ForeColor = Color.White;
            btnThemNhanVien.Location = new Point(382, 0);
            btnThemNhanVien.Name = "btnThemNhanVien";
            btnThemNhanVien.Size = new Size(176, 40);
            btnThemNhanVien.TabIndex = 2;
            btnThemNhanVien.Text = "Thêm nhân viên";
            btnThemNhanVien.UseVisualStyleBackColor = false;
            // 
            // cbNhanVien
            // 
            cbNhanVien.Dock = DockStyle.Left;
            cbNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNhanVien.Font = new Font("Segoe UI", 14F);
            cbNhanVien.FormattingEnabled = true;
            cbNhanVien.Location = new Point(0, 0);
            cbNhanVien.Name = "cbNhanVien";
            cbNhanVien.Size = new Size(281, 39);
            cbNhanVien.TabIndex = 0;
            // 
            // panel12
            // 
            panel12.Controls.Add(label5);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(10, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(558, 50);
            panel12.TabIndex = 2;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(558, 50);
            label5.TabIndex = 0;
            label5.Text = "Nhân viên";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(panel9);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 180);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10, 0, 0, 0);
            panel7.Size = new Size(568, 90);
            panel7.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnThemQuyen);
            panel8.Controls.Add(cbQuyen);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(10, 50);
            panel8.Name = "panel8";
            panel8.Size = new Size(558, 40);
            panel8.TabIndex = 3;
            // 
            // btnThemQuyen
            // 
            btnThemQuyen.BackColor = Color.DodgerBlue;
            btnThemQuyen.BorderColor = Color.DodgerBlue;
            btnThemQuyen.BorderRadius = 20;
            btnThemQuyen.BorderSize = 0;
            btnThemQuyen.Dock = DockStyle.Right;
            btnThemQuyen.FlatAppearance.BorderSize = 0;
            btnThemQuyen.FlatStyle = FlatStyle.Flat;
            btnThemQuyen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThemQuyen.ForeColor = Color.White;
            btnThemQuyen.Location = new Point(382, 0);
            btnThemQuyen.Name = "btnThemQuyen";
            btnThemQuyen.Size = new Size(176, 40);
            btnThemQuyen.TabIndex = 2;
            btnThemQuyen.Text = "Thêm quyền";
            btnThemQuyen.UseVisualStyleBackColor = false;
            btnThemQuyen.Click += btnThemQuyen_Click;
            // 
            // cbQuyen
            // 
            cbQuyen.Dock = DockStyle.Left;
            cbQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbQuyen.Font = new Font("Segoe UI", 14F);
            cbQuyen.FormattingEnabled = true;
            cbQuyen.Location = new Point(0, 0);
            cbQuyen.Name = "cbQuyen";
            cbQuyen.Size = new Size(281, 39);
            cbQuyen.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(label4);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(10, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(558, 50);
            panel9.TabIndex = 2;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(558, 50);
            label4.TabIndex = 0;
            label4.Text = "Quyền";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel6);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 90);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10, 0, 0, 0);
            panel2.Size = new Size(568, 90);
            panel2.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtbMatKhau);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(10, 50);
            panel5.Name = "panel5";
            panel5.Size = new Size(558, 40);
            panel5.TabIndex = 3;
            // 
            // txtbMatKhau
            // 
            txtbMatKhau.Dock = DockStyle.Fill;
            txtbMatKhau.Font = new Font("Segoe UI", 14F);
            txtbMatKhau.Location = new Point(0, 0);
            txtbMatKhau.Name = "txtbMatKhau";
            txtbMatKhau.Size = new Size(558, 39);
            txtbMatKhau.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(label3);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(10, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(558, 50);
            panel6.TabIndex = 2;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(558, 50);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // field
            // 
            field.Controls.Add(panel4);
            field.Controls.Add(panel3);
            field.Dock = DockStyle.Top;
            field.Location = new Point(0, 0);
            field.Name = "field";
            field.Padding = new Padding(10, 0, 0, 0);
            field.Size = new Size(568, 90);
            field.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtbTenTaiKhoan);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(10, 50);
            panel4.Name = "panel4";
            panel4.Size = new Size(558, 40);
            panel4.TabIndex = 3;
            // 
            // txtbTenTaiKhoan
            // 
            txtbTenTaiKhoan.Dock = DockStyle.Fill;
            txtbTenTaiKhoan.Font = new Font("Segoe UI", 14F);
            txtbTenTaiKhoan.Location = new Point(0, 0);
            txtbTenTaiKhoan.Name = "txtbTenTaiKhoan";
            txtbTenTaiKhoan.Size = new Size(558, 39);
            txtbTenTaiKhoan.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(10, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(558, 50);
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(558, 50);
            label2.TabIndex = 0;
            label2.Text = "Tên tài khoản";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // right
            // 
            right.Controls.Add(panel18);
            right.Controls.Add(panel15);
            right.Dock = DockStyle.Right;
            right.Location = new Point(568, 0);
            right.Name = "right";
            right.Padding = new Padding(0, 0, 0, 10);
            right.Size = new Size(212, 460);
            right.TabIndex = 11;
            // 
            // panel18
            // 
            panel18.Controls.Add(pictureBox1);
            panel18.Dock = DockStyle.Bottom;
            panel18.Location = new Point(0, 198);
            panel18.Name = "panel18";
            panel18.Size = new Size(212, 212);
            panel18.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(212, 212);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel15
            // 
            panel15.Controls.Add(btnChonAnh);
            panel15.Controls.Add(panel19);
            panel15.Dock = DockStyle.Bottom;
            panel15.Location = new Point(0, 410);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(10, 0, 0, 0);
            panel15.Size = new Size(212, 40);
            panel15.TabIndex = 2;
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.DodgerBlue;
            btnChonAnh.BorderColor = Color.DodgerBlue;
            btnChonAnh.BorderRadius = 20;
            btnChonAnh.BorderSize = 0;
            btnChonAnh.Dock = DockStyle.Right;
            btnChonAnh.FlatAppearance.BorderSize = 0;
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(50, 0);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(125, 40);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Chọn Ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // title
            // 
            title.Controls.Add(label1);
            title.Dock = DockStyle.Top;
            title.Location = new Point(0, 0);
            title.Name = "title";
            title.Size = new Size(780, 80);
            title.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(780, 80);
            label1.TabIndex = 0;
            label1.Text = "Thêm Tài Khoản";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // panel19
            // 
            panel19.Dock = DockStyle.Right;
            panel19.Location = new Point(175, 0);
            panel19.Name = "panel19";
            panel19.Size = new Size(37, 40);
            panel19.TabIndex = 2;
            // 
            // AddAccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 660);
            Controls.Add(panel1);
            Name = "AddAccountForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddAccountForm";
            Load += AddAccountForm_Load;
            panel1.ResumeLayout(false);
            button.ResumeLayout(false);
            panel14.ResumeLayout(false);
            middle.ResumeLayout(false);
            left.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel17.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            field.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            right.ResumeLayout(false);
            panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel15.ResumeLayout(false);
            title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel title;
        private Panel middle;
        private Label label1;
        private Controls.RoundedButton btnChonAnh;
        private ImageList imageList1;
        private Panel button;
        private Controls.RoundedButton btnXacNhanTTK;
        private Controls.RoundedButton btnThoatTTK;
        private Panel panel14;
        private Panel panel15;
        private ErrorProvider errorProvider1;
        private Panel panel17;
        private Panel panel16;
        private Label label7;
        private Panel panel18;
        private Panel left;
        private Panel right;
        private Panel panel4;
        private Panel panel3;
        private Panel field;
        private TextBox txtbTenTaiKhoan;
        private Label label2;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Label label5;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Label label4;
        private Panel panel2;
        private Panel panel5;
        private TextBox txtbMatKhau;
        private Panel panel6;
        private Label label3;
        private ComboBox cbNhanVien;
        private ComboBox cbQuyen;
        private Panel panel13;
        private TextBox txtbDuongDanAnh;
        private Label label6;
        private Controls.RoundedButton btnThemNhanVien;
        private Controls.RoundedButton btnThemQuyen;
        private PictureBox pictureBox1;
        private Panel panel19;
    }
}