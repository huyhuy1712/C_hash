using MilkTea.Client.Controls;

namespace MilkTea.Client.Forms.ChildForm_Discount
{
    partial class AddDiscountForm
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
            label1 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            panel5 = new Panel();
            panel9 = new Panel();
            btnThoatDiscount = new RoundedButton();
            btnThemDiscount = new RoundedButton();
            panel8 = new Panel();
            dGV_sp_KM_ADD = new DataGridView();
            chon_add = new DataGridViewCheckBoxColumn();
            maSP_add = new DataGridViewTextBoxColumn();
            tenSanPham_add = new DataGridViewTextBoxColumn();
            loai_add = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            panel14 = new Panel();
            panel23 = new Panel();
            panel46 = new Panel();
            roundedTextBox1 = new RoundedTextBox();
            panel47 = new Panel();
            checkBox6 = new CheckBox();
            panel7 = new Panel();
            panel10 = new Panel();
            label2 = new Label();
            panel19 = new Panel();
            panel24 = new Panel();
            label9 = new Label();
            textBox2 = new TextBox();
            panel18 = new Panel();
            panel22 = new Panel();
            dateTimePicker2 = new DateTimePicker();
            label8 = new Label();
            panel17 = new Panel();
            panel21 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            panel16 = new Panel();
            panel20 = new Panel();
            roundedComboBox1 = new RoundedComboBox();
            label6 = new Label();
            panel6 = new Panel();
            textBox1 = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_sp_KM_ADD).BeginInit();
            panel4.SuspendLayout();
            panel14.SuspendLayout();
            panel23.SuspendLayout();
            panel46.SuspendLayout();
            panel47.SuspendLayout();
            panel7.SuspendLayout();
            panel10.SuspendLayout();
            panel19.SuspendLayout();
            panel24.SuspendLayout();
            panel18.SuspendLayout();
            panel22.SuspendLayout();
            panel17.SuspendLayout();
            panel21.SuspendLayout();
            panel16.SuspendLayout();
            panel20.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1020, 60);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1020, 60);
            label1.TabIndex = 0;
            label1.Text = "Thêm khuyến mãi";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1020, 737);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 60);
            panel3.Name = "panel3";
            panel3.Size = new Size(1020, 677);
            panel3.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(panel9);
            panel5.Controls.Add(panel8);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel19);
            panel5.Controls.Add(panel18);
            panel5.Controls.Add(panel17);
            panel5.Controls.Add(panel16);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1020, 677);
            panel5.TabIndex = 1;
            panel5.Paint += panel5_Paint;
            // 
            // panel9
            // 
            panel9.Controls.Add(btnThoatDiscount);
            panel9.Controls.Add(btnThemDiscount);
            panel9.Dock = DockStyle.Bottom;
            panel9.Location = new Point(0, 636);
            panel9.Name = "panel9";
            panel9.Size = new Size(1020, 41);
            panel9.TabIndex = 2;
            // 
            // btnThoatDiscount
            // 
            btnThoatDiscount.BackColor = Color.Crimson;
            btnThoatDiscount.BorderColor = Color.Crimson;
            btnThoatDiscount.BorderRadius = 20;
            btnThoatDiscount.BorderSize = 0;
            btnThoatDiscount.Dock = DockStyle.Right;
            btnThoatDiscount.FlatAppearance.BorderSize = 0;
            btnThoatDiscount.FlatStyle = FlatStyle.Flat;
            btnThoatDiscount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThoatDiscount.ForeColor = Color.White;
            btnThoatDiscount.Location = new Point(811, 0);
            btnThoatDiscount.Margin = new Padding(3, 2, 3, 2);
            btnThoatDiscount.Name = "btnThoatDiscount";
            btnThoatDiscount.Size = new Size(82, 41);
            btnThoatDiscount.TabIndex = 3;
            btnThoatDiscount.Text = "Hủy";
            btnThoatDiscount.UseVisualStyleBackColor = false;
            btnThoatDiscount.Click += btnThoatDiscount_Click_1;
            // 
            // btnThemDiscount
            // 
            btnThemDiscount.AutoSize = true;
            btnThemDiscount.BackColor = Color.DodgerBlue;
            btnThemDiscount.BorderColor = Color.DodgerBlue;
            btnThemDiscount.BorderRadius = 20;
            btnThemDiscount.BorderSize = 0;
            btnThemDiscount.Dock = DockStyle.Right;
            btnThemDiscount.FlatAppearance.BorderSize = 0;
            btnThemDiscount.FlatStyle = FlatStyle.Flat;
            btnThemDiscount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThemDiscount.ForeColor = Color.White;
            btnThemDiscount.Location = new Point(893, 0);
            btnThemDiscount.Margin = new Padding(3, 2, 3, 2);
            btnThemDiscount.Name = "btnThemDiscount";
            btnThemDiscount.Size = new Size(127, 41);
            btnThemDiscount.TabIndex = 2;
            btnThemDiscount.Text = "Xác nhận";
            btnThemDiscount.UseVisualStyleBackColor = false;
            btnThemDiscount.Click += roundedButton1_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(dGV_sp_KM_ADD);
            panel8.Controls.Add(panel4);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 282);
            panel8.Name = "panel8";
            panel8.Size = new Size(1020, 354);
            panel8.TabIndex = 1;
            // 
            // dGV_sp_KM_ADD
            // 
            dGV_sp_KM_ADD.AllowUserToAddRows = false;
            dGV_sp_KM_ADD.AllowUserToDeleteRows = false;
            dGV_sp_KM_ADD.AllowUserToResizeColumns = false;
            dGV_sp_KM_ADD.AllowUserToResizeRows = false;
            dGV_sp_KM_ADD.BackgroundColor = SystemColors.ButtonFace;
            dGV_sp_KM_ADD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_sp_KM_ADD.Columns.AddRange(new DataGridViewColumn[] { chon_add, maSP_add, tenSanPham_add, loai_add });
            dGV_sp_KM_ADD.Dock = DockStyle.Top;
            dGV_sp_KM_ADD.Location = new Point(0, 63);
            dGV_sp_KM_ADD.Name = "dGV_sp_KM_ADD";
            dGV_sp_KM_ADD.Size = new Size(1020, 334);
            dGV_sp_KM_ADD.TabIndex = 1;
            // 
            // chon_add
            // 
            chon_add.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chon_add.HeaderText = "Chọn";
            chon_add.Name = "chon_add";
            chon_add.Width = 60;
            // 
            // maSP_add
            // 
            maSP_add.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            maSP_add.HeaderText = "Mã sản phẩm";
            maSP_add.Name = "maSP_add";
            maSP_add.Width = 104;
            // 
            // tenSanPham_add
            // 
            tenSanPham_add.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenSanPham_add.HeaderText = "Tên sản phẩm";
            tenSanPham_add.Name = "tenSanPham_add";
            // 
            // loai_add
            // 
            loai_add.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            loai_add.HeaderText = "Loại sản phẩm";
            loai_add.Name = "loai_add";
            // 
            // panel4
            // 
            panel4.Controls.Add(panel14);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1020, 63);
            panel4.TabIndex = 0;
            // 
            // panel14
            // 
            panel14.Controls.Add(panel23);
            panel14.Controls.Add(panel47);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(1020, 63);
            panel14.TabIndex = 2;
            // 
            // panel23
            // 
            panel23.Controls.Add(panel46);
            panel23.Dock = DockStyle.Fill;
            panel23.Location = new Point(129, 0);
            panel23.Name = "panel23";
            panel23.Size = new Size(891, 63);
            panel23.TabIndex = 4;
            // 
            // panel46
            // 
            panel46.Controls.Add(roundedTextBox1);
            panel46.Dock = DockStyle.Left;
            panel46.Location = new Point(0, 0);
            panel46.Margin = new Padding(3, 2, 3, 2);
            panel46.Name = "panel46";
            panel46.Padding = new Padding(13, 11, 13, 11);
            panel46.Size = new Size(207, 63);
            panel46.TabIndex = 9;
            // 
            // roundedTextBox1
            // 
            roundedTextBox1.BackColor = Color.White;
            roundedTextBox1.BorderColor = Color.Gray;
            roundedTextBox1.BorderRadius = 20;
            roundedTextBox1.Dock = DockStyle.Fill;
            roundedTextBox1.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox1.Location = new Point(13, 11);
            roundedTextBox1.Margin = new Padding(3, 2, 3, 2);
            roundedTextBox1.Name = "roundedTextBox1";
            roundedTextBox1.Padding = new Padding(9, 4, 35, 4);
            roundedTextBox1.Placeholder = "Từ khóa tìm kiếm...";
            roundedTextBox1.Size = new Size(181, 41);
            roundedTextBox1.TabIndex = 0;
            roundedTextBox1.TextValue = "";
            roundedTextBox1.DataContextChanged += roundedTextBox1_TextChanged;
            roundedTextBox1.KeyDown += roundedTextBox1_KeyDown;
            // 
            // panel47
            // 
            panel47.Controls.Add(checkBox6);
            panel47.Dock = DockStyle.Left;
            panel47.Location = new Point(0, 0);
            panel47.Name = "panel47";
            panel47.Size = new Size(129, 63);
            panel47.TabIndex = 3;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Dock = DockStyle.Fill;
            checkBox6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox6.Location = new Point(0, 0);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(129, 63);
            checkBox6.TabIndex = 2;
            checkBox6.Text = "Chọn tất cả";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += checkBox6_CheckedChanged;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Control;
            panel7.Controls.Add(panel10);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 219);
            panel7.Name = "panel7";
            panel7.Size = new Size(1020, 63);
            panel7.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(label2);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(1020, 63);
            panel10.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1020, 63);
            label2.TabIndex = 0;
            label2.Text = "Sản phẩm khuyến mãi";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel19
            // 
            panel19.Controls.Add(panel24);
            panel19.Dock = DockStyle.Top;
            panel19.Location = new Point(0, 176);
            panel19.Name = "panel19";
            panel19.Size = new Size(1020, 43);
            panel19.TabIndex = 5;
            // 
            // panel24
            // 
            panel24.Controls.Add(label9);
            panel24.Controls.Add(textBox2);
            panel24.Dock = DockStyle.Top;
            panel24.Location = new Point(0, 0);
            panel24.Name = "panel24";
            panel24.Size = new Size(1020, 44);
            panel24.TabIndex = 1;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(175, 44);
            label9.TabIndex = 3;
            label9.Text = "Mô tả:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            label9.Click += label9_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(274, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(746, 33);
            textBox2.TabIndex = 0;
            // 
            // panel18
            // 
            panel18.Controls.Add(panel22);
            panel18.Controls.Add(label8);
            panel18.Dock = DockStyle.Top;
            panel18.Location = new Point(0, 132);
            panel18.Name = "panel18";
            panel18.Size = new Size(1020, 44);
            panel18.TabIndex = 4;
            // 
            // panel22
            // 
            panel22.Controls.Add(dateTimePicker2);
            panel22.Dock = DockStyle.Fill;
            panel22.Location = new Point(175, 0);
            panel22.Name = "panel22";
            panel22.Size = new Size(845, 44);
            panel22.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(99, 10);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 4;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Left;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(175, 44);
            label8.TabIndex = 3;
            label8.Text = "Ngày kết thúc";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel17
            // 
            panel17.Controls.Add(panel21);
            panel17.Controls.Add(label7);
            panel17.Dock = DockStyle.Top;
            panel17.Location = new Point(0, 88);
            panel17.Name = "panel17";
            panel17.Size = new Size(1020, 44);
            panel17.TabIndex = 3;
            // 
            // panel21
            // 
            panel21.Controls.Add(dateTimePicker1);
            panel21.Dock = DockStyle.Fill;
            panel21.Location = new Point(175, 0);
            panel21.Name = "panel21";
            panel21.Size = new Size(845, 44);
            panel21.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(99, 10);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(175, 44);
            label7.TabIndex = 2;
            label7.Text = "Ngày bắt đầu";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Click += label7_Click;
            // 
            // panel16
            // 
            panel16.Controls.Add(panel20);
            panel16.Controls.Add(label6);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(0, 44);
            panel16.Name = "panel16";
            panel16.Size = new Size(1020, 44);
            panel16.TabIndex = 2;
            // 
            // panel20
            // 
            panel20.Controls.Add(roundedComboBox1);
            panel20.Location = new Point(274, 0);
            panel20.Name = "panel20";
            panel20.Size = new Size(746, 44);
            panel20.TabIndex = 2;
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
            roundedComboBox1.Items.AddRange(new object[] { "10%", "20%", "30%", "40%", "50%", "60%" });
            roundedComboBox1.Location = new Point(0, 3);
            roundedComboBox1.Margin = new Padding(3, 2, 3, 2);
            roundedComboBox1.Name = "roundedComboBox1";
            roundedComboBox1.Size = new Size(746, 36);
            roundedComboBox1.Sorted = true;
            roundedComboBox1.TabIndex = 4;
            roundedComboBox1.SelectedIndexChanged += roundedComboBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(175, 44);
            label6.TabIndex = 1;
            label6.Text = "Giảm giá(%)";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.Controls.Add(textBox1);
            panel6.Controls.Add(label5);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1020, 44);
            panel6.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(274, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(746, 33);
            textBox1.TabIndex = 0;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(278, 44);
            label5.TabIndex = 0;
            label5.Text = "Tên chương trình khuyến mãi";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Click += label5_Click;
            // 
            // AddDiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 737);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddDiscountForm";
            Text = "AddDiscountForm";
            Load += AddDiscountForm_Load_1;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_sp_KM_ADD).EndInit();
            panel4.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel23.ResumeLayout(false);
            panel46.ResumeLayout(false);
            panel47.ResumeLayout(false);
            panel47.PerformLayout();
            panel7.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel24.ResumeLayout(false);
            panel24.PerformLayout();
            panel18.ResumeLayout(false);
            panel22.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel21.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        private void label7_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private Panel panel5;
        private Panel panel9;
        private Panel panel8;
        private Panel panel7;
        private Panel panel10;
        private Label label2;
        private Panel panel6;
        private RoundedButton btnThemDiscount;
        private RoundedButton btnThoatDiscount;
        private Panel panel19;
        private Panel panel18;
        private Panel panel17;
        private Panel panel16;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private Panel panel20;
        private RoundedComboBox roundedComboBox1;
        private Label label7;
        private Panel panel22;
        private DateTimePicker dateTimePicker2;
        private Label label8;
        private Panel panel21;
        private DateTimePicker dateTimePicker1;
        private Panel panel24;
        private TextBox textBox2;
        private Label label9;
        private Panel panel4;
        private Panel panel14;
        private Panel panel23;
        private Panel panel46;
        private RoundedTextBox roundedTextBox1;
        private Panel panel47;
        private CheckBox checkBox6;
        private DataGridView dGV_sp_KM_ADD;
        private DataGridViewCheckBoxColumn chon_add;
        private DataGridViewTextBoxColumn tenSanPham_add;
        private DataGridViewTextBoxColumn loai_add;
        private DataGridViewTextBoxColumn maSP_add;
    }
}