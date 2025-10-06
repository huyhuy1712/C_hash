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
    public partial class ProductItem : UserControl
    {
        public ProductItem()
        {
            InitializeComponent();
        }

        // Hàm để nhận dữ liệu từ API và set vào UI
        public void SetData(SanPham sp)
        {
            // Hiển thị tên và giá
            ten_sp_label1.Text = sp.TenSP;
            gia_label1.Text = sp.Gia.ToString("N0") + " VND";

            try
            {
                // Đường dẫn ảnh tuyệt đối
                string imgPath = Path.Combine(Application.StartupPath, "images", "tra_sua", sp.Anh ?? "");

                if (!string.IsNullOrEmpty(sp.Anh) && File.Exists(imgPath))
                {
                    // Load ảnh từ file
                    product_picture1.Image = Image.FromFile(imgPath);
                }
                else
                {
                    // fallback ảnh mặc định nếu không tìm thấy
                    product_picture1.Image = Properties.Resources.tra_sua_truyen_thong;
                }
            }
            catch
            {
                // fallback nếu có lỗi đọc ảnh
                product_picture1.Image = Properties.Resources.tra_sua_truyen_thong;
            }
        }

    }
}
