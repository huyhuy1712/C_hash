
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
            Panel panel3;
            Panel panel5;
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            Panel panel2;
            Panel panel4;
            btnDanhSachQuyen = new MilkTea.Client.Controls.RoundedButton();
            roundedComboBox2 = new MilkTea.Client.Controls.RoundedComboBox();
            roundedComboBox1 = new MilkTea.Client.Controls.RoundedComboBox();
            Search = new MilkTea.Client.Controls.RoundedTextBox();
            btnThemAccount = new MilkTea.Client.Controls.RoundedButton();
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
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            panel5 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(btnDanhSachQuyen);
            panel3.Controls.Add(roundedComboBox2);
            panel3.Controls.Add(roundedComboBox1);
            panel3.Controls.Add(Search);
            panel3.Controls.Add(btnThemAccount);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(1658, 50);
            panel3.TabIndex = 2;
            // 
            // btnDanhSachQuyen
            // 
            btnDanhSachQuyen.BackColor = Color.DodgerBlue;
            btnDanhSachQuyen.BorderColor = Color.DodgerBlue;
            btnDanhSachQuyen.BorderRadius = 20;
            btnDanhSachQuyen.BorderSize = 0;
            btnDanhSachQuyen.FlatAppearance.BorderSize = 0;
            btnDanhSachQuyen.FlatStyle = FlatStyle.Flat;
            btnDanhSachQuyen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDanhSachQuyen.ForeColor = Color.White;
            btnDanhSachQuyen.Location = new Point(715, 6);
            btnDanhSachQuyen.Name = "btnDanhSachQuyen";
            btnDanhSachQuyen.Size = new Size(228, 36);
            btnDanhSachQuyen.TabIndex = 4;
            btnDanhSachQuyen.Text = "Danh Sách Quyền";
            btnDanhSachQuyen.UseVisualStyleBackColor = false;
            btnDanhSachQuyen.Click += btnDanhSachQuyen_Click;
            // 
            // roundedComboBox2
            // 
            roundedComboBox2.BackColor = Color.White;
            roundedComboBox2.BorderColor = Color.Gray;
            roundedComboBox2.BorderRadius = 15;
            roundedComboBox2.BorderSize = 1;
            roundedComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox2.FlatStyle = FlatStyle.Flat;
            roundedComboBox2.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox2.Font = new Font("Segoe UI", 10F);
            roundedComboBox2.FormattingEnabled = true;
            roundedComboBox2.ItemHeight = 30;
            roundedComboBox2.Items.AddRange(new object[] { "Cũ Nhất", "Mới Nhất" });
            roundedComboBox2.Location = new Point(558, 6);
            roundedComboBox2.Name = "roundedComboBox2";
            roundedComboBox2.Size = new Size(151, 36);
            roundedComboBox2.TabIndex = 3;
            // 
            // roundedComboBox1
            // 
            roundedComboBox1.BackColor = Color.White;
            roundedComboBox1.BorderColor = Color.Gray;
            roundedComboBox1.BorderRadius = 15;
            roundedComboBox1.BorderSize = 1;
            roundedComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox1.FlatStyle = FlatStyle.Flat;
            roundedComboBox1.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox1.Font = new Font("Segoe UI", 10F);
            roundedComboBox1.FormattingEnabled = true;
            roundedComboBox1.ItemHeight = 30;
            roundedComboBox1.Location = new Point(401, 6);
            roundedComboBox1.Name = "roundedComboBox1";
            roundedComboBox1.Size = new Size(151, 36);
            roundedComboBox1.TabIndex = 2;
            // 
            // Search
            // 
            Search.BackColor = Color.White;
            Search.BorderColor = Color.Gray;
            Search.BorderRadius = 20;
            Search.FocusBorderColor = Color.DeepSkyBlue;
            Search.Location = new Point(145, 6);
            Search.Name = "Search";
            Search.Padding = new Padding(10, 5, 40, 5);
            Search.Placeholder = "Từ khóa tìm kiếm...";
            Search.Size = new Size(250, 36);
            Search.TabIndex = 1;
            Search.TextValue = "";
            // 
            // btnThemAccount
            // 
            btnThemAccount.BackColor = Color.DodgerBlue;
            btnThemAccount.BorderColor = Color.DodgerBlue;
            btnThemAccount.BorderRadius = 20;
            btnThemAccount.BorderSize = 0;
            btnThemAccount.FlatAppearance.BorderSize = 0;
            btnThemAccount.FlatStyle = FlatStyle.Flat;
            btnThemAccount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThemAccount.ForeColor = Color.White;
            btnThemAccount.Location = new Point(12, 6);
            btnThemAccount.Name = "btnThemAccount";
            btnThemAccount.Size = new Size(127, 36);
            btnThemAccount.TabIndex = 0;
            btnThemAccount.Text = "+ Thêm";
            btnThemAccount.UseVisualStyleBackColor = false;
            btnThemAccount.Click += btnThemAccount_Click;
            // 
            // panel5
            // 
            panel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 180);
            panel5.Name = "panel5";
            panel5.Size = new Size(1658, 339);
            panel5.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, taiKhoan, hoVaTen, trangThai, ngayTao, quyen, chiTiet, sua, khoa, xoa });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1658, 339);
            dataGridView1.TabIndex = 0;
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
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = resources.GetObject("dataGridViewCellStyle9.NullValue");
            dataGridViewCellStyle9.Padding = new Padding(3);
            chiTiet.DefaultCellStyle = dataGridViewCellStyle9;
            chiTiet.HeaderText = "Chi Tiết";
            chiTiet.Image = Properties.Resources.circle_user;
            chiTiet.ImageLayout = DataGridViewImageCellLayout.Zoom;
            chiTiet.MinimumWidth = 6;
            chiTiet.Name = "chiTiet";
            chiTiet.ReadOnly = true;
            chiTiet.Resizable = DataGridViewTriState.False;
            chiTiet.Width = 75;
            // 
            // sua
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = resources.GetObject("dataGridViewCellStyle10.NullValue");
            dataGridViewCellStyle10.Padding = new Padding(3);
            sua.DefaultCellStyle = dataGridViewCellStyle10;
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
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.NullValue = resources.GetObject("dataGridViewCellStyle11.NullValue");
            dataGridViewCellStyle11.Padding = new Padding(3);
            khoa.DefaultCellStyle = dataGridViewCellStyle11;
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
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.NullValue = resources.GetObject("dataGridViewCellStyle12.NullValue");
            dataGridViewCellStyle12.Padding = new Padding(3);
            xoa.DefaultCellStyle = dataGridViewCellStyle12;
            xoa.HeaderText = "Xóa";
            xoa.Image = Properties.Resources.trash;
            xoa.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoa.MinimumWidth = 6;
            xoa.Name = "xoa";
            xoa.ReadOnly = true;
            xoa.Resizable = DataGridViewTriState.False;
            xoa.Width = 75;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1658, 80);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1658, 80);
            label1.TabIndex = 0;
            label1.Text = "Tài Khoản";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 130);
            panel4.Name = "panel4";
            panel4.Size = new Size(1658, 50);
            panel4.TabIndex = 3;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1658, 50);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Tài Khoản";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
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
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
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
        private Controls.RoundedTextBox Search;
        private Controls.RoundedComboBox roundedComboBox1;
        private Controls.RoundedComboBox roundedComboBox2;
        private DataGridView dataGridView1;
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
        private Controls.RoundedButton btnDanhSachQuyen;
        private Label label2;
        private Label label1;
    }
}