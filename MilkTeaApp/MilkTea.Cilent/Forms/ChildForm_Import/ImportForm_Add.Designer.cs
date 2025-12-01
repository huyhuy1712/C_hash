namespace MilkTea.Client.Forms.ChildForm_Import
{
    partial class ImportForm_Add
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
            panel1 = new Panel();
            txt_maPN_PN_ADD = new TextBox();
            label6 = new Label();
            cbo_NhaCungCap_PN_ADD = new ComboBox();
            btn_Them_PN_ADD = new MilkTea.Client.Controls.RoundedButton();
            nb_soLuong_PN_ADD = new NumericUpDown();
            cbo_HangHoa_PN_ADD = new ComboBox();
            txt_iPort_nguoitao = new TextBox();
            dt_iPort_ngaylap = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            panel3 = new Panel();
            btn_Luu_Iport_add = new MilkTea.Client.Controls.RoundedButton();
            btn_Thoat_iPort_add = new MilkTea.Client.Controls.RoundedButton();
            dGV_HangHoa_PN_ADD = new DataGridView();
            maPhieuNhap_tb_add = new DataGridViewTextBoxColumn();
            ngayNhap_tb_add = new DataGridViewTextBoxColumn();
            tenNL_tb_add = new DataGridViewTextBoxColumn();
            soLuong_tb_add = new DataGridViewTextBoxColumn();
            tenNVN_tb_add = new DataGridViewTextBoxColumn();
            tongTien_tb_add = new DataGridViewTextBoxColumn();
            xoa_tb_add = new DataGridViewImageColumn();
            panel5 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nb_soLuong_PN_ADD).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_HangHoa_PN_ADD).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txt_maPN_PN_ADD);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cbo_NhaCungCap_PN_ADD);
            panel1.Controls.Add(btn_Them_PN_ADD);
            panel1.Controls.Add(nb_soLuong_PN_ADD);
            panel1.Controls.Add(cbo_HangHoa_PN_ADD);
            panel1.Controls.Add(txt_iPort_nguoitao);
            panel1.Controls.Add(dt_iPort_ngaylap);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1166, 301);
            panel1.TabIndex = 0;
            // 
            // txt_maPN_PN_ADD
            // 
            txt_maPN_PN_ADD.Enabled = false;
            txt_maPN_PN_ADD.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_maPN_PN_ADD.Location = new Point(266, 19);
            txt_maPN_PN_ADD.Margin = new Padding(3, 4, 3, 4);
            txt_maPN_PN_ADD.Name = "txt_maPN_PN_ADD";
            txt_maPN_PN_ADD.Size = new Size(850, 32);
            txt_maPN_PN_ADD.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(63, 23);
            label6.Name = "label6";
            label6.Size = new Size(145, 25);
            label6.TabIndex = 12;
            label6.Text = "Mã phiếu nhập";
            // 
            // cbo_NhaCungCap_PN_ADD
            // 
            cbo_NhaCungCap_PN_ADD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_NhaCungCap_PN_ADD.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbo_NhaCungCap_PN_ADD.FormattingEnabled = true;
            cbo_NhaCungCap_PN_ADD.Location = new Point(266, 63);
            cbo_NhaCungCap_PN_ADD.Margin = new Padding(3, 4, 3, 4);
            cbo_NhaCungCap_PN_ADD.Name = "cbo_NhaCungCap_PN_ADD";
            cbo_NhaCungCap_PN_ADD.Size = new Size(850, 33);
            cbo_NhaCungCap_PN_ADD.TabIndex = 11;
            // 
            // btn_Them_PN_ADD
            // 
            btn_Them_PN_ADD.BackColor = Color.DodgerBlue;
            btn_Them_PN_ADD.BorderColor = Color.DodgerBlue;
            btn_Them_PN_ADD.BorderRadius = 20;
            btn_Them_PN_ADD.BorderSize = 0;
            btn_Them_PN_ADD.FlatAppearance.BorderSize = 0;
            btn_Them_PN_ADD.FlatStyle = FlatStyle.Flat;
            btn_Them_PN_ADD.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Them_PN_ADD.ForeColor = Color.White;
            btn_Them_PN_ADD.Location = new Point(986, 222);
            btn_Them_PN_ADD.Margin = new Padding(3, 4, 3, 4);
            btn_Them_PN_ADD.Name = "btn_Them_PN_ADD";
            btn_Them_PN_ADD.Size = new Size(130, 42);
            btn_Them_PN_ADD.TabIndex = 9;
            btn_Them_PN_ADD.Text = "Thêm";
            btn_Them_PN_ADD.UseVisualStyleBackColor = false;
            btn_Them_PN_ADD.Click += btn_Them_PN_ADD_Click;
            // 
            // nb_soLuong_PN_ADD
            // 
            nb_soLuong_PN_ADD.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nb_soLuong_PN_ADD.Location = new Point(720, 232);
            nb_soLuong_PN_ADD.Margin = new Padding(3, 4, 3, 4);
            nb_soLuong_PN_ADD.Name = "nb_soLuong_PN_ADD";
            nb_soLuong_PN_ADD.Size = new Size(129, 32);
            nb_soLuong_PN_ADD.TabIndex = 8;
            // 
            // cbo_HangHoa_PN_ADD
            // 
            cbo_HangHoa_PN_ADD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_HangHoa_PN_ADD.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbo_HangHoa_PN_ADD.FormattingEnabled = true;
            cbo_HangHoa_PN_ADD.Location = new Point(266, 231);
            cbo_HangHoa_PN_ADD.Margin = new Padding(3, 4, 3, 4);
            cbo_HangHoa_PN_ADD.Name = "cbo_HangHoa_PN_ADD";
            cbo_HangHoa_PN_ADD.Size = new Size(409, 33);
            cbo_HangHoa_PN_ADD.TabIndex = 7;
            // 
            // txt_iPort_nguoitao
            // 
            txt_iPort_nguoitao.Enabled = false;
            txt_iPort_nguoitao.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_iPort_nguoitao.Location = new Point(266, 175);
            txt_iPort_nguoitao.Margin = new Padding(3, 4, 3, 4);
            txt_iPort_nguoitao.Name = "txt_iPort_nguoitao";
            txt_iPort_nguoitao.Size = new Size(850, 32);
            txt_iPort_nguoitao.TabIndex = 6;
            // 
            // dt_iPort_ngaylap
            // 
            dt_iPort_ngaylap.CustomFormat = "";
            dt_iPort_ngaylap.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dt_iPort_ngaylap.Format = DateTimePickerFormat.Short;
            dt_iPort_ngaylap.Location = new Point(266, 116);
            dt_iPort_ngaylap.Margin = new Padding(3, 4, 3, 4);
            dt_iPort_ngaylap.Name = "dt_iPort_ngaylap";
            dt_iPort_ngaylap.Size = new Size(850, 32);
            dt_iPort_ngaylap.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(63, 235);
            label4.Name = "label4";
            label4.Size = new Size(147, 25);
            label4.TabIndex = 3;
            label4.Text = "Chọn hàng hóa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(63, 123);
            label3.Name = "label3";
            label3.Size = new Size(146, 25);
            label3.TabIndex = 2;
            label3.Text = "Ngày lập phiếu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(63, 179);
            label2.Name = "label2";
            label2.Size = new Size(158, 25);
            label2.TabIndex = 1;
            label2.Text = "Người tạo phiếu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(63, 67);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 0;
            label1.Text = "Nhà cung cấp";
            // 
            // panel2
            // 
            panel2.Controls.Add(label5);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 301);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1166, 107);
            panel2.TabIndex = 1;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DodgerBlue;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(1166, 107);
            label5.TabIndex = 2;
            label5.Text = "Danh Sách Hàng Hóa";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_Luu_Iport_add);
            panel3.Controls.Add(btn_Thoat_iPort_add);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 903);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1166, 80);
            panel3.TabIndex = 5;
            // 
            // btn_Luu_Iport_add
            // 
            btn_Luu_Iport_add.BackColor = Color.DodgerBlue;
            btn_Luu_Iport_add.BorderColor = Color.DodgerBlue;
            btn_Luu_Iport_add.BorderRadius = 20;
            btn_Luu_Iport_add.BorderSize = 0;
            btn_Luu_Iport_add.FlatAppearance.BorderSize = 0;
            btn_Luu_Iport_add.FlatStyle = FlatStyle.Flat;
            btn_Luu_Iport_add.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Luu_Iport_add.ForeColor = Color.White;
            btn_Luu_Iport_add.Location = new Point(877, 16);
            btn_Luu_Iport_add.Margin = new Padding(3, 4, 3, 4);
            btn_Luu_Iport_add.Name = "btn_Luu_Iport_add";
            btn_Luu_Iport_add.Size = new Size(130, 42);
            btn_Luu_Iport_add.TabIndex = 11;
            btn_Luu_Iport_add.Text = "Lưu";
            btn_Luu_Iport_add.UseVisualStyleBackColor = false;
            btn_Luu_Iport_add.Click += btn_Luu_Iport_add_Click;
            // 
            // btn_Thoat_iPort_add
            // 
            btn_Thoat_iPort_add.BackColor = Color.DodgerBlue;
            btn_Thoat_iPort_add.BorderColor = Color.DodgerBlue;
            btn_Thoat_iPort_add.BorderRadius = 20;
            btn_Thoat_iPort_add.BorderSize = 0;
            btn_Thoat_iPort_add.FlatAppearance.BorderSize = 0;
            btn_Thoat_iPort_add.FlatStyle = FlatStyle.Flat;
            btn_Thoat_iPort_add.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Thoat_iPort_add.ForeColor = Color.White;
            btn_Thoat_iPort_add.Location = new Point(1013, 16);
            btn_Thoat_iPort_add.Margin = new Padding(3, 4, 3, 4);
            btn_Thoat_iPort_add.Name = "btn_Thoat_iPort_add";
            btn_Thoat_iPort_add.Size = new Size(130, 42);
            btn_Thoat_iPort_add.TabIndex = 10;
            btn_Thoat_iPort_add.Text = "Thoát";
            btn_Thoat_iPort_add.UseVisualStyleBackColor = false;
            btn_Thoat_iPort_add.Click += btn_Thoat_iPort_add_Click;
            // 
            // dGV_HangHoa_PN_ADD
            // 
            dGV_HangHoa_PN_ADD.AllowUserToAddRows = false;
            dGV_HangHoa_PN_ADD.BackgroundColor = SystemColors.ButtonFace;
            dGV_HangHoa_PN_ADD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_HangHoa_PN_ADD.Columns.AddRange(new DataGridViewColumn[] { maPhieuNhap_tb_add, ngayNhap_tb_add, tenNL_tb_add, soLuong_tb_add, tenNVN_tb_add, tongTien_tb_add, xoa_tb_add });
            dGV_HangHoa_PN_ADD.Dock = DockStyle.Top;
            dGV_HangHoa_PN_ADD.Location = new Point(23, 27);
            dGV_HangHoa_PN_ADD.Margin = new Padding(3, 4, 3, 4);
            dGV_HangHoa_PN_ADD.Name = "dGV_HangHoa_PN_ADD";
            dGV_HangHoa_PN_ADD.RowHeadersWidth = 51;
            dGV_HangHoa_PN_ADD.Size = new Size(1120, 445);
            dGV_HangHoa_PN_ADD.TabIndex = 0;
            dGV_HangHoa_PN_ADD.CellClick += dGV_HangHoa_PN_ADD_CellClick;
            // 
            // maPhieuNhap_tb_add
            // 
            maPhieuNhap_tb_add.HeaderText = "Mã Phiếu Nhập";
            maPhieuNhap_tb_add.MinimumWidth = 6;
            maPhieuNhap_tb_add.Name = "maPhieuNhap_tb_add";
            maPhieuNhap_tb_add.Width = 125;
            // 
            // ngayNhap_tb_add
            // 
            ngayNhap_tb_add.HeaderText = "Ngày nhập";
            ngayNhap_tb_add.MinimumWidth = 6;
            ngayNhap_tb_add.Name = "ngayNhap_tb_add";
            ngayNhap_tb_add.Width = 150;
            // 
            // tenNL_tb_add
            // 
            tenNL_tb_add.HeaderText = "Tên nguyên liệu";
            tenNL_tb_add.MinimumWidth = 6;
            tenNL_tb_add.Name = "tenNL_tb_add";
            tenNL_tb_add.Width = 125;
            // 
            // soLuong_tb_add
            // 
            soLuong_tb_add.HeaderText = "Số lượng";
            soLuong_tb_add.MinimumWidth = 6;
            soLuong_tb_add.Name = "soLuong_tb_add";
            soLuong_tb_add.Width = 80;
            // 
            // tenNVN_tb_add
            // 
            tenNVN_tb_add.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenNVN_tb_add.HeaderText = "Tên NV nhập";
            tenNVN_tb_add.MinimumWidth = 6;
            tenNVN_tb_add.Name = "tenNVN_tb_add";
            // 
            // tongTien_tb_add
            // 
            tongTien_tb_add.HeaderText = "Tổng Tiền";
            tongTien_tb_add.MinimumWidth = 6;
            tongTien_tb_add.Name = "tongTien_tb_add";
            tongTien_tb_add.Width = 200;
            // 
            // xoa_tb_add
            // 
            xoa_tb_add.HeaderText = "Xóa";
            xoa_tb_add.Image = Properties.Resources.icons8_trash_96;
            xoa_tb_add.MinimumWidth = 6;
            xoa_tb_add.Name = "xoa_tb_add";
            xoa_tb_add.Width = 125;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(dGV_HangHoa_PN_ADD);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 408);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(23, 27, 23, 27);
            panel5.Size = new Size(1166, 575);
            panel5.TabIndex = 4;
            panel5.TabStop = true;
            // 
            // ImportForm_Add
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 983);
            Controls.Add(panel3);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportForm_Add";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ImportForm_Add";
            Load += ImportForm_Add_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nb_soLuong_PN_ADD).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_HangHoa_PN_ADD).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox txt_iPort_nguoitao;
        private DateTimePicker dt_iPort_ngaylap;
        private Controls.RoundedButton btn_Them_PN_ADD;
        private NumericUpDown nb_soLuong_PN_ADD;
        private ComboBox cbo_HangHoa_PN_ADD;
        private Panel panel2;
        private Label label5;
        private Panel panel3;
        private Controls.RoundedButton btn_Thoat_iPort_add;
        private Controls.RoundedButton btn_Luu_Iport_add;
        private DataGridView dGV_HangHoa_PN_ADD;
        private Panel panel5;
        private ComboBox cbo_NhaCungCap_PN_ADD;
        private TextBox txt_maPN_PN_ADD;
        private Label label6;
        private DataGridViewTextBoxColumn maPhieuNhap_tb_add;
        private DataGridViewTextBoxColumn ngayNhap_tb_add;
        private DataGridViewTextBoxColumn tenNL_tb_add;
        private DataGridViewTextBoxColumn soLuong_tb_add;
        private DataGridViewTextBoxColumn tenNVN_tb_add;
        private DataGridViewTextBoxColumn tongTien_tb_add;
        private DataGridViewImageColumn xoa_tb_add;
    }
}