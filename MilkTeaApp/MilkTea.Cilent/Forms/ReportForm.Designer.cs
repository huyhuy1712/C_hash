
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
            tableLayoutPanel2 = new TableLayoutPanel();
            txtLoiNhuan = new Label();
            txtDoanhThu = new Label();
            txtChiPhi = new Label();
            dataGridView1 = new DataGridView();
            thoiGian = new DataGridViewTextBoxColumn();
            sanPham = new DataGridViewTextBoxColumn();
            size1 = new DataGridViewTextBoxColumn();
            soLuong = new DataGridViewTextBoxColumn();
            chiPhi = new DataGridViewTextBoxColumn();
            doanhThu = new DataGridViewTextBoxColumn();
            loiNhuan = new DataGridViewTextBoxColumn();
            Filter = new Panel();
            Order = new Panel();
            panel1 = new Panel();
            cbbLoc = new MilkTea.Client.Controls.RoundedComboBox();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            cbbLoai = new MilkTea.Client.Controls.RoundedComboBox();
            label5 = new Label();
            panel2 = new Panel();
            dateFrom = new DateTimePicker();
            label3 = new Label();
            panel3 = new Panel();
            dateTo = new DateTimePicker();
            label4 = new Label();
            panel5 = new Panel();
            cbbSP = new MilkTea.Client.Controls.RoundedComboBox();
            label6 = new Label();
            panel7 = new Panel();
            cbbSize = new MilkTea.Client.Controls.RoundedComboBox();
            label7 = new Label();
            btnLayDuLieu = new MilkTea.Client.Controls.RoundedButton();
            Header = new Panel();
            label2 = new Label();
            ReportPanel.SuspendLayout();
            Content.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Filter.SuspendLayout();
            Order.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            Header.SuspendLayout();
            SuspendLayout();
            // 
            // ReportPanel
            // 
            ReportPanel.Controls.Add(Content);
            ReportPanel.Controls.Add(Header);
            ReportPanel.Dock = DockStyle.Fill;
            ReportPanel.Location = new Point(0, 0);
            ReportPanel.Margin = new Padding(3, 2, 3, 2);
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(948, 557);
            ReportPanel.TabIndex = 0;
            ReportPanel.Paint += ReportPanel_Paint;
            // 
            // Content
            // 
            Content.Controls.Add(tableLayoutPanel2);
            Content.Controls.Add(dataGridView1);
            Content.Controls.Add(Filter);
            Content.Dock = DockStyle.Fill;
            Content.Location = new Point(0, 65);
            Content.Name = "Content";
            Content.Size = new Size(948, 492);
            Content.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.Controls.Add(txtLoiNhuan, 7, 0);
            tableLayoutPanel2.Controls.Add(txtDoanhThu, 6, 0);
            tableLayoutPanel2.Controls.Add(txtChiPhi, 5, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 454);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel2.Size = new Size(948, 38);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // txtLoiNhuan
            // 
            txtLoiNhuan.AutoSize = true;
            txtLoiNhuan.Dock = DockStyle.Fill;
            txtLoiNhuan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLoiNhuan.Location = new Point(829, 0);
            txtLoiNhuan.Name = "txtLoiNhuan";
            txtLoiNhuan.Size = new Size(116, 38);
            txtLoiNhuan.TabIndex = 7;
            txtLoiNhuan.Text = "Tổng";
            txtLoiNhuan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDoanhThu
            // 
            txtDoanhThu.AutoSize = true;
            txtDoanhThu.Dock = DockStyle.Fill;
            txtDoanhThu.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDoanhThu.Location = new Point(711, 0);
            txtDoanhThu.Name = "txtDoanhThu";
            txtDoanhThu.Size = new Size(112, 38);
            txtDoanhThu.TabIndex = 6;
            txtDoanhThu.Text = "Tổng";
            txtDoanhThu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtChiPhi
            // 
            txtChiPhi.AutoSize = true;
            txtChiPhi.Dock = DockStyle.Fill;
            txtChiPhi.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChiPhi.Location = new Point(593, 0);
            txtChiPhi.Name = "txtChiPhi";
            txtChiPhi.Size = new Size(112, 38);
            txtChiPhi.TabIndex = 0;
            txtChiPhi.Text = "Tổng";
            txtChiPhi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { thoiGian, sanPham, size1, soLuong, chiPhi, doanhThu, loiNhuan });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 142);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(948, 350);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // thoiGian
            // 
            thoiGian.HeaderText = "Thời gian";
            thoiGian.MinimumWidth = 6;
            thoiGian.Name = "thoiGian";
            thoiGian.ReadOnly = true;
            // 
            // sanPham
            // 
            sanPham.HeaderText = "Sản phẩm";
            sanPham.MinimumWidth = 6;
            sanPham.Name = "sanPham";
            sanPham.ReadOnly = true;
            // 
            // size1
            // 
            size1.HeaderText = "Size";
            size1.MinimumWidth = 6;
            size1.Name = "size1";
            size1.ReadOnly = true;
            // 
            // soLuong
            // 
            soLuong.HeaderText = "Số lượng";
            soLuong.MinimumWidth = 6;
            soLuong.Name = "soLuong";
            soLuong.ReadOnly = true;
            // 
            // chiPhi
            // 
            chiPhi.HeaderText = "Chi phí";
            chiPhi.MinimumWidth = 6;
            chiPhi.Name = "chiPhi";
            chiPhi.ReadOnly = true;
            // 
            // doanhThu
            // 
            doanhThu.HeaderText = "Doanh thu";
            doanhThu.MinimumWidth = 6;
            doanhThu.Name = "doanhThu";
            doanhThu.ReadOnly = true;
            // 
            // loiNhuan
            // 
            loiNhuan.HeaderText = "Lợi nhuận";
            loiNhuan.MinimumWidth = 6;
            loiNhuan.Name = "loiNhuan";
            loiNhuan.ReadOnly = true;
            // 
            // Filter
            // 
            Filter.Controls.Add(Order);
            Filter.Controls.Add(tableLayoutPanel1);
            Filter.Dock = DockStyle.Top;
            Filter.Location = new Point(0, 0);
            Filter.Name = "Filter";
            Filter.Size = new Size(948, 142);
            Filter.TabIndex = 0;
            // 
            // Order
            // 
            Order.Controls.Add(panel1);
            Order.Dock = DockStyle.Fill;
            Order.Location = new Point(0, 82);
            Order.Name = "Order";
            Order.Padding = new Padding(5);
            Order.Size = new Size(948, 60);
            Order.TabIndex = 1;
            Order.Paint += Order_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbbLoc);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(665, 5);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 11, 0, 0);
            panel1.Size = new Size(278, 50);
            panel1.TabIndex = 1;
            // 
            // cbbLoc
            // 
            cbbLoc.BackColor = Color.White;
            cbbLoc.BorderColor = Color.Gray;
            cbbLoc.BorderRadius = 15;
            cbbLoc.BorderSize = 1;
            cbbLoc.Dock = DockStyle.Fill;
            cbbLoc.DrawMode = DrawMode.OwnerDrawFixed;
            cbbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLoc.FlatStyle = FlatStyle.Flat;
            cbbLoc.FocusBorderColor = Color.DeepSkyBlue;
            cbbLoc.Font = new Font("Segoe UI", 10F);
            cbbLoc.FormattingEnabled = true;
            cbbLoc.ItemHeight = 30;
            cbbLoc.Items.AddRange(new object[] { "Doanh thu cao đến thấp", "Doanh thu thấp đến cao", "Số lượng cao đến thấp", "Số lượng thấp đến cao" });
            cbbLoc.Location = new Point(51, 11);
            cbbLoc.Name = "cbbLoc";
            cbbLoc.Size = new Size(227, 36);
            cbbLoc.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(0, 11);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 8);
            label1.Size = new Size(51, 39);
            label1.TabIndex = 0;
            label1.Text = "Lọc";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            tableLayoutPanel1.Controls.Add(btnLayDuLieu, 5, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(6, 5, 6, 5);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(948, 82);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel4
            // 
            panel4.Controls.Add(cbbLoai);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(324, 10);
            panel4.Margin = new Padding(6, 5, 6, 5);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(9, 15, 9, 8);
            panel4.Size = new Size(144, 62);
            panel4.TabIndex = 7;
            // 
            // cbbLoai
            // 
            cbbLoai.BackColor = Color.White;
            cbbLoai.BorderColor = Color.Gray;
            cbbLoai.BorderRadius = 15;
            cbbLoai.BorderSize = 1;
            cbbLoai.DisplayMember = "A";
            cbbLoai.Dock = DockStyle.Fill;
            cbbLoai.DrawMode = DrawMode.OwnerDrawFixed;
            cbbLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLoai.FlatStyle = FlatStyle.Flat;
            cbbLoai.FocusBorderColor = Color.DeepSkyBlue;
            cbbLoai.Font = new Font("Segoe UI", 10F);
            cbbLoai.FormattingEnabled = true;
            cbbLoai.ItemHeight = 30;
            cbbLoai.Items.AddRange(new object[] { "A", "B", "C" });
            cbbLoai.Location = new Point(51, 15);
            cbbLoai.Margin = new Padding(3, 7, 3, 3);
            cbbLoai.Name = "cbbLoai";
            cbbLoai.Size = new Size(84, 36);
            cbbLoai.TabIndex = 1;
            cbbLoai.SelectedIndexChanged += cbbLoai_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(9, 15);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 5, 0, 0);
            label5.Size = new Size(42, 26);
            label5.TabIndex = 0;
            label5.Text = "Loại";
            label5.Click += label5_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(dateFrom);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(9, 8);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(9, 15, 9, 8);
            panel2.Size = new Size(150, 66);
            panel2.TabIndex = 5;
            // 
            // dateFrom
            // 
            dateFrom.CalendarForeColor = Color.Black;
            dateFrom.CalendarMonthBackground = Color.Transparent;
            dateFrom.CalendarTitleBackColor = Color.Transparent;
            dateFrom.CalendarTitleForeColor = Color.Transparent;
            dateFrom.CalendarTrailingForeColor = Color.Transparent;
            dateFrom.CustomFormat = "dd/MM/yyyy";
            dateFrom.Dock = DockStyle.Fill;
            dateFrom.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateFrom.Format = DateTimePickerFormat.Custom;
            dateFrom.Location = new Point(39, 15);
            dateFrom.Margin = new Padding(3, 8, 3, 3);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(102, 36);
            dateFrom.TabIndex = 0;
            dateFrom.ValueChanged += dateFrom_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(9, 15);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 6, 0, 0);
            label3.Size = new Size(30, 27);
            label3.TabIndex = 0;
            label3.Text = "Từ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(dateTo);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(165, 8);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(9, 15, 9, 8);
            panel3.Size = new Size(150, 66);
            panel3.TabIndex = 6;
            // 
            // dateTo
            // 
            dateTo.CustomFormat = "dd/MM/yyyy";
            dateTo.Dock = DockStyle.Fill;
            dateTo.Font = new Font("Segoe UI", 16F);
            dateTo.Format = DateTimePickerFormat.Custom;
            dateTo.Location = new Point(50, 15);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(91, 36);
            dateTo.TabIndex = 0;
            dateTo.ValueChanged += dateTo_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(9, 15);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 6, 0, 0);
            label4.Size = new Size(41, 27);
            label4.TabIndex = 0;
            label4.Text = "Đến";
            label4.Click += label4_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(cbbSP);
            panel5.Controls.Add(label6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(477, 8);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(9, 16, 9, 8);
            panel5.Size = new Size(150, 66);
            panel5.TabIndex = 8;
            // 
            // cbbSP
            // 
            cbbSP.BackColor = Color.White;
            cbbSP.BorderColor = Color.Gray;
            cbbSP.BorderRadius = 15;
            cbbSP.BorderSize = 1;
            cbbSP.Dock = DockStyle.Fill;
            cbbSP.DrawMode = DrawMode.OwnerDrawFixed;
            cbbSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSP.FlatStyle = FlatStyle.Flat;
            cbbSP.FocusBorderColor = Color.DeepSkyBlue;
            cbbSP.Font = new Font("Segoe UI", 10F);
            cbbSP.FormattingEnabled = true;
            cbbSP.ItemHeight = 30;
            cbbSP.Location = new Point(87, 16);
            cbbSP.Name = "cbbSP";
            cbbSP.Size = new Size(54, 36);
            cbbSP.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(9, 16);
            label6.Name = "label6";
            label6.Padding = new Padding(0, 7, 0, 0);
            label6.Size = new Size(78, 27);
            label6.TabIndex = 0;
            label6.Text = "Sản phẩm";
            // 
            // panel7
            // 
            panel7.Controls.Add(cbbSize);
            panel7.Controls.Add(label7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(633, 8);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(9, 15, 9, 8);
            panel7.Size = new Size(150, 66);
            panel7.TabIndex = 9;
            // 
            // cbbSize
            // 
            cbbSize.BackColor = Color.White;
            cbbSize.BorderColor = Color.Gray;
            cbbSize.BorderRadius = 15;
            cbbSize.BorderSize = 1;
            cbbSize.Dock = DockStyle.Fill;
            cbbSize.DrawMode = DrawMode.OwnerDrawFixed;
            cbbSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSize.FlatStyle = FlatStyle.Flat;
            cbbSize.FocusBorderColor = Color.DeepSkyBlue;
            cbbSize.Font = new Font("Segoe UI", 10F);
            cbbSize.FormattingEnabled = true;
            cbbSize.ItemHeight = 30;
            cbbSize.Location = new Point(50, 15);
            cbbSize.Name = "cbbSize";
            cbbSize.Size = new Size(91, 36);
            cbbSize.TabIndex = 1;
            cbbSize.SelectedIndexChanged += cbbSize_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(9, 15);
            label7.Name = "label7";
            label7.Padding = new Padding(0, 6, 0, 0);
            label7.Size = new Size(41, 27);
            label7.TabIndex = 0;
            label7.Text = "Size";
            // 
            // btnLayDuLieu
            // 
            btnLayDuLieu.BackColor = Color.SteelBlue;
            btnLayDuLieu.BorderColor = Color.DodgerBlue;
            btnLayDuLieu.BorderRadius = 20;
            btnLayDuLieu.BorderSize = 0;
            btnLayDuLieu.Dock = DockStyle.Fill;
            btnLayDuLieu.FlatAppearance.BorderSize = 0;
            btnLayDuLieu.FlatStyle = FlatStyle.Flat;
            btnLayDuLieu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLayDuLieu.ForeColor = Color.White;
            btnLayDuLieu.Location = new Point(795, 13);
            btnLayDuLieu.Margin = new Padding(9, 8, 9, 8);
            btnLayDuLieu.Name = "btnLayDuLieu";
            btnLayDuLieu.Size = new Size(138, 56);
            btnLayDuLieu.TabIndex = 10;
            btnLayDuLieu.Text = "Lấy dữ liệu";
            btnLayDuLieu.UseVisualStyleBackColor = false;
            btnLayDuLieu.Click += btnLayDuLieu_Click;
            // 
            // Header
            // 
            Header.Controls.Add(label2);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(948, 65);
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
            label2.Location = new Point(351, 14);
            label2.Name = "label2";
            label2.Size = new Size(241, 32);
            label2.TabIndex = 0;
            label2.Text = "Thống Kê Bán Hàng";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 557);
            Controls.Add(ReportPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ReportForm";
            Text = "OrderForm";
            Load += ReportForm_Load;
            ReportPanel.ResumeLayout(false);
            Content.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Filter.ResumeLayout(false);
            Order.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            Header.ResumeLayout(false);
            Header.PerformLayout();
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
        private DateTimePicker dateFrom;
        private DateTimePicker dateTo;
        private Controls.RoundedComboBox cbbLoai;
        private Panel panel5;
        private Controls.RoundedComboBox cbbSP;
        private Label label6;
        private Controls.RoundedComboBox cbbLoc;
        private Panel panel7;
        private Label label7;
        private Controls.RoundedButton btnLayDuLieu;
        private TableLayoutPanel tableLayoutPanel2;
        private Label txtChiPhi;
        private Label txtLoiNhuan;
        private Label txtDoanhThu;
        private Controls.RoundedComboBox cbbSize;
        private DataGridViewTextBoxColumn thoiGian;
        private DataGridViewTextBoxColumn sanPham;
        private DataGridViewTextBoxColumn size1;
        private DataGridViewTextBoxColumn soLuong;
        private DataGridViewTextBoxColumn chiPhi;
        private DataGridViewTextBoxColumn doanhThu;
        private DataGridViewTextBoxColumn loiNhuan;
    }
}