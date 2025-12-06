
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            ButtonQuyen = new Panel();
            btnDanhSachQuyen = new MilkTea.Client.Controls.RoundedButton();
            SearchBox = new Panel();
            Search = new MilkTea.Client.Controls.RoundedTextBox();
            SearchFilter = new Panel();
            cbSearchFilter = new ComboBox();
            ButtonThem = new Panel();
            btnThemAccount = new MilkTea.Client.Controls.RoundedButton();
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            taiKhoan = new DataGridViewTextBoxColumn();
            trangThai = new DataGridViewTextBoxColumn();
            quyen = new DataGridViewTextBoxColumn();
            chiTiet = new DataGridViewImageColumn();
            sua = new DataGridViewImageColumn();
            khoa = new DataGridViewImageColumn();
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
            SearchBox.SuspendLayout();
            SearchFilter.SuspendLayout();
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
            panel4.Size = new Size(1658, 51);
            panel4.TabIndex = 3;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1658, 51);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Tài Khoản";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Tool
            // 
            Tool.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Tool.BackColor = SystemColors.ActiveBorder;
            Tool.Controls.Add(ButtonQuyen);
            Tool.Controls.Add(SearchBox);
            Tool.Controls.Add(SearchFilter);
            Tool.Controls.Add(ButtonThem);
            Tool.Dock = DockStyle.Top;
            Tool.Location = new Point(0, 100);
            Tool.Name = "Tool";
            Tool.Padding = new Padding(21, 29, 21, 29);
            Tool.Size = new Size(1658, 100);
            Tool.TabIndex = 2;
            // 
            // ButtonQuyen
            // 
            ButtonQuyen.Controls.Add(btnDanhSachQuyen);
            ButtonQuyen.Dock = DockStyle.Top;
            ButtonQuyen.Location = new Point(611, 29);
            ButtonQuyen.Name = "ButtonQuyen";
            ButtonQuyen.Size = new Size(1026, 40);
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
            btnDanhSachQuyen.Location = new Point(823, 0);
            btnDanhSachQuyen.Name = "btnDanhSachQuyen";
            btnDanhSachQuyen.Size = new Size(203, 40);
            btnDanhSachQuyen.TabIndex = 4;
            btnDanhSachQuyen.Text = "Danh Sách Quyền";
            btnDanhSachQuyen.UseVisualStyleBackColor = false;
            btnDanhSachQuyen.Click += btnDanhSachQuyen_Click;
            // 
            // SearchBox
            // 
            SearchBox.Controls.Add(Search);
            SearchBox.Dock = DockStyle.Left;
            SearchBox.Location = new Point(341, 29);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(270, 42);
            SearchBox.TabIndex = 13;
            // 
            // Search
            // 
            Search.BackColor = Color.White;
            Search.BorderColor = Color.Gray;
            Search.BorderRadius = 20;
            Search.Dock = DockStyle.Left;
            Search.FocusBorderColor = Color.DeepSkyBlue;
            Search.Font = new Font("Segoe UI", 14F);
            Search.Location = new Point(0, 0);
            Search.Name = "Search";
            Search.Padding = new Padding(10, 5, 40, 5);
            Search.Placeholder = "Từ khóa tìm kiếm...";
            Search.Size = new Size(250, 42);
            Search.TabIndex = 1;
            Search.TextValue = "";
            Search.KeyUp += Search_KeyUp;
            // 
            // SearchFilter
            // 
            SearchFilter.Controls.Add(cbSearchFilter);
            SearchFilter.Dock = DockStyle.Left;
            SearchFilter.Location = new Point(171, 29);
            SearchFilter.Name = "SearchFilter";
            SearchFilter.Size = new Size(170, 42);
            SearchFilter.TabIndex = 14;
            // 
            // cbSearchFilter
            // 
            cbSearchFilter.Dock = DockStyle.Left;
            cbSearchFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchFilter.Font = new Font("Segoe UI", 14.8F);
            cbSearchFilter.FormattingEnabled = true;
            cbSearchFilter.Location = new Point(0, 0);
            cbSearchFilter.Name = "cbSearchFilter";
            cbSearchFilter.Size = new Size(151, 43);
            cbSearchFilter.TabIndex = 0;
            cbSearchFilter.SelectedIndexChanged += cbSearchFilter_SelectedIndexChanged;
            // 
            // ButtonThem
            // 
            ButtonThem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonThem.Controls.Add(btnThemAccount);
            ButtonThem.Dock = DockStyle.Left;
            ButtonThem.Location = new Point(21, 29);
            ButtonThem.Name = "ButtonThem";
            ButtonThem.Size = new Size(150, 42);
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
            btnThemAccount.Size = new Size(130, 42);
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
            Table.Location = new Point(0, 251);
            Table.Name = "Table";
            Table.Padding = new Padding(21, 20, 21, 20);
            Table.Size = new Size(1658, 268);
            Table.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(21, 20);
            panel5.Name = "panel5";
            panel5.Size = new Size(1616, 197);
            panel5.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, taiKhoan, trangThai, quyen, chiTiet, sua, khoa });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1616, 197);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ID.DataPropertyName = "MaTK";
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
            taiKhoan.DataPropertyName = "TenTaiKhoan";
            taiKhoan.HeaderText = "Tài Khoản";
            taiKhoan.MinimumWidth = 6;
            taiKhoan.Name = "taiKhoan";
            taiKhoan.ReadOnly = true;
            taiKhoan.Resizable = DataGridViewTriState.False;
            // 
            // trangThai
            // 
            trangThai.DataPropertyName = "TrangThai";
            trangThai.HeaderText = "Trạng Thái";
            trangThai.MinimumWidth = 6;
            trangThai.Name = "trangThai";
            trangThai.ReadOnly = true;
            trangThai.Resizable = DataGridViewTriState.False;
            trangThai.Width = 150;
            // 
            // quyen
            // 
            quyen.DataPropertyName = "MaQuyen";
            quyen.HeaderText = "Quyền";
            quyen.MinimumWidth = 6;
            quyen.Name = "quyen";
            quyen.ReadOnly = true;
            quyen.Resizable = DataGridViewTriState.False;
            quyen.Width = 200;
            // 
            // chiTiet
            // 
            chiTiet.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
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
            dataGridViewCellStyle2.NullValue = null;
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
            dataGridViewCellStyle3.NullValue = null;
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
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(lblStatus);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(21, 217);
            panel3.Name = "panel3";
            panel3.Size = new Size(1616, 31);
            panel3.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1616, 31);
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
            SearchBox.ResumeLayout(false);
            SearchFilter.ResumeLayout(false);
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
        private ComboBox comboBox1;
        private ComboBox cbSearchFilter;
    }
}