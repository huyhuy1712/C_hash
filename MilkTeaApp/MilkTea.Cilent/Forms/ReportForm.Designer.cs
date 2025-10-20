
namespace MilkTea.Client.Forms
{
    partial class ReportForm
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
            ReportPanel = new Panel();
            label1 = new Label();
            ReportPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ReportPanel
            // 
            ReportPanel.Controls.Add(label1);
            ReportPanel.Dock = DockStyle.Fill;
            ReportPanel.Location = new Point(0, 0);
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(800, 450);
            ReportPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 450);
            label1.TabIndex = 0;
            label1.Text = "Đây là trang thống kê";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ReportPanel);
            Name = "ReportForm";
            Text = "OrderForm";
            Load += ReportForm_Load;
            ReportPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel ReportPanel;
        private Label label1;
    }
}