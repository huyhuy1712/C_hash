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

namespace MilkTea.Client.Forms.ChildForm_Supplier
{
    public partial class SupplierForm_ADD_EDIT : Form
    {
        private readonly NhaCungCapService _nhaCungCapService;
        private NhaCungCap? _currentNCC; // Dùng khi sửa
        private bool _isEditMode = false;

        public NhaCungCap? ResultNCC { get; private set; }

        public SupplierForm_ADD_EDIT(NhaCungCap? ncc = null)
        {
            InitializeComponent();
            _nhaCungCapService = new NhaCungCapService();
            _currentNCC = ncc;
            _isEditMode = ncc != null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (_isEditMode && _currentNCC != null)
            {
                this.Text = "Sửa nhà cung cấp";
                label1.Text = "Sửa nhà cung cấp";

                txt_ten_NCC_ADD.Text = _currentNCC.TenNCC;
                txt_sdt_NCC_ADD.Text = _currentNCC.SDT;
                txt_diachi_NCC_ADD.Text = _currentNCC.DiaChi;

                btn_them_NCC_ADD.Text = "Cập nhật";
            }
            else
            {
                this.Text = "Thêm nhà cung cấp";
                label1.Text = "Thêm nhà cung cấp";
                btn_them_NCC_ADD.Text = "Thêm";
            }
        }

        private async void btn_them_NCC_ADD_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string sdt = txt_sdt_NCC_ADD.Text.Trim();
            string tenNCC = txt_ten_NCC_ADD.Text.Trim();

            try
            {
                var allNCC = await _nhaCungCapService.GetNhaCungCapAsync();

                bool isDuplicate = allNCC.Any(n =>
                    string.Equals(n.SDT.Trim(), sdt, StringComparison.OrdinalIgnoreCase) &&
                    (!_isEditMode || n.MaNCC != _currentNCC?.MaNCC)
                );

                if (isDuplicate)
                {
                    MessageBox.Show("Nhà cung cấp có SDT này đã tồn tại!\nVui lòng nhập tên khác.",
                        "Trùng tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ten_NCC_ADD.Focus();
                    txt_ten_NCC_ADD.SelectAll();
                    return;
                }

                var ncc = new NhaCungCap
                {
                    TenNCC = tenNCC,
                    SDT = txt_sdt_NCC_ADD.Text.Trim(),
                    DiaChi = txt_diachi_NCC_ADD.Text.Trim(),
                    TrangThai = 1
                };

                if (_isEditMode && _currentNCC != null)
                {
                    ncc.MaNCC = _currentNCC.MaNCC;
                    var success = await _nhaCungCapService.UpdateAsync(ncc);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResultNCC = ncc;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    var addedNCC = await _nhaCungCapService.AddAsync(ncc);
                    if (addedNCC != null)
                    {
                        MessageBox.Show($"Thêm thành công! Mã NCC: {addedNCC.MaNCC}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResultNCC = addedNCC;
                        ClearFields();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_ten_NCC_ADD.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ten_NCC_ADD.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_sdt_NCC_ADD.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_sdt_NCC_ADD.Focus();
                return false;
            }

            if (txt_sdt_NCC_ADD.Text.Length < 10 || txt_sdt_NCC_ADD.Text.Length > 11 || !long.TryParse(txt_sdt_NCC_ADD.Text, out _))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (10-11 số).", "Lỗi định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_sdt_NCC_ADD.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txt_ten_NCC_ADD.Clear();
            txt_sdt_NCC_ADD.Clear();
            txt_diachi_NCC_ADD.Clear();
            txt_ten_NCC_ADD.Focus();
        }

        private void btn_thoat_NCC_ADD_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
