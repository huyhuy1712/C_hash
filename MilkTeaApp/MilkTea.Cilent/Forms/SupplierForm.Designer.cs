namespace MilkTea.Client.Forms
{
    partial class SupplierForm
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
            Supplier_panel = new Panel();
            label1 = new Label();
            Supplier_panel.SuspendLayout();
            SuspendLayout();
            // 
            // Supplier_panel
            // 
            Supplier_panel.Controls.Add(label1);
            Supplier_panel.Dock = DockStyle.Fill;
            Supplier_panel.Location = new Point(0, 0);
            Supplier_panel.Name = "Supplier_panel";
            Supplier_panel.Size = new Size(800, 450);
            Supplier_panel.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 450);
            label1.TabIndex = 0;
            label1.Text = "Đây là trang nhà cung cấp";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Supplier_panel);
            Name = "SupplierForm";
            Text = "SupplierForm";
            Supplier_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Supplier_panel;
        private Label label1;
    }
}