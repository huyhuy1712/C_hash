using MilkTea.Client.Forms.ChildForm_Discount;

namespace MilkTea.Client.Forms
{
    partial class DiscountForm
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
            Panel panel2;
            Panel panel3;
            Panel panel4;
            label1 = new Label();
            panel10 = new Panel();
            roundedButton1 = new MilkTea.Client.Controls.RoundedButton();
            panel6 = new Panel();
            roundedComboBox2 = new MilkTea.Client.Controls.RoundedComboBox();
            panel5 = new Panel();
            label3 = new Label();
            panel1 = new Panel();
            roundedTextBox2 = new MilkTea.Client.Controls.RoundedTextBox();
            label2 = new Label();
            DiscountPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel7 = new Panel();
            panel9 = new Panel();
            label5 = new Label();
            panel8 = new Panel();
            product_delete_btn1 = new PictureBox();
            product_edit_btn1 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel10.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            DiscountPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)product_delete_btn1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)product_edit_btn1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1660, 60);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1660, 60);
            label1.TabIndex = 0;
            label1.Text = "Khuyến mãi";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(panel10);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 60);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(4);
            panel3.Size = new Size(1660, 38);
            panel3.TabIndex = 3;
            // 
            // panel10
            // 
            panel10.Controls.Add(roundedButton1);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(1519, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(137, 30);
            panel10.TabIndex = 3;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.DodgerBlue;
            roundedButton1.BorderColor = Color.DodgerBlue;
            roundedButton1.BorderRadius = 20;
            roundedButton1.BorderSize = 0;
            roundedButton1.Dock = DockStyle.Left;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(0, 0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(139, 30);
            roundedButton1.TabIndex = 1;
            roundedButton1.Text = "Thêm";
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(roundedComboBox2);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(367, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(142, 30);
            panel6.TabIndex = 2;
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
            roundedComboBox2.Items.AddRange(new object[] { "Tất cả", "Đang hoạt động", "Hết hạn" });
            roundedComboBox2.Location = new Point(0, 0);
            roundedComboBox2.Name = "roundedComboBox2";
            roundedComboBox2.Size = new Size(142, 36);
            roundedComboBox2.TabIndex = 1;
            roundedComboBox2.SelectedIndexChanged += roundedComboBox2_SelectedIndexChanged;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(204, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(163, 30);
            panel5.TabIndex = 1;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(163, 30);
            label3.TabIndex = 0;
            label3.Text = "Trạng thái";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedTextBox2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 30);
            panel1.TabIndex = 0;
            // 
            // roundedTextBox2
            // 
            roundedTextBox2.BackColor = Color.White;
            roundedTextBox2.BorderColor = Color.Gray;
            roundedTextBox2.BorderRadius = 20;
            roundedTextBox2.Dock = DockStyle.Fill;
            roundedTextBox2.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox2.Location = new Point(0, 0);
            roundedTextBox2.Name = "roundedTextBox2";
            roundedTextBox2.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox2.Placeholder = "Nhập mã hoặc tên khuyến mãi...";
            roundedTextBox2.Size = new Size(200, 30);
            roundedTextBox2.TabIndex = 2;
            roundedTextBox2.TextValue = "";
            roundedTextBox2.TextChanged += roundedTextBox2_TextChanged;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 98);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(1660, 38);
            panel4.TabIndex = 4;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1660, 38);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Khuyến Mãi";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DiscountPanel
            // 
            DiscountPanel.Controls.Add(flowLayoutPanel1);
            DiscountPanel.Controls.Add(panel4);
            DiscountPanel.Controls.Add(panel3);
            DiscountPanel.Controls.Add(panel2);
            DiscountPanel.Dock = DockStyle.Fill;
            DiscountPanel.Location = new Point(0, 0);
            DiscountPanel.Margin = new Padding(3, 2, 3, 2);
            DiscountPanel.Name = "DiscountPanel";
            DiscountPanel.Size = new Size(1660, 527);
            DiscountPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveBorder;
            flowLayoutPanel1.Controls.Add(panel7);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 136);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(1660, 391);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.Location = new Point(23, 23);
            panel7.Name = "panel7";
            panel7.Size = new Size(200, 100);
            panel7.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(label5);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(200, 72);
            panel9.TabIndex = 1;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(200, 72);
            label5.TabIndex = 0;
            label5.Text = "Chương trình 8/8";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.ActiveCaption;
            panel8.Controls.Add(product_delete_btn1);
            panel8.Controls.Add(product_edit_btn1);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 72);
            panel8.Name = "panel8";
            panel8.Size = new Size(200, 28);
            panel8.TabIndex = 0;
            // 
            // product_delete_btn1
            // 
            product_delete_btn1.Cursor = Cursors.Hand;
            product_delete_btn1.Dock = DockStyle.Right;
            product_delete_btn1.Image = Properties.Resources.trash;
            product_delete_btn1.Location = new Point(165, 0);
            product_delete_btn1.Margin = new Padding(3, 2, 3, 2);
            product_delete_btn1.Name = "product_delete_btn1";
            product_delete_btn1.Size = new Size(35, 28);
            product_delete_btn1.SizeMode = PictureBoxSizeMode.Zoom;
            product_delete_btn1.TabIndex = 2;
            product_delete_btn1.TabStop = false;
            // 
            // product_edit_btn1
            // 
            product_edit_btn1.Cursor = Cursors.Hand;
            product_edit_btn1.Dock = DockStyle.Left;
            product_edit_btn1.Image = Properties.Resources.edit;
            product_edit_btn1.Location = new Point(0, 0);
            product_edit_btn1.Margin = new Padding(3, 2, 3, 2);
            product_edit_btn1.Name = "product_edit_btn1";
            product_edit_btn1.Size = new Size(24, 28);
            product_edit_btn1.SizeMode = PictureBoxSizeMode.Zoom;
            product_edit_btn1.TabIndex = 1;
            product_edit_btn1.TabStop = false;
            product_edit_btn1.Click += product_edit_btn1_Click;
            // 
            // DiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1660, 527);
            Controls.Add(DiscountPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DiscountForm";
            Text = "OrderForm";
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            DiscountPanel.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)product_delete_btn1).EndInit();
            ((System.ComponentModel.ISupportInitialize)product_edit_btn1).EndInit();
            ResumeLayout(false);

            //Bật tắt các nút theo quyền
            //btnThemAccount.Enabled = false;
        }




        private void btnThemAccount_Click(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();
            addDiscountForm.ShowDialog();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            DetailDiscountForm detailForm = new DetailDiscountForm(1);
            detailForm.ShowDialog();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnThemDisccount_Click(object sender, EventArgs e)
        {
            // Khởi tạo và hiển thị form AddDiscountForm
            AddDiscountForm addDiscountForm = new AddDiscountForm();
            addDiscountForm.ShowDialog();
        }
       
        #endregion

        private Panel DiscountPanel;
        private Label label1;
        private Controls.RoundedButton btnThemAccount;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel7;
        private Panel panel9;
        private Label label5;
        private Panel panel8;
        private PictureBox product_delete_btn1;
        private PictureBox product_edit_btn1;
        private Controls.RoundedTextBox roundedTextBox1;
        private Controls.RoundedComboBox roundedComboBox1;
        private Panel panel6;
        private Panel panel5;
        private Panel panel1;
        private Panel panel10;
        private Label label3;
        private Controls.RoundedTextBox roundedTextBox2;
        private Controls.RoundedComboBox roundedComboBox2;
        private Controls.RoundedButton roundedButton1;
    }
}