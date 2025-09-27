using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTea.Client.Controls
{
    public class ToggleButton : CheckBox
    {
        // Màu khi OFF
        public Color OffBackColor { get; set; } = Color.Gray;
        public Color OffToggleColor { get; set; } = Color.White;

        // Màu khi ON
        public Color OnBackColor { get; set; } = Color.MediumSlateBlue;
        public Color OnToggleColor { get; set; } = Color.White;

        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
            this.AutoSize = false;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            int toggleSize = this.Height - 5;

            // Vẽ background (OFF/ON)
            using (GraphicsPath path = GetFigurePath(this.ClientRectangle, this.Height / 2))
            using (SolidBrush backBrush = new SolidBrush(this.Checked ? OnBackColor : OffBackColor))
            {
                pevent.Graphics.FillPath(backBrush, path);
            }

            // Vẽ nút tròn (toggle)
            Rectangle toggleRect;
            if (this.Checked) // ON
            {
                toggleRect = new Rectangle(this.Width - this.Height + 2, 2, toggleSize, toggleSize);
                using (SolidBrush toggleBrush = new SolidBrush(OnToggleColor))
                {
                    pevent.Graphics.FillEllipse(toggleBrush, toggleRect);
                }
            }
            else // OFF
            {
                toggleRect = new Rectangle(2, 2, toggleSize, toggleSize);
                using (SolidBrush toggleBrush = new SolidBrush(OffToggleColor))
                {
                    pevent.Graphics.FillEllipse(toggleBrush, toggleRect);
                }
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int curveSize = radius * 2;

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
