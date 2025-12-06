namespace MilkTea.Client.Forms.ChildForm_Report
{
    partial class InvoiceReport
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
            dataGridView1 = new DataGridView();
            Tgian = new DataGridViewTextBoxColumn();
            MaDH = new DataGridViewTextBoxColumn();
            MaSize = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            ChiPhi = new DataGridViewTextBoxColumn();
            DoanhThu = new DataGridViewTextBoxColumn();
            LoiNhuan = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Tgian, MaDH, MaSize, SoLuong, ChiPhi, DoanhThu, LoiNhuan });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 450);
            dataGridView1.TabIndex = 0;
            // 
            // Tgian
            // 
            Tgian.FillWeight = 150F;
            Tgian.HeaderText = "Thời gian";
            Tgian.MinimumWidth = 6;
            Tgian.Name = "Tgian";
            Tgian.ReadOnly = true;
            // 
            // MaDH
            // 
            MaDH.HeaderText = "Mã đơn hàng";
            MaDH.MinimumWidth = 6;
            MaDH.Name = "MaDH";
            MaDH.ReadOnly = true;
            // 
            // MaSize
            // 
            MaSize.HeaderText = "Size";
            MaSize.MinimumWidth = 6;
            MaSize.Name = "MaSize";
            MaSize.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // ChiPhi
            // 
            ChiPhi.HeaderText = "Chi phí";
            ChiPhi.MinimumWidth = 6;
            ChiPhi.Name = "ChiPhi";
            ChiPhi.ReadOnly = true;
            // 
            // DoanhThu
            // 
            DoanhThu.HeaderText = "Doanh thu";
            DoanhThu.MinimumWidth = 6;
            DoanhThu.Name = "DoanhThu";
            DoanhThu.ReadOnly = true;
            // 
            // LoiNhuan
            // 
            LoiNhuan.HeaderText = "Lợi nhuận";
            LoiNhuan.MinimumWidth = 6;
            LoiNhuan.Name = "LoiNhuan";
            LoiNhuan.ReadOnly = true;
            // 
            // InvoiceReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "InvoiceReport";
            Text = "InvoiceReport";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Tgian;
        private DataGridViewTextBoxColumn MaDH;
        private DataGridViewTextBoxColumn MaSize;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn ChiPhi;
        private DataGridViewTextBoxColumn DoanhThu;
        private DataGridViewTextBoxColumn LoiNhuan;
    }
}