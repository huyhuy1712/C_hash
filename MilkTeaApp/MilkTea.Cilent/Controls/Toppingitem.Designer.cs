namespace MilkTea.Client.Controls
{
    partial class Toppingitem
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
            item_panel = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            comboBox3 = new ComboBox();
            lb_slcl = new Label();
            lb_ten = new Label();
            checkBox1 = new CheckBox();
            item_panel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // item_panel
            // 
            item_panel.Controls.Add(tableLayoutPanel2);
            item_panel.Dock = DockStyle.Top;
            item_panel.Location = new Point(0, 0);
            item_panel.Name = "item_panel";
            item_panel.Size = new Size(584, 45);
            item_panel.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.9365349F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.3344765F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.6638079F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.69863F));
            tableLayoutPanel2.Controls.Add(comboBox3, 1, 0);
            tableLayoutPanel2.Controls.Add(lb_slcl, 2, 0);
            tableLayoutPanel2.Controls.Add(lb_ten, 0, 0);
            tableLayoutPanel2.Controls.Add(checkBox1, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(584, 45);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.None;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(242, 8);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(176, 28);
            comboBox3.TabIndex = 5;
            comboBox3.TabStop = false;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // lb_slcl
            // 
            lb_slcl.Dock = DockStyle.Fill;
            lb_slcl.Location = new Point(437, 1);
            lb_slcl.Name = "lb_slcl";
            lb_slcl.Size = new Size(61, 43);
            lb_slcl.TabIndex = 2;
            lb_slcl.Text = "SL";
            lb_slcl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_ten
            // 
            lb_ten.Dock = DockStyle.Fill;
            lb_ten.Location = new Point(4, 1);
            lb_ten.Name = "lb_ten";
            lb_ten.Size = new Size(220, 43);
            lb_ten.TabIndex = 0;
            lb_ten.Text = "Tên nguyên liệu";
            lb_ten.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox1.Dock = DockStyle.Fill;
            checkBox1.Location = new Point(505, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(75, 37);
            checkBox1.TabIndex = 4;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Toppingitem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(item_panel);
            Name = "Toppingitem";
            Size = new Size(584, 45);
            item_panel.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel item_panel;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lb_slcl;
        private Label lb_ten;
        private CheckBox checkBox1;
        private ComboBox comboBox3;
    }
}
