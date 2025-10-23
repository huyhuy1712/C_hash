using MilkTea.Client.Interfaces;
using MilkTea.Client.Services;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class EditQuyenPresenter
    {
        public IBaseForm _form;
        private readonly ChucNangService _chucNangService = new();
        public EditQuyenPresenter(IBaseForm form)
        {
            _form = form;
        }
        public async Task LoadDataAsync(String id)
        {
            var grid = _form.Grid;
            var lbl = _form.LblStatus;

            lbl.ForeColor = Color.Gray;
            lbl.Text = "🔄 Đang tải dữ liệu...";

            var dataGridView1 = _form.Grid;
            try
            {
                var listChucNang = await _chucNangService.GetChucNangsByMaQuyenAsync(id);
                dataGridView1.Rows.Clear();

                if (listChucNang != null && listChucNang.Any())
                {
                    foreach (var cn in listChucNang)
                    {
                        int rowIndex = dataGridView1.Rows.Add();

                        dataGridView1.Rows[rowIndex].Cells["id"].Value = cn.MaChucNang;
                        dataGridView1.Rows[rowIndex].Cells["tenChucNang"].Value = cn.TenChucNang;
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
                Console.WriteLine("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
    }
}
