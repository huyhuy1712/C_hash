
namespace MilkTea.Client.Forms
{
    partial class InvoiceForm
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
            panel9 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            btnXacNhan = new Button();
            btnHuy = new Button();
            panel8 = new Panel();
            txtTongCong = new Label();
            label10 = new Label();
            dataGridView1 = new DataGridView();
            panel5 = new Panel();
            txtNgay = new Label();
            label4 = new Label();
            panel7 = new Panel();
            txtPTTT = new Label();
            label8 = new Label();
            panel6 = new Panel();
            txtTenNV = new Label();
            label6 = new Label();
            panel4 = new Panel();
            txtMaHD = new Label();
            label2 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            tenSP = new DataGridViewTextBoxColumn();
            donGia = new DataGridViewTextBoxColumn();
            tienGiam = new DataGridViewTextBoxColumn();
            soLuong = new DataGridViewTextBoxColumn();
            thanhTien = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel9.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(30, 15, 30, 15);
            panel1.Size = new Size(522, 640);
            panel1.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(label5);
            panel9.Location = new Point(28, 537);
            panel9.Name = "panel9";
            panel9.Size = new Size(466, 25);
            panel9.TabIndex = 6;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(466, 25);
            label5.TabIndex = 0;
            label5.Text = "Xin cảm ơn hẹn gặp lại quý khách";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnXacNhan);
            panel2.Controls.Add(btnHuy);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(30, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(462, 610);
            panel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(152, 499);
            label3.Name = "label3";
            label3.Size = new Size(171, 20);
            label3.TabIndex = 8;
            label3.Text = "---------------------------";
            label3.Click += label3_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = SystemColors.ScrollBar;
            btnXacNhan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXacNhan.Location = new Point(346, 568);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(116, 42);
            btnXacNhan.TabIndex = 7;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = SystemColors.ScrollBar;
            btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHuy.Location = new Point(208, 568);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(128, 42);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += button1_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(txtTongCong);
            panel8.Controls.Add(label10);
            panel8.Location = new Point(1, 435);
            panel8.Name = "panel8";
            panel8.Size = new Size(461, 36);
            panel8.TabIndex = 5;
            // 
            // txtTongCong
            // 
            txtTongCong.Dock = DockStyle.Fill;
            txtTongCong.Location = new Point(121, 0);
            txtTongCong.Name = "txtTongCong";
            txtTongCong.Size = new Size(340, 36);
            txtTongCong.TabIndex = 1;
            txtTongCong.Text = "0đ";
            txtTongCong.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Left;
            label10.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(121, 36);
            label10.TabIndex = 0;
            label10.Text = "Tổng cộng: ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tenSP, donGia, tienGiam, soLuong, thanhTien });
            dataGridView1.Location = new Point(0, 193);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(462, 219);
            dataGridView1.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtNgay);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(1, 79);
            panel5.Name = "panel5";
            panel5.Size = new Size(461, 26);
            panel5.TabIndex = 2;
            // 
            // txtNgay
            // 
            txtNgay.Dock = DockStyle.Fill;
            txtNgay.Location = new Point(207, 0);
            txtNgay.Name = "txtNgay";
            txtNgay.Size = new Size(254, 26);
            txtNgay.TabIndex = 1;
            txtNgay.Text = "dd/MM/yyyy";
            txtNgay.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(207, 26);
            label4.TabIndex = 0;
            label4.Text = "Ngày: ";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            panel7.Controls.Add(txtPTTT);
            panel7.Controls.Add(label8);
            panel7.Location = new Point(3, 152);
            panel7.Name = "panel7";
            panel7.Size = new Size(461, 25);
            panel7.TabIndex = 3;
            // 
            // txtPTTT
            // 
            txtPTTT.Dock = DockStyle.Fill;
            txtPTTT.Font = new Font("Segoe UI", 11F);
            txtPTTT.ImageAlign = ContentAlignment.MiddleLeft;
            txtPTTT.Location = new Point(236, 0);
            txtPTTT.Name = "txtPTTT";
            txtPTTT.Size = new Size(225, 25);
            txtPTTT.TabIndex = 1;
            txtPTTT.Text = "Tiền mặt";
            txtPTTT.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Left;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(236, 25);
            label8.TabIndex = 0;
            label8.Text = "Phương thức thanh toán: ";
            // 
            // panel6
            // 
            panel6.Controls.Add(txtTenNV);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(1, 121);
            panel6.Name = "panel6";
            panel6.Size = new Size(461, 25);
            panel6.TabIndex = 2;
            // 
            // txtTenNV
            // 
            txtTenNV.Dock = DockStyle.Fill;
            txtTenNV.Font = new Font("Segoe UI", 11F);
            txtTenNV.Location = new Point(110, 0);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(351, 25);
            txtTenNV.TabIndex = 1;
            txtTenNV.Text = "AAA";
            txtTenNV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(110, 25);
            label6.TabIndex = 0;
            label6.Text = "Thu ngân: ";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtMaHD);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(1, 47);
            panel4.Name = "panel4";
            panel4.Size = new Size(461, 26);
            panel4.TabIndex = 1;
            // 
            // txtMaHD
            // 
            txtMaHD.Dock = DockStyle.Fill;
            txtMaHD.Location = new Point(232, 0);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.Size = new Size(229, 26);
            txtMaHD.TabIndex = 1;
            txtMaHD.Text = "HD001";
            txtMaHD.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(232, 26);
            label2.TabIndex = 0;
            label2.Text = "Mã DH: ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(1, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(461, 41);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(461, 41);
            label1.TabIndex = 0;
            label1.Text = "HÓA ĐƠN THANH TOÁN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click_1;
            // 
            // tenSP
            // 
            tenSP.HeaderText = "Tên SP";
            tenSP.MinimumWidth = 6;
            tenSP.Name = "tenSP";
            tenSP.ReadOnly = true;
            tenSP.Width = 92;
            // 
            // donGia
            // 
            donGia.HeaderText = "Đơn giá";
            donGia.MinimumWidth = 6;
            donGia.Name = "donGia";
            donGia.ReadOnly = true;
            donGia.Width = 92;
            // 
            // tienGiam
            // 
            tienGiam.HeaderText = "Tiền giảm";
            tienGiam.MinimumWidth = 6;
            tienGiam.Name = "tienGiam";
            tienGiam.ReadOnly = true;
            tienGiam.Width = 92;
            // 
            // soLuong
            // 
            soLuong.HeaderText = "Số lượng";
            soLuong.MinimumWidth = 6;
            soLuong.Name = "soLuong";
            soLuong.ReadOnly = true;
            soLuong.Width = 91;
            // 
            // thanhTien
            // 
            thanhTien.HeaderText = "Thành Tiền";
            thanhTien.MinimumWidth = 6;
            thanhTien.Name = "thanhTien";
            thanhTien.ReadOnly = true;
            thanhTien.Width = 92;
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 640);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InvoiceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "OrderForm";
            panel1.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private Panel panel7;
        private Panel panel6;
        private Panel panel4;
        private Label label1;
        private Label label2;
        private Label txtMaHD;
        private Label txtNgay;
        private Label label4;
        private Label label8;
        private Label txtTenNV;
        private Label label6;
        private Panel panel9;
        private Button btnXacNhan;
        private Button btnHuy;
        private Panel panel8;
        private DataGridView dataGridView1;
        private Label txtPTTT;
        private Label label10;
        private Label txtTongCong;
        private Label label3;
        private Label label5;
        private DataGridViewTextBoxColumn tenSP;
        private DataGridViewTextBoxColumn donGia;
        private DataGridViewTextBoxColumn tienGiam;
        private DataGridViewTextBoxColumn soLuong;
        private DataGridViewTextBoxColumn thanhTien;
    }
}