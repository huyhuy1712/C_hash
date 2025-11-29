using MilkTea.Client.Forms.ChildForm_Account;
using MilkTea.Client.Forms.ChildForm_Account.Account;
using MilkTea.Client.Interfaces;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Presenters
{
    public class AccountPresenter
    {
        private readonly AccountService _taiKhoanService = new();
        private readonly NhanVienService _nhanVienService = new();
        private readonly QuyenService _quyenService = new();
        private readonly IBaseForm _form;

        private List<TaiKhoan> listTaiKhoan;
        private List<Quyen> listQuyen;
        private List<NhanVien> listNhanVien;

        public AccountPresenter(IBaseForm form)
        {
            _form = form;
        }
        public void EditAccount(string id)
        {
            using (var frm = new EditAccountForm(id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi form con OK → load lại danh sách
                    _ = LoadDataAsync();
                }
            }
        }

        public void ViewAccount(string id)
        {
            using (var frm = new ViewAccountForm(id))
            {
                frm.ShowDialog();
            }
        }

        public async Task LockAccount(string id)
        {
            TaiKhoan tk = null;
            try
            {
                tk = await _taiKhoanService.GetAccountsByIdAsync(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin tài khoản!\n" + ex.Message);
            }

            if (tk != null)
            {
                if (tk.TrangThai == 1)
                {
                    tk.TrangThai = 0;
                }
                else
                {
                    tk.TrangThai = 1;
                }
                try
                {
                    await _taiKhoanService.UpdateAccountsAsync(tk);
                    foreach (DataGridViewRow row in _form.Grid.Rows)
                    {
                        if (row.Cells["ID"].Value != null &&
                            Convert.ToInt32(row.Cells["ID"].Value) == tk.MaTK)
                        {
                            if (tk.TrangThai == 1)
                            {
                                row.Cells["trangThai"].Value = "Hoạt động";
                                row.Cells["trangThai"].Style.ForeColor = Color.Green;
                            }
                            else
                            {
                                row.Cells["trangThai"].Value = "Khóa";
                                row.Cells["trangThai"].Style.ForeColor = Color.Red;
                            }
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái!\n" + ex.Message);
                }
            }
        }

        public async Task LoadDataAsync()
        {
            var grid = _form.Grid;
            var lbl = _form.LblStatus;

            lbl.ForeColor = Color.Gray;
            lbl.Text = "🔄 Đang tải dữ liệu...";

            var dataGridView1 = _form.Grid;
            try
            {
                listTaiKhoan = await _taiKhoanService.GetAccountsAsync();
                listNhanVien = await _nhanVienService.GetNhanVienAsync();
                listQuyen = await _quyenService.GetQuyensAsync();

                dataGridView1.Rows.Clear();
                if (listTaiKhoan != null && listTaiKhoan.Any())
                {
                    foreach (var tk in listTaiKhoan)
                    {
                        var nv = listNhanVien.FirstOrDefault(n => n.MaTK == tk.MaTK);
                        var q = listQuyen.FirstOrDefault(quyen => quyen.MaQuyen == tk.MaQuyen);

                        int rowIndex = dataGridView1.Rows.Add();

                        dataGridView1.Rows[rowIndex].Cells["ID"].Value = tk.MaTK;
                        dataGridView1.Rows[rowIndex].Cells["taiKhoan"].Value = tk.TenTaiKhoan;

                        dataGridView1.Columns[2].DefaultCellStyle.Font = new Font(
                        dataGridView1.Font, // giữ font mặc định của DataGridView
                        FontStyle.Bold      // chuyển sang Bold
                        );
                        if (tk.TrangThai == 1)
                        {
                            dataGridView1.Rows[rowIndex].Cells["trangThai"].Value = "Hoạt động";
                            dataGridView1.Rows[rowIndex].Cells["trangThai"].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            dataGridView1.Rows[rowIndex].Cells["trangThai"].Value = "Khóa";
                            dataGridView1.Rows[rowIndex].Cells["trangThai"].Style.ForeColor = Color.Red;
                        }

                        dataGridView1.Rows[rowIndex].Cells["quyen"].Value = q.TenQuyen;
                    }
                    lbl.ForeColor = Color.ForestGreen;
                    lbl.Text = $"✅ Đã tải {listTaiKhoan.Count} tài khoản.";
                }
                else
                {
                    lbl.ForeColor = Color.DarkOrange;
                    lbl.Text = "⚠️ Không có dữ liệu tài khoản để hiển thị.";
                }
            }
            catch (Exception ex)
            {
                lbl.ForeColor = Color.IndianRed;
                lbl.Text = "❌ Không thể tải dữ liệu. Vui lòng thử lại sau.";
                Debug.WriteLine("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }
    }
}