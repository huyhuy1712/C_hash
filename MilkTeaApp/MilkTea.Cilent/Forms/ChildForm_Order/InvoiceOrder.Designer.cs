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
            panel_buzzer = new Panel();
            mamay_label = new Label();
            label18 = new Label();
            huy_btn = new MilkTea.Client.Controls.RoundedButton();
            import_btn = new MilkTea.Client.Controls.RoundedButton();
            label23 = new Label();
            label22 = new Label();
            total_panel = new Panel();
            total_label = new Label();
            label21 = new Label();
            order_detail_panel = new Panel();
            panel2 = new Panel();
            pttt_label = new Label();
            label4 = new Label();
            panel1 = new Panel();
            ten_thu_ngan_label = new Label();
            label1 = new Label();
            order_date_label = new Label();
            Title_label = new Label();
            InvoiceOrder_Panel.SuspendLayout();
            footer_panel.SuspendLayout();
            panel_buzzer.SuspendLayout();
            total_panel.SuspendLayout();
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
            InvoiceOrder_Panel.Controls.Add(Title_label);
            InvoiceOrder_Panel.Dock = DockStyle.Fill;
            InvoiceOrder_Panel.Location = new Point(0, 0);
            InvoiceOrder_Panel.Name = "InvoiceOrder_Panel";
            InvoiceOrder_Panel.Size = new Size(1068, 604);
            InvoiceOrder_Panel.TabIndex = 0;
            InvoiceOrder_Panel.Paint += InvoiceOrder_Panel_Paint;
            // 
            // footer_panel
            // 
            footer_panel.Controls.Add(panel_buzzer);
            footer_panel.Controls.Add(huy_btn);
            footer_panel.Controls.Add(import_btn);
            footer_panel.Dock = DockStyle.Bottom;
            footer_panel.Location = new Point(0, 542);
            footer_panel.Name = "footer_panel";
            footer_panel.Padding = new Padding(14);
            footer_panel.Size = new Size(1068, 62);
            footer_panel.TabIndex = 9;
            // 
            // panel_buzzer
            // 
            panel_buzzer.Controls.Add(mamay_label);
            panel_buzzer.Controls.Add(label18);
            panel_buzzer.Dock = DockStyle.Left;
            panel_buzzer.Location = new Point(14, 14);
            panel_buzzer.Name = "panel_buzzer";
            panel_buzzer.Size = new Size(154, 34);
            panel_buzzer.TabIndex = 5;
            // 
            // mamay_label
            // 
            mamay_label.Dock = DockStyle.Left;
            mamay_label.Font = new Font("Segoe UI", 11F);
            mamay_label.Location = new Point(90, 0);
            mamay_label.Name = "mamay_label";
            mamay_label.Size = new Size(79, 34);
            mamay_label.TabIndex = 1;
            // 
            // label18
            // 
            label18.Dock = DockStyle.Left;
            label18.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label18.Location = new Point(0, 0);
            label18.Name = "label18";
            label18.Size = new Size(90, 34);
            label18.TabIndex = 0;
            label18.Text = "Mã Máy: ";
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
            huy_btn.Location = new Point(826, 14);
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
            import_btn.Location = new Point(940, 14);
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
            label23.Location = new Point(0, 491);
            label23.Name = "label23";
            label23.Size = new Size(1068, 23);
            label23.TabIndex = 8;
            label23.Text = "Xin cám ơn hẹn gặp lại quý khách";
            label23.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            label22.Dock = DockStyle.Top;
            label22.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.Location = new Point(0, 468);
            label22.Name = "label22";
            label22.Size = new Size(1068, 23);
            label22.TabIndex = 7;
            label22.Text = "----------------------";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // total_panel
            // 
            total_panel.Controls.Add(total_label);
            total_panel.Controls.Add(label21);
            total_panel.Dock = DockStyle.Top;
            total_panel.Location = new Point(0, 422);
            total_panel.Name = "total_panel";
            total_panel.Size = new Size(1068, 46);
            total_panel.TabIndex = 6;
            // 
            // total_label
            // 
            total_label.Dock = DockStyle.Right;
            total_label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            total_label.Location = new Point(936, 0);
            total_label.Name = "total_label";
            total_label.Size = new Size(132, 46);
            total_label.TabIndex = 1;
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
            order_detail_panel.Dock = DockStyle.Top;
            order_detail_panel.Location = new Point(0, 153);
            order_detail_panel.Name = "order_detail_panel";
            order_detail_panel.Size = new Size(1068, 269);
            order_detail_panel.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(pttt_label);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 119);
            panel2.Name = "panel2";
            panel2.Size = new Size(1068, 34);
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
            panel1.Location = new Point(0, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(1068, 34);
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
            order_date_label.Location = new Point(0, 49);
            order_date_label.Name = "order_date_label";
            order_date_label.Size = new Size(1068, 36);
            order_date_label.TabIndex = 2;
            order_date_label.TextAlign = ContentAlignment.MiddleCenter;
            order_date_label.Click += order_date_label_Click;
            // 
            // Title_label
            // 
            Title_label.Dock = DockStyle.Top;
            Title_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Title_label.Location = new Point(0, 0);
            Title_label.Name = "Title_label";
            Title_label.Size = new Size(1068, 49);
            Title_label.TabIndex = 0;
            Title_label.Text = "Hóa đơn thanh toán";
            Title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InvoiceOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 604);
            Controls.Add(InvoiceOrder_Panel);
            Name = "InvoiceOrder";
            Text = "InvoiceOrder";
            InvoiceOrder_Panel.ResumeLayout(false);
            footer_panel.ResumeLayout(false);
            panel_buzzer.ResumeLayout(false);
            total_panel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel InvoiceOrder_Panel;
        private Label order_date_label;
        private Label Title_label;
        private Panel panel2;
        private Label pttt_label;
        private Label label4;
        private Panel panel1;
        private Label ten_thu_ngan_label;
        private Label label1;
        private Label label23;
        private Label label22;
        private Panel total_panel;
        private Label total_label;
        private Label label21;
        private Panel footer_panel;
        private Controls.RoundedButton huy_btn;
        private Controls.RoundedButton import_btn;
        private Panel panel_buzzer;
        private Label mamay_label;
        private Label label18;
        private Panel order_detail_panel;
    }
}