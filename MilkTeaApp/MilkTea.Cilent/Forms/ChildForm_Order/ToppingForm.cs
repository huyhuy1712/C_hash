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
            _allNguyenLieu = listNL.ToList(); // lưu danh sách dữ liệu gốc

            HienThiNguyenLieu(_allNguyenLieu);
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
    }
}
