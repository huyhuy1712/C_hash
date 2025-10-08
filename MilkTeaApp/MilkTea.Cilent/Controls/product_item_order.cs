using MilkTea.Client.Forms;
using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public partial class product_item_order : UserControl
    {
        private readonly SizeService _sizeService;

        public string TenSP { get; set; }
        public int SanPhamId { get; set; }
        public decimal Gia { get; set; }
        public string Anh { get; set; }
        public string khuyenmai { get; set; }
        public decimal phantramgiam { get; set; }
        public int SLMuaDuoc { get; set; }
        public List<Topping> DSTopping { get; set; } = new List<Topping>();

        private int slCu = 1; // số lượng cũ để tính chênh lệch

        public event EventHandler ThanhTienChanged;
        public event EventHandler OnOrderUpdated;

        public product_item_order()
        {
            InitializeComponent();
            _sizeService = new SizeService();
            product_item_order_Load(this, EventArgs.Empty);
        }

        // ===================== Hiển thị dữ liệu sản phẩm =====================
        public async void setData()
        {
            lb.Text = TenSP;
            textBox1.Text = "1";

            var sizes = await _sizeService.GetAll();
            size_comboBox1.DataSource = sizes;
            size_comboBox1.DisplayMember = "TenSize";
            size_comboBox1.ValueMember = "MaSize";

            SL_dc_label.Text = SLMuaDuoc.ToString();
            label27.Text = khuyenmai?.ToString() ?? "Không có";

            decimal tienGiam = (Gia * phantramgiam) / 100;
            label26.Text = tienGiam.ToString("N0");

            decimal thanhTien = Gia - tienGiam + 10000;
            thanhtien_lb.Text = thanhTien.ToString("N0");

            try
            {
                string imgPath = Path.Combine(Application.StartupPath, "images", "tra_sua", Anh ?? "");
                if (File.Exists(imgPath))
                    pictureBox9.Image = Image.FromFile(imgPath);
            }
            catch { }
        }

        // ===================== Load event =====================
        private void product_item_order_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += (s, ev) => UpdateThanhTien();
            size_comboBox1.SelectedIndexChanged += (s, ev) => UpdateThanhTien();
        }

        // ===================== Cập nhật thành tiền =====================
        private void UpdateThanhTien()
        {
            try
            {
                int soLuong = int.TryParse(textBox1.Text, out var sl) && sl > 0 ? sl : 1;

                decimal sizePhuThu = 0;
                if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selectedSize)
                    sizePhuThu = selectedSize.PhuThu;

                decimal tienGiamMotSP = Gia * phantramgiam / 100;
                decimal tienGiamTong = tienGiamMotSP * soLuong;
                decimal thanhTien = ((Gia + sizePhuThu) * soLuong) - tienGiamTong;

                label26.Text = tienGiamTong.ToString("N0");
                thanhtien_lb.Text = thanhTien.ToString("N0");

                ThanhTienChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                thanhtien_lb.Text = Gia.ToString("N0");
            }
        }

        // ===================== Popup 3 chấm =====================
        private void three_dots_label_Click(object sender, EventArgs e)
        {
            popup.Show(three_dots_label, new Point(0, three_dots_label.Height));
        }

        // ===================== Hủy sản phẩm (hoàn nguyên liệu tạm) =====================
        private async void huy_Click(object sender, EventArgs e)
        {
            try
            {
                var parentForm = this.FindForm() as OrderForm;
                if (parentForm == null) return;

                var ctService = new CTCongThucService();
                var dsCongThuc = await ctService.GetChiTietCongThucTheoSPAsync(SanPhamId);

                // Cộng lại nguyên liệu đã dùng tạm
                foreach (var ct in dsCongThuc)
                {
                    var dict = parentForm.GetNguyenLieuDaDungTam();
                    if (dict.ContainsKey(ct.MaNL))
                    {
                        dict[ct.MaNL] -= ct.SoLuongCanDung * slCu;
                        if (dict[ct.MaNL] <= 0)
                            dict.Remove(ct.MaNL);
                    }
                }

                // Báo cập nhật lại toàn bộ danh sách
                OnOrderUpdated?.Invoke(this, EventArgs.Empty);

                // Xóa khỏi giao diện
                this.Parent?.Controls.Remove(this);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn nguyên nguyên liệu: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== Ô nhập số lượng ====================
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == "0")
                textBox1.Text = "1";
        }

        // Khi thay đổi số lượng
        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox1.Text, out int slMoi) || slMoi <= 0)
                    slMoi = 1;

                await CapNhatNguyenLieuTheoSoLuongMoi(slMoi);

                UpdateThanhTien();
                OnOrderUpdated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số lượng: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== Cập nhật nguyên liệu tạm theo SL mới =====================
        private async Task CapNhatNguyenLieuTheoSoLuongMoi(int slMoi)
        {
            var parentForm = this.FindForm() as OrderForm;
            if (parentForm == null) return;

            var dict = parentForm.GetNguyenLieuDaDungTam();
            var ctService = new CTCongThucService();
            var dsCongThuc = await ctService.GetChiTietCongThucTheoSPAsync(SanPhamId);

            int chenhLech = slMoi - slCu;

            if (chenhLech != 0)
            {
                foreach (var ct in dsCongThuc)
                {
                    if (dict.ContainsKey(ct.MaNL))
                        dict[ct.MaNL] += ct.SoLuongCanDung * chenhLech;
                    else
                        dict[ct.MaNL] = ct.SoLuongCanDung * chenhLech;

                    if (dict[ct.MaNL] < 0)
                        dict[ct.MaNL] = 0;
                }

                slCu = slMoi;
                OnOrderUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        // ===================== Topping =====================
        private void Topping_Click(object sender, EventArgs e)
        {
            var tp = new ToppingForm(this);

            tp.OnToppingConfirmed += (s, toppings) =>
            {
                DSTopping = toppings;
                CapNhatThanhTienTheoTopping();
                OnOrderUpdated?.Invoke(this, EventArgs.Empty);
            };

            tp.ShowDialog();
        }

        private void CapNhatThanhTienTheoTopping()
        {
            decimal tongTopping = DSTopping.Sum(t => t.gia);

            decimal sizePhuThu = 0;
            if (size_comboBox1.SelectedItem is MilkTea.Client.Models.Size selectedSize)
                sizePhuThu = selectedSize.PhuThu;

            int soLuong = int.TryParse(textBox1.Text, out var sl) ? sl : 1;
            decimal tienGiamMotSP = Gia * phantramgiam / 100;
            decimal tienGiamTong = tienGiamMotSP * soLuong;
            decimal thanhTien = ((Gia + sizePhuThu + tongTopping) * soLuong) - tienGiamTong;

            thanhtien_lb.Text = thanhTien.ToString("N0");
            ThanhTienChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
