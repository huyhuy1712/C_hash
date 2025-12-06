using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class EditQuyenPresenter
    {
        public IEditQuyen _form;

        private readonly ChucNangService _chucNangService = new();
        private readonly QuyenChucNangService _quyenChucNangService = new();
        private readonly QuyenService _quyenService = new();

        private List<ChucNang> listChucNang;
        private List<ChucNang> listCurrentChucNang;

        public EditQuyenPresenter(IEditQuyen form)
        {
            _form = form;
        }

        private int load(List<ChucNang> data, List<ChucNang> data2)
        {
            int count = 0;
            _form.Grid.Rows.Clear();

            foreach (var cn in data)
            {
                int rowIndex = _form.Grid.Rows.Add();
                count++;

                _form.Grid.Rows[rowIndex].Cells["id"].Value = cn.MaChucNang;
                _form.Grid.Rows[rowIndex].Cells["tenChucNang"].Value = cn.TenChucNang;

                if (data2.Any(x => x.MaChucNang == cn.MaChucNang))
                {
                    _form.Grid.Rows[rowIndex].Cells["chkChucNang"].Value = 1;
                }
            }
            return count;
        }

        public async Task LoadDataAsync(string id, string tenQuyen)
        {
            var dataGridView1 = _form.Grid;
            var lbl = _form.LblStatus;

            lbl.ForeColor = Color.Gray;
            lbl.Text = "🔄 Đang tải dữ liệu...";

            try
            {
                listChucNang = await _chucNangService.GetChucNangsAsync();
                listCurrentChucNang = await _chucNangService.GetChucNangsByMaQuyenAsync(Convert.ToInt32(id));

                dataGridView1.Rows.Clear();
                _form.Txtb.Text = tenQuyen;

                //Load all chuc nang
                if (listChucNang != null && listChucNang.Any())
                {
                    int Count = load(listChucNang, listCurrentChucNang);

                    lbl.ForeColor = Color.ForestGreen;
                    lbl.Text = $"✅ Đã tải {Count} chức năng.";
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
                int value = Convert.ToInt32(row.Cells["chkChucNang"].Value);
                if (value == 1)
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    list.Add(id);
                }
            }

            return list;
        }

        public void SearchChucNangTheoTen(string column, string keyword)
        {
            foreach (DataGridViewRow row in _form.Grid.Rows)
            {
                if (row.Cells[column].Value != null &&
                    row.Cells[column].Value.ToString().ToLower().Contains(keyword))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
        public async Task<bool> UpdateRoleAsync(int id, string tenQuyen)
        {
            // Validate tên quyền
            if (string.IsNullOrEmpty(tenQuyen))
            {
                _form.Error.SetError(_form.Txtb, "Tên quyền không được để trống.");
                _form.Txtb.Focus();
                return false;
            }

            Quyen q = new()
            {
                MaQuyen = id,
                TenQuyen = tenQuyen,
                Mota = "123",
                TrangThai = 1
            };

            try
            {
                // Kiểm tra có quyền chức năng để xóa không
                var existingChucNangs = await _quyenChucNangService.GetQuyenChucNangById(q.MaQuyen);

                if (existingChucNangs != null)
                {
                    // Xoá tất cả quyền chức năng hiện tại của quyền
                    await _quyenChucNangService.DeleteAllQuyenChucNangAsync(q.MaQuyen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá quyền chức năng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Lấy các chức năng được chọn
            List<int> selected = GetSelectedChucNangs();

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
                    MessageBox.Show("Lỗi khi thêm quyền chức năng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }


            // Cập nhật thông tin quyền
            try
            {
                await _quyenService.UpdateQuyenAsync(q);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa quyền! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            MessageBox.Show("Đã sửa quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
}
