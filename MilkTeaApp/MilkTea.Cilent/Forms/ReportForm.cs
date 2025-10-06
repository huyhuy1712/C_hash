using MilkTea.Client.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MilkTea.Client.Forms
{

    public partial class ReportForm : Form
    {

        private readonly LoaiService _loaiService;

        public ReportForm()
        {
            InitializeComponent();
            _loaiService = new LoaiService();
        }


        private async void ReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1Load danh sách loại (category)
                var loais = await _loaiService.GetLoaisAsync();
                cbbLoai.DataSource = loais;
                cbbLoai.DisplayMember = "TenLoai";
                cbbLoai.ValueMember = "MaLoai";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gọi API: " + ex.Message);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ReportPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Order_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
