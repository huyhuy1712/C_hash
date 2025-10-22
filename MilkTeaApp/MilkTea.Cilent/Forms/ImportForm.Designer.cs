
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            txt_TimkiemPN_PN = new TextBox();
            panel8 = new Panel();
            panel6 = new Panel();
            panel4 = new Panel();
            label2 = new Label();
            panel5 = new Panel();
            lblStatus_PN = new Label();
            dGV_phieuNhap = new DataGridView();
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
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_phieuNhap).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
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
            label1.Text = "Phiếu Nhập Kho";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            panel7.Controls.Add(txt_TimkiemPN_PN);
            panel7.Controls.Add(panel8);
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(1371, 0);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10, 11, 10, 11);
            panel7.Size = new Size(553, 72);
            panel7.TabIndex = 1;
            // 
            // txt_TimkiemPN_PN
            // 
            txt_TimkiemPN_PN.Dock = DockStyle.Left;
            txt_TimkiemPN_PN.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_TimkiemPN_PN.Location = new Point(10, 11);
            txt_TimkiemPN_PN.Margin = new Padding(3, 4, 3, 4);
            txt_TimkiemPN_PN.Name = "txt_TimkiemPN_PN";
            txt_TimkiemPN_PN.PlaceholderText = "Tìm kiếm...";
            txt_TimkiemPN_PN.Size = new Size(313, 47);
            txt_TimkiemPN_PN.TabIndex = 3;
            txt_TimkiemPN_PN.TextChanged += txt_TimkiemPN_PN_TextChanged;
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(370, 11);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(173, 50);
            panel8.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(6, 9, 6, 9);
            panel6.Size = new Size(350, 72);
            panel6.TabIndex = 0;
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
            label2.Text = "Danh Sách Phiếu Nhập";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(lblStatus_PN);
            panel5.Controls.Add(dGV_phieuNhap);
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
            lblStatus_PN.Dock = DockStyle.Bottom;
            lblStatus_PN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus_PN.Location = new Point(26, 646);
            lblStatus_PN.Name = "lblStatus_PN";
            lblStatus_PN.Size = new Size(1872, 31);
            lblStatus_PN.TabIndex = 1;
            lblStatus_PN.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dGV_phieuNhap
            // 
            dGV_phieuNhap.AllowUserToAddRows = false;
            dGV_phieuNhap.BackgroundColor = SystemColors.ButtonFace;
            dGV_phieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_phieuNhap.Columns.AddRange(new DataGridViewColumn[] { maPhieuNhap_Tb_iPort, ngayNhap_Tb_iPort, soLuong_Tb_iPort, tenNVN_Tb_iPort, tongTien_Tb_iPort, thongTin_Tb_iPort, xoa_Tb_iPort });
            dGV_phieuNhap.Dock = DockStyle.Fill;
            dGV_phieuNhap.Location = new Point(26, 36);
            dGV_phieuNhap.Margin = new Padding(3, 5, 3, 5);
            dGV_phieuNhap.Name = "dGV_phieuNhap";
            dGV_phieuNhap.RowHeadersVisible = false;
            dGV_phieuNhap.RowHeadersWidth = 51;
            dGV_phieuNhap.Size = new Size(1872, 641);
            dGV_phieuNhap.TabIndex = 0;
            dGV_phieuNhap.CellClick += dGV_phieuNhap_CellClick;
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
            dataGridViewCellStyle1.NullValue = null;
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
            dataGridViewCellStyle2.NullValue = null;
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
            panel1.Margin = new Padding(3, 5, 3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 937);
            panel1.TabIndex = 0;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 937);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ImportForm";
            Text = "Import Form";
            Load += ImportForm_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_phieuNhap).EndInit();
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
        private DataGridView dGV_phieuNhap;
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
        private Panel panel6;
        private Controls.RoundedButton roundedButton2;
        private Controls.RoundedButton roundedButton1;
        private Controls.RoundedComboBox cbo_timkiemtheo_PN;
        private Panel panel8;
        private TextBox txt_TimkiemPN_PN;
        private Label lblStatus_PN;
    }
}