using System.Drawing;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    partial class DonHangItem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panel5 = new Panel();
            label_NgayLap = new Label();
            label_maDH = new Label();
            panel6 = new Panel();
            panel10 = new Panel();
            panel11 = new Panel();
            pictureBox_PhuongThucThanhToan = new PictureBox();
            label_GioLap = new Label();
            pictureBox8 = new PictureBox();
            label_TongGia = new Label();
            panel7 = new Panel();
            label_MaBuzzer = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PhuongThucThanhToan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel7.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.MenuHighlight;
            panel5.Controls.Add(label_NgayLap);
            panel5.Controls.Add(label_maDH);
            panel5.Dock = DockStyle.Top;
            panel5.ForeColor = SystemColors.ButtonHighlight;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(210, 32);
            panel5.TabIndex = 1;
            // 
            // label_NgayLap
            // 
            label_NgayLap.Dock = DockStyle.Right;
            label_NgayLap.Location = new Point(102, 0);
            label_NgayLap.Name = "label_NgayLap";
            label_NgayLap.Size = new Size(108, 32);
            label_NgayLap.TabIndex = 0;
            label_NgayLap.Text = "12 - 09 - 2025";
            label_NgayLap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_maDH
            // 
            label_maDH.Dock = DockStyle.Left;
            label_maDH.Location = new Point(0, 0);
            label_maDH.Name = "label_maDH";
            label_maDH.Size = new Size(32, 32);
            label_maDH.TabIndex = 1;
            label_maDH.Text = "1";
            label_maDH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ControlLight;
            panel6.Controls.Add(panel10);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 32);
            panel6.Name = "panel6";
            panel6.Size = new Size(210, 70);
            panel6.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.BackColor = SystemColors.ButtonHighlight;
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(label_TongGia);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(48, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(162, 70);
            panel10.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(pictureBox_PhuongThucThanhToan);
            panel11.Controls.Add(label_GioLap);
            panel11.Controls.Add(pictureBox8);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(0, 29);
            panel11.Name = "panel11";
            panel11.Size = new Size(162, 41);
            panel11.TabIndex = 0;
            // 
            // pictureBox_PhuongThucThanhToan
            // 
            pictureBox_PhuongThucThanhToan.Dock = DockStyle.Right;
            pictureBox_PhuongThucThanhToan.Image = Properties.Resources.money;
            pictureBox_PhuongThucThanhToan.Location = new Point(85, 0);
            pictureBox_PhuongThucThanhToan.Name = "pictureBox_PhuongThucThanhToan";
            pictureBox_PhuongThucThanhToan.Size = new Size(75, 39);
            pictureBox_PhuongThucThanhToan.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_PhuongThucThanhToan.TabIndex = 0;
            pictureBox_PhuongThucThanhToan.TabStop = false;
            pictureBox_PhuongThucThanhToan.Click += pictureBox_PhuongThucThanhToan_Click;
            // 
            // label_GioLap
            // 
            label_GioLap.Dock = DockStyle.Fill;
            label_GioLap.Location = new Point(32, 0);
            label_GioLap.Name = "label_GioLap";
            label_GioLap.Size = new Size(128, 39);
            label_GioLap.TabIndex = 1;
            label_GioLap.Text = "14:30";
            label_GioLap.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox8
            // 
            pictureBox8.Dock = DockStyle.Left;
            pictureBox8.Image = Properties.Resources.alarm;
            pictureBox8.Location = new Point(0, 0);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(32, 39);
            pictureBox8.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox8.TabIndex = 2;
            pictureBox8.TabStop = false;
            // 
            // label_TongGia
            // 
            label_TongGia.Dock = DockStyle.Top;
            label_TongGia.Location = new Point(0, 0);
            label_TongGia.Name = "label_TongGia";
            label_TongGia.Size = new Size(162, 29);
            label_TongGia.TabIndex = 1;
            label_TongGia.Text = "90.000";
            label_TongGia.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ButtonHighlight;
            panel7.Controls.Add(label_MaBuzzer);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(48, 70);
            panel7.TabIndex = 1;
            // 
            // label_MaBuzzer
            // 
            label_MaBuzzer.BorderStyle = BorderStyle.FixedSingle;
            label_MaBuzzer.Dock = DockStyle.Fill;
            label_MaBuzzer.Location = new Point(0, 0);
            label_MaBuzzer.Name = "label_MaBuzzer";
            label_MaBuzzer.Size = new Size(48, 70);
            label_MaBuzzer.TabIndex = 0;
            label_MaBuzzer.Text = "B1";
            label_MaBuzzer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            tableLayoutPanel2.Controls.Add(pictureBox4, 0, 0);
            tableLayoutPanel2.Controls.Add(pictureBox5, 1, 0);
            tableLayoutPanel2.Controls.Add(pictureBox6, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 102);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(210, 38);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // pictureBox4
            // 
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Image = Properties.Resources.hourglass;
            pictureBox4.Location = new Point(4, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(62, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Dock = DockStyle.Fill;
            pictureBox5.Image = Properties.Resources.info;
            pictureBox5.Location = new Point(73, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(62, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Dock = DockStyle.Fill;
            pictureBox6.Image = Properties.Resources.recycle_bin;
            pictureBox6.Location = new Point(142, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(64, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox6.TabIndex = 2;
            pictureBox6.TabStop = false;
            // 
            // DonHangItem
            // 
            Controls.Add(panel6);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(panel5);
            Name = "DonHangItem";
            Size = new Size(210, 140);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_PhuongThucThanhToan).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel7.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private Panel panel6;
        private Panel panel10;
        private Panel panel11;
        private Panel panel7;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label_maDH;
        private Label label_NgayLap;
        private Label label_MaBuzzer;
        private Label label_GioLap;
        private Label label_TongGia;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox_PhuongThucThanhToan;
        private PictureBox pictureBox8;
    }
}
