namespace MilkTea.Client.Forms.ChildForm_Account
{
    partial class DanhSachQuyenForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhSachQuyenForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel3 = new Panel();
            Table = new Panel();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            tenQuyen = new DataGridViewTextBoxColumn();
            sua = new DataGridViewImageColumn();
            xoa = new DataGridViewImageColumn();
            Button = new Panel();
            lblStatus = new Label();
            btnDong = new MilkTea.Client.Controls.RoundedButton();
            Tool = new Panel();
            panel7 = new Panel();
            btnThemQuyen = new MilkTea.Client.Controls.RoundedButton();
            txtbSearchQuyen = new MilkTea.Client.Controls.RoundedTextBox();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Button.SuspendLayout();
            Tool.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ScrollBar;
            panel3.Controls.Add(Table);
            panel3.Controls.Add(Button);
            panel3.Controls.Add(Tool);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20);
            panel3.Size = new Size(800, 350);
            panel3.TabIndex = 1;
            // 
            // Table
            // 
            Table.Controls.Add(dataGridView1);
            Table.Dock = DockStyle.Fill;
            Table.Location = new Point(20, 70);
            Table.Name = "Table";
            Table.Size = new Size(760, 210);
            Table.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, tenQuyen, sua, xoa });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 210);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += this.dataGridView1_CellClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Resizable = DataGridViewTriState.False;
            ID.Width = 75;
            // 
            // tenQuyen
            // 
            tenQuyen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenQuyen.HeaderText = "Tên Quyền";
            tenQuyen.MinimumWidth = 6;
            tenQuyen.Name = "tenQuyen";
            tenQuyen.ReadOnly = true;
            tenQuyen.Resizable = DataGridViewTriState.False;
            // 
            // sua
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = resources.GetObject("dataGridViewCellStyle1.NullValue");
            dataGridViewCellStyle1.Padding = new Padding(3);
            sua.DefaultCellStyle = dataGridViewCellStyle1;
            sua.HeaderText = "Sửa";
            sua.Image = Properties.Resources.edit;
            sua.ImageLayout = DataGridViewImageCellLayout.Zoom;
            sua.MinimumWidth = 6;
            sua.Name = "sua";
            sua.ReadOnly = true;
            sua.Resizable = DataGridViewTriState.True;
            sua.SortMode = DataGridViewColumnSortMode.Automatic;
            sua.Width = 125;
            // 
            // xoa
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = resources.GetObject("dataGridViewCellStyle2.NullValue");
            dataGridViewCellStyle2.Padding = new Padding(3);
            xoa.DefaultCellStyle = dataGridViewCellStyle2;
            xoa.HeaderText = "Xóa";
            xoa.Image = Properties.Resources.trash;
            xoa.MinimumWidth = 6;
            xoa.Name = "xoa";
            xoa.ReadOnly = true;
            xoa.Width = 125;
            // 
            // Button
            // 
            Button.Controls.Add(lblStatus);
            Button.Controls.Add(btnDong);
            Button.Dock = DockStyle.Bottom;
            Button.Location = new Point(20, 280);
            Button.Name = "Button";
            Button.Padding = new Padding(0, 10, 0, 0);
            Button.Size = new Size(760, 50);
            Button.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Left;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(0, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(629, 40);
            lblStatus.TabIndex = 1;
            // 
            // btnDong
            // 
            btnDong.BackColor = Color.Red;
            btnDong.BorderColor = Color.DodgerBlue;
            btnDong.BorderRadius = 20;
            btnDong.BorderSize = 0;
            btnDong.Dock = DockStyle.Right;
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(635, 10);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(125, 40);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // Tool
            // 
            Tool.Controls.Add(panel7);
            Tool.Controls.Add(txtbSearchQuyen);
            Tool.Dock = DockStyle.Top;
            Tool.Location = new Point(20, 20);
            Tool.Name = "Tool";
            Tool.Padding = new Padding(0, 0, 0, 10);
            Tool.Size = new Size(760, 50);
            Tool.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnThemQuyen);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(250, 40);
            panel7.TabIndex = 2;
            // 
            // btnThemQuyen
            // 
            btnThemQuyen.BackColor = Color.DodgerBlue;
            btnThemQuyen.BorderColor = Color.DodgerBlue;
            btnThemQuyen.BorderRadius = 20;
            btnThemQuyen.BorderSize = 0;
            btnThemQuyen.Dock = DockStyle.Left;
            btnThemQuyen.FlatAppearance.BorderSize = 0;
            btnThemQuyen.FlatStyle = FlatStyle.Flat;
            btnThemQuyen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThemQuyen.ForeColor = Color.White;
            btnThemQuyen.Location = new Point(0, 0);
            btnThemQuyen.Name = "btnThemQuyen";
            btnThemQuyen.Size = new Size(125, 40);
            btnThemQuyen.TabIndex = 0;
            btnThemQuyen.Text = "+ Thêm";
            btnThemQuyen.UseVisualStyleBackColor = false;
            btnThemQuyen.Click += btnThemQuyen_Click;
            // 
            // txtbSearchQuyen
            // 
            txtbSearchQuyen.BackColor = Color.White;
            txtbSearchQuyen.BorderColor = Color.Gray;
            txtbSearchQuyen.BorderRadius = 20;
            txtbSearchQuyen.Dock = DockStyle.Right;
            txtbSearchQuyen.FocusBorderColor = Color.DeepSkyBlue;
            txtbSearchQuyen.Location = new Point(426, 0);
            txtbSearchQuyen.Name = "txtbSearchQuyen";
            txtbSearchQuyen.Padding = new Padding(10, 5, 40, 5);
            txtbSearchQuyen.Placeholder = "Từ khóa tìm kiếm...";
            txtbSearchQuyen.Size = new Size(334, 40);
            txtbSearchQuyen.TabIndex = 1;
            txtbSearchQuyen.TextValue = "";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 100);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 100);
            label1.TabIndex = 0;
            label1.Text = "Quyền";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DanhSachQuyenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "DanhSachQuyenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh Sách Quyền";
            Load += DanhSachQuyenForm_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Button.ResumeLayout(false);
            Tool.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Panel Button;
        private Controls.RoundedButton btnDong;
        private Panel Table;
        private DataGridView dataGridView1;
        private Panel Tool;
        private Controls.RoundedTextBox txtbSearchQuyen;
        private Controls.RoundedButton btnThemQuyen;
        private Panel panel7;
        private Label lblStatus;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn tenQuyen;
        private DataGridViewImageColumn sua;
        private DataGridViewImageColumn xoa;
    }
}