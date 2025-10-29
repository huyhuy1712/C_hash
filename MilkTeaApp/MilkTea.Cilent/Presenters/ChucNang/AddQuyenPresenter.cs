using MilkTea.Client.Interfaces;
using MilkTea.Client.Services;
using MilkTea.Client.Models;
using System.Diagnostics;

namespace MilkTea.Client.Presenters
{
    public class AddQuyenPresenter
    {
        private readonly ChucNangService _chucNangService = new();
        private readonly QuyenChucNangService _quyenChucNangService = new();
        private readonly QuyenService _quyenService = new();
        private readonly IAddQuyen _form;

        public AddQuyenPresenter(IAddQuyen form)
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
                var listChucNang = await _chucNangService.GetChucNangsAsync();

                if (listChucNang != null)
                {
                    dataGridView1.Rows.Clear();

                    foreach (var q in listChucNang)
                    {
                        int rowIndex = dataGridView1.Rows.Add();

                        dataGridView1.Rows[rowIndex].Cells["ID"].Value = q.MaChucNang;
                        dataGridView1.Rows[rowIndex].Cells["chucNang"].Value = q.TenChucNang;
                    }
                    lblStatus.ForeColor = Color.ForestGreen;
                    lblStatus.Text = $"✅ Đã tải {listChucNang.Count} Chức Năng.";
                }

                else
                {
                    dataGridView1.Rows.Clear();
                    lblStatus.ForeColor = Color.DarkOrange;
                    lblStatus.Text = "⚠️ Không có dữ liệu chức năng để hiển thị.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        public List<int> GetSelectedChucNangs()
        {
            var list = new List<int>();
            var datagridview1 = _form.Grid;

            foreach (DataGridViewRow row in _form.Grid.Rows)
            {
                int value = Convert.ToInt32(row.Cells["chkChucNang"].Value);
                if (value == 1)
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    list.Add(id);
                }
            }

            return list;
        }

        public async Task<bool> SaveAsync(string tenQuyen)
        {
            // Validate tên quyền
            if (string.IsNullOrEmpty(tenQuyen))
            {
                _form.Error.SetError(_form.Rtxtb, "Tên quyền không được để trống.");
                _form.Rtxtb.Focus();
                return false;
            }

            Quyen q = new();
            q.TenQuyen = tenQuyen;
            q.TrangThai = 1;
            q.Mota = "123";

            // Thêm quyền mới và lấy id được tạo
            try
            {
                q.MaQuyen = await _quyenService.AddQuyenAsync(q);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm quyền: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Lấy các chức năng được chọn
            List<int> selected = GetSelectedChucNangs();

            // Thêm mới các quyền chức năng được chọn
            foreach (var c in selected)
            {
                Quyen_ChucNang qc = new();
                qc.MaChucNang = c;
                qc.MaQuyen = q.MaQuyen;

                try
                {
                    await _quyenChucNangService.AddQuyenChucNangAsync(qc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm quyền chức năng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            MessageBox.Show("Đã thêm quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
}