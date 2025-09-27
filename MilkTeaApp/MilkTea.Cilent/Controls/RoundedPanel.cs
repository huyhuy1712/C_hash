using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 20;
        public Color BorderColor { get; set; } = Color.DodgerBlue;
        public int BorderSize { get; set; } = 0;

        public RoundedPanel()
        {
            this.BackColor = Color.White;   // nền mặc định
            this.ForeColor = Color.Black;   // chữ mặc định (nếu chứa Label)
            this.DoubleBuffered = true;     // giảm giật lag khi vẽ lại
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -1, -1);

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - 1))
            using (Pen penSurface = new Pen(this.Parent?.BackColor ?? Color.White, 2))
            using (Pen penBorder = new Pen(BorderColor, BorderSize))
            {
                // bo góc panel
                this.Region = new Region(pathSurface);

                // vẽ nền panel
                e.Graphics.FillPath(new SolidBrush(this.BackColor), pathSurface);

                // vẽ viền panel
                if (BorderSize >= 1)
                    e.Graphics.DrawPath(penBorder, pathBorder);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // ép control vẽ lại khi đổi kích thước
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
