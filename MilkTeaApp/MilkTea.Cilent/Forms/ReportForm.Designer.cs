
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
            TableLayout3 = new TableLayoutPanel();
            txtLoiNhuan = new Label();
            txtDoanhThu = new Label();
            txtChiPhi = new Label();
            label8 = new Label();
            txtSoLuong = new Label();
            dataGridView1 = new DataGridView();
            sanPham = new DataGridViewTextBoxColumn();
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
            TableLayout3.SuspendLayout();
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
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(1083, 743);
            ReportPanel.TabIndex = 0;
            ReportPanel.Paint += ReportPanel_Paint;
            // 
            // Content
            // 
            Content.Controls.Add(TableLayout3);
            Content.Controls.Add(dataGridView1);
            Content.Controls.Add(Filter);
            Content.Dock = DockStyle.Fill;
            Content.Location = new Point(0, 87);
            Content.Margin = new Padding(3, 4, 3, 4);
            Content.Name = "Content";
            Content.Size = new Size(1083, 656);
            Content.TabIndex = 1;
            // 
            // TableLayout3
            // 
            TableLayout3.ColumnCount = 5;
            TableLayout3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9999962F));
            TableLayout3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9999962F));
            TableLayout3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0000019F));
            TableLayout3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0000019F));
            TableLayout3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0000019F));
            TableLayout3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayout3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayout3.Controls.Add(txtLoiNhuan, 4, 0);
            TableLayout3.Controls.Add(txtDoanhThu, 3, 0);
            TableLayout3.Controls.Add(txtChiPhi, 2, 0);
            TableLayout3.Controls.Add(label8, 0, 0);
            TableLayout3.Controls.Add(txtSoLuong, 1, 0);
            TableLayout3.Dock = DockStyle.Bottom;
            TableLayout3.Location = new Point(0, 605);
            TableLayout3.Margin = new Padding(3, 4, 3, 4);
            TableLayout3.Name = "TableLayout3";
            TableLayout3.RowCount = 1;
            TableLayout3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayout3.Size = new Size(1083, 51);
            TableLayout3.TabIndex = 2;
            TableLayout3.Paint += txtSoLuong_Paint;
            // 
            // txtLoiNhuan
            // 
            txtLoiNhuan.AutoSize = true;
            txtLoiNhuan.Dock = DockStyle.Fill;
            txtLoiNhuan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLoiNhuan.Location = new Point(867, 0);
            txtLoiNhuan.Name = "txtLoiNhuan";
            txtLoiNhuan.Size = new Size(213, 51);
            txtLoiNhuan.TabIndex = 7;
            txtLoiNhuan.Text = "Tổng";
            txtLoiNhuan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDoanhThu
            // 
            txtDoanhThu.AutoSize = true;
            txtDoanhThu.Dock = DockStyle.Fill;
            txtDoanhThu.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDoanhThu.Location = new Point(651, 0);
            txtDoanhThu.Name = "txtDoanhThu";
            txtDoanhThu.Size = new Size(210, 51);
            txtDoanhThu.TabIndex = 6;
            txtDoanhThu.Text = "Tổng";
            txtDoanhThu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtChiPhi
            // 
            txtChiPhi.AutoSize = true;
            txtChiPhi.Dock = DockStyle.Fill;
            txtChiPhi.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChiPhi.Location = new Point(435, 0);
            txtChiPhi.Name = "txtChiPhi";
            txtChiPhi.Size = new Size(210, 51);
            txtChiPhi.TabIndex = 0;
            txtChiPhi.Text = "Tổng";
            txtChiPhi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(210, 51);
            label8.TabIndex = 8;
            label8.Text = "Tổng cộng";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            label8.Click += label8_Click;
            // 
            // txtSoLuong
            // 
            txtSoLuong.AutoSize = true;
            txtSoLuong.Dock = DockStyle.Fill;
            txtSoLuong.Font = new Font("Segoe UI", 13.8F);
            txtSoLuong.Location = new Point(219, 0);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(210, 51);
            txtSoLuong.TabIndex = 9;
            txtSoLuong.Text = "Tổng";
            txtSoLuong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sanPham, soLuong, chiPhi, doanhThu, loiNhuan });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 189);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1083, 467);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // sanPham
            // 
            sanPham.HeaderText = "Sản phẩm";
            sanPham.MinimumWidth = 6;
            sanPham.Name = "sanPham";
            sanPham.ReadOnly = true;
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
            Filter.Margin = new Padding(3, 4, 3, 4);
            Filter.Name = "Filter";
            Filter.Size = new Size(1083, 189);
            Filter.TabIndex = 0;
            // 
            // Order
            // 
            Order.Controls.Add(panel1);
            Order.Dock = DockStyle.Fill;
            Order.Location = new Point(0, 109);
            Order.Margin = new Padding(3, 4, 3, 4);
            Order.Name = "Order";
            Order.Padding = new Padding(6, 7, 6, 7);
            Order.Size = new Size(1083, 80);
            Order.TabIndex = 1;
            Order.Paint += Order_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbbLoc);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(759, 7);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 15, 0, 0);
            panel1.Size = new Size(318, 66);
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
            cbbLoc.Items.AddRange(new object[] { "Tất cả", "Doanh thu cao đến thấp", "Doanh thu thấp đến cao", "Số lượng cao đến thấp", "Số lượng thấp đến cao" });
            cbbLoc.Location = new Point(58, 15);
            cbbLoc.Margin = new Padding(3, 4, 3, 4);
            cbbLoc.Name = "cbbLoc";
            cbbLoc.Size = new Size(260, 36);
            cbbLoc.TabIndex = 1;
            cbbLoc.SelectedIndexChanged += cbbLoc_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(0, 15);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 11);
            label1.Size = new Size(58, 51);
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
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(7);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1083, 109);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel4
            // 
            panel4.Controls.Add(cbbLoai);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(370, 14);
            panel4.Margin = new Padding(7);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10, 20, 10, 11);
            panel4.Size = new Size(164, 81);
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
            cbbLoai.Location = new Point(61, 20);
            cbbLoai.Margin = new Padding(3, 9, 3, 4);
            cbbLoai.Name = "cbbLoai";
            cbbLoai.Size = new Size(93, 36);
            cbbLoai.TabIndex = 1;
            cbbLoai.SelectedIndexChanged += cbbLoai_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(10, 20);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 7, 0, 0);
            label5.Size = new Size(51, 35);
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
            panel2.Location = new Point(10, 11);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10, 20, 10, 11);
            panel2.Size = new Size(172, 87);
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
            dateFrom.Location = new Point(47, 20);
            dateFrom.Margin = new Padding(3, 11, 3, 4);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(115, 43);
            dateFrom.TabIndex = 0;
            dateFrom.ValueChanged += dateFrom_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(10, 20);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 8, 0, 0);
            label3.Size = new Size(37, 36);
            label3.TabIndex = 0;
            label3.Text = "Từ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(dateTo);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(188, 11);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10, 20, 10, 11);
            panel3.Size = new Size(172, 87);
            panel3.TabIndex = 6;
            // 
            // dateTo
            // 
            dateTo.CustomFormat = "dd/MM/yyyy";
            dateTo.Dock = DockStyle.Fill;
            dateTo.Font = new Font("Segoe UI", 16F);
            dateTo.Format = DateTimePickerFormat.Custom;
            dateTo.Location = new Point(60, 20);
            dateTo.Margin = new Padding(3, 4, 3, 4);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(102, 43);
            dateTo.TabIndex = 0;
            dateTo.ValueChanged += dateTo_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(10, 20);
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
            panel5.Padding = new Padding(10, 21, 10, 11);
            panel5.Size = new Size(172, 87);
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
            cbbSP.Location = new Point(45, 21);
            cbbSP.Margin = new Padding(3, 4, 3, 4);
            cbbSP.Name = "cbbSP";
            cbbSP.Size = new Size(117, 36);
            cbbSP.TabIndex = 1;
            cbbSP.SelectedIndexChanged += cbbSP_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(10, 21);
            label6.Name = "label6";
            label6.Padding = new Padding(0, 9, 0, 0);
            label6.Size = new Size(35, 34);
            label6.TabIndex = 0;
            label6.Text = "SP";
            // 
            // panel7
            // 
            panel7.Controls.Add(cbbSize);
            panel7.Controls.Add(label7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(722, 11);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10, 20, 10, 11);
            panel7.Size = new Size(172, 87);
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
            cbbSize.Location = new Point(60, 20);
            cbbSize.Margin = new Padding(3, 4, 3, 4);
            cbbSize.Name = "cbbSize";
            cbbSize.Size = new Size(102, 36);
            cbbSize.TabIndex = 1;
            cbbSize.SelectedIndexChanged += cbbSize_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(10, 20);
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
            btnLayDuLieu.FlatAppearance.BorderSize = 0;
            btnLayDuLieu.FlatStyle = FlatStyle.Flat;
            btnLayDuLieu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLayDuLieu.ForeColor = Color.White;
            btnLayDuLieu.Location = new Point(907, 18);
            btnLayDuLieu.Margin = new Padding(10, 11, 10, 11);
            btnLayDuLieu.Name = "btnLayDuLieu";
            btnLayDuLieu.Size = new Size(158, 53);
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
            Header.Size = new Size(1083, 87);
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
            label2.Location = new Point(401, 19);
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
            TableLayout3.ResumeLayout(false);
            TableLayout3.PerformLayout();
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
        private TableLayoutPanel TableLayout3;
        private Label txtChiPhi;
        private Label txtLoiNhuan;
        private Label txtDoanhThu;
        private Controls.RoundedComboBox cbbSize;
        private Label label8;
        private DataGridViewTextBoxColumn sanPham;
        private DataGridViewTextBoxColumn soLuong;
        private DataGridViewTextBoxColumn chiPhi;
        private DataGridViewTextBoxColumn doanhThu;
        private DataGridViewTextBoxColumn loiNhuan;
        private Label txtSoLuong;
    }
}