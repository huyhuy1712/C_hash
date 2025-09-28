namespace MilkTea.Client.Forms.ChildForm_Account
{
    partial class AddQuyenForm
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
            panel10 = new Panel();
            panel11 = new Panel();
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            tenQuyen = new DataGridViewTextBoxColumn();
            chon = new DataGridViewCheckBoxColumn();
            panel6 = new Panel();
            txtbSearch = new MilkTea.Client.Controls.RoundedTextBox();
            panel9 = new Panel();
            btnXacNhan = new MilkTea.Client.Controls.RoundedButton();
            btnDong = new MilkTea.Client.Controls.RoundedButton();
            panel3 = new Panel();
            txtbTenQuyen = new MilkTea.Client.Controls.RoundedTextBox();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel6.SuspendLayout();
            panel9.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel10);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(panel9);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 170);
            panel10.Name = "panel10";
            panel10.Size = new Size(800, 280);
            panel10.TabIndex = 2;
            // 
            // panel11
            // 
            panel11.Controls.Add(panel5);
            panel11.Controls.Add(panel6);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(800, 230);
            panel11.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(800, 180);
            panel5.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tenQuyen, chon });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 180);
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
            panel6.Location = new Point(0, 180);
            panel6.Name = "panel6";
            panel6.Size = new Size(800, 50);
            panel6.TabIndex = 2;
            // 
            // txtbSearch
            // 
            txtbSearch.BackColor = Color.White;
            txtbSearch.BorderColor = Color.Gray;
            txtbSearch.BorderRadius = 20;
            txtbSearch.Dock = DockStyle.Fill;
            txtbSearch.FocusBorderColor = Color.DeepSkyBlue;
            txtbSearch.Location = new Point(0, 0);
            txtbSearch.Name = "txtbSearch";
            txtbSearch.Padding = new Padding(10, 5, 40, 5);
            txtbSearch.Placeholder = "Từ khóa tìm kiếm...";
            txtbSearch.Size = new Size(800, 50);
            txtbSearch.TabIndex = 0;
            txtbSearch.TextValue = "";
            // 
            // panel9
            // 
            panel9.Controls.Add(btnXacNhan);
            panel9.Controls.Add(btnDong);
            panel9.Dock = DockStyle.Bottom;
            panel9.Location = new Point(0, 230);
            panel9.Name = "panel9";
            panel9.Size = new Size(800, 50);
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
            btnXacNhan.Location = new Point(540, 0);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(135, 50);
            btnXacNhan.TabIndex = 1;
            btnXacNhan.Text = "Xác Nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
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
            btnDong.Location = new Point(675, 0);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(125, 50);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtbTenQuyen);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 70);
            panel3.TabIndex = 1;
            // 
            // txtbTenQuyen
            // 
            txtbTenQuyen.BackColor = Color.White;
            txtbTenQuyen.BorderColor = Color.Gray;
            txtbTenQuyen.BorderRadius = 20;
            txtbTenQuyen.Dock = DockStyle.Fill;
            txtbTenQuyen.FocusBorderColor = Color.DeepSkyBlue;
            txtbTenQuyen.Location = new Point(0, 32);
            txtbTenQuyen.Name = "txtbTenQuyen";
            txtbTenQuyen.Padding = new Padding(10, 5, 40, 5);
            txtbTenQuyen.Placeholder = "";
            txtbTenQuyen.Size = new Size(800, 38);
            txtbTenQuyen.TabIndex = 1;
            txtbTenQuyen.TextValue = "";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(800, 32);
            label2.TabIndex = 0;
            label2.Text = "Tên Quyền";
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
            label1.Text = "Thêm Quyền";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddQuyenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "AddQuyenForm";
            Text = "Quyền";
            panel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel6.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Label label2;
        private Controls.RoundedTextBox txtbTenQuyen;
        private Panel panel10;
        private Panel panel11;
        private Panel panel5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn tenQuyen;
        private DataGridViewCheckBoxColumn chon;
        private Panel panel6;
        private Controls.RoundedTextBox txtbSearch;
        private Panel panel9;
        private Controls.RoundedButton btnXacNhan;
        private Controls.RoundedButton btnDong;
    }
}