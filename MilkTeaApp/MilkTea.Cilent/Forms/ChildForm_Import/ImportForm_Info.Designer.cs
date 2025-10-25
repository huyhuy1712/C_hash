namespace MilkTea.Client.Forms.ChildForm_Import
{
    partial class ImportForm_Info
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
            panel5 = new Panel();
            dGV_chitietphieunhap = new DataGridView();
            maPhieuNhap_tb_info = new DataGridViewTextBoxColumn();
            soLuong_tb_add = new DataGridViewTextBoxColumn();
            tenNL_tb_info = new DataGridViewTextBoxColumn();
            donGia_tb_info = new DataGridViewTextBoxColumn();
            tongTien_tb_info = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_chitietphieunhap).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(962, 527);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(dGV_chitietphieunhap);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 80);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(20);
            panel5.Size = new Size(962, 447);
            panel5.TabIndex = 5;
            panel5.TabStop = true;
            // 
            // dGV_chitietphieunhap
            // 
            dGV_chitietphieunhap.AllowUserToAddRows = false;
            dGV_chitietphieunhap.BackgroundColor = SystemColors.ButtonFace;
            dGV_chitietphieunhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_chitietphieunhap.Columns.AddRange(new DataGridViewColumn[] { maPhieuNhap_tb_info, soLuong_tb_add, tenNL_tb_info, donGia_tb_info, tongTien_tb_info });
            dGV_chitietphieunhap.Dock = DockStyle.Top;
            dGV_chitietphieunhap.Location = new Point(20, 20);
            dGV_chitietphieunhap.Name = "dGV_chitietphieunhap";
            dGV_chitietphieunhap.Size = new Size(922, 404);
            dGV_chitietphieunhap.TabIndex = 0;
            // 
            // maPhieuNhap_tb_info
            // 
            maPhieuNhap_tb_info.HeaderText = "Mã phiếu nhập";
            maPhieuNhap_tb_info.Name = "maPhieuNhap_tb_info";
            maPhieuNhap_tb_info.Width = 150;
            // 
            // soLuong_tb_add
            // 
            soLuong_tb_add.HeaderText = "Số lượng";
            soLuong_tb_add.Name = "soLuong_tb_add";
            soLuong_tb_add.Width = 80;
            // 
            // tenNL_tb_info
            // 
            tenNL_tb_info.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenNL_tb_info.HeaderText = "Tên nguyên liệu";
            tenNL_tb_info.Name = "tenNL_tb_info";
            // 
            // donGia_tb_info
            // 
            donGia_tb_info.HeaderText = "Đơn giá";
            donGia_tb_info.Name = "donGia_tb_info";
            // 
            // tongTien_tb_info
            // 
            tongTien_tb_info.HeaderText = "Tổng Tiền";
            tongTien_tb_info.Name = "tongTien_tb_info";
            tongTien_tb_info.Width = 200;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(962, 80);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(962, 80);
            label1.TabIndex = 1;
            label1.Text = "Chi Tiết Phiếu Nhập Kho";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImportForm_Info
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 527);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportForm_Info";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ImportForm_Info";
            Load += ImportForm_Info_Load_1;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_chitietphieunhap).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel5;
        private DataGridView dGV_chitietphieunhap;
        private DataGridViewTextBoxColumn maPhieuNhap_tb_info;
        private DataGridViewTextBoxColumn soLuong_tb_add;
        private DataGridViewTextBoxColumn tenNL_tb_info;
        private DataGridViewTextBoxColumn donGia_tb_info;
        private DataGridViewTextBoxColumn tongTien_tb_info;
    }
}