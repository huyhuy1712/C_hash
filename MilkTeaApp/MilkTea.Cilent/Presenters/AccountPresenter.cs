using MilkTea.Client.Forms;
using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class AccountPresenter
    {
        private readonly TaiKhoanService _taiKhoanService;
        private readonly IAccountForm _form;
        public AccountPresenter(IAccountForm form, TaiKhoanService taiKhoanService)
        {
            _form = form;
            _taiKhoanService = taiKhoanService;
        }
        public void EditAccount(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            using (var frm = new EditAccountForm())
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
            if (string.IsNullOrEmpty(id)) return;

            using (var frm = new ViewAccountForm())
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
            var dataGridView1 = _form.GridTaiKhoan;

            try
            {
                var listTaiKhoan = await _taiKhoanService.GetAccountsAsync();
                dataGridView1.Rows.Clear();
                if (listTaiKhoan != null && listTaiKhoan.Any())
                {
                    foreach (var tk in listTaiKhoan)
                    {
                        int rowIndex = dataGridView1.Rows.Add();
                        dataGridView1.Rows[rowIndex].Cells["ID"].Value = tk.MaTK;
                        dataGridView1.Rows[rowIndex].Cells["taiKhoan"].Value = tk.TenTaiKhoan;
                        dataGridView1.Rows[rowIndex].Cells["hoVaTen"].Value = tk.anh ?? "";
                        dataGridView1.Rows[rowIndex].Cells["trangThai"].Value = tk.TrangThai == 1 ? "Hoạt động" : "Khóa";
                        dataGridView1.Rows[rowIndex].Cells["ngayTao"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                        dataGridView1.Rows[rowIndex].Cells["quyen"].Value = tk.MaQuyen;
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu tài khoản để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
    }
}