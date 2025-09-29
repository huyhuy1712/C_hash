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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel4 = new Panel();
            Table = new Panel();
            dataGridView1 = new DataGridView();
            tenQuyen = new DataGridViewTextBoxColumn();
            chon = new DataGridViewCheckBoxColumn();
            TimKiem = new Panel();
            textBox1 = new TextBox();
            Button = new Panel();
            btnXacNhan = new MilkTea.Client.Controls.RoundedButton();
            panel2 = new Panel();
            btnDong = new MilkTea.Client.Controls.RoundedButton();
            TextBox = new Panel();
            txtbTenQuyen = new MilkTea.Client.Controls.RoundedTextBox();
            label = new Panel();
            label2 = new Label();
            Title = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            TimKiem.SuspendLayout();
            Button.SuspendLayout();
            panel2.SuspendLayout();
            TextBox.SuspendLayout();
            label.SuspendLayout();
            Title.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(Title);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ScrollBar;
            panel4.Controls.Add(Table);
            panel4.Controls.Add(TimKiem);
            panel4.Controls.Add(Button);
            panel4.Controls.Add(TextBox);
            panel4.Controls.Add(label);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 100);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(20);
            panel4.Size = new Size(800, 350);
            panel4.TabIndex = 1;
            // 
            // Table
            // 
            Table.Controls.Add(dataGridView1);
            Table.Dock = DockStyle.Fill;
            Table.Location = new Point(20, 110);
            Table.Name = "Table";
            Table.Size = new Size(760, 130);
            Table.TabIndex = 1;
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
            dataGridView1.Size = new Size(760, 130);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.Padding = new Padding(3);
            chon.DefaultCellStyle = dataGridViewCellStyle1;
            chon.HeaderText = "";
            chon.MinimumWidth = 6;
            chon.Name = "chon";
            chon.ReadOnly = true;
            chon.Resizable = DataGridViewTriState.True;
            chon.SortMode = DataGridViewColumnSortMode.Automatic;
            chon.Width = 125;
            // 
            // TimKiem
            // 
            TimKiem.Controls.Add(textBox1);
            TimKiem.Dock = DockStyle.Bottom;
            TimKiem.Location = new Point(20, 240);
            TimKiem.Name = "TimKiem";
            TimKiem.Size = new Size(760, 40);
            TimKiem.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Segoe UI", 15F);
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tìm Kiếm ...";
            textBox1.Size = new Size(760, 41);
            textBox1.TabIndex = 0;
            // 
            // Button
            // 
            Button.Controls.Add(btnXacNhan);
            Button.Controls.Add(panel2);
            Button.Dock = DockStyle.Bottom;
            Button.Location = new Point(20, 280);
            Button.Name = "Button";
            Button.Padding = new Padding(0, 10, 0, 0);
            Button.Size = new Size(760, 50);
            Button.TabIndex = 3;
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
            btnXacNhan.Location = new Point(490, 10);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(125, 40);
            btnXacNhan.TabIndex = 1;
            btnXacNhan.Text = "Xác Nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDong);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(615, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(145, 40);
            panel2.TabIndex = 2;
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
            // TextBox
            // 
            TextBox.Controls.Add(txtbTenQuyen);
            TextBox.Dock = DockStyle.Top;
            TextBox.Location = new Point(20, 60);
            TextBox.Name = "TextBox";
            TextBox.Padding = new Padding(0, 0, 0, 10);
            TextBox.Size = new Size(760, 50);
            TextBox.TabIndex = 1;
            // 
            // txtbTenQuyen
            // 
            txtbTenQuyen.BackColor = Color.White;
            txtbTenQuyen.BorderColor = Color.Gray;
            txtbTenQuyen.BorderRadius = 20;
            txtbTenQuyen.Dock = DockStyle.Fill;
            txtbTenQuyen.FocusBorderColor = Color.DeepSkyBlue;
            txtbTenQuyen.Location = new Point(0, 0);
            txtbTenQuyen.Name = "txtbTenQuyen";
            txtbTenQuyen.Padding = new Padding(10, 5, 40, 5);
            txtbTenQuyen.Placeholder = "";
            txtbTenQuyen.Size = new Size(760, 40);
            txtbTenQuyen.TabIndex = 1;
            txtbTenQuyen.TextValue = "";
            // 
            // label
            // 
            label.Controls.Add(label2);
            label.Dock = DockStyle.Top;
            label.Location = new Point(20, 20);
            label.Name = "label";
            label.Size = new Size(760, 40);
            label.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(760, 30);
            label2.TabIndex = 0;
            label2.Text = "Tên Quyền";
            // 
            // Title
            // 
            Title.Controls.Add(label1);
            Title.Dock = DockStyle.Top;
            Title.Location = new Point(0, 0);
            Title.Name = "Title";
            Title.Size = new Size(800, 100);
            Title.TabIndex = 0;
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
            Load += AddQuyenForm_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            TimKiem.ResumeLayout(false);
            TimKiem.PerformLayout();
            Button.ResumeLayout(false);
            panel2.ResumeLayout(false);
            TextBox.ResumeLayout(false);
            label.ResumeLayout(false);
            Title.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel Title;
        private Label label1;
        private Panel label;
        private Label label2;
        private Controls.RoundedTextBox txtbTenQuyen;
        private Panel Table;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn tenQuyen;
        private DataGridViewCheckBoxColumn chon;
        private Panel TimKiem;
        private Panel Button;
        private Controls.RoundedButton btnXacNhan;
        private Controls.RoundedButton btnDong;
        private Panel panel4;
        private TextBox textBox1;
        private Panel TextBox;
        private Panel panel2;
    }
}