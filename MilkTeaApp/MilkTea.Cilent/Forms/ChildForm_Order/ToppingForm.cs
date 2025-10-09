using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class ToppingForm : Form
    {
        private readonly product_item_order _sanphamHienTai;
        private List<NguyenLieu> _allNguyenLieu = new List<NguyenLieu>();
        private readonly NguyenLieuService _nguyenLieuService;

        public event EventHandler<List<Topping>> OnToppingConfirmed;

        public ToppingForm(product_item_order sanpham)
        {
            InitializeComponent();
            _sanphamHienTai = sanpham;
            _nguyenLieuService = new NguyenLieuService();
            this.Load += FormLoad;
        }

        // ================== class lưu trạng thái topping ===================
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
                        GiaTriCombo = BuildComboFromPrice(t.MaNL, t.gia)
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

                // Khôi phục trạng thái cũ nếu có
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
            decimal tong = topping_table_panel.Controls.OfType<Toppingitem>().Sum(item => item.GetGiaTopping());
            total_label.Text = $"{tong:N0} VND";
        }

        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================== XÁC NHẬN CHỌN TOPPING ===================
        private async void XacNhan_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedToppings = new List<Topping>();

                // 🔹 Lấy form cha (OrderForm) để cập nhật dictionary tạm
                var parentForm = _sanphamHienTai.FindForm() as OrderForm;
                if (parentForm == null)
                {
                    MessageBox.Show("Không tìm thấy form OrderForm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dict = parentForm.GetNguyenLieuDaDungTam();

                foreach (Toppingitem item in topping_table_panel.Controls.OfType<Toppingitem>())
                {
                    if (item.IsChecked())
                    {
                        var nl = item.GetData();

                        // Xác định số gram topping theo % (quy tắc)
                        decimal gramToTru = 0;
                        string comboValue = item.GetSelectedComboText();

                        if (comboValue.Contains("25%")) gramToTru = 3;
                        else if (comboValue.Contains("50%")) gramToTru = 10;
                        else if (comboValue.Contains("75%")) gramToTru = 20;

                        // ✅ Cập nhật vào dictionary tạm thay vì DB
                        if (dict.ContainsKey(nl.MaNL))
                            dict[nl.MaNL] += gramToTru;
                        else
                            dict[nl.MaNL] = gramToTru;

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

                // Gửi danh sách topping về lại product_item_order
                OnToppingConfirmed?.Invoke(this, selectedToppings);

                // Báo cập nhật lại OrderForm (SL mua được)
                _sanphamHienTai?.RaiseOrderUpdated();

                MessageBox.Show("Đã chọn topping",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận topping: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== Xây chuỗi combo theo giá ===================
        private string BuildComboFromPrice(int maNL, decimal gia)
        {
            var nl = _allNguyenLieu.FirstOrDefault(x => x.MaNL == maNL);
            if (nl == null) return "";

            if (gia == nl.GiaBan) return $"25% - {nl.GiaBan:N0} VND";
            if (gia == nl.GiaBan * 2) return $"50% - {(nl.GiaBan * 2):N0} VND";
            if (gia == nl.GiaBan * 3) return $"75% - {(nl.GiaBan * 3):N0} VND";

            return $"25% - {nl.GiaBan:N0} VND";
        }


    }

}
