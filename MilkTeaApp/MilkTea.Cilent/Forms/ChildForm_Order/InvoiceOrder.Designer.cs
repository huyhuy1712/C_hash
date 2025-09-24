namespace MilkTea.Client.Forms.ChildForm_Order
{
    partial class InvoiceOrder
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
            InvoiceOrder_Panel = new Panel();
            footer_panel = new Panel();
            huy_btn = new MilkTea.Client.Controls.RoundedButton();
            import_btn = new MilkTea.Client.Controls.RoundedButton();
            label23 = new Label();
            label22 = new Label();
            total_panel = new Panel();
            total_label = new Label();
            label21 = new Label();
            order_detail_panel = new Panel();
            item_panel = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label10 = new Label();
            label9 = new Label();
            label15 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            textBox1 = new TextBox();
            header_panel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label24 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            pttt_label = new Label();
            label4 = new Label();
            panel1 = new Panel();
            ten_thu_ngan_label = new Label();
            label1 = new Label();
            order_date_label = new Label();
            ID_Order_label = new Label();
            Title_label = new Label();
            InvoiceOrder_Panel.SuspendLayout();
            footer_panel.SuspendLayout();
            total_panel.SuspendLayout();
            order_detail_panel.SuspendLayout();
            item_panel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            header_panel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // InvoiceOrder_Panel
            // 
            InvoiceOrder_Panel.BackColor = SystemColors.ButtonHighlight;
            InvoiceOrder_Panel.Controls.Add(footer_panel);
            InvoiceOrder_Panel.Controls.Add(label23);
            InvoiceOrder_Panel.Controls.Add(label22);
            InvoiceOrder_Panel.Controls.Add(total_panel);
            InvoiceOrder_Panel.Controls.Add(order_detail_panel);
            InvoiceOrder_Panel.Controls.Add(panel2);
            InvoiceOrder_Panel.Controls.Add(panel1);
            InvoiceOrder_Panel.Controls.Add(order_date_label);
            InvoiceOrder_Panel.Controls.Add(ID_Order_label);
            InvoiceOrder_Panel.Controls.Add(Title_label);
            InvoiceOrder_Panel.Dock = DockStyle.Fill;
            InvoiceOrder_Panel.Location = new Point(0, 0);
            InvoiceOrder_Panel.Name = "InvoiceOrder_Panel";
            InvoiceOrder_Panel.Size = new Size(980, 604);
            InvoiceOrder_Panel.TabIndex = 0;
            InvoiceOrder_Panel.Paint += InvoiceOrder_Panel_Paint;
            // 
            // footer_panel
            // 
            footer_panel.Controls.Add(huy_btn);
            footer_panel.Controls.Add(import_btn);
            footer_panel.Dock = DockStyle.Bottom;
            footer_panel.Location = new Point(0, 542);
            footer_panel.Name = "footer_panel";
            footer_panel.Padding = new Padding(14);
            footer_panel.Size = new Size(980, 62);
            footer_panel.TabIndex = 9;
            // 
            // huy_btn
            // 
            huy_btn.BackColor = Color.OrangeRed;
            huy_btn.BorderColor = Color.DodgerBlue;
            huy_btn.BorderRadius = 20;
            huy_btn.BorderSize = 0;
            huy_btn.Dock = DockStyle.Right;
            huy_btn.FlatAppearance.BorderSize = 0;
            huy_btn.FlatStyle = FlatStyle.Flat;
            huy_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            huy_btn.ForeColor = Color.White;
            huy_btn.Location = new Point(738, 14);
            huy_btn.Name = "huy_btn";
            huy_btn.Size = new Size(114, 34);
            huy_btn.TabIndex = 1;
            huy_btn.Text = "Hủy";
            huy_btn.UseVisualStyleBackColor = false;
            huy_btn.Click += huy_btn_Click;
            // 
            // import_btn
            // 
            import_btn.BackColor = Color.DodgerBlue;
            import_btn.BorderColor = Color.DodgerBlue;
            import_btn.BorderRadius = 20;
            import_btn.BorderSize = 0;
            import_btn.Dock = DockStyle.Right;
            import_btn.FlatAppearance.BorderSize = 0;
            import_btn.FlatStyle = FlatStyle.Flat;
            import_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            import_btn.ForeColor = Color.White;
            import_btn.Location = new Point(852, 14);
            import_btn.Name = "import_btn";
            import_btn.Size = new Size(114, 34);
            import_btn.TabIndex = 0;
            import_btn.Text = "In đơn";
            import_btn.UseVisualStyleBackColor = false;
            // 
            // label23
            // 
            label23.Dock = DockStyle.Top;
            label23.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(0, 516);
            label23.Name = "label23";
            label23.Size = new Size(980, 23);
            label23.TabIndex = 8;
            label23.Text = "Xin cám ơn hẹn gặp lại quý khách";
            label23.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            label22.Dock = DockStyle.Top;
            label22.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.Location = new Point(0, 493);
            label22.Name = "label22";
            label22.Size = new Size(980, 23);
            label22.TabIndex = 7;
            label22.Text = "----------------------";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // total_panel
            // 
            total_panel.Controls.Add(total_label);
            total_panel.Controls.Add(label21);
            total_panel.Dock = DockStyle.Top;
            total_panel.Location = new Point(0, 447);
            total_panel.Name = "total_panel";
            total_panel.Size = new Size(980, 46);
            total_panel.TabIndex = 6;
            // 
            // total_label
            // 
            total_label.Dock = DockStyle.Right;
            total_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            total_label.Location = new Point(848, 0);
            total_label.Name = "total_label";
            total_label.Size = new Size(132, 46);
            total_label.TabIndex = 1;
            total_label.Text = "60.000";
            total_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            label21.Dock = DockStyle.Left;
            label21.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(0, 0);
            label21.Name = "label21";
            label21.Size = new Size(168, 46);
            label21.TabIndex = 0;
            label21.Text = "Tổng cộng:";
            label21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // order_detail_panel
            // 
            order_detail_panel.AutoScroll = true;
            order_detail_panel.Controls.Add(item_panel);
            order_detail_panel.Controls.Add(header_panel);
            order_detail_panel.Dock = DockStyle.Top;
            order_detail_panel.Location = new Point(0, 178);
            order_detail_panel.Name = "order_detail_panel";
            order_detail_panel.Size = new Size(980, 269);
            order_detail_panel.TabIndex = 5;
            // 
            // item_panel
            // 
            item_panel.BackColor = SystemColors.ButtonHighlight;
            item_panel.Controls.Add(tableLayoutPanel2);
            item_panel.Dock = DockStyle.Top;
            item_panel.Location = new Point(0, 37);
            item_panel.Name = "item_panel";
            item_panel.Size = new Size(980, 84);
            item_panel.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel2.ColumnCount = 7;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.1759148F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.0354195F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.201889F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.383707F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.799292F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.420804F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel2.Controls.Add(label10, 4, 0);
            tableLayoutPanel2.Controls.Add(label9, 5, 0);
            tableLayoutPanel2.Controls.Add(label15, 6, 0);
            tableLayoutPanel2.Controls.Add(label12, 2, 0);
            tableLayoutPanel2.Controls.Add(label13, 1, 0);
            tableLayoutPanel2.Controls.Add(label14, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox1, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(980, 84);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label10
            // 
            label10.BackColor = SystemColors.ButtonHighlight;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 10F);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(645, 0);
            label10.Name = "label10";
            label10.Size = new Size(77, 84);
            label10.TabIndex = 13;
            label10.Text = "30.000";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.BackColor = SystemColors.ButtonHighlight;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(728, 0);
            label9.Name = "label9";
            label9.Size = new Size(116, 84);
            label9.TabIndex = 11;
            label9.Text = "10.000";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.BackColor = SystemColors.ButtonHighlight;
            label15.Dock = DockStyle.Fill;
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ActiveCaptionText;
            label15.Location = new Point(850, 0);
            label15.Name = "label15";
            label15.Size = new Size(127, 84);
            label15.TabIndex = 10;
            label15.Text = "60.000";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.BackColor = SystemColors.ButtonHighlight;
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ActiveCaptionText;
            label12.Location = new Point(369, 0);
            label12.Name = "label12";
            label12.Size = new Size(55, 84);
            label12.TabIndex = 8;
            label12.Text = "3";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.ActiveCaptionText;
            label13.Location = new Point(284, 0);
            label13.Name = "label13";
            label13.Size = new Size(79, 84);
            label13.TabIndex = 7;
            label13.Text = "S";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.BackColor = SystemColors.ButtonHighlight;
            label14.Dock = DockStyle.Fill;
            label14.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ActiveCaptionText;
            label14.Location = new Point(3, 0);
            label14.Name = "label14";
            label14.Size = new Size(275, 84);
            label14.TabIndex = 6;
            label14.Text = "Trà sữa chân trâu đường đen";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ButtonHighlight;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(430, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(209, 78);
            textBox1.TabIndex = 14;
            textBox1.TabStop = false;
            textBox1.Text = "25% Trân châu đường đen\r\n50% Trân châu đường vàng \r\n75% sữa";
            // 
            // header_panel
            // 
            header_panel.Controls.Add(tableLayoutPanel1);
            header_panel.Dock = DockStyle.Top;
            header_panel.Location = new Point(0, 0);
            header_panel.Name = "header_panel";
            header_panel.Size = new Size(980, 37);
            header_panel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ActiveBorder;
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.37278F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.822485F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.45562124F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.3254433F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.704142F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.3195267F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 133F));
            tableLayoutPanel1.Controls.Add(label6, 3, 0);
            tableLayoutPanel1.Controls.Add(label7, 4, 0);
            tableLayoutPanel1.Controls.Add(label8, 5, 0);
            tableLayoutPanel1.Controls.Add(label24, 6, 0);
            tableLayoutPanel1.Controls.Add(label5, 2, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(980, 37);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ActiveBorder;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(431, 0);
            label6.Name = "label6";
            label6.Size = new Size(208, 37);
            label6.TabIndex = 9;
            label6.Text = "Topping";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ActiveBorder;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(645, 0);
            label7.Name = "label7";
            label7.Size = new Size(76, 37);
            label7.TabIndex = 8;
            label7.Text = "Đ.Giá";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ActiveBorder;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(727, 0);
            label8.Name = "label8";
            label8.Size = new Size(115, 37);
            label8.TabIndex = 7;
            label8.Text = "Tiền Giảm";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            label24.BackColor = SystemColors.ActiveBorder;
            label24.Dock = DockStyle.Fill;
            label24.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label24.ForeColor = SystemColors.ActiveCaptionText;
            label24.Location = new Point(848, 0);
            label24.Name = "label24";
            label24.Size = new Size(129, 37);
            label24.TabIndex = 6;
            label24.Text = "Tổng Tiền";
            label24.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ActiveBorder;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(368, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 37);
            label5.TabIndex = 2;
            label5.Text = "SL";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ActiveBorder;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(285, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 37);
            label3.TabIndex = 1;
            label3.Text = "Size";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveBorder;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(276, 37);
            label2.TabIndex = 0;
            label2.Text = "Tên SP";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(pttt_label);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 144);
            panel2.Name = "panel2";
            panel2.Size = new Size(980, 34);
            panel2.TabIndex = 4;
            // 
            // pttt_label
            // 
            pttt_label.Dock = DockStyle.Left;
            pttt_label.Font = new Font("Segoe UI", 11F);
            pttt_label.Location = new Point(245, 0);
            pttt_label.Name = "pttt_label";
            pttt_label.Size = new Size(138, 34);
            pttt_label.TabIndex = 1;
            pttt_label.Text = "Chuyển khoản";
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(245, 34);
            label4.TabIndex = 0;
            label4.Text = "Phương thức thanh toán:";
            // 
            // panel1
            // 
            panel1.Controls.Add(ten_thu_ngan_label);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(980, 34);
            panel1.TabIndex = 3;
            // 
            // ten_thu_ngan_label
            // 
            ten_thu_ngan_label.Dock = DockStyle.Left;
            ten_thu_ngan_label.Font = new Font("Segoe UI", 11F);
            ten_thu_ngan_label.Location = new Point(104, 0);
            ten_thu_ngan_label.Name = "ten_thu_ngan_label";
            ten_thu_ngan_label.Size = new Size(127, 34);
            ten_thu_ngan_label.TabIndex = 1;
            ten_thu_ngan_label.Text = "Anh Huy";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 34);
            label1.TabIndex = 0;
            label1.Text = "Thu ngân:";
            // 
            // order_date_label
            // 
            order_date_label.Dock = DockStyle.Top;
            order_date_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            order_date_label.Location = new Point(0, 74);
            order_date_label.Name = "order_date_label";
            order_date_label.Size = new Size(980, 36);
            order_date_label.TabIndex = 2;
            order_date_label.Text = "Ngày: 16/09/2025";
            order_date_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ID_Order_label
            // 
            ID_Order_label.Dock = DockStyle.Top;
            ID_Order_label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ID_Order_label.Location = new Point(0, 49);
            ID_Order_label.Name = "ID_Order_label";
            ID_Order_label.Size = new Size(980, 25);
            ID_Order_label.TabIndex = 1;
            ID_Order_label.Text = "Mã ĐH: 001";
            ID_Order_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Title_label
            // 
            Title_label.Dock = DockStyle.Top;
            Title_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Title_label.Location = new Point(0, 0);
            Title_label.Name = "Title_label";
            Title_label.Size = new Size(980, 49);
            Title_label.TabIndex = 0;
            Title_label.Text = "Hóa đơn thanh toán";
            Title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InvoiceOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 604);
            Controls.Add(InvoiceOrder_Panel);
            Name = "InvoiceOrder";
            Text = "InvoiceOrder";
            InvoiceOrder_Panel.ResumeLayout(false);
            footer_panel.ResumeLayout(false);
            total_panel.ResumeLayout(false);
            order_detail_panel.ResumeLayout(false);
            item_panel.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            header_panel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel InvoiceOrder_Panel;
        private Label order_date_label;
        private Label ID_Order_label;
        private Label Title_label;
        private Panel panel2;
        private Label pttt_label;
        private Label label4;
        private Panel panel1;
        private Label ten_thu_ngan_label;
        private Label label1;
        private Panel order_detail_panel;
        private Panel header_panel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel item_panel;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label23;
        private Label label22;
        private Panel total_panel;
        private Label total_label;
        private Label label21;
        private Panel footer_panel;
        private Controls.RoundedButton huy_btn;
        private Controls.RoundedButton import_btn;
        private Label label10;
        private Label label9;
        private Label label15;
        private TextBox textBox1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label24;
    }
}