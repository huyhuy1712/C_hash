using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class ToppingForm : Form
    {
        private product_item_order _sanphamHienTai;
        private List<NguyenLieu> _allNguyenLieu = new List<NguyenLieu>();
        private readonly NguyenLieuService _nguyenLieuService;

        public event EventHandler<List<Topping>> OnToppingConfirmed;


        public ToppingForm(Controls.product_item_order sanpham)
        {
            InitializeComponent();
            _sanphamHienTai = sanpham;
            _nguyenLieuService = new NguyenLieuService();

            this.Load += FormLoad;
        }

        //  class lưu trạng thái topping khi cần refresh
        private class ToppingState
        {
            public int MaNguyenLieu { get; set; }
            public string GiaTriCombo { get; set; }
            public bool Checked { get; set; }
        }

        // ================== LOAD FORM ===================
        public async void FormLoad(object sender, EventArgs e)
        {
            label3.Text = _sanphamHienTai.TenSP;

            var listNL = await _nguyenLieuService.GetAll();
            _allNguyenLieu = listNL.ToList();

            var previous = new List<ToppingState>();

            if (_sanphamHienTai.DSTopping != null && _sanphamHienTai.DSTopping.Count > 0)
            {
                foreach (var t in _sanphamHienTai.DSTopping)
                {
                    previous.Add(new ToppingState
                    {
                        MaNguyenLieu = t.MaNL,
                        Checked = true,
                        GiaTriCombo = BuildComboFromPrice(t.MaNL, t.gia) // xác định combo từ giá
                    });
                }
            }

            HienThiNguyenLieu(_allNguyenLieu, previous);
        }


        // ================== HIỂN THỊ DANH SÁCH ===================
        private void HienThiNguyenLieu(List<NguyenLieu> danhSach, List<ToppingState> previousStates = null)
        {
            topping_table_panel.Controls.Clear();

            foreach (var item in danhSach)
            {
                var toppingItem = new Toppingitem();
                toppingItem.SetData(item);
                toppingItem.ToppingChanged += (s, e) => CapNhatTongTien();

                //  Khôi phục trạng thái nếu có
                if (previousStates != null)
                {
                    var old = previousStates.FirstOrDefault(x => x.MaNguyenLieu == item.MaNL);
                    if (old != null)
                    {
                        toppingItem.SetChecked(old.Checked);
                        toppingItem.SetSelectedComboText(old.GiaTriCombo);
                    }
                }

                toppingItem.Dock = DockStyle.Top;
                topping_table_panel.Controls.Add(toppingItem);
            }

            CapNhatTongTien();
        }

        // ================== CẬP NHẬT TỔNG TIỀN ===================
        private void CapNhatTongTien()
        {
            decimal tong = 0;

            foreach (Toppingitem item in topping_table_panel.Controls.OfType<Toppingitem>())
            {
                tong += item.GetGiaTopping();
            }

            total_label.Text = $"{tong:N0} VND";
        }

        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void XacNhan_btn_Click(object sender, EventArgs e)
        {
            try
            {
                List<Topping> selectedToppings = new List<Topping>();
                var nlService = new NguyenLieuService(); // để gọi API trừ nguyên liệu

                foreach (Toppingitem item in topping_table_panel.Controls.OfType<Toppingitem>())
                {
                    if (item.IsChecked()) // nếu topping được chọn
                    {
                        var nl = item.GetData();

                        // Xác định khối lượng topping tương ứng theo phần trăm
                        decimal gramToTru = 0;
                        string comboValue = item.GetSelectedComboText(); // vd: "25% - 1,000 VND"
                        if (comboValue.Contains("25%")) gramToTru = 3;    // 25% = 3g
                        else if (comboValue.Contains("50%")) gramToTru = 10; // 50% = 10g
                        else if (comboValue.Contains("75%")) gramToTru = 20; // 75% = 20g

                        // Trừ topping trong kho (DB)
                        await nlService.CapNhatNguyenLieuTheoToppingAsync(nl.MaNL, gramToTru);

                        // Tạo object topping để gửi về product_item_order
                        var topping = new Topping
                        {
                            MaNL = nl.MaNL,
                            ten = nl.Ten,
                            SL = nl.SoLuong,
                            gia = item.GetGiaTopping()
                        };

                        selectedToppings.Add(topping);
                    }
                }

                // Gửi danh sách topping đã chọn về product_item_order
                OnToppingConfirmed?.Invoke(this, selectedToppings);

                // Hiển thị thông báo
                MessageBox.Show("Đã chọn topping và cập nhật kho nguyên liệu!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form topping
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận topping: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string BuildComboFromPrice(int maNL, decimal gia)
        {
            var nl = _allNguyenLieu.FirstOrDefault(x => x.MaNL == maNL);
            if (nl == null) return "";

            if (gia == nl.GiaBan) return $"25% - {nl.GiaBan:N0} VND";
            if (gia == nl.GiaBan * 2) return $"50% - {(nl.GiaBan * 2):N0} VND";
            if (gia == nl.GiaBan * 3) return $"75% - {(nl.GiaBan * 3):N0} VND";

            return $"25% - {nl.GiaBan:N0} VND"; // mặc định nếu không khớp
        }

    }
}
