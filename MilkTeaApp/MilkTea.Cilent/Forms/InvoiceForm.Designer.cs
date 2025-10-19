namespace MilkTea.Client.Forms
{
    partial class InvoiceForm
    {
        private System.ComponentModel.IContainer components = null;

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            // Panels
            invoicePanel = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel10 = new Panel();
            panel11 = new Panel();

            // TableLayoutPanels
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();

            // Buttons
            btnChoThanhToan = new Button();
            btnDaThanhToan = new Button();

            // Labels
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label6 = new Label();
            label7 = new Label();

            // PictureBoxes
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();

            // Controls
            roundedComboBox1 = new Controls.RoundedComboBox();
            textboxTimKiem = new Controls.RoundedTextBox();

            SuspendLayout();

            #region invoicePanel
            invoicePanel.Controls.Add(panel3);
            invoicePanel.Controls.Add(panel2);
            invoicePanel.Controls.Add(panel1);
            invoicePanel.Dock = DockStyle.Fill;
            invoicePanel.Location = new Point(0, 0);
            invoicePanel.Name = "invoicePanel";
            invoicePanel.Size = new Size(934, 588);
            invoicePanel.TabIndex = 0;
            #endregion

            #region panel1 - Header Buttons
            panel1.Controls.Add(btnDaThanhToan);
            panel1.Controls.Add(btnChoThanhToan);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(934, 49);
            panel1.TabIndex = 0;

            btnChoThanhToan.BackColor = SystemColors.MenuHighlight;
            btnChoThanhToan.Dock = DockStyle.Left;
            btnChoThanhToan.ForeColor = SystemColors.ButtonHighlight;
            btnChoThanhToan.Location = new Point(5, 5);
            btnChoThanhToan.Margin = new Padding(10);
            btnChoThanhToan.Name = "btnChoThanhToan";
            btnChoThanhToan.Size = new Size(175, 39);
            btnChoThanhToan.TabIndex = 0;
            btnChoThanhToan.Text = "Chờ thanh toán (5)";
            btnChoThanhToan.UseVisualStyleBackColor = false;

            btnDaThanhToan.Dock = DockStyle.Left;
            btnDaThanhToan.Location = new Point(180, 5);
            btnDaThanhToan.Margin = new Padding(10);
            btnDaThanhToan.Name = "btnDaThanhToan";
            btnDaThanhToan.Size = new Size(152, 39);
            btnDaThanhToan.TabIndex = 1;
            btnDaThanhToan.Text = "Đã thanh toán (6)";
            btnDaThanhToan.UseVisualStyleBackColor = true;
            #endregion

            #region panel2 - Search Area
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(roundedComboBox1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(textboxTimKiem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 49);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(7);
            panel2.Size = new Size(934, 47);
            panel2.TabIndex = 1;

            // roundedComboBox1
            roundedComboBox1.BackColor = Color.White;
            roundedComboBox1.BorderColor = Color.Gray;
            roundedComboBox1.BorderRadius = 15;
            roundedComboBox1.BorderSize = 1;
            roundedComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox1.FlatStyle = FlatStyle.Flat;
            roundedComboBox1.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox1.Font = new Font("Segoe UI", 10F);
            roundedComboBox1.FormattingEnabled = true;
            roundedComboBox1.ItemHeight = 30;
            roundedComboBox1.Location = new Point(272, 6);
            roundedComboBox1.Margin = new Padding(10);
            roundedComboBox1.Name = "roundedComboBox1";
            roundedComboBox1.Size = new Size(147, 36);
            roundedComboBox1.TabIndex = 2;

            // pictureBox1
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.ErrorImage = Properties.Resources.search;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(202, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 24);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;

            // textboxTimKiem
            textboxTimKiem.BackColor = Color.White;
            textboxTimKiem.BorderColor = Color.Gray;
            textboxTimKiem.BorderRadius = 20;
            textboxTimKiem.Dock = DockStyle.Left;
            textboxTimKiem.FocusBorderColor = Color.DeepSkyBlue;
            textboxTimKiem.Location = new Point(7, 7);
            textboxTimKiem.Name = "textboxTimKiem";
            textboxTimKiem.Padding = new Padding(10, 5, 40, 5);
            textboxTimKiem.Placeholder = "Từ khóa tìm kiếm...";
            textboxTimKiem.Size = new Size(234, 33);
            textboxTimKiem.TabIndex = 0;
            textboxTimKiem.TextValue = "";
            #endregion

            #region panel3 - Invoice Items Area
            panel3.AutoScroll = true;
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 96);
            panel3.Name = "panel3";
            panel3.Size = new Size(934, 492);
            panel3.TabIndex = 0;

            // tableLayoutPanel1
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(7);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333F));
            tableLayoutPanel1.Size = new Size(934, 492);
            tableLayoutPanel1.TabIndex = 2;
            #endregion

            #region panel4 - Single Invoice Item
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(tableLayoutPanel2);
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(17, 17);
            panel4.Margin = new Padding(10);
            panel4.Name = "panel4";
            panel4.Size = new Size(210, 139);
            panel4.TabIndex = 0;
            panel4.Visible = false;

            // panel5 - Top Info
            panel5.BackColor = SystemColors.MenuHighlight;
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Top;
            panel5.ForeColor = SystemColors.ButtonHighlight;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(210, 32);
            panel5.TabIndex = 0;

            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 32);
            label1.TabIndex = 0;
            label1.Text = "1";
            label1.TextAlign = ContentAlignment.MiddleCenter;

            label2.Dock = DockStyle.Right;
            label2.Location = new Point(102, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 32);
            label2.TabIndex = 1;
            label2.Text = "12 - 09 - 2025";
            label2.TextAlign = ContentAlignment.MiddleCenter;

            // panel6 - Middle Content
            panel6.Controls.Add(panel10);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 32);
            panel6.Name = "panel6";
            panel6.Size = new Size(210, 69);
            panel6.TabIndex = 1;

            // panel7 - Left label
            panel7.BackColor = SystemColors.ButtonHighlight;
            panel7.Controls.Add(label3);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(48, 69);
            panel7.TabIndex = 2;

            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 69);
            label3.TabIndex = 0;
            label3.Text = "B1";
            label3.TextAlign = ContentAlignment.MiddleCenter;

            // panel10 - Right content
            panel10.BackColor = SystemColors.ButtonHighlight;
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(label7);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(48, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(162, 69);
            panel10.TabIndex = 4;

            // panel11 - Inner content
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(pictureBox7);
            panel11.Controls.Add(label6);
            panel11.Controls.Add(pictureBox8);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 29);
            panel11.Name = "panel11";
            panel11.Size = new Size(162, 40);
            panel11.TabIndex = 1;

            // pictureBox7
            pictureBox7.Dock = DockStyle.Right;
            pictureBox7.Image = Properties.Resources.money;
            pictureBox7.Location = new Point(85, 0);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(75, 38);
            pictureBox7.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox7.TabIndex = 2;
            pictureBox7.TabStop = false;

            // label6
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(32, 0);
            label6.Name = "label6";
            label6.Size = new Size(128, 38);
            label6.TabIndex = 1;
            label6.Text = "5'11";
            label6.TextAlign = ContentAlignment.MiddleLeft;

            // pictureBox8
            pictureBox8.Dock = DockStyle.Left;
            pictureBox8.Image = Properties.Resources.alarm;
            pictureBox8.Location = new Point(0, 0);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(32, 38);
            pictureBox8.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox8.TabIndex = 0;
            pictureBox8.TabStop = false;

            // label7 - Top price
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Dock = DockStyle.Top;
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(162, 29);
            label7.TabIndex = 0;
            label7.Text = "9000";
            label7.TextAlign = ContentAlignment.MiddleCenter;

            // tableLayoutPanel2 - Bottom images
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tableLayoutPanel2.Controls.Add(pictureBox4, 0, 0);
            tableLayoutPanel2.Controls.Add(pictureBox5, 1, 0);
            tableLayoutPanel2.Controls.Add(pictureBox6, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 101);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(210, 38);
            tableLayoutPanel2.TabIndex = 0;

            // pictureBoxes in tableLayoutPanel2
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Image = Properties.Resources.hourglass;
            pictureBox4.Location = new Point(4, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(62, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;

            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Dock = DockStyle.Fill;
            pictureBox5.Image = Properties.Resources.info;
            pictureBox5.Location = new Point(73, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(62, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;

            pictureBox6.Dock = DockStyle.Fill;
            pictureBox6.Image = Properties.Resources.recycle_bin;
            pictureBox6.Location = new Point(142, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(64, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox6.TabIndex = 2;
            pictureBox6.TabStop = false;
            #endregion

            // Form properties
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 588);
            Controls.Add(invoicePanel);
            Name = "InvoiceForm";
            Text = "InvoiceForm";

            ResumeLayout(false);
        }
        #endregion

        #region Variables
        private Panel invoicePanel;
        private Panel panel1;
        private Button btnChoThanhToan;
        private Button btnDaThanhToan;
        private Panel panel2;
        private Controls.RoundedTextBox textboxTimKiem;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Controls.RoundedComboBox roundedComboBox1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel7;
        private Label label1;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Panel panel6;
        private Panel panel10;
        private Panel panel11;
        private PictureBox pictureBox7;
        private Label label6;
        private PictureBox pictureBox8;
        private Label label7;
        #endregion
    }
}
