using MilkTea.Client.Models;
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

namespace MilkTea.Client.Controls
{
    public partial class nguyenlieu_congthuc_item : UserControl
    {
        private readonly DonViTinhService _donViTinhService = new DonViTinhService();

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

        public int MaDVT { 
            get; 
            set; 
        }
        public nguyenlieu_congthuc_item()
        {
            InitializeComponent();
        }


        public void SetData(NguyenLieu nl,string name_dvt)
        {
            try
            {
                MaNL = nl.MaNL;
                //// Gán tên hiển thị
                lbl_ten.Text = nl.Ten;

                txt_sl.Text = "1";

                //// Bỏ chọn checkbox mặc định
                check.Checked = false;

                // Lấy đơn vị tính và gán vào combobox
                lb_donvi.Text = name_dvt;
                MaDVT = nl.maDVT;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi SetData nguyên liệu: {ex.Message}");
            }
        }

    }
}