namespace MilkTea.Client.Forms   // sửa lại đúng là Client, không phải Cilent
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            panelMain = new Panel();
            panelContent = new Panel();
            label1 = new Label();
            panelFooter = new Panel();
            signature = new Label();
            Infopanel = new Panel();
            username = new Label();
            avatarUser = new PictureBox();
            panelMenu = new Panel();
            layoutMenu = new TableLayoutPanel();
            btnNhanVien = new Button();
            btnDangXuat = new Button();
            btnNguyenLieu = new Button();
            btnOrder = new Button();
            btnHoaDon = new Button();
            btnThongKe = new Button();
            btnKhuyenMai = new Button();
            btnPhieuNhap = new Button();
            btnTaiKhoan = new Button();
            btnNhaCungCap = new Button();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            panelFooter.SuspendLayout();
            Infopanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avatarUser).BeginInit();
            panelMenu.SuspendLayout();
            layoutMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelFooter);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(176, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1675, 885);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.BackColor = SystemColors.Menu;
            panelContent.Controls.Add(label1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1675, 826);
            panelContent.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 30, 0);
            label1.Size = new Size(1675, 826);
            label1.TabIndex = 0;
            label1.Text = "Welcome Home Cheater";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.DodgerBlue;
            panelFooter.Controls.Add(signature);
            panelFooter.Controls.Add(Infopanel);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 826);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(10, 11, 10, 11);
            panelFooter.Size = new Size(1675, 59);
            panelFooter.TabIndex = 0;
            // 
            // signature
            // 
            signature.BackColor = Color.DodgerBlue;
            signature.Dock = DockStyle.Fill;
            signature.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signature.ForeColor = SystemColors.ButtonHighlight;
            signature.Location = new Point(10, 11);
            signature.Name = "signature";
            signature.Size = new Size(1440, 37);
            signature.TabIndex = 1;
            signature.Text = "Chào mừng đến với wibu world";
            signature.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Infopanel
            // 
            Infopanel.Controls.Add(username);
            Infopanel.Controls.Add(avatarUser);
            Infopanel.Dock = DockStyle.Right;
            Infopanel.Location = new Point(1450, 11);
            Infopanel.Name = "Infopanel";
            Infopanel.Size = new Size(215, 37);
            Infopanel.TabIndex = 0;
            // 
            // username
            // 
            username.Dock = DockStyle.Fill;
            username.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username.ForeColor = SystemColors.ButtonHighlight;
            username.Location = new Point(0, 0);
            username.Name = "username";
            username.Size = new Size(153, 37);
            username.TabIndex = 1;
            username.Text = "Anh Huy";
            username.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // avatarUser
            // 
            avatarUser.Dock = DockStyle.Right;
            avatarUser.Image = Properties.Resources.circle_user;
            avatarUser.Location = new Point(153, 0);
            avatarUser.Name = "avatarUser";
            avatarUser.Padding = new Padding(34, 0, 0, 0);
            avatarUser.Size = new Size(62, 37);
            avatarUser.SizeMode = PictureBoxSizeMode.Zoom;
            avatarUser.TabIndex = 0;
            avatarUser.TabStop = false;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.DodgerBlue;
            panelMenu.Controls.Add(layoutMenu);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(176, 885);
            panelMenu.TabIndex = 0;
            // 
            // layoutMenu
            // 
            layoutMenu.ColumnCount = 1;
            layoutMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMenu.Controls.Add(btnNhanVien, 0, 8);
            layoutMenu.Controls.Add(btnDangXuat, 0, 9);
            layoutMenu.Controls.Add(btnNguyenLieu, 0, 7);
            layoutMenu.Controls.Add(btnOrder, 0, 0);
            layoutMenu.Controls.Add(btnHoaDon, 0, 1);
            layoutMenu.Controls.Add(btnThongKe, 0, 2);
            layoutMenu.Controls.Add(btnKhuyenMai, 0, 3);
            layoutMenu.Controls.Add(btnPhieuNhap, 0, 4);
            layoutMenu.Controls.Add(btnTaiKhoan, 0, 5);
            layoutMenu.Controls.Add(btnNhaCungCap, 0, 6);
            layoutMenu.Dock = DockStyle.Fill;
            layoutMenu.Location = new Point(0, 0);
            layoutMenu.Name = "layoutMenu";
            layoutMenu.RowCount = 10;
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutMenu.Size = new Size(176, 885);
            layoutMenu.TabIndex = 0;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Dock = DockStyle.Fill;
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNhanVien.ForeColor = SystemColors.ButtonHighlight;
            btnNhanVien.Image = Properties.Resources.ncc;
            btnNhanVien.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhanVien.Location = new Point(3, 707);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(170, 82);
            btnNhanVien.TabIndex = 9;
            btnNhanVien.Text = "Nhân viên";
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Dock = DockStyle.Fill;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDangXuat.ForeColor = SystemColors.ButtonHighlight;
            btnDangXuat.Image = Properties.Resources.logout;
            btnDangXuat.ImageAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.Location = new Point(3, 795);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(170, 87);
            btnDangXuat.TabIndex = 10;
            btnDangXuat.Text = "   Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnNguyenLieu
            // 
            btnNguyenLieu.Dock = DockStyle.Fill;
            btnNguyenLieu.FlatAppearance.BorderSize = 0;
            btnNguyenLieu.FlatStyle = FlatStyle.Flat;
            btnNguyenLieu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNguyenLieu.ForeColor = SystemColors.ButtonHighlight;
            btnNguyenLieu.Image = Properties.Resources.ingredient;
            btnNguyenLieu.ImageAlign = ContentAlignment.MiddleLeft;
            btnNguyenLieu.Location = new Point(3, 619);
            btnNguyenLieu.Name = "btnNguyenLieu";
            btnNguyenLieu.Size = new Size(170, 82);
            btnNguyenLieu.TabIndex = 8;
            btnNguyenLieu.Text = "      Nguyên Liệu";
            btnNguyenLieu.UseVisualStyleBackColor = true;
            btnNguyenLieu.Click += btnNguyenLieu_Click;
            // 
            // btnOrder
            // 
            btnOrder.Dock = DockStyle.Fill;
            btnOrder.FlatAppearance.BorderSize = 0;
            btnOrder.FlatStyle = FlatStyle.Flat;
            btnOrder.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOrder.ForeColor = SystemColors.ButtonHighlight;
            btnOrder.Image = Properties.Resources.order;
            btnOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrder.Location = new Point(3, 3);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(170, 82);
            btnOrder.TabIndex = 1;
            btnOrder.Text = "    Order";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnHoaDon
            // 
            btnHoaDon.Dock = DockStyle.Fill;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnHoaDon.ForeColor = SystemColors.ButtonHighlight;
            btnHoaDon.Image = Properties.Resources.invoice;
            btnHoaDon.ImageAlign = ContentAlignment.MiddleLeft;
            btnHoaDon.Location = new Point(3, 91);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(170, 82);
            btnHoaDon.TabIndex = 2;
            btnHoaDon.Text = "    Hóa đơn";
            btnHoaDon.UseVisualStyleBackColor = true;
            btnHoaDon.Click += btnInvoice_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.Dock = DockStyle.Fill;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThongKe.ForeColor = SystemColors.ButtonHighlight;
            btnThongKe.Image = Properties.Resources.report;
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Location = new Point(3, 179);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(170, 82);
            btnThongKe.TabIndex = 3;
            btnThongKe.Text = "    Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnReport_Click;
            // 
            // btnKhuyenMai
            // 
            btnKhuyenMai.Dock = DockStyle.Fill;
            btnKhuyenMai.FlatAppearance.BorderSize = 0;
            btnKhuyenMai.FlatStyle = FlatStyle.Flat;
            btnKhuyenMai.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnKhuyenMai.ForeColor = SystemColors.ButtonHighlight;
            btnKhuyenMai.Image = Properties.Resources.discount;
            btnKhuyenMai.ImageAlign = ContentAlignment.MiddleLeft;
            btnKhuyenMai.Location = new Point(3, 267);
            btnKhuyenMai.Name = "btnKhuyenMai";
            btnKhuyenMai.Size = new Size(170, 82);
            btnKhuyenMai.TabIndex = 4;
            btnKhuyenMai.Text = "    Khuyến mãi";
            btnKhuyenMai.UseVisualStyleBackColor = true;
            btnKhuyenMai.Click += btnDiscount_Click;
            // 
            // btnPhieuNhap
            // 
            btnPhieuNhap.Dock = DockStyle.Fill;
            btnPhieuNhap.FlatAppearance.BorderSize = 0;
            btnPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnPhieuNhap.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPhieuNhap.ForeColor = SystemColors.ButtonHighlight;
            btnPhieuNhap.Image = Properties.Resources.import;
            btnPhieuNhap.ImageAlign = ContentAlignment.MiddleLeft;
            btnPhieuNhap.Location = new Point(3, 355);
            btnPhieuNhap.Name = "btnPhieuNhap";
            btnPhieuNhap.Size = new Size(170, 82);
            btnPhieuNhap.TabIndex = 5;
            btnPhieuNhap.Text = "    Phiếu nhập";
            btnPhieuNhap.UseVisualStyleBackColor = true;
            btnPhieuNhap.Click += btnImport_Click;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.Dock = DockStyle.Fill;
            btnTaiKhoan.FlatAppearance.BorderSize = 0;
            btnTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnTaiKhoan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTaiKhoan.ForeColor = SystemColors.ButtonHighlight;
            btnTaiKhoan.Image = Properties.Resources.user;
            btnTaiKhoan.ImageAlign = ContentAlignment.MiddleLeft;
            btnTaiKhoan.Location = new Point(3, 443);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(170, 82);
            btnTaiKhoan.TabIndex = 6;
            btnTaiKhoan.Text = "   Tài khoản";
            btnTaiKhoan.UseVisualStyleBackColor = true;
            btnTaiKhoan.Click += btnAccount_Click;
            // 
            // btnNhaCungCap
            // 
            btnNhaCungCap.Dock = DockStyle.Fill;
            btnNhaCungCap.FlatAppearance.BorderSize = 0;
            btnNhaCungCap.FlatStyle = FlatStyle.Flat;
            btnNhaCungCap.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNhaCungCap.ForeColor = SystemColors.ButtonHighlight;
            btnNhaCungCap.Image = Properties.Resources.ncc;
            btnNhaCungCap.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhaCungCap.Location = new Point(3, 531);
            btnNhaCungCap.Name = "btnNhaCungCap";
            btnNhaCungCap.Size = new Size(170, 82);
            btnNhaCungCap.TabIndex = 7;
            btnNhaCungCap.Text = "     Nhà cung cấp";
            btnNhaCungCap.TextAlign = ContentAlignment.MiddleRight;
            btnNhaCungCap.UseVisualStyleBackColor = true;
            btnNhaCungCap.Click += btnNhaCungCap_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1851, 885);
            Controls.Add(panelMain);
            Controls.Add(panelMenu);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            Infopanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)avatarUser).EndInit();
            panelMenu.ResumeLayout(false);
            layoutMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void BtnDiscount_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panelMain;
        private Panel panelFooter;
        private Panel panelMenu;
        private Panel panelContent;
        private TableLayoutPanel layoutMenu;
        private Button btnOrder;
        private Button btnHoaDon;
        private Button btnThongKe;
        private Button btnKhuyenMai;
        private Button btnPhieuNhap;
        private Button btnTaiKhoan;
        private Button btnNhaCungCap;
        private Panel Infopanel;
        private PictureBox avatarUser;
        private Label username;
        private Label signature;
        private Button btnDangXuat;
        private Button btnNguyenLieu;
        private Button btnNhanVien;
        private Label label1;
    }
}
