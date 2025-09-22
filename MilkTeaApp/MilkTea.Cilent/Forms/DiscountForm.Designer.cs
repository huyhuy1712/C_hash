
namespace MilkTea.Client.Forms
{
    partial class DiscountForm
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
            DiscountPanel = new Panel();
            label1 = new Label();
            DiscountPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DiscountPanel
            // 
            DiscountPanel.Controls.Add(label1);
            DiscountPanel.Dock = DockStyle.Fill;
            DiscountPanel.Location = new Point(0, 0);
            DiscountPanel.Name = "DiscountPanel";
            DiscountPanel.Size = new Size(800, 450);
            DiscountPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 450);
            label1.TabIndex = 0;
            label1.Text = "Đây là trang khuyến mãi";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // DiscountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DiscountPanel);
            Name = "DiscountForm";
            Text = "OrderForm";
            DiscountPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel DiscountPanel;
        private Label label1;
    }
}