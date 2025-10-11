
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
            khuyenMai = new DataGridViewTextBoxColumn();
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
            roundedPanel1 = new MilkTea.Client.Controls.RoundedPanel();
            dateFrom = new DateTimePicker();
            label3 = new Label();
            panel3 = new Panel();
            roundedPanel2 = new MilkTea.Client.Controls.RoundedPanel();
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
            roundedPanel1.SuspendLayout();
            panel3.SuspendLayout();
            roundedPanel2.SuspendLayout();
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
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(1083, 743);
            ReportPanel.TabIndex = 0;
            ReportPanel.Paint += ReportPanel_Paint;
            // 
            // Content
            // 
            Content.Controls.Add(tableLayoutPanel2);
            Content.Controls.Add(dataGridView1);
            Content.Controls.Add(Filter);
            Content.Dock = DockStyle.Fill;
            Content.Location = new Point(0, 57);
            Content.Margin = new Padding(3, 4, 3, 4);
            Content.Name = "Content";
            Content.Size = new Size(1083, 686);
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
            tableLayoutPanel2.Location = new Point(0, 635);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel2.Size = new Size(1083, 51);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // txtLoiNhuan
            // 
            txtLoiNhuan.AutoSize = true;
            txtLoiNhuan.Dock = DockStyle.Fill;
            txtLoiNhuan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLoiNhuan.Location = new Point(948, 0);
            txtLoiNhuan.Name = "txtLoiNhuan";
            txtLoiNhuan.Size = new Size(132, 51);
            txtLoiNhuan.TabIndex = 7;
            txtLoiNhuan.Text = "Tổng";
            txtLoiNhuan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDoanhThu
            // 
            txtDoanhThu.AutoSize = true;
            txtDoanhThu.Dock = DockStyle.Fill;
            txtDoanhThu.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDoanhThu.Location = new Point(813, 0);
            txtDoanhThu.Name = "txtDoanhThu";
            txtDoanhThu.Size = new Size(129, 51);
            txtDoanhThu.TabIndex = 6;
            txtDoanhThu.Text = "Tổng";
            txtDoanhThu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtChiPhi
            // 
            txtChiPhi.AutoSize = true;
            txtChiPhi.Dock = DockStyle.Fill;
            txtChiPhi.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChiPhi.Location = new Point(678, 0);
            txtChiPhi.Name = "txtChiPhi";
            txtChiPhi.Size = new Size(129, 51);
            txtChiPhi.TabIndex = 0;
            txtChiPhi.Text = "Tổng";
            txtChiPhi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { thoiGian, sanPham, size1, soLuong, khuyenMai, chiPhi, doanhThu, loiNhuan });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 127);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1083, 559);
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
            // khuyenMai
            // 
            khuyenMai.HeaderText = "% Khuyến mãi";
            khuyenMai.MinimumWidth = 6;
            khuyenMai.Name = "khuyenMai";
            khuyenMai.ReadOnly = true;
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
            Filter.Margin = new Padding(3, 4, 3, 4);
            Filter.Name = "Filter";
            Filter.Size = new Size(1083, 127);
            Filter.TabIndex = 0;
            // 
            // Order
            // 
            Order.Controls.Add(panel1);
            Order.Dock = DockStyle.Fill;
            Order.Location = new Point(0, 63);
            Order.Margin = new Padding(3, 4, 3, 4);
            Order.Name = "Order";
            Order.Padding = new Padding(6, 7, 6, 7);
            Order.Size = new Size(1083, 64);
            Order.TabIndex = 1;
            Order.Paint += Order_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbbLoc);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(757, 7);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(320, 50);
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
            cbbLoc.Location = new Point(58, 0);
            cbbLoc.Margin = new Padding(3, 4, 3, 4);
            cbbLoc.Name = "cbbLoc";
            cbbLoc.Size = new Size(262, 36);
            cbbLoc.TabIndex = 1;
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
            tableLayoutPanel1.Controls.Add(btnLayDuLieu, 5, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(7);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1083, 63);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel4
            // 
            panel4.Controls.Add(cbbLoai);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(366, 11);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(172, 41);
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
            cbbLoai.Location = new Point(51, 0);
            cbbLoai.Margin = new Padding(3, 4, 3, 4);
            cbbLoai.Name = "cbbLoai";
            cbbLoai.Size = new Size(121, 36);
            cbbLoai.TabIndex = 1;
            cbbLoai.SelectedIndexChanged += cbbLoai_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 8, 0, 0);
            label5.Size = new Size(51, 36);
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
            panel2.Location = new Point(10, 11);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(172, 41);
            panel2.TabIndex = 5;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.White;
            roundedPanel1.BorderColor = Color.White;
            roundedPanel1.BorderRadius = 20;
            roundedPanel1.BorderSize = 0;
            roundedPanel1.Controls.Add(dateFrom);
            roundedPanel1.Dock = DockStyle.Fill;
            roundedPanel1.ForeColor = Color.Black;
            roundedPanel1.Location = new Point(37, 0);
            roundedPanel1.Margin = new Padding(3, 4, 3, 4);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(135, 41);
            roundedPanel1.TabIndex = 1;
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
            dateFrom.Location = new Point(0, 0);
            dateFrom.Margin = new Padding(3, 4, 3, 4);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(135, 43);
            dateFrom.TabIndex = 0;
            dateFrom.ValueChanged += dateFrom_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 8, 0, 0);
            label3.Size = new Size(37, 36);
            label3.TabIndex = 0;
            label3.Text = "Từ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(roundedPanel2);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(188, 11);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(172, 41);
            panel3.TabIndex = 6;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.White;
            roundedPanel2.BorderColor = Color.DodgerBlue;
            roundedPanel2.BorderRadius = 20;
            roundedPanel2.BorderSize = 0;
            roundedPanel2.Controls.Add(dateTo);
            roundedPanel2.Dock = DockStyle.Fill;
            roundedPanel2.ForeColor = Color.Black;
            roundedPanel2.Location = new Point(50, 0);
            roundedPanel2.Margin = new Padding(3, 4, 3, 4);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(122, 41);
            roundedPanel2.TabIndex = 1;
            // 
            // dateTo
            // 
            dateTo.CustomFormat = "dd/MM/yyyy";
            dateTo.Dock = DockStyle.Fill;
            dateTo.Font = new Font("Segoe UI", 16F);
            dateTo.Format = DateTimePickerFormat.Custom;
            dateTo.Location = new Point(0, 0);
            dateTo.Margin = new Padding(3, 4, 3, 4);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(122, 43);
            dateTo.TabIndex = 0;
            dateTo.ValueChanged += dateTo_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 8, 0, 0);
            label4.Size = new Size(50, 36);
            label4.TabIndex = 0;
            label4.Text = "Đến";
            label4.Click += label4_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(cbbSP);
            panel5.Controls.Add(label6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(544, 11);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(172, 41);
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
            cbbSP.Location = new Point(100, 0);
            cbbSP.Margin = new Padding(3, 4, 3, 4);
            cbbSP.Name = "cbbSP";
            cbbSP.Size = new Size(72, 36);
            cbbSP.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(0, 8, 0, 0);
            label6.Size = new Size(100, 33);
            label6.TabIndex = 0;
            label6.Text = "Sản phẩm";
            // 
            // panel7
            // 
            panel7.Controls.Add(cbbSize);
            panel7.Controls.Add(label7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(722, 11);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(172, 41);
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
            cbbSize.Location = new Point(50, 0);
            cbbSize.Margin = new Padding(3, 4, 3, 4);
            cbbSize.Name = "cbbSize";
            cbbSize.Size = new Size(122, 36);
            cbbSize.TabIndex = 1;
            cbbSize.SelectedIndexChanged += cbbSize_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Padding = new Padding(0, 8, 0, 0);
            label7.Size = new Size(50, 36);
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
            btnLayDuLieu.Location = new Point(900, 11);
            btnLayDuLieu.Margin = new Padding(3, 4, 3, 4);
            btnLayDuLieu.Name = "btnLayDuLieu";
            btnLayDuLieu.Size = new Size(173, 41);
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
            Header.Margin = new Padding(3, 4, 3, 4);
            Header.Name = "Header";
            Header.Size = new Size(1083, 57);
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
            label2.Location = new Point(401, 3);
            label2.Name = "label2";
            label2.Size = new Size(297, 41);
            label2.TabIndex = 0;
            label2.Text = "Thống Kê Bán Hàng";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 743);
            Controls.Add(ReportPanel);
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
        private Controls.RoundedPanel roundedPanel1;
        private DateTimePicker dateFrom;
        private Controls.RoundedPanel roundedPanel2;
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
        private DataGridViewTextBoxColumn thoiGian;
        private DataGridViewTextBoxColumn sanPham;
        private DataGridViewTextBoxColumn size1;
        private DataGridViewTextBoxColumn soLuong;
        private DataGridViewTextBoxColumn khuyenMai;
        private DataGridViewTextBoxColumn chiPhi;
        private DataGridViewTextBoxColumn doanhThu;
        private DataGridViewTextBoxColumn loiNhuan;
        private Controls.RoundedComboBox cbbSize;
    }
}