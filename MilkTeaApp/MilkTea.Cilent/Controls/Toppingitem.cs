using MilkTea.Client.Models;
using System;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public partial class Toppingitem : UserControl
    {
        private NguyenLieu _data;
        public event EventHandler ToppingChanged;

        public Toppingitem()
        {
            InitializeComponent();
        }

        public void SetData(NguyenLieu nl)
        {
            _data = nl;

            // Gán dữ liệu cho các control
            lb_ten.Text = nl.Ten;
            lb_slcl.Text = nl.SoLuong.ToString();

            comboBox3.Items.Clear();
            comboBox3.Items.Add($"25% - {nl.GiaBan:N0} VND");
            comboBox3.Items.Add($"50% - {(nl.GiaBan * 2):N0} VND");
            comboBox3.Items.Add($"75% - {(nl.GiaBan * 3):N0} VND");
            comboBox3.SelectedIndex = 0;

            checkBox1.Checked = false;
        }

        // Gọi sự kiện khi thay đổi
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ToppingChanged?.Invoke(this, EventArgs.Empty);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToppingChanged?.Invoke(this, EventArgs.Empty);
        }

        // ====== Hỗ trợ =======
        public NguyenLieu GetData() => _data;

        public bool IsChecked() => checkBox1.Checked;

        public string GetSelectedComboText() => comboBox3.SelectedItem?.ToString() ?? "";

        public void SetChecked(bool value)
        {
            checkBox1.Checked = value;
        }

        public void SetSelectedComboText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var index = comboBox3.Items.IndexOf(text);
                if (index >= 0)
                    comboBox3.SelectedIndex = index;
            }
        }

        // ====== Lấy giá topping =======
        public decimal GetGiaTopping()
        {
            if (!checkBox1.Checked) return 0;

            if (comboBox3.SelectedItem == null)
                return 0;

            string text = comboBox3.SelectedItem.ToString();
            int dashIndex = text.IndexOf('-');
            if (dashIndex == -1) return 0;

            string giaText = text.Substring(dashIndex + 1)
                                 .Replace("VND", "")
                                 .Replace(",", "")
                                 .Trim();

            if (decimal.TryParse(giaText, out decimal gia))
                return gia;
            return 0;
        }
    }
}
