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
            invoicePanel = new Panel();
            panel3 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel2 = new Panel();
            roundedComboBox2 = new MilkTea.Client.Controls.RoundedComboBox();
            roundedComboBox1 = new MilkTea.Client.Controls.RoundedComboBox();
            pictureBox1 = new PictureBox();
            textboxTimKiem = new MilkTea.Client.Controls.RoundedTextBox();
            panel1 = new Panel();
            btnFilter = new MilkTea.Client.Controls.RoundedButton();
            dtpToDate = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            invoicePanel.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // invoicePanel
            // 
            invoicePanel.Controls.Add(panel3);
            invoicePanel.Controls.Add(panel2);
            invoicePanel.Controls.Add(panel1);
            invoicePanel.Dock = DockStyle.Fill;
            invoicePanel.Location = new Point(0, 0);
            invoicePanel.Name = "invoicePanel";
            invoicePanel.Size = new Size(934, 588);
            invoicePanel.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(flowLayoutPanel2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 96);
            panel3.Name = "panel3";
            panel3.Size = new Size(934, 492);
            panel3.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.AutoScroll = true;

            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(934, 492);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(934, 492);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(roundedComboBox2);
            panel2.Controls.Add(roundedComboBox1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(textboxTimKiem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 49);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(7);
            panel2.Size = new Size(934, 47);
            panel2.TabIndex = 1;
            // 
            // roundedComboBox2
            // 
            roundedComboBox2.BackColor = Color.White;
            roundedComboBox2.BorderColor = Color.Gray;
            roundedComboBox2.BorderRadius = 15;
            roundedComboBox2.BorderSize = 1;
            roundedComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox2.FlatStyle = FlatStyle.Flat;
            roundedComboBox2.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox2.Font = new Font("Segoe UI", 10F);
            roundedComboBox2.FormattingEnabled = true;
            roundedComboBox2.ItemHeight = 30;
            roundedComboBox2.Location = new Point(414, 4);
            roundedComboBox2.Name = "roundedComboBox2";
            roundedComboBox2.Size = new Size(151, 36);
            roundedComboBox2.TabIndex = 4;
            roundedComboBox2.SelectedIndexChanged += roundedComboBox2_SelectedIndexChanged;
            // 
            // roundedComboBox1
            // 
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
            roundedComboBox1.Location = new Point(254, 4);
            roundedComboBox1.Margin = new Padding(10);
            roundedComboBox1.Name = "roundedComboBox1";
            roundedComboBox1.Size = new Size(147, 36);
            roundedComboBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
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
            // 
            // textboxTimKiem
            // 
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
            textboxTimKiem.KeyDown += textboxTimKiem_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnFilter);
            panel1.Controls.Add(dtpToDate);
            panel1.Controls.Add(dtpFromDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(934, 49);
            panel1.TabIndex = 0;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.SteelBlue;
            btnFilter.BorderColor = Color.DodgerBlue;
            btnFilter.BorderRadius = 20;
            btnFilter.BorderSize = 0;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(487, 6);
            btnFilter.Margin = new Padding(10, 11, 10, 11);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(88, 39);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // dtpToDate
            // 
            dtpToDate.CalendarFont = new Font("Segoe UI", 14F);
            dtpToDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.Font = new Font("Segoe UI", 12F);
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(290, 6);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(151, 34);
            dtpToDate.TabIndex = 6;
            // 
            // dtpFromDate
            // 
            dtpFromDate.CalendarFont = new Font("Segoe UI", 14F);
            dtpFromDate.CustomFormat = "dd/MM/yyyy";
            dtpFromDate.Font = new Font("Segoe UI", 12F);
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Location = new Point(76, 7);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(151, 34);
            dtpFromDate.TabIndex = 5;
            dtpFromDate.Value = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtpFromDate.ValueChanged += dtpFromDate_ValueChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(39, 14);
            label1.Name = "label1";
            label1.Size = new Size(34, 28);
            label1.TabIndex = 12;
            label1.Text = "Từ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(237, 12);
            label2.Name = "label2";
            label2.Size = new Size(47, 28);
            label2.TabIndex = 13;
            label2.Text = "Đến";
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 588);
            Controls.Add(invoicePanel);
            Name = "InvoiceForm";
            Text = "InvoiceForm";
            Load += InvoiceForm_Load;
            invoicePanel.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        #region Variables
        private Panel invoicePanel;
        private Panel panel1;
        private Panel panel2;
        private Controls.RoundedTextBox textboxTimKiem;
        private PictureBox pictureBox1;
        private Controls.RoundedComboBox roundedComboBox1;
        private Panel panel3;
        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Controls.RoundedComboBox roundedComboBox2;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private Controls.RoundedButton btnFilter;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
    }
}
