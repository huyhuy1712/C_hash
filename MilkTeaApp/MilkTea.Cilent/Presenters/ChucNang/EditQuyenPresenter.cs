using MilkTea.Client.Interfaces;
using MilkTea.Client.Services;
using System.Diagnostics;
using MilkTea.Client.Models;

namespace MilkTea.Client.Presenters
{
    public class EditQuyenPresenter
    {
        public IEditQuyen _form;

        private readonly ChucNangService _chucNangService = new();
        private readonly QuyenChucNangService _quyenChucNangService = new();
        private readonly QuyenService _quyenService = new();

        public EditQuyenPresenter(IEditQuyen form)
        {
            _form = form;
        }
        public async Task LoadDataAsync(string id, string tenQuyen)
        {
            var dataGridView1 = _form.Grid;
            var lbl = _form.LblStatus;

            lbl.ForeColor = Color.Gray;
            lbl.Text = "🔄 Đang tải dữ liệu...";

            try
            {
                var listChucNang = await _chucNangService.GetChucNangsAsync();
                var listCurrentChucNang = await _chucNangService.GetChucNangsByMaQuyenAsync(Convert.ToInt32(id));

                dataGridView1.Rows.Clear();
                _form.Txtb.Text = tenQuyen;

                //Load all chuc nang
                if (listChucNang != null && listChucNang.Any())
                {
                    foreach (var cn in listChucNang)
                    {
                        int rowIndex = dataGridView1.Rows.Add();

                        dataGridView1.Rows[rowIndex].Cells["id"].Value = cn.MaChucNang;
                        dataGridView1.Rows[rowIndex].Cells["tenChucNang"].Value = cn.TenChucNang;

                        if (listCurrentChucNang.Any(x => x.MaChucNang == cn.MaChucNang))
                        {
                            dataGridView1.Rows[rowIndex].Cells["chkChucNang"].Value = 1;
                        }
                    }
                    lbl.ForeColor = Color.ForestGreen;
                    lbl.Text = $"✅ Đã tải {listChucNang.Count} chức năng.";
                }
                else
                {
                    lbl.ForeColor = Color.DarkOrange;
                    lbl.Text = "⚠️ Không có dữ liệu chức năng để hiển thị.";
                }

            }
            catch (Exception ex)
            {
                lbl.ForeColor = Color.IndianRed;
                lbl.Text = "❌ Không thể tải dữ liệu. Vui lòng thử lại sau.";
                Debug.WriteLine("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        public List<int> GetSelectedChucNangs()
        {
            var list = new List<int>();
            var datagridview1 = _form.Grid;

            foreach (DataGridViewRow row in _form.Grid.Rows)
            {
                bool value = Convert.ToBoolean(row.Cells["chkChucNang"].Value);
                if (value)
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    list.Add(id);
                }
            }

            return list;
        }

        public async Task SaveAsync()
        {
        }

        public async Task<bool> UpdateRoleAsync(Quyen q, List<int> selected)
        {
            // Validate tên quyền
            if (string.IsNullOrEmpty(q.TenQuyen))
            {
                _form.error.SetError(_form.Txtb, "Tên quyền không được để trống.");
                return false;
            }

            // Xoá tất cả quyền chức năng hiện tại của quyền
            try
            {
                await _quyenChucNangService.DeleteAllQuyenChucNangAsync(q.MaQuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá quyền chức năng: " + ex.Message);
            }

            // Thêm lại các quyền chức năng được chọn
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
                    MessageBox.Show("Lỗi khi thêm quyền chức năng: " + ex.Message);
                }
            }


            // Cập nhật thông tin quyền
            await _quyenService.UpdateQuyenAsync(q);
            return true;
        }
    }
}
