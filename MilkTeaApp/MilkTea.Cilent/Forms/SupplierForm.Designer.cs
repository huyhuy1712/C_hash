namespace MilkTea.Client.Forms
{
    partial class SupplierForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel5 = new Panel();
            lblStatus_PN = new Label();
            dGV_nhacungcap = new DataGridView();
            ma_Tb_NCC = new DataGridViewTextBoxColumn();
            ten_Tb_NCC = new DataGridViewTextBoxColumn();
            sdt_Tb_NCC = new DataGridViewTextBoxColumn();
            diachi_Tb_NCC = new DataGridViewTextBoxColumn();
            sua_Tb_NCC = new DataGridViewImageColumn();
            xoa_Tb_NCC = new DataGridViewImageColumn();
            panel4 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            txt_Timkiem_NCC = new TextBox();
            panel8 = new Panel();
            cbo_timkiemtheo_NCC = new MilkTea.Client.Controls.RoundedComboBox();
            panel6 = new Panel();
            btn_Them_NCC = new MilkTea.Client.Controls.RoundedButton();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_nhacungcap).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 5, 3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 937);
            panel1.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(lblStatus_PN);
            panel5.Controls.Add(dGV_nhacungcap);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 224);
            panel5.Margin = new Padding(3, 5, 3, 5);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(26, 36, 26, 36);
            panel5.Size = new Size(1924, 713);
            panel5.TabIndex = 3;
            panel5.TabStop = true;
            // 
            // lblStatus_PN
            // 
            lblStatus_PN.Dock = DockStyle.Top;
            lblStatus_PN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus_PN.Location = new Point(26, 571);
            lblStatus_PN.Name = "lblStatus_PN";
            lblStatus_PN.Size = new Size(1872, 31);
            lblStatus_PN.TabIndex = 1;
            lblStatus_PN.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dGV_nhacungcap
            // 
            dGV_nhacungcap.AllowUserToAddRows = false;
            dGV_nhacungcap.AllowUserToDeleteRows = false;
            dGV_nhacungcap.AllowUserToResizeColumns = false;
            dGV_nhacungcap.AllowUserToResizeRows = false;
            dGV_nhacungcap.BackgroundColor = SystemColors.ButtonFace;
            dGV_nhacungcap.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dGV_nhacungcap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_nhacungcap.Columns.AddRange(new DataGridViewColumn[] { ma_Tb_NCC, ten_Tb_NCC, sdt_Tb_NCC, diachi_Tb_NCC, sua_Tb_NCC, xoa_Tb_NCC });
            dGV_nhacungcap.Dock = DockStyle.Top;
            dGV_nhacungcap.Location = new Point(26, 36);
            dGV_nhacungcap.Margin = new Padding(3, 5, 3, 5);
            dGV_nhacungcap.Name = "dGV_nhacungcap";
            dGV_nhacungcap.RowHeadersVisible = false;
            dGV_nhacungcap.RowHeadersWidth = 51;
            dGV_nhacungcap.Size = new Size(1872, 535);
            dGV_nhacungcap.TabIndex = 0;
            dGV_nhacungcap.CellClick += dGV_nhacungcap_CellClick;
            // 
            // ma_Tb_NCC
            // 
            ma_Tb_NCC.HeaderText = "Mã nhà cung cấp";
            ma_Tb_NCC.MinimumWidth = 6;
            ma_Tb_NCC.Name = "ma_Tb_NCC";
            ma_Tb_NCC.Width = 200;
            // 
            // ten_Tb_NCC
            // 
            ten_Tb_NCC.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ten_Tb_NCC.HeaderText = "Tên nhà cung cấp";
            ten_Tb_NCC.MinimumWidth = 6;
            ten_Tb_NCC.Name = "ten_Tb_NCC";
            // 
            // sdt_Tb_NCC
            // 
            sdt_Tb_NCC.HeaderText = "Số điện thoại";
            sdt_Tb_NCC.MinimumWidth = 6;
            sdt_Tb_NCC.Name = "sdt_Tb_NCC";
            sdt_Tb_NCC.Width = 175;
            // 
            // diachi_Tb_NCC
            // 
            diachi_Tb_NCC.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            diachi_Tb_NCC.HeaderText = "Địa chỉ";
            diachi_Tb_NCC.MinimumWidth = 6;
            diachi_Tb_NCC.Name = "diachi_Tb_NCC";
            // 
            // sua_Tb_NCC
            // 
            sua_Tb_NCC.HeaderText = "Sửa";
            sua_Tb_NCC.Image = Properties.Resources.edit;
            sua_Tb_NCC.MinimumWidth = 6;
            sua_Tb_NCC.Name = "sua_Tb_NCC";
            sua_Tb_NCC.Width = 125;
            // 
            // xoa_Tb_NCC
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.Padding = new Padding(3);
            xoa_Tb_NCC.DefaultCellStyle = dataGridViewCellStyle1;
            xoa_Tb_NCC.HeaderText = "Xóa";
            xoa_Tb_NCC.Image = Properties.Resources.trash;
            xoa_Tb_NCC.MinimumWidth = 6;
            xoa_Tb_NCC.Name = "xoa_Tb_NCC";
            xoa_Tb_NCC.Resizable = DataGridViewTriState.True;
            xoa_Tb_NCC.SortMode = DataGridViewColumnSortMode.Automatic;
            xoa_Tb_NCC.Width = 125;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 148);
            panel4.Margin = new Padding(3, 5, 3, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(1924, 76);
            panel4.TabIndex = 2;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1924, 76);
            label2.TabIndex = 1;
            label2.Text = "Danh Sách Nhà Cung Cấp";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 76);
            panel3.Margin = new Padding(3, 5, 3, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1924, 72);
            panel3.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(txt_Timkiem_NCC);
            panel7.Controls.Add(panel8);
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(1371, 0);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10, 11, 10, 11);
            panel7.Size = new Size(553, 72);
            panel7.TabIndex = 1;
            // 
            // txt_Timkiem_NCC
            // 
            txt_Timkiem_NCC.Dock = DockStyle.Left;
            txt_Timkiem_NCC.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_Timkiem_NCC.Location = new Point(10, 11);
            txt_Timkiem_NCC.Margin = new Padding(3, 4, 3, 4);
            txt_Timkiem_NCC.Name = "txt_Timkiem_NCC";
            txt_Timkiem_NCC.PlaceholderText = "Tìm kiếm...";
            txt_Timkiem_NCC.Size = new Size(313, 47);
            txt_Timkiem_NCC.TabIndex = 3;
            txt_Timkiem_NCC.TextChanged += txt_Timkiem_NCC_TextChanged;
            // 
            // panel8
            // 
            panel8.Controls.Add(cbo_timkiemtheo_NCC);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(370, 11);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(173, 50);
            panel8.TabIndex = 2;
            // 
            // cbo_timkiemtheo_NCC
            // 
            cbo_timkiemtheo_NCC.BackColor = Color.White;
            cbo_timkiemtheo_NCC.BorderColor = Color.Gray;
            cbo_timkiemtheo_NCC.BorderRadius = 15;
            cbo_timkiemtheo_NCC.BorderSize = 1;
            cbo_timkiemtheo_NCC.Dock = DockStyle.Fill;
            cbo_timkiemtheo_NCC.DrawMode = DrawMode.OwnerDrawFixed;
            cbo_timkiemtheo_NCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_timkiemtheo_NCC.FlatStyle = FlatStyle.Flat;
            cbo_timkiemtheo_NCC.FocusBorderColor = Color.DeepSkyBlue;
            cbo_timkiemtheo_NCC.Font = new Font("Segoe UI", 10F);
            cbo_timkiemtheo_NCC.FormattingEnabled = true;
            cbo_timkiemtheo_NCC.ItemHeight = 30;
            cbo_timkiemtheo_NCC.Location = new Point(0, 0);
            cbo_timkiemtheo_NCC.Margin = new Padding(3, 4, 3, 4);
            cbo_timkiemtheo_NCC.Name = "cbo_timkiemtheo_NCC";
            cbo_timkiemtheo_NCC.Size = new Size(173, 36);
            cbo_timkiemtheo_NCC.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(btn_Them_NCC);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(6, 9, 6, 9);
            panel6.Size = new Size(350, 72);
            panel6.TabIndex = 0;
            // 
            // btn_Them_NCC
            // 
            btn_Them_NCC.BackColor = Color.DodgerBlue;
            btn_Them_NCC.BorderColor = Color.DodgerBlue;
            btn_Them_NCC.BorderRadius = 20;
            btn_Them_NCC.BorderSize = 0;
            btn_Them_NCC.Dock = DockStyle.Left;
            btn_Them_NCC.FlatAppearance.BorderSize = 0;
            btn_Them_NCC.FlatStyle = FlatStyle.Flat;
            btn_Them_NCC.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Them_NCC.ForeColor = Color.White;
            btn_Them_NCC.Location = new Point(6, 9);
            btn_Them_NCC.Margin = new Padding(3, 4, 3, 4);
            btn_Them_NCC.Name = "btn_Them_NCC";
            btn_Them_NCC.Size = new Size(159, 54);
            btn_Them_NCC.TabIndex = 0;
            btn_Them_NCC.Text = "Thêm";
            btn_Them_NCC.UseVisualStyleBackColor = false;
            btn_Them_NCC.Click += btn_Them_NCC_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 5, 3, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1924, 76);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1924, 76);
            label1.TabIndex = 0;
            label1.Text = "Nhà Cung Cấp";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 937);
            Controls.Add(panel1);
            Name = "SupplierForm";
            Text = "SupplierForm";
            Load += SupplierForm_Load;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_nhacungcap).EndInit();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel5;
        private Label lblStatus_PN;
        private DataGridView dGV_nhacungcap;
        private Panel panel4;
        private Label label2;
        private Panel panel6;
        private Panel panel7;
        private TextBox txt_Timkiem_NCC;
        private Panel panel8;
        private Controls.RoundedComboBox cbo_timkiemtheo_NCC;
        private Panel panel9;
        private Controls.RoundedButton btn_Them_NCC;
        private Panel panel10;
        private Label label1;
        private Panel panel2;
        private DataGridViewTextBoxColumn ma_Tb_NCC;
        private DataGridViewTextBoxColumn ten_Tb_NCC;
        private DataGridViewTextBoxColumn sdt_Tb_NCC;
        private DataGridViewTextBoxColumn diachi_Tb_NCC;
        private DataGridViewImageColumn sua_Tb_NCC;
        private DataGridViewImageColumn xoa_Tb_NCC;
    }
}