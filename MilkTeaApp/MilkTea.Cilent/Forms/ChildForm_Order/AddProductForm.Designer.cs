namespace MilkTea.Client.Forms.ChildForm_Order
{
    partial class AddProductForm
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
            label1 = new Label();
            footer_panel = new Panel();
            huy_btn = new MilkTea.Client.Controls.RoundedButton();
            XacNhan_btn = new MilkTea.Client.Controls.RoundedButton();
            panel1 = new Panel();
            checkThemCongThuc = new CheckBox();
            roundedButton2 = new MilkTea.Client.Controls.RoundedButton();
            panel3 = new Panel();
            txtFileDaChon = new Label();
            btn_chon_file = new MilkTea.Client.Controls.RoundedButton();
            label5 = new Label();
            panel2 = new Panel();
            cboLoai = new MilkTea.Client.Controls.RoundedComboBox();
            label4 = new Label();
            gia_textbox = new MilkTea.Client.Controls.RoundedTextBox();
            label3 = new Label();
            ten_textbox = new MilkTea.Client.Controls.RoundedTextBox();
            label2 = new Label();
            openFileDialog1 = new OpenFileDialog();
            footer_panel.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(452, 58);
            label1.TabIndex = 0;
            label1.Text = "Thêm sản phẩm";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // footer_panel
            // 
            footer_panel.Controls.Add(huy_btn);
            footer_panel.Controls.Add(XacNhan_btn);
            footer_panel.Dock = DockStyle.Bottom;
            footer_panel.Location = new Point(10, 384);
            footer_panel.Name = "footer_panel";
            footer_panel.Padding = new Padding(10);
            footer_panel.Size = new Size(452, 56);
            footer_panel.TabIndex = 4;
            // 
            // huy_btn
            // 
            huy_btn.BackColor = Color.Red;
            huy_btn.BorderColor = Color.DodgerBlue;
            huy_btn.BorderRadius = 20;
            huy_btn.BorderSize = 0;
            huy_btn.Cursor = Cursors.Hand;
            huy_btn.Dock = DockStyle.Right;
            huy_btn.FlatAppearance.BorderSize = 0;
            huy_btn.FlatStyle = FlatStyle.Flat;
            huy_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            huy_btn.ForeColor = Color.White;
            huy_btn.Location = new Point(236, 10);
            huy_btn.Name = "huy_btn";
            huy_btn.Size = new Size(80, 36);
            huy_btn.TabIndex = 1;
            huy_btn.Text = "Hủy";
            huy_btn.UseVisualStyleBackColor = false;
            huy_btn.Click += huy_btn_Click;
            // 
            // XacNhan_btn
            // 
            XacNhan_btn.BackColor = Color.DodgerBlue;
            XacNhan_btn.BorderColor = Color.DodgerBlue;
            XacNhan_btn.BorderRadius = 20;
            XacNhan_btn.BorderSize = 0;
            XacNhan_btn.Cursor = Cursors.Hand;
            XacNhan_btn.Dock = DockStyle.Right;
            XacNhan_btn.FlatAppearance.BorderSize = 0;
            XacNhan_btn.FlatStyle = FlatStyle.Flat;
            XacNhan_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            XacNhan_btn.ForeColor = Color.White;
            XacNhan_btn.Location = new Point(316, 10);
            XacNhan_btn.Name = "XacNhan_btn";
            XacNhan_btn.Size = new Size(126, 36);
            XacNhan_btn.TabIndex = 0;
            XacNhan_btn.Text = "Xác nhận";
            XacNhan_btn.UseVisualStyleBackColor = false;
            XacNhan_btn.Click += XacNhan_btn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkThemCongThuc);
            panel1.Controls.Add(roundedButton2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(gia_textbox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(ten_textbox);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(10, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(452, 316);
            panel1.TabIndex = 5;
            // 
            // checkThemCongThuc
            // 
            checkThemCongThuc.AutoSize = true;
            checkThemCongThuc.Enabled = false;
            checkThemCongThuc.Location = new Point(187, 286);
            checkThemCongThuc.Name = "checkThemCongThuc";
            checkThemCongThuc.Size = new Size(18, 17);
            checkThemCongThuc.TabIndex = 7;
            checkThemCongThuc.UseVisualStyleBackColor = true;
            // 
            // roundedButton2
            // 
            roundedButton2.BackColor = Color.CadetBlue;
            roundedButton2.BorderColor = Color.Cyan;
            roundedButton2.BorderRadius = 20;
            roundedButton2.BorderSize = 0;
            roundedButton2.Cursor = Cursors.Hand;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            roundedButton2.ForeColor = Color.White;
            roundedButton2.Location = new Point(8, 273);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(169, 37);
            roundedButton2.TabIndex = 6;
            roundedButton2.Text = "Thêm công thức";
            roundedButton2.UseVisualStyleBackColor = false;
            roundedButton2.Click += roundedButton2_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtFileDaChon);
            panel3.Controls.Add(btn_chon_file);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 202);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(452, 54);
            panel3.TabIndex = 5;
            // 
            // txtFileDaChon
            // 
            txtFileDaChon.Location = new Point(221, 8);
            txtFileDaChon.Name = "txtFileDaChon";
            txtFileDaChon.Size = new Size(119, 36);
            txtFileDaChon.TabIndex = 5;
            txtFileDaChon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_chon_file
            // 
            btn_chon_file.BackColor = Color.SlateBlue;
            btn_chon_file.BorderColor = Color.DodgerBlue;
            btn_chon_file.BorderRadius = 20;
            btn_chon_file.BorderSize = 0;
            btn_chon_file.Cursor = Cursors.Hand;
            btn_chon_file.Dock = DockStyle.Left;
            btn_chon_file.FlatAppearance.BorderSize = 0;
            btn_chon_file.FlatStyle = FlatStyle.Flat;
            btn_chon_file.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_chon_file.ForeColor = Color.White;
            btn_chon_file.Location = new Point(79, 8);
            btn_chon_file.Name = "btn_chon_file";
            btn_chon_file.Size = new Size(126, 38);
            btn_chon_file.TabIndex = 4;
            btn_chon_file.Text = "Chọn file";
            btn_chon_file.UseVisualStyleBackColor = false;
            btn_chon_file.Click += btn_chon_file_Click;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Control;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label5.ForeColor = Color.DeepSkyBlue;
            label5.Location = new Point(8, 8);
            label5.Name = "label5";
            label5.Padding = new Padding(5);
            label5.Size = new Size(71, 38);
            label5.TabIndex = 3;
            label5.Text = "Ảnh";
            // 
            // panel2
            // 
            panel2.Controls.Add(cboLoai);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 148);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(452, 54);
            panel2.TabIndex = 4;
            // 
            // cboLoai
            // 
            cboLoai.BackColor = Color.White;
            cboLoai.BorderColor = Color.Gray;
            cboLoai.BorderRadius = 15;
            cboLoai.BorderSize = 1;
            cboLoai.Dock = DockStyle.Left;
            cboLoai.DrawMode = DrawMode.OwnerDrawFixed;
            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoai.FlatStyle = FlatStyle.Flat;
            cboLoai.FocusBorderColor = Color.DeepSkyBlue;
            cboLoai.Font = new Font("Segoe UI", 10F);
            cboLoai.FormattingEnabled = true;
            cboLoai.ItemHeight = 30;
            cboLoai.Location = new Point(79, 8);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(237, 36);
            cboLoai.TabIndex = 4;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.Control;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.DeepSkyBlue;
            label4.Location = new Point(8, 8);
            label4.Name = "label4";
            label4.Padding = new Padding(5);
            label4.Size = new Size(71, 38);
            label4.TabIndex = 3;
            label4.Text = "Loại";
            // 
            // gia_textbox
            // 
            gia_textbox.BackColor = Color.White;
            gia_textbox.BorderColor = Color.Gray;
            gia_textbox.BorderRadius = 20;
            gia_textbox.Cursor = Cursors.IBeam;
            gia_textbox.Dock = DockStyle.Top;
            gia_textbox.FocusBorderColor = Color.DeepSkyBlue;
            gia_textbox.Location = new Point(0, 115);
            gia_textbox.Name = "gia_textbox";
            gia_textbox.Padding = new Padding(10, 5, 40, 5);
            gia_textbox.Placeholder = "";
            gia_textbox.Size = new Size(452, 33);
            gia_textbox.TabIndex = 3;
            gia_textbox.TextValue = "";
            gia_textbox.Load += gia_textbox_Load;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.Control;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.ForeColor = Color.DeepSkyBlue;
            label3.Location = new Point(0, 74);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(452, 41);
            label3.TabIndex = 2;
            label3.Text = "Giá sản phẩm";
            // 
            // ten_textbox
            // 
            ten_textbox.BackColor = Color.White;
            ten_textbox.BorderColor = Color.Gray;
            ten_textbox.BorderRadius = 20;
            ten_textbox.Cursor = Cursors.IBeam;
            ten_textbox.Dock = DockStyle.Top;
            ten_textbox.FocusBorderColor = Color.DeepSkyBlue;
            ten_textbox.Location = new Point(0, 41);
            ten_textbox.Name = "ten_textbox";
            ten_textbox.Padding = new Padding(10, 5, 40, 5);
            ten_textbox.Placeholder = "";
            ten_textbox.Size = new Size(452, 33);
            ten_textbox.TabIndex = 1;
            ten_textbox.TextValue = "";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Control;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.DeepSkyBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(452, 41);
            label2.TabIndex = 0;
            label2.Text = "Tên sản phẩm";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 450);
            Controls.Add(panel1);
            Controls.Add(footer_panel);
            Controls.Add(label1);
            Name = "AddProductForm";
            Padding = new Padding(10);
            Text = "AddProductForm";
            footer_panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel footer_panel;
        private Controls.RoundedButton huy_btn;
        private Controls.RoundedButton XacNhan_btn;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Label label4;
        private Controls.RoundedTextBox gia_textbox;
        private Label label3;
        private Controls.RoundedTextBox ten_textbox;
        private Controls.RoundedComboBox cboLoai;
        private Panel panel3;
        private Label label5;
        private Controls.RoundedButton btn_chon_file;
        private CheckBox checkThemCongThuc;
        private Controls.RoundedButton roundedButton2;
        private OpenFileDialog openFileDialog1;
        private Label txtFileDaChon;
    }
}