namespace MilkTea.Client.Controls
{
    partial class nguyenlieu_congthuc_item
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel3 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            check = new CheckBox();
            lbl_ten = new Label();
            txt_sl = new TextBox();
            comboBox1 = new RoundedComboBox();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(478, 35);
            panel3.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(check, 3, 0);
            tableLayoutPanel2.Controls.Add(lbl_ten, 0, 0);
            tableLayoutPanel2.Controls.Add(txt_sl, 1, 0);
            tableLayoutPanel2.Controls.Add(comboBox1, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(478, 35);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // check
            // 
            check.AutoSize = true;
            check.CheckAlign = ContentAlignment.MiddleCenter;
            check.Dock = DockStyle.Fill;
            check.Location = new Point(361, 4);
            check.Name = "check";
            check.Size = new Size(113, 27);
            check.TabIndex = 4;
            check.TextAlign = ContentAlignment.MiddleCenter;
            check.UseVisualStyleBackColor = true;
            // 
            // lbl_ten
            // 
            lbl_ten.Dock = DockStyle.Fill;
            lbl_ten.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ten.ForeColor = Color.DeepSkyBlue;
            lbl_ten.Location = new Point(4, 1);
            lbl_ten.Name = "lbl_ten";
            lbl_ten.Size = new Size(112, 33);
            lbl_ten.TabIndex = 1;
            lbl_ten.Text = "Đá";
            lbl_ten.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_sl
            // 
            txt_sl.Dock = DockStyle.Fill;
            txt_sl.Location = new Point(123, 4);
            txt_sl.Name = "txt_sl";
            txt_sl.Size = new Size(112, 27);
            txt_sl.TabIndex = 2;
            txt_sl.TextAlign = HorizontalAlignment.Center;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.White;
            comboBox1.BorderColor = Color.Gray;
            comboBox1.BorderRadius = 15;
            comboBox1.BorderSize = 1;
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.FocusBorderColor = Color.DeepSkyBlue;
            comboBox1.Font = new Font("Segoe UI", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.ItemHeight = 30;
            comboBox1.Location = new Point(242, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 36);
            comboBox1.TabIndex = 5;
            // 
            // nguyenlieu_congthuc_item
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Name = "nguyenlieu_congthuc_item";
            Size = new Size(478, 37);
            panel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lbl_ten;
        private TextBox txt_sl;
        private CheckBox check;
        private RoundedComboBox comboBox1;
    }
}
