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
            panel2 = new Panel();
            roundedComboBox1 = new MilkTea.Client.Controls.RoundedComboBox();
            pictureBox1 = new PictureBox();
            textboxTimKiem = new MilkTea.Client.Controls.RoundedTextBox();
            panel1 = new Panel();
            btnDaThanhToan = new Button();
            btnChoThanhToan = new Button();
            invoicePanel.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
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
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 96);
            panel3.Name = "panel3";
            panel3.Size = new Size(934, 492);
            panel3.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(934, 492);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
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
            roundedComboBox1.Location = new Point(272, 6);
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
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDaThanhToan);
            panel1.Controls.Add(btnChoThanhToan);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(934, 49);
            panel1.TabIndex = 0;
            // 
            // btnDaThanhToan
            // 
            btnDaThanhToan.Dock = DockStyle.Left;
            btnDaThanhToan.Location = new Point(180, 5);
            btnDaThanhToan.Margin = new Padding(10);
            btnDaThanhToan.Name = "btnDaThanhToan";
            btnDaThanhToan.Size = new Size(152, 39);
            btnDaThanhToan.TabIndex = 1;
            btnDaThanhToan.Text = "Đã thanh toán (6)";
            btnDaThanhToan.UseVisualStyleBackColor = true;
            // 
            // btnChoThanhToan
            // 
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
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 588);
            Controls.Add(invoicePanel);
            Name = "InvoiceForm";
            Text = "InvoiceForm";
            invoicePanel.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
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
        private Controls.RoundedComboBox roundedComboBox1;
        private Panel panel3;
        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
    }
}
