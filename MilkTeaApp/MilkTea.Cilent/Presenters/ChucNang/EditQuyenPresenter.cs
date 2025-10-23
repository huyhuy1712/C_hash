using MilkTea.Client.Interfaces;
using MilkTea.Client.Services;
using System.Diagnostics;

namespace MilkTea.Client.Presenters.ChucNang
{
    public class EditQuyenPresenter
    {
        public IBaseForm _form;
        private readonly ChucNangService _chucNangService = new();
        public EditQuyenPresenter(IBaseForm form)
        {
            _form = form;
        }
        public async Task LoadDataAsync(string id)
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
    }
}
