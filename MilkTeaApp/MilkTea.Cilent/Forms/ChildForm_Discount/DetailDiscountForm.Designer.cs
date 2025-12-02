namespace MilkTea.Client.Forms.ChildForm_Discount
{
    partial class DetailDiscountForm
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
            panel3 = new Panel();
            panel7 = new Panel();
            dGV_sp_KM_CT = new DataGridView();
            maSP_ct = new DataGridViewTextBoxColumn();
            tenSanPham_ct = new DataGridViewTextBoxColumn();
            loai_ct = new DataGridViewTextBoxColumn();
            panel6 = new Panel();
            label4 = new Label();
            panel5 = new Panel();
            panel9 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            panel8 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_sp_KM_CT).BeginInit();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 79);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 371);
            panel3.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(dGV_sp_KM_CT);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 138);
            panel7.Name = "panel7";
            panel7.Size = new Size(800, 233);
            panel7.TabIndex = 3;
            // 
            // dGV_sp_KM_CT
            // 
            dGV_sp_KM_CT.AllowUserToAddRows = false;
            dGV_sp_KM_CT.AllowUserToDeleteRows = false;
            dGV_sp_KM_CT.AllowUserToResizeColumns = false;
            dGV_sp_KM_CT.AllowUserToResizeRows = false;
            dGV_sp_KM_CT.BackgroundColor = SystemColors.ButtonFace;
            dGV_sp_KM_CT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_sp_KM_CT.Columns.AddRange(new DataGridViewColumn[] { maSP_ct, tenSanPham_ct, loai_ct });
            dGV_sp_KM_CT.Dock = DockStyle.Fill;
            dGV_sp_KM_CT.Location = new Point(0, 0);
            dGV_sp_KM_CT.Name = "dGV_sp_KM_CT";
            dGV_sp_KM_CT.Size = new Size(800, 233);
            dGV_sp_KM_CT.TabIndex = 2;
            // 
            // maSP_ct
            // 
            maSP_ct.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            maSP_ct.HeaderText = "Mã sản phẩm";
            maSP_ct.Name = "maSP_ct";
            maSP_ct.Width = 104;
            // 
            // tenSanPham_ct
            // 
            tenSanPham_ct.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenSanPham_ct.HeaderText = "Tên sản phẩm";
            tenSanPham_ct.Name = "tenSanPham_ct";
            // 
            // loai_ct
            // 
            loai_ct.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            loai_ct.HeaderText = "Loại sản phẩm";
            loai_ct.Name = "loai_ct";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Control;
            panel6.Controls.Add(label7);
            panel6.Controls.Add(label4);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 92);
            panel6.Name = "panel6";
            panel6.Size = new Size(800, 46);
            panel6.TabIndex = 2;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(155, 46);
            label4.TabIndex = 0;
            label4.Text = "Ngày kết thúc:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(panel9);
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 46);
            panel5.Name = "panel5";
            panel5.Size = new Size(800, 46);
            panel5.TabIndex = 1;
            // 
            // panel9
            // 
            panel9.Controls.Add(label6);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(155, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(645, 46);
            panel9.TabIndex = 2;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 46);
            label3.TabIndex = 0;
            label3.Text = "Ngày bắt đầu:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(800, 46);
            panel4.TabIndex = 4;
            // 
            // panel8
            // 
            panel8.Controls.Add(label5);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(155, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(645, 46);
            panel8.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(155, 46);
            label2.TabIndex = 0;
            label2.Text = "Giảm giá:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 79);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Control;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 79);
            label1.TabIndex = 0;
            label1.Text = "Chương trình 8/8";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(155, 46);
            label5.TabIndex = 1;
            label5.Text = "30%";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(155, 46);
            label6.TabIndex = 2;
            label6.Text = "1/11/2025";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(155, 0);
            label7.Name = "label7";
            label7.Size = new Size(155, 46);
            label7.TabIndex = 2;
            label7.Text = "31/12/2025";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DetailDiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "DetailDiscountForm";
            Text = "DetailDiscountForm";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_sp_KM_CT).EndInit();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label label1;
        private Panel panel5;
        private Panel panel6;
        private Label label4;
        private Label label3;
        private Panel panel7;
        private DataGridView dGV_sp_KM_CT;
        private DataGridViewTextBoxColumn maSP_ct;
        private DataGridViewTextBoxColumn tenSanPham_ct;
        private DataGridViewTextBoxColumn loai_ct;
        private Panel panel4;
        private Label label2;
        private Panel panel9;
        private Panel panel8;
        private Label label6;
        private Label label5;
        private Label label7;
    }
}