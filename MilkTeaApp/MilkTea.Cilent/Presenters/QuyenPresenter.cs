using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class QuyenPresenter
    {
        private readonly QuyenService _quyenService;
        private readonly IBaseForm _form;

        public QuyenPresenter(IBaseForm form, QuyenService quyenService)
        {
            _form = form;
            _quyenService = quyenService;
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
        public void EditQuyen(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            using (var frm = new EditQuyenForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi form con OK → load lại danh sách
                    _ = LoadDataAsync();
                }
            }
        }
        public void ViewQuyen(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            using (var frm = new DanhSachQuyenForm())
            {
                frm.ShowDialog();
            }
        }

        public void DeleteQuyen(string id)
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
    }
}