using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public class RoundedTextBox : UserControl
    {
        private TextBox textBox;
        private PictureBox icon;

        public string Placeholder { get; set; } = "Từ khóa tìm kiếm...";
        public Color BorderColor { get; set; } = Color.Gray;
        public Color FocusBorderColor { get; set; } = Color.DeepSkyBlue;
        public int BorderRadius { get; set; } = 20;

        private bool isFocused = false;

        public RoundedTextBox()
        {
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            this.Padding = new Padding(10, 5, 40, 5); // chừa chỗ cho icon bên phải

            // --- TextBox ---
            textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.ForeColor = Color.Gray;
            textBox.Text = Placeholder;
            textBox.Location = new Point(10, 7);
            textBox.Width = this.Width - 50; // chừa icon
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

            textBox.Enter += (s, e) =>
            {
                isFocused = true;
                if (textBox.Text == Placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
                this.Invalidate();
            };

            textBox.Leave += (s, e) =>
            {
                isFocused = false;
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = Placeholder;
                    textBox.ForeColor = Color.Gray;
                }
                this.Invalidate();
            };

            // Forward KeyDown từ textBox ra ngoài
            textBox.KeyDown += (s, e) =>
            {
                this.OnKeyDown(e);
            };

            // --- Icon ---
            icon = new PictureBox();
            icon.Image = Properties.Resources.search; // icon search
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.Width = 20;
            icon.Height = 20;
            icon.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            this.Controls.Add(textBox);
            this.Controls.Add(icon);

            this.Resize += (s, e) => AdjustLayout();

            AdjustLayout();
        }

        private void AdjustLayout()
        {
            // căn icon sang phải và giữa theo chiều dọc
            icon.Location = new Point(this.Width - icon.Width - 10, (this.Height - icon.Height) / 2);

            // căn textbox còn lại, tránh icon
            textBox.Width = this.Width - icon.Width - 25;
            textBox.Location = new Point(10, (this.Height - textBox.Height) / 2);
            SetRoundedRegion();
        }

        private void SetRoundedRegion()
        {
            using (var path = GetRoundedPath(this.ClientRectangle, BorderRadius))
            {
                this.Region = new Region(path);
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (var path = GetRoundedPath(rect, BorderRadius))
            using (var pen = new Pen(isFocused ? FocusBorderColor : BorderColor, 2))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public string TextValue
        {
            get => textBox.Text == Placeholder ? "" : textBox.Text;
            set
            {
                textBox.Text = string.IsNullOrEmpty(value) ? Placeholder : value;
                textBox.ForeColor = string.IsNullOrEmpty(value) ? Color.Gray : Color.Black;
            }
        }
    }
}
