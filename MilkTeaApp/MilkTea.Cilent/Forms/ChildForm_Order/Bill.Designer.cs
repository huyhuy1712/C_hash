namespace MilkTea.Client.Forms.ChildForm_Order
{
    partial class Bill
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
            panel1 = new Panel();
            InvoiceOrder_Panel = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            tenSP = new DataGridViewTextBoxColumn();
            topping = new DataGridViewTextBoxColumn();
            tbSize = new DataGridViewTextBoxColumn();
            donGia = new DataGridViewTextBoxColumn();
            soLuong = new DataGridViewTextBoxColumn();
            tongTien = new DataGridViewTextBoxColumn();
            panel7 = new Panel();
            label22 = new Label();
            label23 = new Label();
            panel6 = new Panel();
            label19 = new Label();
            label20 = new Label();
            panel4 = new Panel();
            ten_thu_ngan_label = new Label();
            label16 = new Label();
            panel3 = new Panel();
            tgian_label = new Label();
            label1 = new Label();
            Title_label = new Label();
            panel1.SuspendLayout();
            InvoiceOrder_Panel.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(InvoiceOrder_Panel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(938, 553);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // InvoiceOrder_Panel
            // 
            InvoiceOrder_Panel.BackColor = SystemColors.ButtonHighlight;
            InvoiceOrder_Panel.Controls.Add(panel2);
            InvoiceOrder_Panel.Controls.Add(dataGridView1);
            InvoiceOrder_Panel.Controls.Add(panel7);
            InvoiceOrder_Panel.Controls.Add(panel6);
            InvoiceOrder_Panel.Controls.Add(panel4);
            InvoiceOrder_Panel.Controls.Add(panel3);
            InvoiceOrder_Panel.Controls.Add(Title_label);
            InvoiceOrder_Panel.Dock = DockStyle.Bottom;
            InvoiceOrder_Panel.Location = new Point(0, 0);
            InvoiceOrder_Panel.Name = "InvoiceOrder_Panel";
            InvoiceOrder_Panel.Size = new Size(938, 553);
            InvoiceOrder_Panel.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(0, 300);
            panel2.Name = "panel2";
            panel2.Size = new Size(938, 53);
            panel2.TabIndex = 7;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Right;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(806, 0);
            label2.Name = "label2";
            label2.Size = new Size(132, 53);
            label2.TabIndex = 1;
            label2.Text = "60.000";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(168, 53);
            label3.TabIndex = 0;
            label3.Text = "Tổng cộng:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
<<<<<<< HEAD
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tenSP, topping, tbSize, donGia, soLuong, tongTien });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 365);
=======
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tenSP, topping, tbSize, donGia, soLuong, tongTien });
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 49);
>>>>>>> 77e4f41b429bf55d20d11a7d00f5736e34cf8188
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(938, 188);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tenSP
            // 
            tenSP.FillWeight = 100.106956F;
            tenSP.HeaderText = "Tên SP";
            tenSP.MinimumWidth = 6;
            tenSP.Name = "tenSP";
            tenSP.ReadOnly = true;
            // 
            // topping
            // 
<<<<<<< HEAD
            topping.FillWeight = 100.08448F;
