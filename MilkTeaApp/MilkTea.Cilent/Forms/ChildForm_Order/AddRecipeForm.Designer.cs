namespace MilkTea.Client.Forms.ChildForm_Order
{
    partial class AddRecipeForm
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
            footer_panel = new Panel();
            huy_btn = new MilkTea.Client.Controls.RoundedButton();
            XacNhan_btn = new MilkTea.Client.Controls.RoundedButton();
            panel1 = new Panel();
            topping_opt_panel = new Panel();
            topping_table_panel = new Panel();
            txtSearch_NL = new TextBox();
            header_panel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label7 = new Label();
            label5 = new Label();
            label12 = new Label();
            txtTenCongThuc = new MilkTea.Client.Controls.RoundedTextBox();
            label4 = new Label();
            panel2 = new Panel();
            tenSP_lbl = new Label();
            label2 = new Label();
            footer_panel.SuspendLayout();
            panel1.SuspendLayout();
            topping_opt_panel.SuspendLayout();
            header_panel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(421, 58);
            label1.TabIndex = 0;
            label1.Text = "Thêm công thức";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // footer_panel
            // 
            footer_panel.Controls.Add(huy_btn);
            footer_panel.Controls.Add(XacNhan_btn);
            footer_panel.Dock = DockStyle.Bottom;
            footer_panel.Location = new Point(10, 502);
            footer_panel.Name = "footer_panel";
            footer_panel.Padding = new Padding(10);
            footer_panel.Size = new Size(421, 56);
            footer_panel.TabIndex = 4;
            // 
            // huy_btn
            // 
            huy_btn.BackColor = Color.Red;
            huy_btn.BorderColor = Color.DodgerBlue;
            huy_btn.BorderRadius = 20;
            huy_btn.BorderSize = 0;
            huy_btn.Cursor = Cursors.Hand;
            huy_btn.Dock = DockStyle.Right;
            huy_btn.FlatAppearance.BorderSize = 0;
            huy_btn.FlatStyle = FlatStyle.Flat;
            huy_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            huy_btn.ForeColor = Color.White;
            huy_btn.Location = new Point(205, 10);
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
            XacNhan_btn.Cursor = Cursors.Hand;
            XacNhan_btn.Dock = DockStyle.Right;
            XacNhan_btn.FlatAppearance.BorderSize = 0;
            XacNhan_btn.FlatStyle = FlatStyle.Flat;
            XacNhan_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            XacNhan_btn.ForeColor = Color.White;
            XacNhan_btn.Location = new Point(285, 10);
            XacNhan_btn.Name = "XacNhan_btn";
            XacNhan_btn.Size = new Size(126, 36);
            XacNhan_btn.TabIndex = 0;
            XacNhan_btn.Text = "Xác nhận";
            XacNhan_btn.UseVisualStyleBackColor = false;
            XacNhan_btn.Click += XacNhan_btn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(topping_opt_panel);
            panel1.Controls.Add(txtTenCongThuc);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(10, 68);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(421, 434);
            panel1.TabIndex = 5;
            // 
            // topping_opt_panel
            // 
            topping_opt_panel.AutoScroll = true;
            topping_opt_panel.Controls.Add(topping_table_panel);
            topping_opt_panel.Controls.Add(txtSearch_NL);
            topping_opt_panel.Controls.Add(header_panel);
            topping_opt_panel.Dock = DockStyle.Fill;
            topping_opt_panel.Location = new Point(5, 116);
            topping_opt_panel.Name = "topping_opt_panel";
            topping_opt_panel.Padding = new Padding(10);
            topping_opt_panel.Size = new Size(411, 313);
            topping_opt_panel.TabIndex = 5;
            // 
            // topping_table_panel
            // 
            topping_table_panel.AutoScroll = true;
            topping_table_panel.Dock = DockStyle.Fill;
            topping_table_panel.Location = new Point(10, 49);
            topping_table_panel.Name = "topping_table_panel";
            topping_table_panel.Size = new Size(391, 221);
            topping_table_panel.TabIndex = 3;
            // 
            // txtSearch_NL
            // 
            txtSearch_NL.BorderStyle = BorderStyle.FixedSingle;
            txtSearch_NL.Cursor = Cursors.IBeam;
            txtSearch_NL.Dock = DockStyle.Bottom;
            txtSearch_NL.Location = new Point(10, 270);
            txtSearch_NL.Multiline = true;
            txtSearch_NL.Name = "txtSearch_NL";
            txtSearch_NL.PlaceholderText = "----Tìm kiếm----";
            txtSearch_NL.Size = new Size(391, 33);
            txtSearch_NL.TabIndex = 2;
            txtSearch_NL.TextAlign = HorizontalAlignment.Center;
            txtSearch_NL.KeyDown += txtSearch_NL_KeyDown;
            // 
            // header_panel
            // 
            header_panel.BackColor = Color.Gainsboro;
            header_panel.Controls.Add(tableLayoutPanel1);
            header_panel.Dock = DockStyle.Top;
            header_panel.Location = new Point(10, 10);
            header_panel.Name = "header_panel";
            header_panel.Size = new Size(391, 39);
            header_panel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.05128F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.1538467F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.7948723F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label7, 2, 0);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label12, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(391, 39);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AccessibleRole = AccessibleRole.None;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DeepSkyBlue;
            label7.Location = new Point(269, 1);
            label7.Name = "label7";
            label7.Size = new Size(118, 37);
            label7.TabIndex = 3;
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DeepSkyBlue;
            label5.Location = new Point(129, 1);
            label5.Name = "label5";
            label5.Size = new Size(133, 37);
            label5.TabIndex = 1;
            label5.Text = "Số lượng";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.DeepSkyBlue;
            label12.Location = new Point(4, 1);
            label12.Name = "label12";
            label12.Size = new Size(118, 37);
            label12.TabIndex = 0;
            label12.Text = "Nguyên liệu";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTenCongThuc
            // 
            txtTenCongThuc.BackColor = Color.White;
            txtTenCongThuc.BorderColor = Color.Gray;
            txtTenCongThuc.BorderRadius = 20;
            txtTenCongThuc.Dock = DockStyle.Top;
            txtTenCongThuc.FocusBorderColor = Color.DeepSkyBlue;
            txtTenCongThuc.Location = new Point(5, 79);
            txtTenCongThuc.Name = "txtTenCongThuc";
            txtTenCongThuc.Padding = new Padding(10, 5, 40, 5);
            txtTenCongThuc.Placeholder = "";
            txtTenCongThuc.Size = new Size(411, 37);
            txtTenCongThuc.TabIndex = 4;
            txtTenCongThuc.TextValue = "";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.Control;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.DeepSkyBlue;
            label4.Location = new Point(5, 38);
            label4.Name = "label4";
            label4.Padding = new Padding(5);
            label4.Size = new Size(411, 41);
            label4.TabIndex = 1;
            label4.Text = "Tên công thức";
            // 
            // panel2
            // 
            panel2.Controls.Add(tenSP_lbl);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(5, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(411, 33);
            panel2.TabIndex = 0;
            // 
            // tenSP_lbl
            // 
            tenSP_lbl.BackColor = SystemColors.Control;
            tenSP_lbl.Dock = DockStyle.Left;
            tenSP_lbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tenSP_lbl.ForeColor = SystemColors.ActiveCaptionText;
            tenSP_lbl.Location = new Point(133, 0);
            tenSP_lbl.Name = "tenSP_lbl";
            tenSP_lbl.Padding = new Padding(5);
            tenSP_lbl.Size = new Size(151, 33);
            tenSP_lbl.TabIndex = 2;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Control;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(133, 33);
            label2.TabIndex = 1;
            label2.Text = "Tên sản phẩm:";
            // 
            // AddRecipeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 568);
            Controls.Add(panel1);
            Controls.Add(footer_panel);
            Controls.Add(label1);
            Name = "AddRecipeForm";
            Padding = new Padding(10);
            Text = "AddRecipeForm";
            footer_panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            topping_opt_panel.ResumeLayout(false);
            topping_opt_panel.PerformLayout();
            header_panel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel footer_panel;
        private Controls.RoundedButton huy_btn;
        private Controls.RoundedButton XacNhan_btn;
        private Panel panel1;
        private Panel panel2;
        private Label tenSP_lbl;
        private Label label2;
        private Label label4;
        private Panel topping_opt_panel;
        private TextBox txtSearch_NL;
        private Panel header_panel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label7;
        private Label label5;
        private Label label12;
        private Controls.RoundedTextBox txtTenCongThuc;
        private Panel topping_table_panel;
    }
}