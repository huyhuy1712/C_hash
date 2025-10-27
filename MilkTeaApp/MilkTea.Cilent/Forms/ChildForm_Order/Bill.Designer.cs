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
            tbSize = new DataGridViewTextBoxColumn();
            Topping = new DataGridViewTextBoxColumn();
            donGia = new DataGridViewTextBoxColumn();
            tien = new DataGridViewTextBoxColumn();
            tongTien = new DataGridViewTextBoxColumn();
            panel7 = new Panel();
            label22 = new Label();
            label23 = new Label();
            panel6 = new Panel();
            label19 = new Label();
            label20 = new Label();
            panel5 = new Panel();
            label17 = new Label();
            label18 = new Label();
            panel4 = new Panel();
            label11 = new Label();
            label16 = new Label();
            panel3 = new Panel();
            ten_thu_ngan_label = new Label();
            label1 = new Label();
            Title_label = new Label();
            panel1.SuspendLayout();
            InvoiceOrder_Panel.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
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
            panel1.Size = new Size(874, 580);
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
            InvoiceOrder_Panel.Controls.Add(panel5);
            InvoiceOrder_Panel.Controls.Add(panel4);
            InvoiceOrder_Panel.Controls.Add(panel3);
            InvoiceOrder_Panel.Controls.Add(Title_label);
            InvoiceOrder_Panel.Dock = DockStyle.Fill;
            InvoiceOrder_Panel.Location = new Point(0, 0);
            InvoiceOrder_Panel.Name = "InvoiceOrder_Panel";
            InvoiceOrder_Panel.Size = new Size(874, 580);
            InvoiceOrder_Panel.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 237);
            panel2.Name = "panel2";
            panel2.Size = new Size(874, 53);
            panel2.TabIndex = 7;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Right;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(742, 0);
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tenSP, tbSize, Topping, donGia, tien, tongTien });
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(874, 188);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tenSP
            // 
            tenSP.HeaderText = "Tên SP";
            tenSP.MinimumWidth = 6;
            tenSP.Name = "tenSP";
            tenSP.Width = 246;
            // 
            // tbSize
            // 
            tbSize.HeaderText = "Size";
            tbSize.MinimumWidth = 6;
            tbSize.Name = "tbSize";
            tbSize.Width = 125;
            // 
            // Topping
            // 
            Topping.HeaderText = "Topping";
            Topping.MinimumWidth = 6;
            Topping.Name = "Topping";
            Topping.Width = 125;
            // 
            // donGia
            // 
            donGia.HeaderText = "Đơn giá";
            donGia.MinimumWidth = 6;
            donGia.Name = "donGia";
            donGia.Width = 125;
            // 
            // tien
            // 
            tien.HeaderText = "Tiền";
            tien.MinimumWidth = 6;
            tien.Name = "tien";
            tien.Width = 125;
            // 
            // tongTien
            // 
            tongTien.HeaderText = "Tổng tiền";
            tongTien.MinimumWidth = 6;
            tongTien.Name = "tongTien";
            tongTien.Width = 125;
            // 
            // panel7
            // 
            panel7.Controls.Add(label22);
            panel7.Controls.Add(label23);
            panel7.Location = new Point(8, 422);
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
            panel6.Location = new Point(8, 468);
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
            // panel5
            // 
            panel5.Controls.Add(label17);
            panel5.Controls.Add(label18);
            panel5.Location = new Point(8, 514);
            panel5.Name = "panel5";
            panel5.Size = new Size(875, 40);
            panel5.TabIndex = 12;
            // 
            // label17
            // 
            label17.Dock = DockStyle.Left;
            label17.Font = new Font("Segoe UI", 11F);
            label17.Location = new Point(104, 0);
            label17.Name = "label17";
            label17.Size = new Size(127, 40);
            label17.TabIndex = 1;
            label17.Text = "aaaaaaaaa";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.Dock = DockStyle.Left;
            label18.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label18.Location = new Point(0, 0);
            label18.Name = "label18";
            label18.Size = new Size(104, 40);
            label18.TabIndex = 0;
            label18.Text = "Ghi chú: ";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label16);
            panel4.Location = new Point(8, 376);
            panel4.Name = "panel4";
            panel4.Size = new Size(875, 40);
            panel4.TabIndex = 11;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Left;
            label11.Font = new Font("Segoe UI", 11F);
            label11.Location = new Point(104, 0);
            label11.Name = "label11";
            label11.Size = new Size(127, 40);
            label11.TabIndex = 1;
            label11.Text = "Anh Huy";
            label11.TextAlign = ContentAlignment.MiddleCenter;
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
            panel3.Controls.Add(ten_thu_ngan_label);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(8, 327);
            panel3.Name = "panel3";
            panel3.Size = new Size(872, 40);
            panel3.TabIndex = 10;
            // 
            // ten_thu_ngan_label
            // 
            ten_thu_ngan_label.Dock = DockStyle.Left;
            ten_thu_ngan_label.Font = new Font("Segoe UI", 11F);
            ten_thu_ngan_label.Location = new Point(104, 0);
            ten_thu_ngan_label.Name = "ten_thu_ngan_label";
            ten_thu_ngan_label.Size = new Size(127, 40);
            ten_thu_ngan_label.TabIndex = 1;
            ten_thu_ngan_label.Text = "9/11/2001";
            ten_thu_ngan_label.TextAlign = ContentAlignment.MiddleCenter;
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
            Title_label.Size = new Size(874, 49);
            Title_label.TabIndex = 0;
            Title_label.Text = "Hóa đơn thanh toán";
            Title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Bill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(874, 580);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Bill";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bill";
            panel1.ResumeLayout(false);
            InvoiceOrder_Panel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel InvoiceOrder_Panel;
        private Panel panel3;
        private Label ten_thu_ngan_label;
        private Label label1;
        private Label Title_label;
        private Panel panel7;
        private Label label22;
        private Label label23;
        private Panel panel6;
        private Label label19;
        private Label label20;
        private Panel panel5;
        private Label label17;
        private Label label18;
        private Panel panel4;
        private Label label11;
        private Label label16;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn tenSP;
        private DataGridViewTextBoxColumn tbSize;
        private DataGridViewTextBoxColumn Topping;
        private DataGridViewTextBoxColumn donGia;
        private DataGridViewTextBoxColumn tien;
        private DataGridViewTextBoxColumn tongTien;
    }
}