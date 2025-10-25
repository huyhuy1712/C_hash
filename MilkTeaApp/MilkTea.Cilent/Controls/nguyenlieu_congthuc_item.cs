using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public partial class nguyenlieu_congthuc_item : UserControl
    {

        public string SoLuong
        {
            get => txt_sl.Text;
            set => txt_sl.Text = value;
        }

        public bool IsChecked
        {
            get => check.Checked;
            set => check.Checked = value;
        }

        public int MaNL { get; set; }  
        public string TenNL
        {
            get => lbl_ten.Text;
            set => lbl_ten.Text = value;
        }
        public nguyenlieu_congthuc_item()
        {
            InitializeComponent();
        }


        public void SetData(NguyenLieu nl)
        {
            try
            {
                MaNL = nl.MaNL;
                //// Gán tên hiển thị
                lbl_ten.Text = nl.Ten;

                txt_sl.Text = "1";

                //// Bỏ chọn checkbox mặc định
                check.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi SetData nguyên liệu: {ex.Message}");
            }
        }

    }
}