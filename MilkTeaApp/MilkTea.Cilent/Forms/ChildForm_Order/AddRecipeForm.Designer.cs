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
            textBox1 = new TextBox();
            topping_table_panel = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            checkBox2 = new CheckBox();
            label10 = new Label();
            checkBox1 = new CheckBox();
            label8 = new Label();
            textBox2 = new TextBox();
            header_panel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label7 = new Label();
            label5 = new Label();
            label12 = new Label();
            ten_textbox = new MilkTea.Client.Controls.RoundedTextBox();
            label4 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            textBox3 = new TextBox();
            footer_panel.SuspendLayout();
            panel1.SuspendLayout();
            topping_opt_panel.SuspendLayout();
            topping_table_panel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
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
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(302, 58);
            label1.TabIndex = 0;
            label1.Text = "Thêm công thức";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // footer_panel
            // 
            footer_panel.Controls.Add(huy_btn);
            footer_panel.Controls.Add(XacNhan_btn);
            footer_panel.Dock = DockStyle.Bottom;
            footer_panel.Location = new Point(0, 512);
            footer_panel.Name = "footer_panel";
            footer_panel.Padding = new Padding(10);
            footer_panel.Size = new Size(302, 56);
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
            huy_btn.Location = new Point(86, 10);
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
            XacNhan_btn.Location = new Point(166, 10);
            XacNhan_btn.Name = "XacNhan_btn";
            XacNhan_btn.Size = new Size(126, 36);
            XacNhan_btn.TabIndex = 0;
            XacNhan_btn.Text = "Xác nhận";
            XacNhan_btn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(topping_opt_panel);
            panel1.Controls.Add(ten_textbox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 454);
            panel1.TabIndex = 5;
            // 
            // topping_opt_panel
            // 
            topping_opt_panel.AutoScroll = true;
            topping_opt_panel.Controls.Add(textBox1);
            topping_opt_panel.Controls.Add(topping_table_panel);
            topping_opt_panel.Controls.Add(header_panel);
            topping_opt_panel.Dock = DockStyle.Top;
            topping_opt_panel.Location = new Point(0, 106);
            topping_opt_panel.Name = "topping_opt_panel";
            topping_opt_panel.Size = new Size(302, 344);
            topping_opt_panel.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Dock = DockStyle.Bottom;
            textBox1.Location = new Point(0, 314);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "----Tìm kiếm----";
            textBox1.Size = new Size(302, 30);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // topping_table_panel
            // 
            topping_table_panel.AutoScroll = true;
            topping_table_panel.Controls.Add(tableLayoutPanel2);
            topping_table_panel.Dock = DockStyle.Fill;
            topping_table_panel.Location = new Point(0, 64);
            topping_table_panel.Name = "topping_table_panel";
            topping_table_panel.Size = new Size(302, 280);
            topping_table_panel.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.9740486F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.54485F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.5614624F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(textBox3, 1, 1);
            tableLayoutPanel2.Controls.Add(checkBox2, 2, 1);
            tableLayoutPanel2.Controls.Add(label10, 0, 1);
            tableLayoutPanel2.Controls.Add(checkBox1, 2, 0);
            tableLayoutPanel2.Controls.Add(label8, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox2, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(302, 77);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // checkBox2
            // 
            checkBox2.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox2.Cursor = Cursors.Hand;
            checkBox2.Dock = DockStyle.Fill;
            checkBox2.Location = new Point(209, 42);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(89, 31);
            checkBox2.TabIndex = 10;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(4, 39);
            label10.Name = "label10";
            label10.Size = new Size(89, 37);
            label10.TabIndex = 7;
            label10.Text = "Kem sữa";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox1.Cursor = Cursors.Hand;
            checkBox1.Dock = DockStyle.Fill;
            checkBox1.Location = new Point(209, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(89, 31);
            checkBox1.TabIndex = 6;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(4, 1);
            label8.Name = "label8";
            label8.Size = new Size(89, 37);
            label8.TabIndex = 0;
            label8.Text = "Đá";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(100, 4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(102, 31);
            textBox2.TabIndex = 11;
            textBox2.TabStop = false;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // header_panel
            // 
            header_panel.Controls.Add(tableLayoutPanel1);
            header_panel.Dock = DockStyle.Top;
            header_panel.Location = new Point(0, 0);
            header_panel.Name = "header_panel";
            header_panel.Size = new Size(302, 64);
            header_panel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.885397F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.2093F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.2292366F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label7, 2, 0);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label12, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(302, 64);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AccessibleRole = AccessibleRole.None;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DeepSkyBlue;
            label7.Location = new Point(210, 1);
            label7.Name = "label7";
            label7.Size = new Size(88, 62);
            label7.TabIndex = 3;
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DeepSkyBlue;
            label5.Location = new Point(99, 1);
            label5.Name = "label5";
            label5.Size = new Size(104, 62);
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
            label12.Size = new Size(88, 62);
            label12.TabIndex = 0;
            label12.Text = "Nguyên liệu";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ten_textbox
            // 
            ten_textbox.BackColor = Color.White;
            ten_textbox.BorderColor = Color.Gray;
            ten_textbox.BorderRadius = 20;
            ten_textbox.Cursor = Cursors.IBeam;
            ten_textbox.Dock = DockStyle.Top;
            ten_textbox.FocusBorderColor = Color.DeepSkyBlue;
            ten_textbox.Location = new Point(0, 73);
            ten_textbox.Name = "ten_textbox";
            ten_textbox.Padding = new Padding(10, 5, 40, 5);
            ten_textbox.Placeholder = "";
            ten_textbox.Size = new Size(302, 33);
            ten_textbox.TabIndex = 2;
            ten_textbox.TextValue = "";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.Control;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.DeepSkyBlue;
            label4.Location = new Point(0, 33);
            label4.Name = "label4";
            label4.Padding = new Padding(5);
            label4.Size = new Size(302, 40);
            label4.TabIndex = 1;
            label4.Text = "Tên công thức";
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(302, 33);
            panel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.Control;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(133, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(151, 33);
            label3.TabIndex = 2;
            label3.Text = "Trà sữa hạt nhài";
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
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Cursor = Cursors.IBeam;
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(100, 42);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(102, 31);
            textBox3.TabIndex = 12;
            textBox3.TabStop = false;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // AddRecipeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 568);
            Controls.Add(panel1);
            Controls.Add(footer_panel);
            Controls.Add(label1);
            Name = "AddRecipeForm";
            Text = "AddRecipeForm";
            footer_panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            topping_opt_panel.ResumeLayout(false);
            topping_opt_panel.PerformLayout();
            topping_table_panel.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
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
        private Label label3;
        private Label label2;
        private Label label4;
        private Controls.RoundedTextBox ten_textbox;
        private Panel topping_opt_panel;
        private TextBox textBox1;
        private Panel topping_table_panel;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckBox checkBox2;
        private Label label10;
        private CheckBox checkBox1;
        private Label label8;
        private Panel header_panel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label7;
        private Label label5;
        private Label label12;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}