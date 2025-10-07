namespace MilkTea.Client.Forms.ChildForm_Order
{
    partial class ToppingForm
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
            label1 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            topping_opt_panel = new Panel();
            header_panel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            topping_table_panel = new Panel();
            panel3 = new Panel();
            total_label = new Label();
            label12 = new Label();
            footer_panel = new Panel();
            huy_btn = new MilkTea.Client.Controls.RoundedButton();
            XacNhan_btn = new MilkTea.Client.Controls.RoundedButton();
            panel1.SuspendLayout();
            topping_opt_panel.SuspendLayout();
            header_panel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            footer_panel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(566, 58);
            label1.TabIndex = 0;
            label1.Text = "Thêm Topping";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(566, 48);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(90, 0);
            label3.Name = "label3";
            label3.Size = new Size(292, 48);
            label3.TabIndex = 1;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 48);
            label2.TabIndex = 0;
            label2.Text = "Sản phẩm: ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topping_opt_panel
            // 
            topping_opt_panel.AutoScroll = true;
            topping_opt_panel.Controls.Add(header_panel);
            topping_opt_panel.Controls.Add(topping_table_panel);
            topping_opt_panel.Dock = DockStyle.Top;
            topping_opt_panel.Location = new Point(0, 106);
            topping_opt_panel.Name = "topping_opt_panel";
            topping_opt_panel.Size = new Size(566, 344);
            topping_opt_panel.TabIndex = 2;
            // 
            // header_panel
            // 
            header_panel.Controls.Add(tableLayoutPanel1);
            header_panel.Dock = DockStyle.Top;
            header_panel.Location = new Point(0, 0);
            header_panel.Name = "header_panel";
            header_panel.Size = new Size(566, 48);
            header_panel.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.34513F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.3362846F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.79646F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.17687F));
            tableLayoutPanel1.Controls.Add(label7, 3, 0);
            tableLayoutPanel1.Controls.Add(label6, 2, 0);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(566, 48);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AccessibleRole = AccessibleRole.None;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DeepSkyBlue;
            label7.Location = new Point(470, 1);
            label7.Name = "label7";
            label7.Size = new Size(92, 46);
            label7.TabIndex = 3;
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DeepSkyBlue;
            label6.Location = new Point(409, 1);
            label6.Name = "label6";
            label6.Size = new Size(54, 46);
            label6.TabIndex = 2;
            label6.Text = "SL\r\n còn ";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DeepSkyBlue;
            label5.Location = new Point(215, 1);
            label5.Name = "label5";
            label5.Size = new Size(187, 46);
            label5.TabIndex = 1;
            label5.Text = "Số lượng";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DeepSkyBlue;
            label4.Location = new Point(4, 1);
            label4.Name = "label4";
            label4.Size = new Size(204, 46);
            label4.TabIndex = 0;
            label4.Text = "Topping";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topping_table_panel
            // 
            topping_table_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            topping_table_panel.AutoScroll = true;
            topping_table_panel.BorderStyle = BorderStyle.FixedSingle;
            topping_table_panel.Location = new Point(0, 0);
            topping_table_panel.Name = "topping_table_panel";
            topping_table_panel.Size = new Size(566, 344);
            topping_table_panel.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(total_label);
            panel3.Controls.Add(label12);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 450);
            panel3.Name = "panel3";
            panel3.Size = new Size(566, 54);
            panel3.TabIndex = 3;
            // 
            // total_label
            // 
            total_label.Dock = DockStyle.Right;
            total_label.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            total_label.Location = new Point(408, 0);
            total_label.Name = "total_label";
            total_label.Size = new Size(158, 54);
            total_label.TabIndex = 2;
            total_label.Text = "0";
            total_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Left;
            label12.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label12.Location = new Point(0, 0);
            label12.Name = "label12";
            label12.Size = new Size(252, 54);
            label12.TabIndex = 1;
            label12.Text = "Tổng Tiền:";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // footer_panel
            // 
            footer_panel.Controls.Add(huy_btn);
            footer_panel.Controls.Add(XacNhan_btn);
            footer_panel.Dock = DockStyle.Bottom;
            footer_panel.Location = new Point(0, 507);
            footer_panel.Name = "footer_panel";
            footer_panel.Padding = new Padding(10);
            footer_panel.Size = new Size(566, 56);
            footer_panel.TabIndex = 4;
            // 
            // huy_btn
            // 
            huy_btn.BackColor = Color.Red;
            huy_btn.BorderColor = Color.DodgerBlue;
            huy_btn.BorderRadius = 20;
            huy_btn.BorderSize = 0;
            huy_btn.Dock = DockStyle.Right;
            huy_btn.FlatAppearance.BorderSize = 0;
            huy_btn.FlatStyle = FlatStyle.Flat;
            huy_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            huy_btn.ForeColor = Color.White;
            huy_btn.Location = new Point(350, 10);
            huy_btn.Name = "huy_btn";
            huy_btn.Size = new Size(80, 36);
            huy_btn.TabIndex = 1;
            huy_btn.Text = "Hủy";
            huy_btn.UseVisualStyleBackColor = false;
            huy_btn.Click += huy_btn_Click;
            // 
            // XacNhan_btn
            // 
            XacNhan_btn.BackColor = Color.DodgerBlue;
            XacNhan_btn.BorderColor = Color.DodgerBlue;
            XacNhan_btn.BorderRadius = 20;
            XacNhan_btn.BorderSize = 0;
            XacNhan_btn.Dock = DockStyle.Right;
            XacNhan_btn.FlatAppearance.BorderSize = 0;
            XacNhan_btn.FlatStyle = FlatStyle.Flat;
            XacNhan_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            XacNhan_btn.ForeColor = Color.White;
            XacNhan_btn.Location = new Point(430, 10);
            XacNhan_btn.Name = "XacNhan_btn";
            XacNhan_btn.Size = new Size(126, 36);
            XacNhan_btn.TabIndex = 0;
            XacNhan_btn.Text = "Xác nhận";
            XacNhan_btn.UseVisualStyleBackColor = false;
            // 
            // ToppingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 563);
            Controls.Add(footer_panel);
            Controls.Add(panel3);
            Controls.Add(topping_opt_panel);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "ToppingForm";
            Text = "ToppingForm";
            panel1.ResumeLayout(false);
            topping_opt_panel.ResumeLayout(false);
            header_panel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            footer_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Panel topping_opt_panel;
        private Panel topping_table_panel;
        private Panel panel3;
        private Label total_label;
        private Label label12;
        private Panel footer_panel;
        private Controls.RoundedButton huy_btn;
        private Controls.RoundedButton XacNhan_btn;
        private Panel header_panel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
    }
}