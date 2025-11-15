using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;

namespace MilkTea.Client.Presenters
{
    public class AccountPresenter
    {
        private readonly AccountService _taiKhoanService = new();
        private readonly NhanVienService _nhanVienService = new();
        private readonly QuyenService _quyenService = new();
        private readonly IBaseForm _form;

        private List<TaiKhoan> listTaiKhoan;
        public AccountPresenter(IBaseForm form)
        {
            _form = form;
        }
        public void EditAccount(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            using (var frm = new EditQuyentForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi form con OK → load lại danh sách
                    _ = LoadDataAsync();
                }
            }
        }

        public void ViewAccount(string id)
        {
            using (var frm = new ViewAccountForm(id))
            {
                frm.ShowDialog();
            }
        }

        public void DeleteAccount(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            if (MessageBox.Show("Bạn có thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                // TODO: Gọi API xóa
                // await _service.DeleteAccountAsync(int.Parse(id));

                MessageBox.Show("Đã xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = LoadDataAsync();
            }
        }
        public async Task LoadDataAsync()
        {
            var grid = _form.Grid;
            var lbl = _form.LblStatus;

            lbl.ForeColor = Color.Gray;
            lbl.Text = "🔄 Đang tải dữ liệu...";

            var dataGridView1 = _form.Grid;
            try
            {
                listTaiKhoan = await _taiKhoanService.GetAccountsAsync();
                var listNhanVien = await _nhanVienService.GetNhanVienAsync();
                var listQuyen = await _quyenService.GetQuyensAsync();

                dataGridView1.Rows.Clear();
                if (listTaiKhoan != null && listTaiKhoan.Any())
                {
                    foreach (var tk in listTaiKhoan)
                    {
                        var nv = listNhanVien.FirstOrDefault(n => n.MaTK == tk.MaTK);
                        var q = listQuyen.FirstOrDefault(quyen => quyen.MaQuyen == tk.MaQuyen);

                        int rowIndex = dataGridView1.Rows.Add();

                        dataGridView1.Rows[rowIndex].Cells["ID"].Value = tk.MaTK;
                        dataGridView1.Rows[rowIndex].Cells["taiKhoan"].Value = tk.TenTaiKhoan;
                        dataGridView1.Rows[rowIndex].Cells["hoVaTen"].Value = nv?.TenNV ?? "Chưa có nhân viên";
                        dataGridView1.Rows[rowIndex].Cells["trangThai"].Value = tk.TrangThai == 1 ? "Hoạt động" : "Khóa";
                        dataGridView1.Rows[rowIndex].Cells["ngayTao"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                        dataGridView1.Rows[rowIndex].Cells["quyen"].Value = q.TenQuyen;
                    }
                    lbl.ForeColor = Color.ForestGreen;
                    lbl.Text = $"✅ Đã tải {listTaiKhoan.Count} tài khoản.";
                }
                else
                {
                    lbl.ForeColor = Color.DarkOrange;
                    lbl.Text = "⚠️ Không có dữ liệu tài khoản để hiển thị.";
                }
            }
            catch (Exception ex)
            {
                lbl.ForeColor = Color.IndianRed;
                lbl.Text = "❌ Không thể tải dữ liệu. Vui lòng thử lại sau.";
                Debug.WriteLine("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
    }
}