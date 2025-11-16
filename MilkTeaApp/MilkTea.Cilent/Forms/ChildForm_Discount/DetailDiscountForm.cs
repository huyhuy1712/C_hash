using MilkTea.Client.Controls;
using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Discount
{
    public partial class DetailDiscountForm : Form
    {
        private LoaiService _loaiService;
        private SanPhamService _sanPhamService;
        private SanPhamKhuyenMaiService _sanPhamKhuyenMaiService;
        private CTKhuyenMaiService _ctKhuyenMaiService;
        private int _maCTKhuyenMai;
        private List<Loai> _detailLoais;

        public DetailDiscountForm(int maCTKhuyenMai)
        {
            InitializeComponent();
            _maCTKhuyenMai = maCTKhuyenMai;
            _loaiService = new LoaiService();
            _sanPhamService = new SanPhamService();
            _sanPhamKhuyenMaiService = new SanPhamKhuyenMaiService();
            _ctKhuyenMaiService = new CTKhuyenMaiService();
            _detailLoais = new List<Loai>();
            this.Load += DetailDiscountForm_Load;
        }

        private async void DetailDiscountForm_Load(object sender, EventArgs e)
        {
            SetupFallbackUI();
            await LoadDiscountAndProductsAsync();
        }

        private void SetupFallbackUI()
        {
            label1.Text = "Đang tải...";
            label5.Text = "0%";
            label6.Text = "Ngày không xác định";
            label7.Text = "Ngày không xác định";
            dGV_sp_KM_CT.Rows.Clear();
        }

        private async Task LoadDiscountAndProductsAsync()
        {
            try
            {
                // 1. Lấy khuyến mãi và danh sách sản phẩm liên kết
                var (km, associations) = await _ctKhuyenMaiService.GetDiscountWithAssociationsAsync(_maCTKhuyenMai);

                if (km == null)
                {
                    SetupFallbackUI();
                    MessageBox.Show("Không tìm thấy chương trình khuyến mãi này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Set dữ liệu chi tiết khuyến mãi vào Labels
                label1.Text = km.TenCTKhuyenMai ?? "Không xác định";
                label6.Text = km.NgayBatDau?.ToString("dd/MM/yyyy") ?? "Không xác định";
                label7.Text = km.NgayKetThuc?.ToString("dd/MM/yyyy") ?? "Không xác định";
                label5.Text = $"{(km.PhanTramKhuyenMai == default(decimal) ? 0 : km.PhanTramKhuyenMai)}%";

                // 3. Lấy tất cả sản phẩm và loại
                var sanPhams = await _sanPhamService.GetSanPhamsAsync();
                _detailLoais = await _loaiService.GetLoaisAsync();

                if (sanPhams == null || !_detailLoais.Any())
                {
                    AddNoProductsRow("Không thể tải sản phẩm/loại.");
                    return;
                }

                // 4. Filter active products
                var activeSanPhams = sanPhams.Where(sp => sp.TrangThai == 1).ToList();

                // 5. Map associations vào GridView
                dGV_sp_KM_CT.Rows.Clear();

                if (associations == null || !associations.Any())
                {
                    AddNoProductsRow("Chưa có sản phẩm nào được liên kết.");
                    return;
                }

                foreach (var assoc in associations)
                {
                    var sp = activeSanPhams.FirstOrDefault(s => s.MaSP == assoc.MaSP);
                    int rowIndex = dGV_sp_KM_CT.Rows.Add();

                    if (sp != null)
                    {
                        var loai = _detailLoais.FirstOrDefault(l => l.MaLoai == sp.MaLoai);
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["maSP_ct"].Value = sp.MaSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["tenSanPham_ct"].Value = sp.TenSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["loai_ct"].Value = loai?.TenLoai ?? "Không xác định";
                    }
                    else
                    {
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["maSP_ct"].Value = assoc.MaSP;
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["tenSanPham_ct"].Value = "Sản phẩm không active";
                        dGV_sp_KM_CT.Rows[rowIndex].Cells["loai_ct"].Value = "-";
                        dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                        dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_CT.DefaultCellStyle.Font, FontStyle.Italic);
                    }
                }
            }
            catch (Exception ex)
            {
                SetupFallbackUI();
                MessageBox.Show($"Lỗi khi tải dữ liệu khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNoProductsRow(string message = "Chưa có sản phẩm nào được liên kết với chương trình này.")
        {
            dGV_sp_KM_CT.Rows.Clear();
            int rowIndex = dGV_sp_KM_CT.Rows.Add();
            dGV_sp_KM_CT.Rows[rowIndex].Cells["tenSanPham_ct"].Value = message;
            dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
            dGV_sp_KM_CT.Rows[rowIndex].DefaultCellStyle.Font = new Font(dGV_sp_KM_CT.DefaultCellStyle.Font, FontStyle.Italic);
        }
    }
}
