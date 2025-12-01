using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public class RoundedTextBox : UserControl
    {
        private TextBox textBox;
        private bool isFocused = false;

        public string Placeholder { get; set; } = "Từ khóa tìm kiếm...";
        public Color BorderColor { get; set; } = Color.Gray;
        public Color FocusBorderColor { get; set; } = Color.DeepSkyBlue;
        public int BorderRadius { get; set; } = 20;

        public RoundedTextBox()
        {
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            // --- TextBox ---
            textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.ForeColor = Color.Gray;
            textBox.Text = Placeholder;
            textBox.Multiline = true; // Cho phép căn giữa dọc
            textBox.TextAlign = HorizontalAlignment.Left; // Hoặc Center nếu muốn giữa ngang
            textBox.ScrollBars = ScrollBars.None;

            // --- Xử lý focus / placeholder ---
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

            // Forward sự kiện bàn phím ra ngoài
            textBox.KeyDown += (s, e) => this.OnKeyDown(e);
            textBox.KeyUp += (s, e) => this.OnKeyUp(e);

            this.Controls.Add(textBox);
            this.Resize += (s, e) => AdjustLayout();

            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int padding = 10;
            textBox.Width = this.Width - padding * 2;
            textBox.Height = TextRenderer.MeasureText("Text", textBox.Font).Height + 6;
            textBox.Location = new Point(padding, (this.Height - textBox.Height) / 2);
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
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;

                if (textBox != null)
                {
                    textBox.Font = value;
                    AdjustLayout();   // cập nhật lại layout theo font mới
                }

                this.Invalidate();
            }
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

        public override string Text
        {
            get => textBox.Text == Placeholder ? string.Empty : textBox.Text;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    textBox.Text = Placeholder;
                    textBox.ForeColor = Color.Gray;
                }
                else
                {
                    textBox.Text = value;
                    textBox.ForeColor = Color.Black;
                }
            }
        }
    }
}
