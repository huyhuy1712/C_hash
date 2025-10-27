using MilkTea.Client.Interfaces;
using MilkTea.Client.Services;

namespace MilkTea.Client.Presenters
{
    public class AddQuyenPresenter
    {
        private readonly ChucNangService _chucNangService;
        private readonly IBaseForm _form;

        public AddQuyenPresenter(IBaseForm form, ChucNangService chucNangService)
        {
            _form = form;
            _chucNangService = chucNangService;
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
    }
}