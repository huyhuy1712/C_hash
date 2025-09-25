
namespace MilkTea.Client.Forms
{
    partial class ReportForm
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
            ReportPanel = new Panel();
            Content = new Panel();
            dataGridView1 = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            product = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Sale = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Profits = new DataGridViewTextBoxColumn();
            Filter = new Panel();
            Order = new Panel();
            panel1 = new Panel();
            roundedComboBox4 = new MilkTea.Client.Controls.RoundedComboBox();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            roundedComboBox1 = new MilkTea.Client.Controls.RoundedComboBox();
            label5 = new Label();
            panel2 = new Panel();
            roundedPanel1 = new MilkTea.Client.Controls.RoundedPanel();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            panel3 = new Panel();
            roundedPanel2 = new MilkTea.Client.Controls.RoundedPanel();
            dateTimePicker2 = new DateTimePicker();
            label4 = new Label();
            panel5 = new Panel();
            roundedComboBox2 = new MilkTea.Client.Controls.RoundedComboBox();
            label6 = new Label();
            panel7 = new Panel();
            roundedComboBox3 = new MilkTea.Client.Controls.RoundedComboBox();
            label7 = new Label();
            roundedButton1 = new MilkTea.Client.Controls.RoundedButton();
            Header = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            ReportPanel.SuspendLayout();
            Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Filter.SuspendLayout();
            Order.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            roundedPanel1.SuspendLayout();
            panel3.SuspendLayout();
            roundedPanel2.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            Header.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // ReportPanel
            // 
            ReportPanel.Controls.Add(Content);
            ReportPanel.Controls.Add(Header);
            ReportPanel.Dock = DockStyle.Fill;
            ReportPanel.Location = new Point(0, 0);
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(919, 537);
            ReportPanel.TabIndex = 0;
            ReportPanel.Paint += ReportPanel_Paint;
            // 
            // Content
            // 
            Content.Controls.Add(panel6);
            Content.Controls.Add(dataGridView1);
            Content.Controls.Add(Filter);
            Content.Dock = DockStyle.Fill;
            Content.Location = new Point(0, 43);
            Content.Name = "Content";
            Content.Size = new Size(919, 494);
            Content.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Time, product, Size, Quantity, Sale, Cost, Total, Profits });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(919, 399);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Time
            // 
            Time.HeaderText = "Thời gian";
            Time.MinimumWidth = 6;
            Time.Name = "Time";
            Time.ReadOnly = true;
            // 
            // product
            // 
            product.HeaderText = "Sản phẩm";
            product.MinimumWidth = 6;
            product.Name = "product";
            product.ReadOnly = true;
            // 
            // Size
            // 
            Size.HeaderText = "Size";
            Size.MinimumWidth = 6;
            Size.Name = "Size";
            Size.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Số lượng";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // Sale
            // 
            Sale.HeaderText = "% Khuyến mãi";
            Sale.MinimumWidth = 6;
            Sale.Name = "Sale";
            Sale.ReadOnly = true;
            // 
            // Cost
            // 
            Cost.HeaderText = "Chi phí";
            Cost.MinimumWidth = 6;
            Cost.Name = "Cost";
            Cost.ReadOnly = true;
            // 
            // Total
            // 
            Total.HeaderText = "Doanh thu";
            Total.MinimumWidth = 6;
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // Profits
            // 
            Profits.HeaderText = "Lợi nhuận";
            Profits.MinimumWidth = 6;
            Profits.Name = "Profits";
            Profits.ReadOnly = true;
            // 
            // Filter
            // 
            Filter.Controls.Add(Order);
            Filter.Controls.Add(tableLayoutPanel1);
            Filter.Dock = DockStyle.Top;
            Filter.Location = new Point(0, 0);
            Filter.Name = "Filter";
            Filter.Size = new Size(919, 95);
            Filter.TabIndex = 0;
            // 
            // Order
            // 
            Order.Controls.Add(panel1);
            Order.Dock = DockStyle.Fill;
            Order.Location = new Point(0, 47);
            Order.Name = "Order";
            Order.Padding = new Padding(5);
            Order.Size = new Size(919, 48);
            Order.TabIndex = 1;
            Order.Paint += Order_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedComboBox4);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(634, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 38);
            panel1.TabIndex = 1;
            // 
            // roundedComboBox4
            // 
            roundedComboBox4.BackColor = Color.White;
            roundedComboBox4.BorderColor = Color.Gray;
            roundedComboBox4.BorderRadius = 15;
            roundedComboBox4.BorderSize = 1;
            roundedComboBox4.Dock = DockStyle.Fill;
            roundedComboBox4.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox4.FlatStyle = FlatStyle.Flat;
            roundedComboBox4.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox4.Font = new Font("Segoe UI", 10F);
            roundedComboBox4.FormattingEnabled = true;
            roundedComboBox4.ItemHeight = 30;
            roundedComboBox4.Items.AddRange(new object[] { "Doanh thu cao đến thấp", "Doanh thu thấp đến cao", "Số lượng cao đến thấp", "Số lượng thấp đến cao" });
            roundedComboBox4.Location = new Point(58, 0);
            roundedComboBox4.Name = "roundedComboBox4";
            roundedComboBox4.Size = new Size(222, 36);
            roundedComboBox4.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(58, 37);
            label1.TabIndex = 0;
            label1.Text = "Lọc";
            label1.Click += label1_Click_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ScrollBar;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(panel4, 2, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel5, 3, 0);
            tableLayoutPanel1.Controls.Add(panel7, 4, 0);
            tableLayoutPanel1.Controls.Add(roundedButton1, 5, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(919, 47);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel4
            // 
            panel4.Controls.Add(roundedComboBox1);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(309, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(147, 41);
            panel4.TabIndex = 7;
            // 
            // roundedComboBox1
            // 
            roundedComboBox1.BackColor = Color.White;
            roundedComboBox1.BorderColor = Color.Gray;
            roundedComboBox1.BorderRadius = 15;
            roundedComboBox1.BorderSize = 1;
            roundedComboBox1.DisplayMember = "A";
            roundedComboBox1.Dock = DockStyle.Fill;
            roundedComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox1.FlatStyle = FlatStyle.Flat;
            roundedComboBox1.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox1.Font = new Font("Segoe UI", 10F);
            roundedComboBox1.FormattingEnabled = true;
            roundedComboBox1.ItemHeight = 30;
            roundedComboBox1.Items.AddRange(new object[] { "A", "B", "C" });
            roundedComboBox1.Location = new Point(51, 0);
            roundedComboBox1.Name = "roundedComboBox1";
            roundedComboBox1.Size = new Size(96, 36);
            roundedComboBox1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 6, 0, 0);
            label5.Size = new Size(51, 34);
            label5.TabIndex = 0;
            label5.Text = "Loại";
            label5.Click += label5_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(roundedPanel1);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(147, 41);
            panel2.TabIndex = 5;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.White;
            roundedPanel1.BorderColor = Color.White;
            roundedPanel1.BorderRadius = 20;
            roundedPanel1.BorderSize = 0;
            roundedPanel1.Controls.Add(dateTimePicker1);
            roundedPanel1.Dock = DockStyle.Fill;
            roundedPanel1.ForeColor = Color.Black;
            roundedPanel1.Location = new Point(37, 0);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(110, 41);
            roundedPanel1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarForeColor = Color.Black;
            dateTimePicker1.CalendarMonthBackground = Color.Transparent;
            dateTimePicker1.CalendarTitleBackColor = Color.Transparent;
            dateTimePicker1.CalendarTitleForeColor = Color.Transparent;
            dateTimePicker1.CalendarTrailingForeColor = Color.Transparent;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(110, 43);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 6, 0, 0);
            label3.Size = new Size(37, 34);
            label3.TabIndex = 0;
            label3.Text = "Từ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(roundedPanel2);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(156, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(147, 41);
            panel3.TabIndex = 6;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.White;
            roundedPanel2.BorderColor = Color.DodgerBlue;
            roundedPanel2.BorderRadius = 20;
            roundedPanel2.BorderSize = 0;
            roundedPanel2.Controls.Add(dateTimePicker2);
            roundedPanel2.Dock = DockStyle.Fill;
            roundedPanel2.ForeColor = Color.Black;
            roundedPanel2.Location = new Point(50, 0);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(97, 41);
            roundedPanel2.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Dock = DockStyle.Fill;
            dateTimePicker2.Font = new Font("Segoe UI", 16F);
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(0, 0);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(97, 43);
            dateTimePicker2.TabIndex = 0;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 6, 0, 0);
            label4.Size = new Size(50, 34);
            label4.TabIndex = 0;
            label4.Text = "Đến";
            label4.Click += label4_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(roundedComboBox2);
            panel5.Controls.Add(label6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(462, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(147, 41);
            panel5.TabIndex = 8;
            // 
            // roundedComboBox2
            // 
            roundedComboBox2.BackColor = Color.White;
            roundedComboBox2.BorderColor = Color.Gray;
            roundedComboBox2.BorderRadius = 15;
            roundedComboBox2.BorderSize = 1;
            roundedComboBox2.Dock = DockStyle.Fill;
            roundedComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox2.FlatStyle = FlatStyle.Flat;
            roundedComboBox2.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox2.Font = new Font("Segoe UI", 10F);
            roundedComboBox2.FormattingEnabled = true;
            roundedComboBox2.ItemHeight = 30;
            roundedComboBox2.Location = new Point(100, 0);
            roundedComboBox2.Name = "roundedComboBox2";
            roundedComboBox2.Size = new Size(47, 36);
            roundedComboBox2.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(0, 6, 0, 0);
            label6.Size = new Size(100, 31);
            label6.TabIndex = 0;
            label6.Text = "Sản phẩm";
            // 
            // panel7
            // 
            panel7.Controls.Add(roundedComboBox3);
            panel7.Controls.Add(label7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(615, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(147, 41);
            panel7.TabIndex = 9;
            // 
            // roundedComboBox3
            // 
            roundedComboBox3.BackColor = Color.White;
            roundedComboBox3.BorderColor = Color.Gray;
            roundedComboBox3.BorderRadius = 15;
            roundedComboBox3.BorderSize = 1;
            roundedComboBox3.Dock = DockStyle.Fill;
            roundedComboBox3.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox3.FlatStyle = FlatStyle.Flat;
            roundedComboBox3.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox3.Font = new Font("Segoe UI", 10F);
            roundedComboBox3.FormattingEnabled = true;
            roundedComboBox3.ItemHeight = 30;
            roundedComboBox3.Location = new Point(50, 0);
            roundedComboBox3.Name = "roundedComboBox3";
            roundedComboBox3.Size = new Size(97, 36);
            roundedComboBox3.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Padding = new Padding(0, 6, 0, 0);
            label7.Size = new Size(50, 34);
            label7.TabIndex = 0;
            label7.Text = "Size";
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.SteelBlue;
            roundedButton1.BorderColor = Color.DodgerBlue;
            roundedButton1.BorderRadius = 20;
            roundedButton1.BorderSize = 0;
            roundedButton1.Dock = DockStyle.Fill;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(768, 3);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(148, 41);
            roundedButton1.TabIndex = 10;
            roundedButton1.Text = "Lấy dữ liệu";
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // Header
            // 
            Header.Controls.Add(label2);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(919, 43);
            Header.TabIndex = 1;
            Header.Paint += Header_Paint;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(336, 2);
            label2.Name = "label2";
            label2.Size = new Size(297, 41);
            label2.TabIndex = 0;
            label2.Text = "Thống Kê Bán Hàng";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(tableLayoutPanel2);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 457);
            panel6.Name = "panel6";
            panel6.Size = new Size(919, 37);
            panel6.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(label8, 0, 0);
            tableLayoutPanel2.Controls.Add(label9, 1, 0);
            tableLayoutPanel2.Controls.Add(label10, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Right;
            tableLayoutPanel2.Location = new Point(584, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(335, 37);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(105, 37);
            label8.TabIndex = 0;
            label8.Text = "Tổng Tiền";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(114, 0);
            label9.Name = "label9";
            label9.Size = new Size(105, 37);
            label9.TabIndex = 1;
            label9.Text = "Tổng";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(225, 0);
            label10.Name = "label10";
            label10.Size = new Size(107, 37);
            label10.TabIndex = 2;
            label10.Text = "Tổng";
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 537);
            Controls.Add(ReportPanel);
            Name = "ReportForm";
            Text = "OrderForm";
            ReportPanel.ResumeLayout(false);
            Content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Filter.ResumeLayout(false);
            Order.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            roundedPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            roundedPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            Header.ResumeLayout(false);
            Header.PerformLayout();
            panel6.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel ReportPanel;
        private Panel Header;
        private Label label2;
        private Panel Content;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn product;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Sale;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Profits;
        private Panel Filter;
        private Panel Order;
        private Panel panel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Label label3;
        private Panel panel3;
        private Label label4;
        private Panel panel4;
        private Label label5;
        private Controls.RoundedPanel roundedPanel1;
        private DateTimePicker dateTimePicker1;
        private Controls.RoundedPanel roundedPanel2;
        private DateTimePicker dateTimePicker2;
        private Controls.RoundedComboBox roundedComboBox1;
        private Panel panel5;
        private Controls.RoundedComboBox roundedComboBox2;
        private Label label6;
        private Controls.RoundedComboBox roundedComboBox4;
        private Panel panel7;
        private Controls.RoundedComboBox roundedComboBox3;
        private Label label7;
        private Controls.RoundedButton roundedButton1;
        private Panel panel6;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}