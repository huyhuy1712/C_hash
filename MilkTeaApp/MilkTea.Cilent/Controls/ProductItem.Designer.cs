namespace MilkTea.Client.Controls
{
    partial class ProductItem
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
            product_panel_1 = new Panel();
            product_bottom_panel_1 = new Panel();
            product_delete_btn1 = new PictureBox();
            product_edit_btn1 = new PictureBox();
            product_top_panel_1 = new Panel();
            product_top_right_panel_1 = new Panel();
            product_picture1 = new PictureBox();
            product_top_left_panel = new Panel();
            ten_sp_label1 = new Label();
            gia_label1 = new Label();
            product_panel_1.SuspendLayout();
            product_bottom_panel_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)product_delete_btn1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)product_edit_btn1).BeginInit();
            product_top_panel_1.SuspendLayout();
            product_top_right_panel_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)product_picture1).BeginInit();
            product_top_left_panel.SuspendLayout();
            SuspendLayout();
            // 
            // product_panel_1
            // 
            product_panel_1.BorderStyle = BorderStyle.FixedSingle;
            product_panel_1.Controls.Add(product_bottom_panel_1);
            product_panel_1.Controls.Add(product_top_panel_1);
            product_panel_1.Dock = DockStyle.Fill;
            product_panel_1.Location = new Point(0, 0);
            product_panel_1.Name = "product_panel_1";
            product_panel_1.Size = new Size(205, 129);
            product_panel_1.TabIndex = 4;
            // 
            // product_bottom_panel_1
            // 
            product_bottom_panel_1.BorderStyle = BorderStyle.FixedSingle;
            product_bottom_panel_1.Controls.Add(product_delete_btn1);
            product_bottom_panel_1.Controls.Add(product_edit_btn1);
            product_bottom_panel_1.Dock = DockStyle.Bottom;
            product_bottom_panel_1.Location = new Point(0, 104);
            product_bottom_panel_1.Name = "product_bottom_panel_1";
            product_bottom_panel_1.Size = new Size(203, 23);
            product_bottom_panel_1.TabIndex = 1;
            // 
            // product_delete_btn1
            // 
            product_delete_btn1.Cursor = Cursors.Hand;
            product_delete_btn1.Dock = DockStyle.Right;
            product_delete_btn1.Image = Properties.Resources.trash;
            product_delete_btn1.Location = new Point(161, 0);
            product_delete_btn1.Name = "product_delete_btn1";
            product_delete_btn1.Size = new Size(40, 21);
            product_delete_btn1.SizeMode = PictureBoxSizeMode.Zoom;
            product_delete_btn1.TabIndex = 1;
            product_delete_btn1.TabStop = false;
            // 
            // product_edit_btn1
            // 
            product_edit_btn1.Cursor = Cursors.Hand;
            product_edit_btn1.Dock = DockStyle.Left;
            product_edit_btn1.Image = Properties.Resources.edit;
            product_edit_btn1.Location = new Point(0, 0);
            product_edit_btn1.Name = "product_edit_btn1";
            product_edit_btn1.Size = new Size(28, 21);
            product_edit_btn1.SizeMode = PictureBoxSizeMode.Zoom;
            product_edit_btn1.TabIndex = 0;
            product_edit_btn1.TabStop = false;
            // 
            // product_top_panel_1
            // 
            product_top_panel_1.Controls.Add(product_top_right_panel_1);
            product_top_panel_1.Controls.Add(product_top_left_panel);
            product_top_panel_1.Cursor = Cursors.Hand;
            product_top_panel_1.Dock = DockStyle.Fill;
            product_top_panel_1.Location = new Point(0, 0);
            product_top_panel_1.Name = "product_top_panel_1";
            product_top_panel_1.Size = new Size(203, 127);
            product_top_panel_1.TabIndex = 0;
            // 
            // product_top_right_panel_1
            // 
            product_top_right_panel_1.Controls.Add(product_picture1);
            product_top_right_panel_1.Dock = DockStyle.Fill;
            product_top_right_panel_1.Location = new Point(119, 0);
            product_top_right_panel_1.Name = "product_top_right_panel_1";
            product_top_right_panel_1.Size = new Size(84, 127);
            product_top_right_panel_1.TabIndex = 1;
            // 
            // product_picture1
            // 
            product_picture1.Dock = DockStyle.Fill;
            product_picture1.Location = new Point(0, 0);
            product_picture1.Name = "product_picture1";
            product_picture1.Size = new Size(84, 127);
            product_picture1.SizeMode = PictureBoxSizeMode.Zoom;
            product_picture1.TabIndex = 0;
            product_picture1.TabStop = false;
            // 
            // product_top_left_panel
            // 
            product_top_left_panel.Controls.Add(ten_sp_label1);
            product_top_left_panel.Controls.Add(gia_label1);
            product_top_left_panel.Dock = DockStyle.Left;
            product_top_left_panel.Location = new Point(0, 0);
            product_top_left_panel.Name = "product_top_left_panel";
            product_top_left_panel.Size = new Size(119, 127);
            product_top_left_panel.TabIndex = 0;
            // 
            // ten_sp_label1
            // 
            ten_sp_label1.BorderStyle = BorderStyle.FixedSingle;
            ten_sp_label1.Dock = DockStyle.Fill;
            ten_sp_label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ten_sp_label1.ForeColor = SystemColors.ControlText;
            ten_sp_label1.Location = new Point(0, 25);
            ten_sp_label1.Name = "ten_sp_label1";
            ten_sp_label1.Size = new Size(119, 102);
            ten_sp_label1.TabIndex = 1;
            ten_sp_label1.Text = "Trà sữa chân trâu đường đen";
            ten_sp_label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // gia_label1
            // 
            gia_label1.BorderStyle = BorderStyle.FixedSingle;
            gia_label1.Dock = DockStyle.Top;
            gia_label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gia_label1.ForeColor = SystemColors.ControlText;
            gia_label1.Location = new Point(0, 0);
            gia_label1.Name = "gia_label1";
            gia_label1.Size = new Size(119, 25);
            gia_label1.TabIndex = 0;
            gia_label1.Text = "40.000";
            gia_label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ProductItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(product_panel_1);
            Name = "ProductItem";
            Size = new Size(205, 129);
            product_panel_1.ResumeLayout(false);
            product_bottom_panel_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)product_delete_btn1).EndInit();
            ((System.ComponentModel.ISupportInitialize)product_edit_btn1).EndInit();
            product_top_panel_1.ResumeLayout(false);
            product_top_right_panel_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)product_picture1).EndInit();
            product_top_left_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel product_panel_1;
        private Panel product_bottom_panel_1;
        private PictureBox product_delete_btn1;
        private PictureBox product_edit_btn1;
        private Panel product_top_panel_1;
        private Panel product_top_right_panel_1;
        private Panel product_top_left_panel;
        private Label ten_sp_label1;
        private Label gia_label1;
        private PictureBox product_picture1;
    }
}
