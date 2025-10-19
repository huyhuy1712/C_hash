
namespace MilkTea.Client.Forms
{
    partial class AccountForm
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
            Panel panel2;
            Panel panel4;
            Panel Tool;
            Panel Table;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            ButtonQuyen = new Panel();
            btnDanhSachQuyen = new MilkTea.Client.Controls.RoundedButton();
            Order = new Panel();
            roundedComboBox1 = new MilkTea.Client.Controls.RoundedComboBox();
            SearchFilter = new Panel();
            roundedComboBox2 = new MilkTea.Client.Controls.RoundedComboBox();
            SearchBox = new Panel();
            Search = new MilkTea.Client.Controls.RoundedTextBox();
            ButtonThem = new Panel();
            btnThemAccount = new MilkTea.Client.Controls.RoundedButton();
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            taiKhoan = new DataGridViewTextBoxColumn();
            hoVaTen = new DataGridViewTextBoxColumn();
            trangThai = new DataGridViewTextBoxColumn();
            ngayTao = new DataGridViewTextBoxColumn();
            quyen = new DataGridViewTextBoxColumn();
            chiTiet = new DataGridViewImageColumn();
            sua = new DataGridViewImageColumn();
            khoa = new DataGridViewImageColumn();
            xoa = new DataGridViewImageColumn();
            panel3 = new Panel();
            lblStatus = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            Tool = new Panel();
            Table = new Panel();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            Tool.SuspendLayout();
            ButtonQuyen.SuspendLayout();
            Order.SuspendLayout();
            SearchFilter.SuspendLayout();
            SearchBox.SuspendLayout();
            ButtonThem.SuspendLayout();
            Table.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1658, 100);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1658, 100);
            label1.TabIndex = 0;
            label1.Text = "Tài Khoản";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 200);
            panel4.Name = "panel4";
            panel4.Size = new Size(1658, 50);
            panel4.TabIndex = 3;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1658, 50);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Tài Khoản";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Tool
            // 
            Tool.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Tool.BackColor = SystemColors.ActiveBorder;
            Tool.Controls.Add(ButtonQuyen);
            Tool.Controls.Add(Order);
            Tool.Controls.Add(SearchFilter);
            Tool.Controls.Add(SearchBox);
            Tool.Controls.Add(ButtonThem);
            Tool.Dock = DockStyle.Top;
            Tool.Location = new Point(0, 100);
            Tool.Name = "Tool";
            Tool.Padding = new Padding(20, 30, 20, 30);
            Tool.Size = new Size(1658, 100);
            Tool.TabIndex = 2;
            // 
            // ButtonQuyen
            // 
            ButtonQuyen.Controls.Add(btnDanhSachQuyen);
            ButtonQuyen.Dock = DockStyle.Top;
            ButtonQuyen.Location = new Point(772, 30);
            ButtonQuyen.Name = "ButtonQuyen";
            ButtonQuyen.Size = new Size(866, 40);
            ButtonQuyen.TabIndex = 16;
            // 
            // btnDanhSachQuyen
            // 
            btnDanhSachQuyen.BackColor = Color.DodgerBlue;
            btnDanhSachQuyen.BorderColor = Color.DodgerBlue;
            btnDanhSachQuyen.BorderRadius = 20;
            btnDanhSachQuyen.BorderSize = 0;
            btnDanhSachQuyen.Dock = DockStyle.Right;
            btnDanhSachQuyen.FlatAppearance.BorderSize = 0;
            btnDanhSachQuyen.FlatStyle = FlatStyle.Flat;
            btnDanhSachQuyen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDanhSachQuyen.ForeColor = Color.White;
            btnDanhSachQuyen.Location = new Point(663, 0);
            btnDanhSachQuyen.Name = "btnDanhSachQuyen";
            btnDanhSachQuyen.Size = new Size(203, 40);
            btnDanhSachQuyen.TabIndex = 4;
            btnDanhSachQuyen.Text = "Danh Sách Quyền";
            btnDanhSachQuyen.UseVisualStyleBackColor = false;
            btnDanhSachQuyen.Click += btnDanhSachQuyen_Click;
            // 
            // Order
            // 
            Order.Controls.Add(roundedComboBox1);
            Order.Dock = DockStyle.Left;
            Order.Location = new Point(610, 30);
            Order.Name = "Order";
            Order.Size = new Size(162, 40);
            Order.TabIndex = 15;
            // 
            // roundedComboBox1
            // 
            roundedComboBox1.BackColor = Color.White;
            roundedComboBox1.BorderColor = Color.Gray;
            roundedComboBox1.BorderRadius = 15;
            roundedComboBox1.BorderSize = 1;
            roundedComboBox1.Dock = DockStyle.Left;
            roundedComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox1.FlatStyle = FlatStyle.Flat;
            roundedComboBox1.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox1.Font = new Font("Segoe UI", 10F);
            roundedComboBox1.FormattingEnabled = true;
            roundedComboBox1.ItemHeight = 30;
            roundedComboBox1.Location = new Point(0, 0);
            roundedComboBox1.Name = "roundedComboBox1";
            roundedComboBox1.Size = new Size(150, 36);
            roundedComboBox1.TabIndex = 2;
            // 
            // SearchFilter
            // 
            SearchFilter.Controls.Add(roundedComboBox2);
            SearchFilter.Dock = DockStyle.Left;
            SearchFilter.Location = new Point(440, 30);
            SearchFilter.Name = "SearchFilter";
            SearchFilter.Size = new Size(170, 40);
            SearchFilter.TabIndex = 14;
            // 
            // roundedComboBox2
            // 
            roundedComboBox2.BackColor = Color.White;
            roundedComboBox2.BorderColor = Color.Gray;
            roundedComboBox2.BorderRadius = 15;
            roundedComboBox2.BorderSize = 1;
            roundedComboBox2.Dock = DockStyle.Left;
            roundedComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox2.FlatStyle = FlatStyle.Flat;
            roundedComboBox2.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox2.Font = new Font("Segoe UI", 10F);
            roundedComboBox2.FormattingEnabled = true;
            roundedComboBox2.ItemHeight = 30;
            roundedComboBox2.Items.AddRange(new object[] { "Cũ Nhất", "Mới Nhất" });
            roundedComboBox2.Location = new Point(0, 0);
            roundedComboBox2.Name = "roundedComboBox2";
            roundedComboBox2.Size = new Size(150, 36);
            roundedComboBox2.TabIndex = 3;
            // 
            // SearchBox
            // 
            SearchBox.Controls.Add(Search);
            SearchBox.Dock = DockStyle.Left;
            SearchBox.Location = new Point(170, 30);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(270, 40);
            SearchBox.TabIndex = 13;
            // 
            // Search
            // 
            Search.BackColor = Color.White;
            Search.BorderColor = Color.Gray;
            Search.BorderRadius = 20;
            Search.Dock = DockStyle.Left;
            Search.FocusBorderColor = Color.DeepSkyBlue;
            Search.Location = new Point(0, 0);
            Search.Name = "Search";
            Search.Padding = new Padding(10, 5, 40, 5);
            Search.Placeholder = "Từ khóa tìm kiếm...";
            Search.Size = new Size(250, 40);
            Search.TabIndex = 1;
            Search.TextValue = "";
            // 
            // ButtonThem
            // 
            ButtonThem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonThem.Controls.Add(btnThemAccount);
            ButtonThem.Dock = DockStyle.Left;
            ButtonThem.Location = new Point(20, 30);
            ButtonThem.Name = "ButtonThem";
            ButtonThem.Size = new Size(150, 40);
            ButtonThem.TabIndex = 9;
            // 
            // btnThemAccount
            // 
            btnThemAccount.BackColor = Color.DodgerBlue;
            btnThemAccount.BorderColor = Color.DodgerBlue;
            btnThemAccount.BorderRadius = 20;
            btnThemAccount.BorderSize = 0;
            btnThemAccount.Dock = DockStyle.Left;
            btnThemAccount.FlatAppearance.BorderSize = 0;
            btnThemAccount.FlatStyle = FlatStyle.Flat;
            btnThemAccount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThemAccount.ForeColor = Color.White;
            btnThemAccount.Location = new Point(0, 0);
            btnThemAccount.Name = "btnThemAccount";
            btnThemAccount.Size = new Size(130, 40);
            btnThemAccount.TabIndex = 0;
            btnThemAccount.Text = "+ Thêm";
            btnThemAccount.UseVisualStyleBackColor = false;
            btnThemAccount.Click += btnThemAccount_Click;
            // 
            // Table
            // 
            Table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Table.BackColor = SystemColors.ScrollBar;
            Table.Controls.Add(panel5);
            Table.Controls.Add(panel3);
            Table.Dock = DockStyle.Fill;
            Table.Location = new Point(0, 250);
            Table.Name = "Table";
            Table.Padding = new Padding(20);
            Table.Size = new Size(1658, 269);
            Table.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(20, 20);
            panel5.Name = "panel5";
            panel5.Size = new Size(1618, 198);
            panel5.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, taiKhoan, hoVaTen, trangThai, ngayTao, quyen, chiTiet, sua, khoa, xoa });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1618, 198);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Resizable = DataGridViewTriState.False;
            ID.Width = 125;
            // 
            // taiKhoan
            // 
            taiKhoan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            taiKhoan.HeaderText = "Tài Khoản";
            taiKhoan.MinimumWidth = 6;
            taiKhoan.Name = "taiKhoan";
            taiKhoan.ReadOnly = true;
            taiKhoan.Resizable = DataGridViewTriState.False;
            // 
            // hoVaTen
            // 
            hoVaTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            hoVaTen.HeaderText = "Họ Và Tên";
            hoVaTen.MinimumWidth = 6;
            hoVaTen.Name = "hoVaTen";
            hoVaTen.ReadOnly = true;
            hoVaTen.Resizable = DataGridViewTriState.False;
            // 
            // trangThai
            // 
            trangThai.HeaderText = "Trạng Thái";
            trangThai.MinimumWidth = 6;
            trangThai.Name = "trangThai";
            trangThai.ReadOnly = true;
            trangThai.Resizable = DataGridViewTriState.False;
            trangThai.Width = 150;
            // 
            // ngayTao
            // 
            ngayTao.HeaderText = "Ngày Tạo";
            ngayTao.MinimumWidth = 6;
            ngayTao.Name = "ngayTao";
            ngayTao.ReadOnly = true;
            ngayTao.Resizable = DataGridViewTriState.False;
            ngayTao.Width = 200;
            // 
            // quyen
            // 
            quyen.HeaderText = "Quyền";
            quyen.MinimumWidth = 6;
            quyen.Name = "quyen";
            quyen.ReadOnly = true;
            quyen.Resizable = DataGridViewTriState.False;
            quyen.Width = 150;
            // 
            // chiTiet
            // 
            chiTiet.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = resources.GetObject("dataGridViewCellStyle1.NullValue");
            dataGridViewCellStyle1.Padding = new Padding(3);
            chiTiet.DefaultCellStyle = dataGridViewCellStyle1;
            chiTiet.HeaderText = "Chi Tiết";
            chiTiet.Image = Properties.Resources.info;
            chiTiet.ImageLayout = DataGridViewImageCellLayout.Zoom;
            chiTiet.MinimumWidth = 6;
            chiTiet.Name = "chiTiet";
            chiTiet.ReadOnly = true;
            chiTiet.Resizable = DataGridViewTriState.False;
            chiTiet.Width = 75;
            // 
            // sua
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = resources.GetObject("dataGridViewCellStyle2.NullValue");
            dataGridViewCellStyle2.Padding = new Padding(3);
            sua.DefaultCellStyle = dataGridViewCellStyle2;
            sua.HeaderText = "Sửa";
            sua.Image = Properties.Resources.edit;
            sua.ImageLayout = DataGridViewImageCellLayout.Zoom;
            sua.MinimumWidth = 6;
            sua.Name = "sua";
            sua.ReadOnly = true;
            sua.Resizable = DataGridViewTriState.False;
            sua.Width = 75;
            // 
            // khoa
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = resources.GetObject("dataGridViewCellStyle3.NullValue");
            dataGridViewCellStyle3.Padding = new Padding(3);
            khoa.DefaultCellStyle = dataGridViewCellStyle3;
            khoa.HeaderText = "Khóa";
            khoa.Image = Properties.Resources.padlock;
            khoa.ImageLayout = DataGridViewImageCellLayout.Zoom;
            khoa.MinimumWidth = 6;
            khoa.Name = "khoa";
            khoa.ReadOnly = true;
            khoa.Resizable = DataGridViewTriState.False;
            khoa.Width = 75;
            // 
            // xoa
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = resources.GetObject("dataGridViewCellStyle4.NullValue");
            dataGridViewCellStyle4.Padding = new Padding(3);
            xoa.DefaultCellStyle = dataGridViewCellStyle4;
            xoa.HeaderText = "Xóa";
            xoa.Image = Properties.Resources.trash;
            xoa.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoa.MinimumWidth = 6;
            xoa.Name = "xoa";
            xoa.ReadOnly = true;
            xoa.Resizable = DataGridViewTriState.False;
            xoa.Width = 75;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(lblStatus);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(20, 218);
            panel3.Name = "panel3";
            panel3.Size = new Size(1618, 31);
            panel3.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1618, 31);
            lblStatus.TabIndex = 0;
            lblStatus.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(Table);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(Tool);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1658, 519);
            panel1.TabIndex = 0;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1658, 519);
            Controls.Add(panel1);
            Name = "AccountForm";
            Load += AccountForm_Load;
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            Tool.ResumeLayout(false);
            ButtonQuyen.ResumeLayout(false);
            Order.ResumeLayout(false);
            SearchFilter.ResumeLayout(false);
            SearchBox.ResumeLayout(false);
            ButtonThem.ResumeLayout(false);
            Table.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private Controls.RoundedButton btnThemAccount;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
        private Panel ButtonThem;
        private Panel SearchBox;
        private Controls.RoundedTextBox Search;
        private Panel ButtonQuyen;
        private Controls.RoundedButton btnDanhSachQuyen;
        private Panel Order;
        private Controls.RoundedComboBox roundedComboBox1;
        private Panel SearchFilter;
        private Controls.RoundedComboBox roundedComboBox2;
        private Panel panel3;
        private Label lblStatus;
        private Panel panel5;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn taiKhoan;
        private DataGridViewTextBoxColumn hoVaTen;
        private DataGridViewTextBoxColumn trangThai;
        private DataGridViewTextBoxColumn ngayTao;
        private DataGridViewTextBoxColumn quyen;
        private DataGridViewImageColumn chiTiet;
        private DataGridViewImageColumn sua;
        private DataGridViewImageColumn khoa;
        private DataGridViewImageColumn xoa;
    }
}