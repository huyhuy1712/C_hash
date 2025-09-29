
namespace MilkTea.Client.Forms
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            roundedTextBox2 = new MilkTea.Client.Controls.RoundedTextBox();
            roundedComboBox2 = new MilkTea.Client.Controls.RoundedComboBox();
            panel6 = new Panel();
            roundedButton2 = new MilkTea.Client.Controls.RoundedButton();
            roundedButton1 = new MilkTea.Client.Controls.RoundedButton();
            roundedComboBox1 = new MilkTea.Client.Controls.RoundedComboBox();
            roundedTextBox1 = new MilkTea.Client.Controls.RoundedTextBox();
            panel4 = new Panel();
            label2 = new Label();
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            maPhieuNhap_Tb_iPort = new DataGridViewTextBoxColumn();
            ngayNhap_Tb_iPort = new DataGridViewTextBoxColumn();
            soLuong_Tb_iPort = new DataGridViewTextBoxColumn();
            tenNVN_Tb_iPort = new DataGridViewTextBoxColumn();
            tongTien_Tb_iPort = new DataGridViewTextBoxColumn();
            thongTin_Tb_iPort = new DataGridViewImageColumn();
            xoa_Tb_iPort = new DataGridViewImageColumn();
            panel1 = new Panel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);

            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1897, 57);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1897, 57);
            label1.TabIndex = 0;
            label1.Text = "Phiếu Nhập Kho";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 57);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1897, 60);
            panel3.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(roundedTextBox2);
            panel7.Controls.Add(roundedComboBox2);
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(1413, 0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(484, 60);
            panel7.TabIndex = 1;
            // 
            // roundedTextBox2
            // 
            roundedTextBox2.BackColor = Color.White;
            roundedTextBox2.BorderColor = Color.Gray;
            roundedTextBox2.BorderRadius = 20;
            roundedTextBox2.Dock = DockStyle.Right;
            roundedTextBox2.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox2.Location = new Point(179, 10);
            roundedTextBox2.Name = "roundedTextBox2";
            roundedTextBox2.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox2.Placeholder = "Từ khóa tìm kiếm...";
            roundedTextBox2.Size = new Size(295, 40);
            roundedTextBox2.TabIndex = 1;
            roundedTextBox2.TextValue = "";
            // 
            // roundedComboBox2
            // 
            roundedComboBox2.BackColor = Color.White;
            roundedComboBox2.BorderColor = Color.Gray;
            roundedComboBox2.BorderRadius = 15;
            roundedComboBox2.BorderSize = 1;
            roundedComboBox2.Dock = DockStyle.Left;
            roundedComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox2.FlatStyle = FlatStyle.Flat;
            roundedComboBox2.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox2.Font = new Font("Segoe UI", 10F);
            roundedComboBox2.FormattingEnabled = true;
            roundedComboBox2.ItemHeight = 30;
            roundedComboBox2.Location = new Point(10, 10);
            roundedComboBox2.Name = "roundedComboBox2";
            roundedComboBox2.Size = new Size(151, 36);
            roundedComboBox2.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(roundedButton2);
            panel6.Controls.Add(roundedButton1);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(10);
            panel6.Size = new Size(306, 60);
            panel6.TabIndex = 0;
            // 
            // roundedButton2
            // 
            roundedButton2.BackColor = Color.DodgerBlue;
            roundedButton2.BorderColor = Color.DodgerBlue;
            roundedButton2.BorderRadius = 20;
            roundedButton2.BorderSize = 0;
            roundedButton2.Dock = DockStyle.Right;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            roundedButton2.ForeColor = Color.White;
            roundedButton2.Location = new Point(155, 10);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(141, 40);
            roundedButton2.TabIndex = 1;
            roundedButton2.Text = "Excel";
            roundedButton2.UseVisualStyleBackColor = false;
            roundedButton2.Click += roundedButton2_Click;
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
            roundedButton1.Location = new Point(10, 10);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(139, 40);
            roundedButton1.TabIndex = 0;
            roundedButton1.Text = "Thêm";
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click_1;
            // 
            // roundedComboBox1
            // 
            roundedComboBox1.BackColor = Color.White;
            roundedComboBox1.BorderColor = Color.Gray;
            roundedComboBox1.BorderRadius = 15;
            roundedComboBox1.BorderSize = 1;
            roundedComboBox1.Dock = DockStyle.Left;
            roundedComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            roundedComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            roundedComboBox1.FlatStyle = FlatStyle.Flat;
            roundedComboBox1.FocusBorderColor = Color.DeepSkyBlue;
            roundedComboBox1.Font = new Font("Segoe UI", 10F);
            roundedComboBox1.FormattingEnabled = true;
            roundedComboBox1.ItemHeight = 30;
            roundedComboBox1.Location = new Point(13, 13);
            roundedComboBox1.Name = "roundedComboBox1";
            roundedComboBox1.Size = new Size(151, 36);
            roundedComboBox1.TabIndex = 1;
            // 
            // roundedTextBox1
            // 
            roundedTextBox1.BackColor = Color.White;
            roundedTextBox1.BorderColor = Color.Gray;
            roundedTextBox1.BorderRadius = 20;
            roundedTextBox1.Dock = DockStyle.Right;
            roundedTextBox1.FocusBorderColor = Color.DeepSkyBlue;
            roundedTextBox1.Location = new Point(179, 13);
            roundedTextBox1.Name = "roundedTextBox1";
            roundedTextBox1.Padding = new Padding(10, 5, 40, 5);
            roundedTextBox1.Placeholder = "Từ khóa tìm kiếm...";
            roundedTextBox1.Size = new Size(300, 35);
            roundedTextBox1.TabIndex = 0;
            roundedTextBox1.TextValue = "";
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 117);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1897, 57);
            panel4.TabIndex = 2;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1897, 57);
            label2.TabIndex = 1;
            label2.Text = "Danh Sách Phiếu Nhập";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 174);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(23, 27, 23, 27);
            panel5.Size = new Size(1897, 529);
            panel5.TabIndex = 3;
            panel5.TabStop = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { maPhieuNhap_Tb_iPort, ngayNhap_Tb_iPort, soLuong_Tb_iPort, tenNVN_Tb_iPort, tongTien_Tb_iPort, thongTin_Tb_iPort, xoa_Tb_iPort });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(23, 27);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1851, 475);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // maPhieuNhap_Tb_iPort
            // 
            maPhieuNhap_Tb_iPort.HeaderText = "Mã Phiếu Nhập";
            maPhieuNhap_Tb_iPort.MinimumWidth = 6;
            maPhieuNhap_Tb_iPort.Name = "maPhieuNhap_Tb_iPort";
            maPhieuNhap_Tb_iPort.Width = 300;
            // 
            // ngayNhap_Tb_iPort
            // 
            ngayNhap_Tb_iPort.HeaderText = "Ngày nhập";
            ngayNhap_Tb_iPort.MinimumWidth = 6;
            ngayNhap_Tb_iPort.Name = "ngayNhap_Tb_iPort";
            ngayNhap_Tb_iPort.Width = 200;
            // 
            // soLuong_Tb_iPort
            // 
            soLuong_Tb_iPort.HeaderText = "Số lượng";
            soLuong_Tb_iPort.MinimumWidth = 6;
            soLuong_Tb_iPort.Name = "soLuong_Tb_iPort";
            soLuong_Tb_iPort.Width = 125;
            // 
            // tenNVN_Tb_iPort
            // 
            tenNVN_Tb_iPort.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenNVN_Tb_iPort.HeaderText = "Tên nhân viên nhập";
            tenNVN_Tb_iPort.MinimumWidth = 6;
            tenNVN_Tb_iPort.Name = "tenNVN_Tb_iPort";
            // 
            // tongTien_Tb_iPort
            // 
            tongTien_Tb_iPort.HeaderText = "Tổng Tiền";
            tongTien_Tb_iPort.MinimumWidth = 6;
            tongTien_Tb_iPort.Name = "tongTien_Tb_iPort";
            tongTien_Tb_iPort.Width = 200;
            // 
            // thongTin_Tb_iPort
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = resources.GetObject("dataGridViewCellStyle1.NullValue");
            dataGridViewCellStyle1.Padding = new Padding(3);
            thongTin_Tb_iPort.DefaultCellStyle = dataGridViewCellStyle1;
            thongTin_Tb_iPort.HeaderText = "Thông tin";
            thongTin_Tb_iPort.Image = Properties.Resources.information;
            thongTin_Tb_iPort.ImageLayout = DataGridViewImageCellLayout.Zoom;
            thongTin_Tb_iPort.MinimumWidth = 6;
            thongTin_Tb_iPort.Name = "thongTin_Tb_iPort";
            thongTin_Tb_iPort.Resizable = DataGridViewTriState.True;
            thongTin_Tb_iPort.SortMode = DataGridViewColumnSortMode.Automatic;
            thongTin_Tb_iPort.Width = 125;
            // 
            // xoa_Tb_iPort
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = resources.GetObject("dataGridViewCellStyle2.NullValue");
            dataGridViewCellStyle2.Padding = new Padding(3);
            xoa_Tb_iPort.DefaultCellStyle = dataGridViewCellStyle2;
            xoa_Tb_iPort.HeaderText = "Xóa";
            xoa_Tb_iPort.Image = Properties.Resources.trash;
            xoa_Tb_iPort.MinimumWidth = 6;
            xoa_Tb_iPort.Name = "xoa_Tb_iPort";
            xoa_Tb_iPort.Resizable = DataGridViewTriState.True;
            xoa_Tb_iPort.SortMode = DataGridViewColumnSortMode.Automatic;
            xoa_Tb_iPort.Width = 125;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1897, 703);
            panel1.TabIndex = 0;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1897, 703);
            Controls.Add(panel1);
            Name = "ImportForm";
            Text = "Import Form";
            Load += ImportForm_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private DataGridView dataGridView1;
        private Panel panel1;
        private DataGridViewTextBoxColumn maPhieuNhap_Tb_iPort;
        private DataGridViewTextBoxColumn ngayNhap_Tb_iPort;
        private DataGridViewTextBoxColumn soLuong_Tb_iPort;
        private DataGridViewTextBoxColumn tenNVN_Tb_iPort;
        private DataGridViewTextBoxColumn tongTien_Tb_iPort;
        private DataGridViewImageColumn thongTin_Tb_iPort;
        private DataGridViewImageColumn xoa_Tb_iPort;
        private Controls.RoundedComboBox roundedComboBox1;
        private Controls.RoundedTextBox roundedTextBox1;
        private Panel panel7;
        private Controls.RoundedTextBox roundedTextBox2;
        private Controls.RoundedComboBox roundedComboBox2;
        private Panel panel6;
        private Controls.RoundedButton roundedButton2;
        private Controls.RoundedButton roundedButton1;
    }
}