using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public class RoundedComboBox : ComboBox
    {
        public int BorderRadius { get; set; } = 15;
        public int BorderSize { get; set; } = 1;
        public Color BorderColor { get; set; } = Color.Gray;
        public Color FocusBorderColor { get; set; } = Color.DeepSkyBlue;

        private bool isFocused = false;

        public RoundedComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.BackColor = Color.White;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 30;

            this.Enter += (s, e) => { isFocused = true; this.Invalidate(); };
            this.Leave += (s, e) => { isFocused = false; this.Invalidate(); };
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            string text = this.Items[e.Index].ToString();

            using (Brush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, br, e.Bounds.X + 10, e.Bounds.Y + 5);
            }
            e.DrawFocusRectangle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            // Border
            using (GraphicsPath path = GetFigurePath(rect, BorderRadius))
            using (Pen pen = new Pen(isFocused ? FocusBorderColor : BorderColor, BorderSize))
            {
                this.Region = new Region(path);
                e.Graphics.DrawPath(pen, path);
            }

            // Vẽ mũi tên dropdown
            int arrowX = rect.Right - 20;
            int arrowY = rect.Height / 2 - 2;

            Point[] arrow = new Point[]
            {
                new Point(arrowX, arrowY),
                new Point(arrowX + 10, arrowY),
                new Point(arrowX + 5, arrowY + 6)
            };

            using (Brush br = new SolidBrush(Color.Black))
            {
                e.Graphics.FillPolygon(br, arrow);
            }

            // Vẽ text chọn
            if (this.SelectedIndex >= 0)
            {
                string text = this.GetItemText(this.Items[this.SelectedIndex]);
                TextRenderer.DrawText(e.Graphics, text, this.Font,
                    new Rectangle(10, 0, rect.Width - 30, rect.Height),
                    this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
