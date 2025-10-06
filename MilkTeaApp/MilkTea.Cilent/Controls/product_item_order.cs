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

    public partial class product_item_order : UserControl
    {
        // Các property để nhận dữ liệu từ form OrderForm
        public string TenSP { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string Anh { get; set; }

        public product_item_order()
        {
            InitializeComponent();
        }

        //  Hàm cập nhật hiển thị
        public void CapNhatHienThi()
        {
            //lb.Text = TenSP;
            //textBox1.Text = SoLuong.ToString();
            //lblThanhTien.Text = (Gia * SoLuong).ToString("N0") + " VND";

            //try
            //{
            //    string imgPath = Path.Combine(Application.StartupPath, "images", "tra_sua", Anh ?? "");
            //    if (File.Exists(imgPath))
            //        picSanPham.Image = Image.FromFile(imgPath);
            //}
            //catch { }
        }
    }

}
