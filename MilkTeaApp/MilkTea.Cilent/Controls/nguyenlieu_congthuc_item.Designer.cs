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
            lbl_ten = new Label();
            txt_sl = new TextBox();
            check = new CheckBox();
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
            panel3.Size = new Size(391, 35);
            panel3.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.2027969F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.7972031F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tableLayoutPanel2.Controls.Add(lbl_ten, 0, 0);
            tableLayoutPanel2.Controls.Add(txt_sl, 1, 0);
            tableLayoutPanel2.Controls.Add(check, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(391, 35);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // lbl_ten
            // 
            lbl_ten.Dock = DockStyle.Fill;
            lbl_ten.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ten.ForeColor = Color.DeepSkyBlue;
            lbl_ten.Location = new Point(4, 1);
            lbl_ten.Name = "lbl_ten";
            lbl_ten.Size = new Size(128, 33);
            lbl_ten.TabIndex = 1;
            lbl_ten.Text = "Đá";
            lbl_ten.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_sl
            // 
            txt_sl.Dock = DockStyle.Fill;
            txt_sl.Location = new Point(139, 4);
            txt_sl.Name = "txt_sl";
            txt_sl.Size = new Size(144, 27);
            txt_sl.TabIndex = 2;
            txt_sl.TextAlign = HorizontalAlignment.Center;
            // 
            // check
            // 
            check.AutoSize = true;
            check.CheckAlign = ContentAlignment.MiddleCenter;
            check.Dock = DockStyle.Fill;
            check.Location = new Point(290, 4);
            check.Name = "check";
            check.Size = new Size(97, 27);
            check.TabIndex = 3;
            check.TextAlign = ContentAlignment.MiddleCenter;
            check.UseVisualStyleBackColor = true;
            // 
            // nguyemlieu_congthuc_item
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Name = "nguyemlieu_congthuc_item";
            Size = new Size(391, 37);
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
    }
}
