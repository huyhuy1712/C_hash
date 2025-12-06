using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class RecipeDetailForm : Form
    {
        private string tenSP;
        private int MaSP;
        private List<CTCongThucSP> danhSachNguyenLieu;
        private string oldValue = "";


        private readonly CTCongThucService _ctCongThucService = new CTCongThucService();
        public RecipeDetailForm(Models.SanPham sanPham)
        {
            InitializeComponent();
            tenSP = sanPham.TenSP;
            MaSP = sanPham.MaSP;
            form_loadAsync(this, EventArgs.Empty);

            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.CellValidating += dataGridView1_CellValidating;

            // Thêm 2 sự kiện để cập nhật số lượng sản phẩm
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;

        }

        private async Task form_loadAsync(object sender, EventArgs e)
        {
            // Lấy công thức hiện tại
            danhSachNguyenLieu = await _ctCongThucService.GetChiTietCongThucTheoIdAsync(MaSP);

            tenSP_lbl.Text = tenSP;

            // Kiểm tra danh sách trước khi truy cập chỉ mục
            if (danhSachNguyenLieu != null && danhSachNguyenLieu.Count > 0)
            {
                txtTenCongThuc.Text = danhSachNguyenLieu[0].TenCongThuc;
            }


            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // 1. Cột ComboBox "Nguyên liệu"
            DataGridViewTextBoxColumn cbNguyenLieuCol = new DataGridViewTextBoxColumn();
            cbNguyenLieuCol.HeaderText = "Nguyên liệu";
            cbNguyenLieuCol.Width = 200;
            cbNguyenLieuCol.Name = "colNguyenLieu";
            cbNguyenLieuCol.ReadOnly = true;
            dataGridView1.Columns.Add(cbNguyenLieuCol);

            // 2. Cột TextBox "Số Lượng"
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.HeaderText = "Số Lượng";
            colSoLuong.Name = "colSoLuong";
            // Đặt ReadOnly = false để cho phép nhập số (được ràng buộc bằng sự kiện ColSoLuong_KeyPress)
            colSoLuong.ReadOnly = true;
            // Nguồn dữ liệu cho ComboBox
            dataGridView1.Columns.Add(colSoLuong);

            // 3. Cột TextBox "SL tồn kho"
            DataGridViewTextBoxColumn colTonKho = new DataGridViewTextBoxColumn();
            colTonKho.HeaderText = "SL tồn kho";
            colTonKho.Name = "colTonKho";
            // Yêu cầu 2: Cột này không được sửa (chỉ đọc)
            colTonKho.ReadOnly = true;
            dataGridView1.Columns.Add(colTonKho);

            dataGridView1.Rows.Clear();

            foreach (var nl in danhSachNguyenLieu)
            {
                dataGridView1.Rows.Add(
                    nl.TenNguyenLieu,    // Cột 0: ComboBox tự chọn đúng item
                    nl.SoLuongCanDung,   // Cột 1: Số Lượng
                    nl.SoLuongTonKho     // Cột 2: SL tồn kho
                );

            }
            label6.Text = TinhSoSanPhamCoTheLam().ToString();

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colSoLuong")
            {
                oldValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString() ?? "";
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colSoLuong")
            {
                string input = e.FormattedValue.ToString();

                // Kiểm tra số nguyên dương
                if (!int.TryParse(input, out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Chỉ được nhập số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    this.BeginInvoke(new Action(() =>
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = oldValue;
                    }));
                    return;
                }

                // Lấy giá trị tồn kho của dòng đó
                int tonKho = Convert.ToInt32(dataGridView1["colTonKho", e.RowIndex].Value);

                if (soLuong > tonKho)
                {
                    MessageBox.Show($"Số lượng không được vượt quá tồn kho ({tonKho})!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    this.BeginInvoke(new Action(() =>
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = oldValue;
                    }));
                    return;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Commit giá trị để CellValueChanged được kích hoạt ngay sau đó
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ quan tâm cột "Số Lượng"
            if (e.ColumnIndex == dataGridView1.Columns["colSoLuong"].Index)
            {
                label6.Text = TinhSoSanPhamCoTheLam().ToString();
            }
        }



        private int TinhSoSanPhamCoTheLam()
        {
            int soLuongMax = int.MaxValue; // Bắt đầu với giá trị lớn

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Bỏ qua các dòng mới (nếu AllowUserToAddRows = true)
                if (row.IsNewRow) continue;

                // Lấy số lượng cần dùng và tồn kho
                if (int.TryParse(row.Cells["colSoLuong"].Value?.ToString(), out int soLuongCanDung) &&
                    int.TryParse(row.Cells["colTonKho"].Value?.ToString(), out int tonKho))
                {
                    if (soLuongCanDung <= 0) continue; // Tránh chia cho 0
                    int sanPham = tonKho / soLuongCanDung;
                    if (sanPham < soLuongMax)
                    {
                        soLuongMax = sanPham;
                    }
                }
            }

            // Nếu không có nguyên liệu hợp lệ, trả về 0
            if (soLuongMax == int.MaxValue) return 0;
            return soLuongMax;
        }


        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
