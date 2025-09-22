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
            panelFooter = new Panel();
            Infopanel = new Panel();
            avatarUser = new PictureBox();
            username = new Label();
            panelMenu = new Panel();
            layoutMenu = new TableLayoutPanel();
            btnOrder = new Button();
            btnHoaDon = new Button();
            btnThongKe = new Button();
            btnKhuyenMai = new Button();
            btnPhieuNhap = new Button();
            btnTaiKhoan = new Button();
            btnDangXuat = new Button();
            signature = new Label();
            panelMain.SuspendLayout();
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
            panelMain.Size = new Size(1101, 531);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.BackColor = SystemColors.Window;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(0, 0, 30, 0);
            panelContent.Size = new Size(1101, 472);
            panelContent.TabIndex = 1;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = SystemColors.MenuHighlight;
            panelFooter.Controls.Add(signature);
            panelFooter.Controls.Add(Infopanel);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 472);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(10);
            panelFooter.Size = new Size(1101, 59);
            panelFooter.TabIndex = 0;
            // 
            // Infopanel
            // 
            Infopanel.Controls.Add(username);
            Infopanel.Controls.Add(avatarUser);
            Infopanel.Dock = DockStyle.Right;
            Infopanel.Location = new Point(876, 10);
            Infopanel.Name = "Infopanel";
            Infopanel.Size = new Size(215, 39);
            Infopanel.TabIndex = 0;
            // 
            // avatarUser
            // 
            avatarUser.Dock = DockStyle.Right;
            avatarUser.Image = Properties.Resources.circle_user;
            avatarUser.Location = new Point(153, 0);
            avatarUser.Name = "avatarUser";
            avatarUser.Padding = new Padding(34, 0, 0, 0);
            avatarUser.Size = new Size(62, 39);
            avatarUser.SizeMode = PictureBoxSizeMode.Zoom;
            avatarUser.TabIndex = 0;
            avatarUser.TabStop = false;
            avatarUser.Click += pictureBox1_Click;
            // 
            // username
            // 
            username.Dock = DockStyle.Fill;
            username.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username.ForeColor = SystemColors.ButtonHighlight;
            username.Location = new Point(0, 0);
            username.Name = "username";
            username.Size = new Size(153, 39);
            username.TabIndex = 1;
            username.Text = "Anh Huy";
            username.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.Highlight;
            panelMenu.Controls.Add(layoutMenu);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(176, 531);
            panelMenu.TabIndex = 0;
            // 
            // layoutMenu
            // 
            layoutMenu.ColumnCount = 1;
            layoutMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMenu.Controls.Add(btnOrder, 0, 0);
            layoutMenu.Controls.Add(btnHoaDon, 0, 1);
            layoutMenu.Controls.Add(btnThongKe, 0, 2);
            layoutMenu.Controls.Add(btnKhuyenMai, 0, 3);
            layoutMenu.Controls.Add(btnPhieuNhap, 0, 4);
            layoutMenu.Controls.Add(btnTaiKhoan, 0, 5);
            layoutMenu.Controls.Add(btnDangXuat, 0, 6);
            layoutMenu.Dock = DockStyle.Fill;
            layoutMenu.Location = new Point(0, 0);
            layoutMenu.Name = "layoutMenu";
            layoutMenu.RowCount = 7;
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            layoutMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutMenu.Size = new Size(176, 531);
            layoutMenu.TabIndex = 0;
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
            btnOrder.Size = new Size(170, 69);
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
            btnHoaDon.Location = new Point(3, 78);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(170, 69);
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
            btnThongKe.Location = new Point(3, 153);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(170, 69);
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
            btnKhuyenMai.Location = new Point(3, 228);
            btnKhuyenMai.Name = "btnKhuyenMai";
            btnKhuyenMai.Size = new Size(170, 69);
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
            btnPhieuNhap.Location = new Point(3, 303);
            btnPhieuNhap.Name = "btnPhieuNhap";
            btnPhieuNhap.Size = new Size(170, 69);
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
            btnTaiKhoan.Location = new Point(3, 378);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(170, 69);
            btnTaiKhoan.TabIndex = 6;
            btnTaiKhoan.Text = "   Tài khoản";
            btnTaiKhoan.UseVisualStyleBackColor = true;
            btnTaiKhoan.Click += btnAccount_Click;
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
            btnDangXuat.Location = new Point(3, 453);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(170, 75);
            btnDangXuat.TabIndex = 7;
            btnDangXuat.Text = "   Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // signature
            // 
            signature.Dock = DockStyle.Fill;
            signature.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signature.ForeColor = SystemColors.ButtonHighlight;
            signature.Location = new Point(10, 10);
            signature.Name = "signature";
            signature.Size = new Size(866, 39);
            signature.TabIndex = 1;
            signature.Text = "Chào mừng đến với wibu world";
            signature.TextAlign = ContentAlignment.MiddleCenter;
            signature.Click += signature_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 531);
            Controls.Add(panelMain);
            Controls.Add(panelMenu);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panelMain.ResumeLayout(false);
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
        private Button btnDangXuat;
        private Panel Infopanel;
        private PictureBox avatarUser;
        private Label username;
        private Label signature;
    }
}
