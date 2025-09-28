namespace MilkTea.Client.Forms.ChildForm_Account
{
    partial class EditQuyenForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel3 = new Panel();
            panel10 = new Panel();
            panel11 = new Panel();
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            tenQuyen = new DataGridViewTextBoxColumn();
            chon = new DataGridViewCheckBoxColumn();
            panel6 = new Panel();
            txtbSearch = new TextBox();
            panel9 = new Panel();
            btnXacNhan = new MilkTea.Client.Controls.RoundedButton();
            panel12 = new Panel();
            btnDong = new MilkTea.Client.Controls.RoundedButton();
            panel4 = new Panel();
            panel8 = new Panel();
            labelTenQuyen = new Label();
            panel7 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel6.SuspendLayout();
            panel9.SuspendLayout();
            panel12.SuspendLayout();
            panel4.SuspendLayout();
            panel8.SuspendLayout();
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
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ScrollBar;
            panel3.Controls.Add(panel10);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20);
            panel3.Size = new Size(800, 350);
            panel3.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(panel9);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(20, 70);
            panel10.Name = "panel10";
            panel10.Size = new Size(760, 260);
            panel10.TabIndex = 1;
            // 
            // panel11
            // 
            panel11.Controls.Add(panel5);
            panel11.Controls.Add(panel6);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(760, 210);
            panel11.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(760, 170);
            panel5.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tenQuyen, chon });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 170);
            dataGridView1.TabIndex = 0;
            // 
            // tenQuyen
            // 
            tenQuyen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenQuyen.HeaderText = "Chức Năng";
            tenQuyen.MinimumWidth = 6;
            tenQuyen.Name = "tenQuyen";
            tenQuyen.ReadOnly = true;
            tenQuyen.Resizable = DataGridViewTriState.False;
            // 
            // chon
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.Padding = new Padding(3);
            chon.DefaultCellStyle = dataGridViewCellStyle2;
            chon.HeaderText = "";
            chon.MinimumWidth = 6;
            chon.Name = "chon";
            chon.ReadOnly = true;
            chon.Resizable = DataGridViewTriState.True;
            chon.SortMode = DataGridViewColumnSortMode.Automatic;
            chon.Width = 125;
            // 
            // panel6
            // 
            panel6.Controls.Add(txtbSearch);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 170);
            panel6.Name = "panel6";
            panel6.Size = new Size(760, 40);
            panel6.TabIndex = 2;
            // 
            // txtbSearch
            // 
            txtbSearch.BorderStyle = BorderStyle.FixedSingle;
            txtbSearch.Dock = DockStyle.Fill;
            txtbSearch.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbSearch.Location = new Point(0, 0);
            txtbSearch.Name = "txtbSearch";
            txtbSearch.PlaceholderText = "Tìm Kiếm ...";
            txtbSearch.Size = new Size(760, 41);
            txtbSearch.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(btnXacNhan);
            panel9.Controls.Add(panel12);
            panel9.Dock = DockStyle.Bottom;
            panel9.Location = new Point(0, 210);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(0, 10, 0, 0);
            panel9.Size = new Size(760, 50);
            panel9.TabIndex = 3;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.Lime;
            btnXacNhan.BorderColor = Color.DodgerBlue;
            btnXacNhan.BorderRadius = 20;
            btnXacNhan.BorderSize = 0;
            btnXacNhan.Dock = DockStyle.Right;
            btnXacNhan.FlatAppearance.BorderSize = 0;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnXacNhan.ForeColor = Color.Black;
            btnXacNhan.Location = new Point(480, 10);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(135, 40);
            btnXacNhan.TabIndex = 1;
            btnXacNhan.Text = "Xác Nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            panel12.Controls.Add(btnDong);
            panel12.Dock = DockStyle.Right;
            panel12.Location = new Point(615, 10);
            panel12.Name = "panel12";
            panel12.Size = new Size(145, 40);
            panel12.TabIndex = 2;
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
            btnDong.ForeColor = Color.Black;
            btnDong.Location = new Point(20, 0);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(125, 40);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(panel7);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(20, 20);
            panel4.Name = "panel4";
            panel4.Size = new Size(760, 50);
            panel4.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(labelTenQuyen);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(244, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(253, 50);
            panel8.TabIndex = 1;
            // 
            // labelTenQuyen
            // 
            labelTenQuyen.Dock = DockStyle.Fill;
            labelTenQuyen.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTenQuyen.Location = new Point(0, 0);
            labelTenQuyen.Name = "labelTenQuyen";
            labelTenQuyen.Size = new Size(253, 50);
            labelTenQuyen.TabIndex = 0;
            labelTenQuyen.Text = "Admin";
            labelTenQuyen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            panel7.Controls.Add(label2);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(244, 50);
            panel7.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(244, 50);
            label2.TabIndex = 0;
            label2.Text = "Tên Quyền:";
            label2.TextAlign = ContentAlignment.MiddleRight;
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
            label1.Text = "Sửa Quyền";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditQuyenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "EditQuyenForm";
            Text = "Quyền";
            Load += EditQuyenForm_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel9.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel6;
        private Panel panel5;
        private DataGridView dataGridView1;
        private Panel panel4;
        private Panel panel2;
        private Label label1;
        private Panel panel8;
        private Panel panel7;
        private Label labelTenQuyen;
        private Label label2;
        private DataGridViewTextBoxColumn tenQuyen;
        private DataGridViewCheckBoxColumn chon;
        private Panel panel9;
        private Controls.RoundedButton btnDong;
        private Panel panel10;
        private Panel panel11;
        private Controls.RoundedButton btnXacNhan;
        private TextBox txtbSearch;
        private Panel panel12;
    }
}