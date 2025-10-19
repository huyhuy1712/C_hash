using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class ChucNangPresenter
    {
        private readonly ChucNangService _chucNangService;
        private readonly IChucNangForm _form;

        public ChucNangPresenter(IChucNangForm form, ChucNangService chucNangService)
        {
            _form = form;
            _chucNangService = chucNangService;
        }

        public async Task LoadDataAsync()
        {
            var grid = _form.GridChucNang;
            try
            {
                var listChucNang = await _chucNangService.GetChucNangsAsync();
                grid.Rows.Clear();
                if (listChucNang != null && listChucNang.Any())
                {
                    foreach (var cn in listChucNang)
                    {
                        int rowIndex = grid.Rows.Add();
                        grid.Rows[rowIndex].Cells["tenChucNang"].Value = cn.TenChucNang;
                        // Thêm các trường khác nếu cần
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu chức năng để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
    }
}