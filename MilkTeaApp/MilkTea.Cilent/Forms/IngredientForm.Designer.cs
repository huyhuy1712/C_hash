namespace MilkTea.Client.Forms
{
    partial class IngredientForm
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
            Ingredient_panel = new Panel();
            label1 = new Label();
            Ingredient_panel.SuspendLayout();
            SuspendLayout();
            // 
            // Ingredient_panel
            // 
            Ingredient_panel.Controls.Add(label1);
            Ingredient_panel.Dock = DockStyle.Fill;
            Ingredient_panel.Location = new Point(0, 0);
            Ingredient_panel.Name = "Ingredient_panel";
            Ingredient_panel.Size = new Size(800, 450);
            Ingredient_panel.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 450);
            label1.TabIndex = 0;
            label1.Text = "Đây là trang nguyên liệu";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IngredienForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Ingredient_panel);
            Name = "IngredienForm";
            Text = "IngredienForm";
            Ingredient_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Ingredient_panel;
        private Label label1;
    }
}