using MilkTea.Client.Controls;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            panel8 = new Panel();
            dateEnd = new DateTimePicker();
            label5 = new Label();
            panel7 = new Panel();
            dateStart = new DateTimePicker();
            label4 = new Label();
            panel10 = new Panel();
            roundedButton1 = new RoundedButton();
            panel6 = new Panel();
            roundedComboBox2 = new RoundedComboBox();
            panel5 = new Panel();
            label3 = new Label();
            panel1 = new Panel();
            roundedTextBox2 = new RoundedTextBox();
            label2 = new Label();
            DiscountPanel = new Panel();
            dGV_discounts = new DataGridView();
            tenKM_col = new DataGridViewTextBoxColumn();
            moTa_col = new DataGridViewTextBoxColumn();
            phanTram_col = new DataGridViewTextBoxColumn();
            ngayBatDau_col = new DataGridViewTextBoxColumn();
            ngayKetThuc_col = new DataGridViewTextBoxColumn();
            trangThai_col = new DataGridViewTextBoxColumn();
            chiTiet = new DataGridViewImageColumn();
            sua = new DataGridViewImageColumn();
            xoa = new DataGridViewImageColumn();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel10.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            DiscountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_discounts).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1897, 80);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1897, 80);
            label1.TabIndex = 0;
            label1.Text = "Khuyến mãi";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel10);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 80);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(1897, 51);
            panel3.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.Controls.Add(dateEnd);
            panel8.Controls.Add(label5);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(800, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(291, 30);
            panel8.TabIndex = 5;
            // 
            // dateEnd
            // 
            dateEnd.CalendarForeColor = Color.Black;
            dateEnd.CalendarMonthBackground = Color.Transparent;
            dateEnd.CalendarTitleBackColor = Color.Transparent;
            dateEnd.CalendarTitleForeColor = Color.Transparent;
            dateEnd.CalendarTrailingForeColor = Color.Transparent;
            dateEnd.CustomFormat = "dd/MM/yyyy";
            dateEnd.Dock = DockStyle.Fill;
            dateEnd.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateEnd.Location = new Point(163, 0);
            dateEnd.Margin = new Padding(3, 8, 3, 3);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(128, 36);
            dateEnd.TabIndex = 2;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(163, 30);
            label5.TabIndex = 1;
            label5.Text = "Ngày kết thúc";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel7
            // 
            panel7.Controls.Add(dateStart);
            panel7.Controls.Add(label4);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(509, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(291, 30);
            panel7.TabIndex = 4;
            // 
            // dateStart
            // 
            dateStart.CalendarForeColor = Color.Black;
            dateStart.CalendarMonthBackground = Color.Transparent;
            dateStart.CalendarTitleBackColor = Color.Transparent;
            dateStart.CalendarTitleForeColor = Color.Transparent;
            dateStart.CalendarTrailingForeColor = Color.Transparent;
            dateStart.CustomFormat = "dd/MM/yyyy";
            dateStart.Dock = DockStyle.Fill;
            dateStart.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateStart.Format = DateTimePickerFormat.Custom;
            dateStart.Location = new Point(163, 0);
            dateStart.Margin = new Padding(3, 8, 3, 3);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(128, 36);
            dateStart.TabIndex = 2;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(163, 30);
            label4.TabIndex = 1;
            label4.Text = "Ngày bắt đầu ";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel10
            // 
            panel10.Controls.Add(roundedButton1);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(1735, 5);
            panel10.Margin = new Padding(3, 4, 3, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(157, 41);
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
            roundedButton1.Margin = new Padding(3, 4, 3, 4);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(159, 41);
            roundedButton1.TabIndex = 1;
            roundedButton1.Text = "Thêm";
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(roundedComboBox2);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(420, 5);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(162, 41);
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
            roundedComboBox2.Margin = new Padding(3, 4, 3, 4);
            roundedComboBox2.Name = "roundedComboBox2";
            roundedComboBox2.Size = new Size(162, 36);
            roundedComboBox2.TabIndex = 1;
            roundedComboBox2.SelectedIndexChanged += roundedComboBox2_SelectedIndexChanged;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(234, 5);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(186, 41);
            panel5.TabIndex = 1;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(186, 41);
            label3.TabIndex = 0;
            label3.Text = "Trạng thái";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedTextBox2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(5, 5);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 41);
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
            roundedTextBox2.Margin = new Padding(3, 4, 3, 4);
            roundedTextBox2.Name = "roundedTextBox2";
            roundedTextBox2.Padding = new Padding(11, 7, 46, 7);
            roundedTextBox2.Placeholder = "Nhập mã hoặc tên khuyến mãi...";
            roundedTextBox2.Size = new Size(229, 41);
            roundedTextBox2.TabIndex = 2;
            roundedTextBox2.TextValue = "";
            roundedTextBox2.TextChanged += roundedTextBox2_TextChanged;
            roundedTextBox2.KeyDown += roundedTextBox2_KeyDown;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 131);
            panel4.Name = "panel4";
            panel4.Size = new Size(1897, 51);
            panel4.TabIndex = 4;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1897, 51);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Khuyến Mãi";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DiscountPanel
            // 
            DiscountPanel.Controls.Add(dGV_discounts);
            DiscountPanel.Controls.Add(panel4);
            DiscountPanel.Controls.Add(panel3);
            DiscountPanel.Controls.Add(panel2);
            DiscountPanel.Dock = DockStyle.Fill;
            DiscountPanel.Location = new Point(0, 0);
            DiscountPanel.Name = "DiscountPanel";
            DiscountPanel.Size = new Size(1897, 703);
            DiscountPanel.TabIndex = 0;
            // 
            // dGV_discounts
            // 
            dGV_discounts.AllowUserToAddRows = false;
            dGV_discounts.AllowUserToDeleteRows = false;
            dGV_discounts.BackgroundColor = SystemColors.ButtonFace;
            dGV_discounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_discounts.Columns.AddRange(new DataGridViewColumn[] { tenKM_col, moTa_col, phanTram_col, ngayBatDau_col, ngayKetThuc_col, trangThai_col, chiTiet, sua, xoa });
            dGV_discounts.Dock = DockStyle.Fill;
            dGV_discounts.Location = new Point(0, 182);
            dGV_discounts.Margin = new Padding(3, 4, 3, 4);
            dGV_discounts.Name = "dGV_discounts";
            dGV_discounts.RowHeadersWidth = 51;
            dGV_discounts.Size = new Size(1897, 521);
            dGV_discounts.TabIndex = 5;
            dGV_discounts.CellContentClick += dGV_discounts_CellContentClick;
            // 
            // tenKM_col
            // 
            tenKM_col.HeaderText = "Tên KM";
            tenKM_col.MinimumWidth = 6;
            tenKM_col.Name = "tenKM_col";
            tenKM_col.Width = 150;
            // 
            // moTa_col
            // 
            moTa_col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            moTa_col.HeaderText = "Mô tả";
            moTa_col.MinimumWidth = 6;
            moTa_col.Name = "moTa_col";
            // 
            // phanTram_col
            // 
            phanTram_col.HeaderText = "Phần trăm (%)";
            phanTram_col.MinimumWidth = 6;
            phanTram_col.Name = "phanTram_col";
            phanTram_col.Width = 120;
            // 
            // ngayBatDau_col
            // 
            ngayBatDau_col.HeaderText = "Ngày bắt đầu";
            ngayBatDau_col.MinimumWidth = 6;
            ngayBatDau_col.Name = "ngayBatDau_col";
            ngayBatDau_col.Width = 120;
            // 
            // ngayKetThuc_col
            // 
            ngayKetThuc_col.HeaderText = "Ngày kết thúc";
            ngayKetThuc_col.MinimumWidth = 6;
            ngayKetThuc_col.Name = "ngayKetThuc_col";
            ngayKetThuc_col.Width = 120;
            // 
            // trangThai_col
            // 
            trangThai_col.HeaderText = "Trạng thái";
            trangThai_col.MinimumWidth = 6;
            trangThai_col.Name = "trangThai_col";
            trangThai_col.Width = 125;
            // 
            // chiTiet
            // 
            chiTiet.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.Padding = new Padding(3);
            chiTiet.DefaultCellStyle = dataGridViewCellStyle1;
            chiTiet.HeaderText = "Chi Tiết";
            chiTiet.Image = Properties.Resources.info;
            chiTiet.ImageLayout = DataGridViewImageCellLayout.Zoom;
            chiTiet.MinimumWidth = 6;
            chiTiet.Name = "chiTiet";
            chiTiet.ReadOnly = true;
            chiTiet.Resizable = DataGridViewTriState.False;
            chiTiet.Width = 75;
            // 
            // sua
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new Padding(3);
            sua.DefaultCellStyle = dataGridViewCellStyle2;
            sua.HeaderText = "Sửa";
            sua.Image = Properties.Resources.edit;
            sua.ImageLayout = DataGridViewImageCellLayout.Zoom;
            sua.MinimumWidth = 6;
            sua.Name = "sua";
            sua.ReadOnly = true;
            sua.Resizable = DataGridViewTriState.False;
            sua.Width = 75;
            // 
            // xoa
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.Padding = new Padding(3);
            xoa.DefaultCellStyle = dataGridViewCellStyle3;
            xoa.HeaderText = "Xóa";
            xoa.Image = Properties.Resources.trash;
            xoa.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoa.MinimumWidth = 6;
            xoa.Name = "xoa";
            xoa.ReadOnly = true;
            xoa.Resizable = DataGridViewTriState.False;
            xoa.Width = 75;
            // 
            // DiscountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1897, 703);
            Controls.Add(DiscountPanel);
            Name = "DiscountForm";
            Text = "DiscountForm";
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            DiscountPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_discounts).EndInit();
            ResumeLayout(false);

            //Bật tắt các nút theo quyền
            //btnThemAccount.Enabled = false;
        }

        #endregion

        private Panel DiscountPanel;
        private Label label1;
        private Controls.RoundedButton btnThemAccount;
        private Label label2;
        private DataGridView dGV_discounts;
        private DataGridViewTextBoxColumn tenKM_col;
        private DataGridViewTextBoxColumn moTa_col;
        private DataGridViewTextBoxColumn phanTram_col;
        private DataGridViewTextBoxColumn ngayBatDau_col;
        private DataGridViewTextBoxColumn ngayKetThuc_col;
        private DataGridViewTextBoxColumn trangThai_col;
        private DataGridViewImageColumn chiTiet;
        private DataGridViewImageColumn sua;
        private DataGridViewImageColumn xoa;
        private Panel panel6;
        private Panel panel5;
        private Panel panel1;
        private Panel panel10;
        private Label label3;
        private Controls.RoundedTextBox roundedTextBox2;
        private Controls.RoundedComboBox roundedComboBox2;
        private Controls.RoundedButton roundedButton1;
        private Panel panel7;
        private Label label4;
        private Panel panel8;
        private DateTimePicker dateEnd;
        private Label label5;
        private DateTimePicker dateStart;
    }
}