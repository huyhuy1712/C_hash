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
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            tenQuyen = new DataGridViewTextBoxColumn();
            sua = new DataGridViewImageColumn();
            xoa = new DataGridViewImageColumn();
            panel4 = new Panel();
            txtbSearchQuyen = new MilkTea.Client.Controls.RoundedTextBox();
            btnThemQuyen = new MilkTea.Client.Controls.RoundedButton();
            panel6 = new Panel();
            btnDong = new MilkTea.Client.Controls.RoundedButton();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
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
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel6);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 350);
            panel3.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 50);
            panel5.Name = "panel5";
            panel5.Size = new Size(800, 250);
            panel5.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tenQuyen, sua, xoa });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 250);
            dataGridView1.TabIndex = 0;
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
            // panel4
            // 
            panel4.Controls.Add(txtbSearchQuyen);
            panel4.Controls.Add(btnThemQuyen);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(800, 50);
            panel4.TabIndex = 0;
            // 
            // txtbSearchQuyen
            // 
            txtbSearchQuyen.BackColor = Color.White;
            txtbSearchQuyen.BorderColor = Color.Gray;
            txtbSearchQuyen.BorderRadius = 20;
            txtbSearchQuyen.Dock = DockStyle.Right;
            txtbSearchQuyen.FocusBorderColor = Color.DeepSkyBlue;
            txtbSearchQuyen.Location = new Point(466, 0);
            txtbSearchQuyen.Name = "txtbSearchQuyen";
            txtbSearchQuyen.Padding = new Padding(10, 5, 40, 5);
            txtbSearchQuyen.Placeholder = "Từ khóa tìm kiếm...";
            txtbSearchQuyen.Size = new Size(334, 50);
            txtbSearchQuyen.TabIndex = 1;
            txtbSearchQuyen.TextValue = "";
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
            btnThemQuyen.Size = new Size(125, 50);
            btnThemQuyen.TabIndex = 0;
            btnThemQuyen.Text = "+ Thêm";
            btnThemQuyen.UseVisualStyleBackColor = false;
            btnThemQuyen.Click += btnThemQuyen_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnDong);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 300);
            panel6.Name = "panel6";
            panel6.Size = new Size(800, 50);
            panel6.TabIndex = 2;
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
            btnDong.Location = new Point(675, 0);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(125, 50);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
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
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Panel panel6;
        private Controls.RoundedButton btnDong;
        private Panel panel5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn tenQuyen;
        private DataGridViewImageColumn sua;
        private DataGridViewImageColumn xoa;
        private Panel panel4;
        private Controls.RoundedTextBox txtbSearchQuyen;
        private Controls.RoundedButton btnThemQuyen;
    }
}