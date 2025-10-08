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
        private readonly IQuyenForm _form;

        public QuyenPresenter(IQuyenForm form, QuyenService quyenService)
        {
            _form = form;
            _quyenService = quyenService;
        }

        public async Task LoadDataAsync()
        {
            var grid = _form.GridQuyen;
            try
            {
                var listQuyen = await _quyenService.GetQuyensAsync();
                grid.Rows.Clear();
                if (listQuyen != null && listQuyen.Any())
                {
                    foreach (var q in listQuyen)
                    {
                        int rowIndex = grid.Rows.Add();
                        grid.Rows[rowIndex].Cells["tenQuyen"].Value = q.TenQuyen;
                        // Th�m c�c tr??ng kh�c n?u c?n
                    }
                }
                else
                {
                    MessageBox.Show("Kh�ng c� d? li?u quy?n ?? hi?n th?.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi load d? li?u: " + ex.Message);
            }
        }
    }
}