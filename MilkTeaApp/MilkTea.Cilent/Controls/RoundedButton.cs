using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 20;
        public Color BorderColor { get; set; } = Color.DodgerBlue;
        public int BorderSize { get; set; } = 0;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.DodgerBlue;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 11, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -1, -1);

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - 1))
            using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
            using (Pen penBorder = new Pen(BorderColor, BorderSize))
            {
                this.Region = new Region(pathSurface);
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                if (BorderSize >= 1)
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
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
