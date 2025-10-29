using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Security.Cryptography;

namespace MilkTea.Client.Presenters
{
    public class QuyenPresenter
    {
        private readonly QuyenService _quyenService = new();
        private readonly IBaseForm _form;

        public QuyenPresenter(IBaseForm form)
        {
            _form = form;
        }

        public async Task LoadDataAsync()
        {
            var dataGridView1 = _form.Grid;
            var lblStatus = _form.LblStatus;

            lblStatus.ForeColor = Color.Gray;
            lblStatus.Text = "🔄 Đang tải dữ liệu...";

            try
            {
                var listQuyen = await _quyenService.GetQuyensAsync();

                if (listQuyen != null)
                {
                    dataGridView1.Rows.Clear();

                    foreach (var q in listQuyen)
                    {
                        int rowIndex = dataGridView1.Rows.Add();

                        dataGridView1.Rows[rowIndex].Cells["ID"].Value = q.MaQuyen;
                        dataGridView1.Rows[rowIndex].Cells["tenQuyen"].Value = q.TenQuyen;
                    }
                    lblStatus.ForeColor = Color.ForestGreen;
                    lblStatus.Text = $"✅ Đã tải {listQuyen.Count} Quyền.";
                }

                else
                {
                    dataGridView1.Rows.Clear();
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

        public async void DeleteQuyen(string id, string tenQuyen)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                Quyen q = new();
                q.MaQuyen = Convert.ToInt32(id);
                q.TenQuyen = tenQuyen;
                q.TrangThai = 0;
                q.Mota = "123";

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
    }
}