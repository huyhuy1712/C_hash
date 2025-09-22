namespace MilkTea.Client.Forms
{
    partial class OrderForm
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
            OrderPanel = new Panel();
            label1 = new Label();
            OrderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OrderPanel
            // 
            OrderPanel.Controls.Add(label1);
            OrderPanel.Dock = DockStyle.Fill;
            OrderPanel.Location = new Point(0, 0);
            OrderPanel.Name = "OrderPanel";
            OrderPanel.Size = new Size(800, 450);
            OrderPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 450);
            label1.TabIndex = 0;
            label1.Text = "Đây là trang order";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(OrderPanel);
            Name = "OrderForm";
            Text = "OrderForm";
            OrderPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel OrderPanel;
        private Label label1;
    }
}