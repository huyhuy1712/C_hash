using MilkTea.Client.Interfaces;
using MilkTea.Client.Presenters;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class DanhSachQuyenForm : Form, IBaseForm
    {
        private readonly QuyenPresenter _presenter;
        public DataGridView Grid => dataGridView1;
        public Label LblStatus => lblStatus;
        private readonly QuyenService _quyenService = new();
        public DanhSachQuyenForm()
        {
            InitializeComponent();
            _presenter = new QuyenPresenter(this, new QuyenService());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void DanhSachQuyenForm_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellClick;
            await _presenter.LoadDataAsync();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // bỏ qua header

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value?.ToString();

            switch (columnName)
            {
                case "sua":
                    _presenter.EditQuyen(id);
                    break;

                case "xoa":
                    _presenter.DeleteQuyen(id);
                    break;
            }
        }

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            var frm = new AddQuyenForm();
            frm.ShowDialog();
        }
    }
}
