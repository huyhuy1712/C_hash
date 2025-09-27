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
            dataGridView1 = new DataGridView();
            maPhieuNhap_Tb_Ct = new DataGridViewTextBoxColumn();
            soLuong_Tb_Ct = new DataGridViewTextBoxColumn();
            tenNL_Tb_Ct = new DataGridViewTextBoxColumn();
            donGia_Tb_Ct = new DataGridViewTextBoxColumn();
            tongTien_Tb_Ct = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            panel1.Size = new Size(1660, 527);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 80);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(20);
            panel5.Size = new Size(1660, 447);
            panel5.TabIndex = 3;
            panel5.TabStop = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { maPhieuNhap_Tb_Ct, soLuong_Tb_Ct, tenNL_Tb_Ct, donGia_Tb_Ct, tongTien_Tb_Ct });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(20, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1620, 407);
            dataGridView1.TabIndex = 0;
            // 
            // maPhieuNhap_Tb_Ct
            // 
            maPhieuNhap_Tb_Ct.HeaderText = "Mã Phiếu Nhập";
            maPhieuNhap_Tb_Ct.Name = "maPhieuNhap_Tb_Ct";
            maPhieuNhap_Tb_Ct.Width = 300;
            // 
            // soLuong_Tb_Ct
            // 
            soLuong_Tb_Ct.HeaderText = "Số lượng";
            soLuong_Tb_Ct.Name = "soLuong_Tb_Ct";
            // 
            // tenNL_Tb_Ct
            // 
            tenNL_Tb_Ct.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenNL_Tb_Ct.HeaderText = "Tên nguyên liệu";
            tenNL_Tb_Ct.Name = "tenNL_Tb_Ct";
            // 
            // donGia_Tb_Ct
            // 
            donGia_Tb_Ct.HeaderText = "Đơn giá";
            donGia_Tb_Ct.Name = "donGia_Tb_Ct";
            donGia_Tb_Ct.Width = 200;
            // 
            // tongTien_Tb_Ct
            // 
            tongTien_Tb_Ct.HeaderText = "Tổng Tiền";
            tongTien_Tb_Ct.Name = "tongTien_Tb_Ct";
            tongTien_Tb_Ct.Width = 200;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1660, 80);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(699, 18);
            label1.Name = "label1";
            label1.Size = new Size(387, 45);
            label1.TabIndex = 1;
            label1.Text = "Chi Tiết Phiếu Nhập Kho";
            // 
            // ImportForm_Info
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1660, 527);
            Controls.Add(panel1);
            Name = "ImportForm_Info";
            Text = "ImportForm_Info";
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel5;
        private DataGridView dataGridView1;
        private Panel panel2;
        private DataGridViewTextBoxColumn maPhieuNhap_Tb_Ct;
        private DataGridViewTextBoxColumn soLuong_Tb_Ct;
        private DataGridViewTextBoxColumn tenNL_Tb_Ct;
        private DataGridViewTextBoxColumn donGia_Tb_Ct;
        private DataGridViewTextBoxColumn tongTien_Tb_Ct;
        private Label label1;
    }
}