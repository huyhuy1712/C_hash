using MilkTea.Client.Forms.ChildForm_Discount;

namespace MilkTea.Client.Forms
{
    partial class DiscountForm
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
            Panel panel3;
            Panel panel4;
            label1 = new Label();
            cbbLoai = new MilkTea.Client.Controls.RoundedComboBox();
            panel20 = new Panel();
            label9 = new Label();
            Search = new MilkTea.Client.Controls.RoundedTextBox();
            panel19 = new Panel();
            label8 = new Label();
            btnThemAccount = new MilkTea.Client.Controls.RoundedButton();
            label2 = new Label();
            DiscountPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel7 = new Panel();
            panel9 = new Panel();
            label5 = new Label();
            panel8 = new Panel();
            product_delete_btn1 = new PictureBox();
            product_edit_btn1 = new PictureBox();
            panel1 = new Panel();
            panel5 = new Panel();
            label3 = new Label();
            panel6 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel10 = new Panel();
            panel11 = new Panel();
            label4 = new Label();
            panel12 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            panel13 = new Panel();
            panel14 = new Panel();
            label6 = new Label();
            panel15 = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            panel16 = new Panel();
            panel17 = new Panel();
            label7 = new Label();
            panel18 = new Panel();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel20.SuspendLayout();
            panel19.SuspendLayout();
            panel4.SuspendLayout();
            DiscountPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)product_delete_btn1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)product_edit_btn1).BeginInit();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel16.SuspendLayout();
            panel17.SuspendLayout();
            panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1660, 60);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1660, 60);
            label1.TabIndex = 0;
            label1.Text = "Khuyến mãi";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(cbbLoai);
            panel3.Controls.Add(panel20);
            panel3.Controls.Add(Search);
            panel3.Controls.Add(panel19);
            panel3.Controls.Add(btnThemAccount);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 60);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1660, 38);
            panel3.TabIndex = 3;
            // 
            // cbbLoai
            // 
            cbbLoai.BackColor = Color.White;
            cbbLoai.BorderColor = Color.Gray;
            cbbLoai.BorderRadius = 15;
            cbbLoai.BorderSize = 1;
            cbbLoai.DisplayMember = "A";
            cbbLoai.Dock = DockStyle.Left;
            cbbLoai.DrawMode = DrawMode.OwnerDrawFixed;
            cbbLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLoai.FlatStyle = FlatStyle.Flat;
            cbbLoai.FocusBorderColor = Color.DeepSkyBlue;
            cbbLoai.Font = new Font("Segoe UI", 10F);
            cbbLoai.FormattingEnabled = true;
            cbbLoai.ItemHeight = 30;
            cbbLoai.Items.AddRange(new object[] { "Đang hoạt động", "Hết hạn" });
            cbbLoai.Location = new Point(405, 0);
            cbbLoai.Margin = new Padding(3, 2, 3, 2);
            cbbLoai.Name = "cbbLoai";
            cbbLoai.Size = new Size(90, 36);
            cbbLoai.TabIndex = 6;
            // 
            // panel20
            // 
            panel20.Controls.Add(label9);
            panel20.Dock = DockStyle.Left;
            panel20.Location = new Point(307, 0);
            panel20.Name = "panel20";
            panel20.Size = new Size(98, 38);
            panel20.TabIndex = 5;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(98, 38);
            label9.TabIndex = 0;
            label9.Text = "Trạng thái:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Search
            // 
            Search.BackColor = Color.White;
            Search.BorderColor = Color.Gray;
            Search.BorderRadius = 20;
            Search.Dock = DockStyle.Left;
            Search.FocusBorderColor = Color.DeepSkyBlue;
            Search.Location = new Point(88, 0);
            Search.Margin = new Padding(3, 2, 3, 2);
            Search.Name = "Search";
            Search.Padding = new Padding(9, 4, 35, 4);
            Search.Placeholder = "Từ khóa tìm kiếm...";
            Search.Size = new Size(219, 38);
            Search.TabIndex = 4;
            Search.TextValue = "";
            // 
            // panel19
            // 
            panel19.Controls.Add(label8);
            panel19.Dock = DockStyle.Left;
            panel19.Location = new Point(0, 0);
            panel19.Name = "panel19";
            panel19.Size = new Size(88, 38);
            panel19.TabIndex = 3;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Padding = new Padding(0, 4, 0, 0);
            label8.Size = new Size(88, 38);
            label8.TabIndex = 3;
            label8.Text = "Tìm kiếm:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnThemAccount
            // 
            btnThemAccount.BackColor = Color.DodgerBlue;
            btnThemAccount.BorderColor = Color.DodgerBlue;
            btnThemAccount.BorderRadius = 20;
            btnThemAccount.BorderSize = 0;
            btnThemAccount.Dock = DockStyle.Right;
            btnThemAccount.FlatAppearance.BorderSize = 0;
            btnThemAccount.FlatStyle = FlatStyle.Flat;
            btnThemAccount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThemAccount.ForeColor = Color.White;
            btnThemAccount.Location = new Point(1549, 0);
            btnThemAccount.Margin = new Padding(3, 2, 3, 2);
            btnThemAccount.Name = "btnThemAccount";
            btnThemAccount.Size = new Size(111, 38);
            btnThemAccount.TabIndex = 0;
            btnThemAccount.Text = "+ Thêm";
            btnThemAccount.UseVisualStyleBackColor = false;
            btnThemAccount.Click += btnThemAccount_Click;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 98);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(1660, 38);
            panel4.TabIndex = 4;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1660, 38);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Khuyến Mãi";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DiscountPanel
            // 
            DiscountPanel.Controls.Add(flowLayoutPanel1);
            DiscountPanel.Controls.Add(panel4);
            DiscountPanel.Controls.Add(panel3);
            DiscountPanel.Controls.Add(panel2);
            DiscountPanel.Dock = DockStyle.Fill;
            DiscountPanel.Location = new Point(0, 0);
            DiscountPanel.Margin = new Padding(3, 2, 3, 2);
            DiscountPanel.Name = "DiscountPanel";
            DiscountPanel.Size = new Size(1660, 527);
            DiscountPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveBorder;
            flowLayoutPanel1.Controls.Add(panel7);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(panel10);
            flowLayoutPanel1.Controls.Add(panel13);
            flowLayoutPanel1.Controls.Add(panel16);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 136);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(1660, 391);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ButtonHighlight;
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(23, 23);
            panel7.Name = "panel7";
            panel7.Size = new Size(200, 100);
            panel7.TabIndex = 3;
            // 
            // panel9
            // 
            panel9.Controls.Add(label5);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(200, 72);
            panel9.TabIndex = 1;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(200, 72);
            label5.TabIndex = 0;
            label5.Text = "Chương trình 8/8";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.ActiveCaption;
            panel8.Controls.Add(product_delete_btn1);
            panel8.Controls.Add(product_edit_btn1);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 72);
            panel8.Name = "panel8";
            panel8.Size = new Size(200, 28);
            panel8.TabIndex = 0;
            // 
            // product_delete_btn1
            // 
            product_delete_btn1.Cursor = Cursors.Hand;
            product_delete_btn1.Dock = DockStyle.Left;
            product_delete_btn1.Image = Properties.Resources.trash;
            product_delete_btn1.Location = new Point(24, 0);
            product_delete_btn1.Margin = new Padding(3, 2, 3, 2);
            product_delete_btn1.Name = "product_delete_btn1";
            product_delete_btn1.Size = new Size(35, 28);
            product_delete_btn1.SizeMode = PictureBoxSizeMode.Zoom;
            product_delete_btn1.TabIndex = 2;
            product_delete_btn1.TabStop = false;
            // 
            // product_edit_btn1
            // 
            product_edit_btn1.Cursor = Cursors.Hand;
            product_edit_btn1.Dock = DockStyle.Left;
            product_edit_btn1.Image = Properties.Resources.edit;
            product_edit_btn1.Location = new Point(0, 0);
            product_edit_btn1.Margin = new Padding(3, 2, 3, 2);
            product_edit_btn1.Name = "product_edit_btn1";
            product_edit_btn1.Size = new Size(24, 28);
            product_edit_btn1.SizeMode = PictureBoxSizeMode.Zoom;
            product_edit_btn1.TabIndex = 1;
            product_edit_btn1.TabStop = false;
            product_edit_btn1.Click += product_edit_btn1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel6);
            panel1.Location = new Point(229, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 72);
            panel5.TabIndex = 1;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(200, 72);
            label3.TabIndex = 0;
            label3.Text = "Chương trình 8/8";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ActiveCaption;
            panel6.Controls.Add(pictureBox1);
            panel6.Controls.Add(pictureBox2);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 72);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 28);
            panel6.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.trash;
            pictureBox1.Location = new Point(24, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Image = Properties.Resources.edit;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // panel10
            // 
            panel10.BackColor = SystemColors.ButtonHighlight;
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(panel12);
            panel10.Location = new Point(435, 23);
            panel10.Name = "panel10";
            panel10.Size = new Size(200, 100);
            panel10.TabIndex = 5;
            // 
            // panel11
            // 
            panel11.Controls.Add(label4);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(200, 72);
            panel11.TabIndex = 1;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(200, 72);
            label4.TabIndex = 0;
            label4.Text = "Chương trình 8/8";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            panel12.BackColor = SystemColors.ActiveCaption;
            panel12.Controls.Add(pictureBox3);
            panel12.Controls.Add(pictureBox4);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 72);
            panel12.Name = "panel12";
            panel12.Size = new Size(200, 28);
            panel12.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Dock = DockStyle.Left;
            pictureBox3.Image = Properties.Resources.trash;
            pictureBox3.Location = new Point(24, 0);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 28);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Dock = DockStyle.Left;
            pictureBox4.Image = Properties.Resources.edit;
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(24, 28);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // panel13
            // 
            panel13.BackColor = SystemColors.ButtonHighlight;
            panel13.Controls.Add(panel14);
            panel13.Controls.Add(panel15);
            panel13.Location = new Point(641, 23);
            panel13.Name = "panel13";
            panel13.Size = new Size(200, 100);
            panel13.TabIndex = 6;
            // 
            // panel14
            // 
            panel14.Controls.Add(label6);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(200, 72);
            panel14.TabIndex = 1;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(200, 72);
            label6.TabIndex = 0;
            label6.Text = "Chương trình 8/8";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            panel15.BackColor = SystemColors.ActiveCaption;
            panel15.Controls.Add(pictureBox5);
            panel15.Controls.Add(pictureBox6);
            panel15.Dock = DockStyle.Bottom;
            panel15.Location = new Point(0, 72);
            panel15.Name = "panel15";
            panel15.Size = new Size(200, 28);
            panel15.TabIndex = 0;
            // 
            // pictureBox5
            // 
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Dock = DockStyle.Left;
            pictureBox5.Image = Properties.Resources.trash;
            pictureBox5.Location = new Point(24, 0);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(35, 28);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 2;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Cursor = Cursors.Hand;
            pictureBox6.Dock = DockStyle.Left;
            pictureBox6.Image = Properties.Resources.edit;
            pictureBox6.Location = new Point(0, 0);
            pictureBox6.Margin = new Padding(3, 2, 3, 2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(24, 28);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 1;
            pictureBox6.TabStop = false;
            // 
            // panel16
            // 
            panel16.BackColor = SystemColors.ButtonHighlight;
            panel16.Controls.Add(panel17);
            panel16.Controls.Add(panel18);
            panel16.Location = new Point(847, 23);
            panel16.Name = "panel16";
            panel16.Size = new Size(200, 100);
            panel16.TabIndex = 7;
            // 
            // panel17
            // 
            panel17.Controls.Add(label7);
            panel17.Dock = DockStyle.Fill;
            panel17.Location = new Point(0, 0);
            panel17.Name = "panel17";
            panel17.Size = new Size(200, 72);
            panel17.TabIndex = 1;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(200, 72);
            label7.TabIndex = 0;
            label7.Text = "Chương trình 8/8";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel18
            // 
            panel18.BackColor = SystemColors.ActiveCaption;
            panel18.Controls.Add(pictureBox7);
            panel18.Controls.Add(pictureBox8);
            panel18.Dock = DockStyle.Bottom;
            panel18.Location = new Point(0, 72);
            panel18.Name = "panel18";
            panel18.Size = new Size(200, 28);
            panel18.TabIndex = 0;
            // 
            // pictureBox7
            // 
            pictureBox7.Cursor = Cursors.Hand;
            pictureBox7.Dock = DockStyle.Left;
            pictureBox7.Image = Properties.Resources.trash;
            pictureBox7.Location = new Point(24, 0);
            pictureBox7.Margin = new Padding(3, 2, 3, 2);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(35, 28);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 2;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Cursor = Cursors.Hand;
            pictureBox8.Dock = DockStyle.Left;
            pictureBox8.Image = Properties.Resources.edit;
            pictureBox8.Location = new Point(0, 0);
            pictureBox8.Margin = new Padding(3, 2, 3, 2);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(24, 28);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 1;
            pictureBox8.TabStop = false;
            // 
            // DiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1660, 527);
            Controls.Add(DiscountPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DiscountForm";
            Text = "OrderForm";
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel4.ResumeLayout(false);
            DiscountPanel.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)product_delete_btn1).EndInit();
            ((System.ComponentModel.ISupportInitialize)product_edit_btn1).EndInit();
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel13.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel16.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
        }

        private void product_edit_btn1_Click(object sender, EventArgs e)
        {
            EditDiscountForm editForm = new EditDiscountForm();
            editForm.ShowDialog();
        }

        private void btnThemAccount_Click(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();
            addDiscountForm.ShowDialog();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            DetailDiscountForm detailForm = new DetailDiscountForm();
            detailForm.ShowDialog();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void roundedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThemDisccount_Click(object sender, EventArgs e)
        {
            // Khởi tạo và hiển thị form AddDiscountForm
            AddDiscountForm addDiscountForm = new AddDiscountForm();
            addDiscountForm.ShowDialog();
        }
        #endregion

        private Panel DiscountPanel;
        private Label label1;
        private Controls.RoundedButton btnThemAccount;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel7;
        private Panel panel9;
        private Label label5;
        private Panel panel8;
        private PictureBox product_delete_btn1;
        private PictureBox product_edit_btn1;
        private Panel panel1;
        private Panel panel5;
        private Label label3;
        private Panel panel6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel10;
        private Panel panel11;
        private Label label4;
        private Panel panel12;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Panel panel13;
        private Panel panel14;
        private Label label6;
        private Panel panel15;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Panel panel16;
        private Panel panel17;
        private Label label7;
        private Panel panel18;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private Label label8;
        private Controls.RoundedTextBox Search;
        private Panel panel19;
        private Panel panel20;
        private Label label9;
        private Controls.RoundedComboBox cbbLoai;
    }
}