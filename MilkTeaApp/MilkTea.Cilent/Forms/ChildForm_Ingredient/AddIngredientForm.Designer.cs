namespace MilkTea.Client.Forms.ChildForm_Import
{
    partial class AddIngredientForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel13 = new Panel();
            panel14 = new Panel();
            textBox4 = new MilkTea.Client.Controls.RoundedComboBox();
            panel15 = new Panel();
            label5 = new Label();
            panel12 = new Panel();
            btnThoat = new MilkTea.Client.Controls.RoundedButton();
            btnXacNhan = new MilkTea.Client.Controls.RoundedButton();
            panel5 = new Panel();
            panel11 = new Panel();
            textBox3 = new TextBox();
            panel8 = new Panel();
            label4 = new Label();
            panel4 = new Panel();
            panel10 = new Panel();
            textBox2 = new TextBox();
            panel7 = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            panel9 = new Panel();
            textBox1 = new TextBox();
            panel6 = new Panel();
            label2 = new Label();
            donViTinhBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel15.SuspendLayout();
            panel12.SuspendLayout();
            panel5.SuspendLayout();
            panel11.SuspendLayout();
            panel8.SuspendLayout();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel9.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)donViTinhBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 100);
            label1.TabIndex = 0;
            label1.Text = "Thêm nguyên liệu";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel13);
            panel2.Controls.Add(panel12);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 350);
            panel2.TabIndex = 1;
            // 
            // panel13
            // 
            panel13.Controls.Add(panel14);
            panel13.Controls.Add(panel15);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 203);
            panel13.Name = "panel13";
            panel13.Size = new Size(800, 66);
            panel13.TabIndex = 4;
            // 
            // panel14
            // 
            panel14.Controls.Add(textBox4);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(157, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(643, 66);
            panel14.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.White;
            textBox4.BorderColor = Color.Gray;
            textBox4.BorderRadius = 15;
            textBox4.BorderSize = 1;
            textBox4.DataSource = donViTinhBindingSource;
            textBox4.DisplayMember = "TenDVT";
            textBox4.DrawMode = DrawMode.OwnerDrawFixed;
            textBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox4.FlatStyle = FlatStyle.Flat;
            textBox4.FocusBorderColor = Color.DeepSkyBlue;
            textBox4.Font = new Font("Segoe UI", 10F);
            textBox4.FormattingEnabled = true;
            textBox4.ItemHeight = 30;
            textBox4.Location = new Point(-3, 15);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.RightToLeft = RightToLeft.No;
            textBox4.Size = new Size(646, 36);
          
            textBox4.TabIndex = 5;
            // 
            // panel15
            // 
            panel15.Controls.Add(label5);
            panel15.Dock = DockStyle.Left;
            panel15.Location = new Point(0, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(157, 66);
            panel15.TabIndex = 1;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(157, 66);
            label5.TabIndex = 1;
            label5.Text = "Đơn vị";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            panel12.Controls.Add(btnThoat);
            panel12.Controls.Add(btnXacNhan);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 309);
            panel12.Name = "panel12";
            panel12.Size = new Size(800, 41);
            panel12.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Crimson;
            btnThoat.BorderColor = Color.Crimson;
            btnThoat.BorderRadius = 20;
            btnThoat.BorderSize = 0;
            btnThoat.Dock = DockStyle.Right;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(591, 0);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(82, 41);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Hủy";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.AutoSize = true;
            btnXacNhan.BackColor = Color.DodgerBlue;
            btnXacNhan.BorderColor = Color.DodgerBlue;
            btnXacNhan.BorderRadius = 20;
            btnXacNhan.BorderSize = 0;
            btnXacNhan.Dock = DockStyle.Right;
            btnXacNhan.FlatAppearance.BorderSize = 0;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Location = new Point(673, 0);
            btnXacNhan.Margin = new Padding(3, 2, 3, 2);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(127, 41);
            btnXacNhan.TabIndex = 2;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel11);
            panel5.Controls.Add(panel8);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 132);
            panel5.Name = "panel5";
            panel5.Size = new Size(800, 71);
            panel5.TabIndex = 2;
            // 
            // panel11
            // 
            panel11.Controls.Add(textBox3);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(157, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(643, 71);
            panel11.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(0, 17);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(643, 33);
            textBox3.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(label4);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(157, 71);
            panel8.TabIndex = 1;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(157, 71);
            label4.TabIndex = 1;
            label4.Text = "Giá bán";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel10);
            panel4.Controls.Add(panel7);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 66);
            panel4.Name = "panel4";
            panel4.Size = new Size(800, 66);
            panel4.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Controls.Add(textBox2);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(157, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(643, 66);
            panel10.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(0, 17);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(643, 33);
            textBox2.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(label3);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(157, 66);
            panel7.TabIndex = 1;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(157, 66);
            label3.TabIndex = 1;
            label3.Text = "Số lượng";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel9);
            panel3.Controls.Add(panel6);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 66);
            panel3.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(textBox1);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(157, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(643, 66);
            panel9.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(-3, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(643, 33);
            textBox1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(label2);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(157, 66);
            panel6.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(157, 66);
            label2.TabIndex = 0;
            label2.Text = "Tên nguyên liệu";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // donViTinhBindingSource
            // 
            donViTinhBindingSource.DataSource = typeof(Models.DonViTinh);
            // 
            // AddIngredientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AddIngredientForm";
            Text = "AddIngredientForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel5.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel8.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)donViTinhBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel5;
        private Panel panel11;
        private Panel panel8;
        private Panel panel4;
        private Panel panel10;
        private Panel panel7;
        private Panel panel3;
        private Panel panel9;
        private Panel panel6;
        private Label label2;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Panel panel12;
        private Controls.RoundedButton btnThoat;
        private Controls.RoundedButton btnXacNhan;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Label label5;
        private Controls.RoundedComboBox textBox4;
        private BindingSource donViTinhBindingSource;
    }
}