=======
>>>>>>> 77e4f41b429bf55d20d11a7d00f5736e34cf8188
            topping.HeaderText = "Topping";
            topping.MinimumWidth = 6;
            topping.Name = "topping";
            topping.ReadOnly = true;
            // 
            // tbSize
            // 
            tbSize.FillWeight = 99.424324F;
            tbSize.HeaderText = "Size";
            tbSize.MinimumWidth = 6;
            tbSize.Name = "tbSize";
            tbSize.ReadOnly = true;
            // 
            // donGia
            // 
            donGia.FillWeight = 100.1572F;
            donGia.HeaderText = "Đơn giá";
            donGia.MinimumWidth = 6;
            donGia.Name = "donGia";
            donGia.ReadOnly = true;
            // 
            // soLuong
            // 
            soLuong.FillWeight = 100.12635F;
            soLuong.HeaderText = "Số Lượng";
            soLuong.MinimumWidth = 6;
            soLuong.Name = "soLuong";
            soLuong.ReadOnly = true;
            // 
            // tongTien
            // 
            tongTien.FillWeight = 100.100677F;
            tongTien.HeaderText = "Tổng tiền";
            tongTien.MinimumWidth = 6;
            tongTien.Name = "tongTien";
            tongTien.ReadOnly = true;
            // 
            // panel7
            // 
            panel7.Controls.Add(label22);
            panel7.Controls.Add(label23);
            panel7.Location = new Point(8, 196);
            panel7.Name = "panel7";
            panel7.Size = new Size(875, 40);
            panel7.TabIndex = 12;
            // 
            // label22
            // 
            label22.Dock = DockStyle.Left;
            label22.Font = new Font("Segoe UI", 11F);
            label22.Location = new Point(246, 0);
            label22.Name = "label22";
            label22.Size = new Size(149, 40);
            label22.TabIndex = 1;
            label22.Text = "Chuyển khoản";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            label23.Dock = DockStyle.Left;
            label23.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label23.Location = new Point(0, 0);
            label23.Name = "label23";
            label23.Size = new Size(246, 40);
            label23.TabIndex = 0;
            label23.Text = "Phương thức thanh toán: ";
            label23.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.Controls.Add(label19);
            panel6.Controls.Add(label20);
            panel6.Location = new Point(8, 261);
            panel6.Name = "panel6";
            panel6.Size = new Size(875, 40);
            panel6.TabIndex = 12;
            // 
            // label19
            // 
            label19.Dock = DockStyle.Left;
            label19.Font = new Font("Segoe UI", 11F);
            label19.Location = new Point(128, 0);
            label19.Name = "label19";
            label19.Size = new Size(127, 40);
            label19.TabIndex = 1;
            label19.Text = "3D";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            label20.Dock = DockStyle.Left;
            label20.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label20.Location = new Point(0, 0);
            label20.Name = "label20";
            label20.Size = new Size(128, 40);
            label20.TabIndex = 0;
            label20.Text = "Mã buzzer: ";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(ten_thu_ngan_label);
            panel4.Controls.Add(label16);
            panel4.Location = new Point(8, 136);
            panel4.Name = "panel4";
            panel4.Size = new Size(875, 40);
            panel4.TabIndex = 11;
            // 
            // ten_thu_ngan_label
            // 
            ten_thu_ngan_label.Dock = DockStyle.Left;
            ten_thu_ngan_label.Font = new Font("Segoe UI", 11F);
            ten_thu_ngan_label.Location = new Point(104, 0);
            ten_thu_ngan_label.Name = "ten_thu_ngan_label";
            ten_thu_ngan_label.Size = new Size(127, 40);
            ten_thu_ngan_label.TabIndex = 1;
            ten_thu_ngan_label.Text = "Anh Huy";
            ten_thu_ngan_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.Dock = DockStyle.Left;
            label16.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label16.Location = new Point(0, 0);
            label16.Name = "label16";
            label16.Size = new Size(104, 40);
            label16.TabIndex = 0;
            label16.Text = "Thu ngân:";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.Controls.Add(tgian_label);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(8, 75);
            panel3.Name = "panel3";
            panel3.Size = new Size(872, 40);
            panel3.TabIndex = 10;
            // 
            // tgian_label
            // 
            tgian_label.Dock = DockStyle.Left;
            tgian_label.Font = new Font("Segoe UI", 11F);
            tgian_label.Location = new Point(104, 0);
            tgian_label.Name = "tgian_label";
            tgian_label.Size = new Size(127, 40);
            tgian_label.TabIndex = 1;
            tgian_label.Text = "9/11/2001";
            tgian_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 40);
            label1.TabIndex = 0;
            label1.Text = "Ngày: ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Title_label
            // 
            Title_label.Dock = DockStyle.Top;
            Title_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Title_label.Location = new Point(0, 0);
            Title_label.Name = "Title_label";
            Title_label.Size = new Size(938, 49);
            Title_label.TabIndex = 0;
            Title_label.Text = "Hóa đơn thanh toán";
            Title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Bill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(938, 553);
            Controls.Add(panel1);
            Name = "Bill";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bill";
            panel1.ResumeLayout(false);
            InvoiceOrder_Panel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel InvoiceOrder_Panel;
        private Panel panel3;
        private Label tgian_label;
        private Label label1;
        private Label Title_label;
        private Panel panel7;
        private Label label22;
        private Label label23;
        private Panel panel6;
        private Label label19;
        private Label label20;
        private Panel panel4;
        private Label ten_thu_ngan_label;
        private Label label16;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn tenSP;
        private DataGridViewTextBoxColumn topping;
        private DataGridViewTextBoxColumn tbSize;
        private DataGridViewTextBoxColumn donGia;
        private DataGridViewTextBoxColumn soLuong;
        private DataGridViewTextBoxColumn tongTien;
    }
}