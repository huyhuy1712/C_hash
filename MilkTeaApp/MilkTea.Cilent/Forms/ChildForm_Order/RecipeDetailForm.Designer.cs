namespace MilkTea.Client.Forms.ChildForm_Order
{
    partial class RecipeDetailForm
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
            panel2 = new Panel();
            tenSP_lbl = new Label();
            label2 = new Label();
            label4 = new Label();
            txtTenCongThuc = new MilkTea.Client.Controls.RoundedTextBox();
            header_panel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label5 = new Label();
            label12 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            label7 = new Label();
            footer_panel = new Panel();
            huy_btn = new MilkTea.Client.Controls.RoundedButton();
            XacNhan_btn = new MilkTea.Client.Controls.RoundedButton();
            dataGridView1 = new DataGridView();
            panel2.SuspendLayout();
            header_panel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            footer_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            label1.Size = new Size(441, 58);
            label1.TabIndex = 1;
            label1.Text = " Công thức";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(tenSP_lbl);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(441, 33);
            panel2.TabIndex = 2;
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
            tenSP_lbl.Size = new Size(283, 33);
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
            // label4
            // 
            label4.BackColor = SystemColors.Control;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.DeepSkyBlue;
            label4.Location = new Point(0, 91);
            label4.Name = "label4";
            label4.Padding = new Padding(5);
            label4.Size = new Size(441, 41);
            label4.TabIndex = 3;
            label4.Text = "Tên công thức";
            // 
            // txtTenCongThuc
            // 
            txtTenCongThuc.BackColor = Color.White;
            txtTenCongThuc.BorderColor = Color.Gray;
            txtTenCongThuc.BorderRadius = 20;
            txtTenCongThuc.Dock = DockStyle.Top;
            txtTenCongThuc.FocusBorderColor = Color.DeepSkyBlue;
            txtTenCongThuc.Location = new Point(0, 132);
            txtTenCongThuc.Name = "txtTenCongThuc";
            txtTenCongThuc.Padding = new Padding(10, 5, 40, 5);
            txtTenCongThuc.Placeholder = "";
            txtTenCongThuc.Size = new Size(441, 37);
            txtTenCongThuc.TabIndex = 5;
            txtTenCongThuc.TextValue = "";
            // 
            // header_panel
            // 
            header_panel.BackColor = Color.Gainsboro;
            header_panel.Controls.Add(tableLayoutPanel1);
            header_panel.Dock = DockStyle.Top;
            header_panel.Location = new Point(0, 169);
            header_panel.Name = "header_panel";
            header_panel.Size = new Size(441, 39);
            header_panel.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.22727F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.772728F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label12, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(441, 39);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DeepSkyBlue;
            label3.Location = new Point(297, 1);
            label3.Name = "label3";
            label3.Size = new Size(140, 37);
            label3.TabIndex = 2;
            label3.Text = "SL tồn kho";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DeepSkyBlue;
            label5.Location = new Point(151, 1);
            label5.Name = "label5";
            label5.Size = new Size(139, 37);
            label5.TabIndex = 1;
            label5.Text = "SL cần dùng";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.DeepSkyBlue;
            label12.Location = new Point(4, 1);
            label12.Name = "label12";
            label12.Size = new Size(140, 37);
            label12.TabIndex = 0;
            label12.Text = "Nguyên liệu";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 479);
            panel1.Name = "panel1";
            panel1.Size = new Size(441, 33);
            panel1.TabIndex = 7;
            // 
            // label6
            // 
            label6.BackColor = SystemColors.Control;
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(207, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(5);
            label6.Size = new Size(234, 33);
            label6.TabIndex = 2;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.Control;
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DodgerBlue;
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Padding = new Padding(5);
            label7.Size = new Size(207, 33);
            label7.TabIndex = 1;
            label7.Text = "SL sản phẩm có thể làm:";
            // 
            // footer_panel
            // 
            footer_panel.Controls.Add(huy_btn);
            footer_panel.Controls.Add(XacNhan_btn);
            footer_panel.Dock = DockStyle.Bottom;
            footer_panel.Location = new Point(0, 512);
            footer_panel.Name = "footer_panel";
            footer_panel.Padding = new Padding(10);
            footer_panel.Size = new Size(441, 56);
            footer_panel.TabIndex = 8;
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
            huy_btn.Location = new Point(225, 10);
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
            XacNhan_btn.Location = new Point(305, 10);
            XacNhan_btn.Name = "XacNhan_btn";
            XacNhan_btn.Size = new Size(126, 36);
            XacNhan_btn.TabIndex = 0;
            XacNhan_btn.Text = "Xác nhận";
            XacNhan_btn.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 208);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(441, 271);
            dataGridView1.TabIndex = 0;
            // 
            // RecipeDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 568);
            Controls.Add(footer_panel);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(header_panel);
            Controls.Add(txtTenCongThuc);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(label1);
            Name = "RecipeDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecipeDetailForm";
            panel2.ResumeLayout(false);
            header_panel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            footer_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel2;
        private Label tenSP_lbl;
        private Label label2;
        private Label label4;
        private Controls.RoundedTextBox txtTenCongThuc;
        private Panel header_panel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label5;
        private Label label12;
        private Label label3;
        private Panel panel1;
        private Label label6;
        private Label label7;
        private Panel footer_panel;
        private Controls.RoundedButton huy_btn;
        private Controls.RoundedButton XacNhan_btn;
        private DataGridView dataGridView1;
    }
}