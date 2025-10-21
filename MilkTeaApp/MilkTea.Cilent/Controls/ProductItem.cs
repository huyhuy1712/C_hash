using MilkTea.Client.Forms.ChildForm_Order;
using MilkTea.Client.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MilkTea.Client.Controls
{
    public partial class ProductItem : UserControl
    {
        // Biến lưu sản phẩm hiện tại để khi click có thể dùng lại
        private SanPham sanPham;

        // Định nghĩa EventArgs tùy chỉnh để truyền dữ liệu sản phẩm ra ngoài

        public event EventHandler OnProductUpdated;

        public class SanPhamEventArgs : EventArgs
        {
            public SanPham SanPham { get; set; }

            public SanPhamEventArgs(SanPham sp)
            {
                SanPham = sp;
            }
        }

        // Sự kiện phát ra khi người dùng click chọn sản phẩm
        public event EventHandler<SanPhamEventArgs> OnProductSelected;

        //  Constructor
        public ProductItem()
        {
            InitializeComponent();

            // Gắn sự kiện click cho các thành phần chính
            product_top_panel_1.Click += Product_Click;
            product_picture1.Click += Product_Click;
            ten_sp_label1.Click += Product_Click;
            gia_label1.Click += Product_Click;
        }

        // Hàm gọi khi người dùng click vào sản phẩm
        private void Product_Click(object sender, EventArgs e)
        {
            // Nếu có dữ liệu sản phẩm thì phát event ra ngoài
            if (sanPham != null)
            {
                OnProductSelected?.Invoke(this, new SanPhamEventArgs(sanPham));
            }
        }

        // Nhận dữ liệu từ API và hiển thị lên giao diện
        public void SetData(SanPham sp)
        {
            sanPham = sp; // lưu lại dữ liệu sản phẩm để khi click còn dùng

            // Hiển thị tên và giá
            ten_sp_label1.Text = sp.TenSP;
            gia_label1.Text = sp.Gia.ToString("N0") + " VND";

            try
            {
                // Tạo đường dẫn tuyệt đối tới ảnh
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

        private void product_edit_btn1_Click(object sender, EventArgs e)
        {
            EditProductForm editForm = new EditProductForm(sanPham);
            editForm.StartPosition = FormStartPosition.CenterScreen;

            // Bắt sự kiện từ form Edit
            editForm.SanPhamUpdated += (s, ev) =>
            {
                OnProductUpdated?.Invoke(this, EventArgs.Empty); // Báo ngược lên cho OrderForm
            };

            editForm.ShowDialog();
        }
    }
}
