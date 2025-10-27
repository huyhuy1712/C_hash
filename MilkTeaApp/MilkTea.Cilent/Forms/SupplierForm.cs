﻿using MilkTea.Client.Forms.ChildForm_Import;
using MilkTea.Client.Forms.ChildForm_Supplier;
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

namespace MilkTea.Client.Forms
{
    public partial class SupplierForm : Form
    {
        private readonly NhaCungCapService _nhaCungCapService;
        public SupplierForm()
        {
            InitializeComponent();
            _nhaCungCapService = new NhaCungCapService();
            InitializeSearchComboBox();
        }

        private void InitializeSearchComboBox()
        {
            //Khởi tạo ComboBox với các cột tìm kiếm
            cbo_timkiemtheo_NCC.Items.AddRange(new object[] { "Tên nhà cung cấp", "Số điện thoại", "Địa chỉ" });
            cbo_timkiemtheo_NCC.SelectedIndex = 0; // Chọn mục đầu tiên làm mặc định
        }

        public async Task LoadNhaCungCaps()
        {
            try
            {
                var nhaCungCaps = await _nhaCungCapService.GetNhaCungCapAsync();

                dGV_nhacungcap.Rows.Clear();

                var phieuNhapsActive = nhaCungCaps?.Where(ncc => ncc.TrangThai == 1).ToList();
                if (phieuNhapsActive != null && phieuNhapsActive.Any())
                {
                    foreach (var ncc in phieuNhapsActive)
                    {
                        int rowIndex = dGV_nhacungcap.Rows.Add();
                        dGV_nhacungcap.Rows[rowIndex].Cells["ma_Tb_NCC"].Value = ncc.MaNCC;
                        dGV_nhacungcap.Rows[rowIndex].Cells["ten_Tb_NCC"].Value = ncc.TenNCC;
                        dGV_nhacungcap.Rows[rowIndex].Cells["sdt_Tb_NCC"].Value = ncc.SDT;
                        dGV_nhacungcap.Rows[rowIndex].Cells["diachi_Tb_NCC"].Value = ncc.DiaChi;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phiếu nhập để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Them_NCC_Click(object sender, EventArgs e)
        {
            SupplierForm_ADD_EDIT form = new SupplierForm_ADD_EDIT();
            form.ShowDialog();
        }

        private async void SupplierForm_Load(object sender, EventArgs e)
        {
            await LoadNhaCungCaps();
        }

        private void txt_Timkiem_NCC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txt_Timkiem_NCC.Text.Trim().ToLower();
                string selectedColumn = cbo_timkiemtheo_NCC.SelectedItem?.ToString();

                // Xác định cột trong DataGridView để tìm kiếm
                string columnName;
                switch (selectedColumn)
                {
                    case "Tên nhà cung cấp":
                        columnName = "ten_Tb_NCC";
                        break;
                    case "Số điện thoại":
                        columnName = "sdt_Tb_NCC";
                        break;
                    case "Địa chỉ":
                        columnName = "diachi_Tb_NCC";
                        break;
                    default:
                        return;
                }

                int visibleRowCount = 0;
                // Lọc các hàng trong DataGridView

                foreach (DataGridViewRow row in dGV_nhacungcap.Rows)
                {
                    if (row.Cells[columnName].Value != null)
                    {
                        string cellValue = row.Cells[columnName].Value.ToString().ToLower();
                        // Hiển thị hàng nếu giá trị trong ô chứa chuỗi tìm kiếm
                        row.Visible = cellValue.Contains(searchValue);
                        if (row.Visible)
                        {
                            visibleRowCount++;
                        }
                    }
                    else
                    {
                        //row.Visible = false;
                        lblStatus_PN.ForeColor = Color.Red;
                        lblStatus_PN.Text = "Không tìm thấy kết quả phù hợp.";
                    }
                }
                if (visibleRowCount == 0)
                {
                    lblStatus_PN.ForeColor = Color.Red;
                    lblStatus_PN.Text = "Không tìm thấy kết quả tìm kiếm";
                }
                else
                {
                    lblStatus_PN.ForeColor = Color.Transparent;
                    lblStatus_PN.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dGV_nhacungcap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc chỉ số không hợp lệ
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dGV_nhacungcap.Columns[e.ColumnIndex].Name;

            try
            {
                // Lấy mã phiếu nhập từ cột ẩn hoặc cột mã
                var maNCCCell = dGV_nhacungcap.Rows[e.RowIndex].Cells["ma_Tb_NCC"].Value;
                if (maNCCCell == null || !int.TryParse(maNCCCell.ToString(), out int maPN))
                {
                    MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Click vào cột "Thông Tin"
                if (columnName == "sua_Tb_NCC")
                {
                    using (var frm = new ImportForm_Info(maPN))
                    {
                        frm.ShowDialog();
                    }
                    // Tùy chọn: reload nếu form chi tiết có thể sửa dữ liệu
                    // await LoadPhieuNhaps();
                }

                // 2. Click vào cột "Xóa"
                else if (columnName == "xoa_Tb_NCC")
                {
                    var result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa phiếu nhập mã {maPN}?\n(Dữ liệu sẽ được ẩn và không thể hoàn tác dễ dàng)",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool success = await _nhaCungCapService.SoftDeleteAsync(maPN);

                        if (success)
                        {
                            MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadNhaCungCaps();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa phiếu nhập (có thể đã bị xóa trước đó).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
