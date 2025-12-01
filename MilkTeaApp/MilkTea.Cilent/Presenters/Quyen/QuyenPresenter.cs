using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using MilkTea.Server.Models;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class QuyenPresenter
    {
        private readonly QuyenService _quyenService = new();
        private readonly AccountService _accountService = new();
        private readonly IBaseForm _form;
        private List<Quyen> listQuyen;

        public QuyenPresenter(IBaseForm form)
        {
            _form = form;
        }

        public int load(List<Quyen> data)
        {
            _form.Grid.Rows.Clear();
            int count = 0;

            foreach (var q in data)
            {
                if (q.TrangThai == 1)
                {
                    int rowIndex = _form.Grid.Rows.Add();
                    count++;

                    _form.Grid.Rows[rowIndex].Cells["ID"].Value = q.MaQuyen;
                    _form.Grid.Rows[rowIndex].Cells["tenQuyen"].Value = q.TenQuyen;
                }
            }
            return count;
        }


        public async Task LoadDataAsync()
        {
            var lblStatus = _form.LblStatus;

            lblStatus.ForeColor = Color.Gray;
            lblStatus.Text = "🔄 Đang tải dữ liệu...";

            try
            {
                listQuyen = await _quyenService.GetQuyensAsync();

                if (listQuyen != null)
                {
                    int count = load(listQuyen);
                    lblStatus.ForeColor = Color.ForestGreen;
                    lblStatus.Text = $"✅ Đã tải {count} Quyền.";
                }
                else
                {
                    _form.Grid.Rows.Clear();
                    lblStatus.ForeColor = Color.DarkOrange;
                    lblStatus.Text = "⚠️ Không có dữ liệu quyền để hiển thị.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        public void AddQuyen()
        {
            using (var frm = new AddQuyenForm())
                frm.ShowDialog();
        }

        public void EditQuyen(string id, string tenQuyen)
        {
            using (var frm = new EditQuyenForm(id, tenQuyen))
                frm.ShowDialog();
        }

        public async Task DeleteQuyen(string id, string tenQuyen)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                Quyen q = new();
                q.MaQuyen = Convert.ToInt32(id);
                q.TenQuyen = tenQuyen;
                q.TrangThai = 0;
                q.Mota = "123";

                List<TaiKhoan> tk;
                try
                {
                    tk = await _accountService.GetAccountsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy danh sách tài khoản! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                tk.Where(x => x.MaQuyen == q.MaQuyen).ToList();
                string list = "";
                foreach (TaiKhoan taikhoan in tk)
                {
                    list += taikhoan.TenTaiKhoan;
                    list += "\n";
                }

                if (tk.Any())
                {
                    MessageBox.Show($"Tài khoản: \n{list}Đang có quyền {q.TenQuyen}! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    await _quyenService.UpdateQuyenAsync(q);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa quyền! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Đã xóa quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchQuyenTheoTen(string keyword)
        {
            List<Quyen> filtered;

            if (string.IsNullOrWhiteSpace(keyword))
                filtered = listQuyen; // danh sách gốc
            else
                filtered = listQuyen
                    .Where(q => q.TenQuyen.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            load(filtered);
        }
    }
}