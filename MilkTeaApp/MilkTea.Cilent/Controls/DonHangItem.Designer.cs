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
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            label_GioLap = new Label();
            pictureBox2 = new PictureBox();
            label_TongGia = new Label();
            panel8 = new Panel();
            label_MaBuzzer = new Label();
            panel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel8.SuspendLayout();
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
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(210, 140);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(210, 70);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label_TongGia);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(48, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(162, 70);
            panel3.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(label_GioLap);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 29);
            panel4.Name = "panel4";
            panel4.Size = new Size(162, 41);
            panel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.money;
            pictureBox1.Location = new Point(85, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
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
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
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
            label_TongGia.Click += label2_Click;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.ButtonHighlight;
            panel8.Controls.Add(label_MaBuzzer);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(48, 70);
            panel8.TabIndex = 1;
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
            // DonHangItem
            // 
            Controls.Add(panel1);
            Name = "DonHangItem";
            Size = new Size(210, 140);
            panel5.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label_maDH;
        private Label label_NgayLap;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private PictureBox pictureBox1;
        private Label label_GioLap;
        private PictureBox pictureBox2;
        private Label label_TongGia;
        private Panel panel8;
        private Label label_MaBuzzer;
    }
}
