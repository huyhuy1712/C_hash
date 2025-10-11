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

namespace MilkTea.Client.Forms.ChildForm_Import
{
    public partial class ImportForm_Info : Form
    {
        private readonly ChiTietPhieuNhapService _chiTietPhieuNhapService;
        private readonly int _maPN;

        public ImportForm_Info(int maPN)
        {
            InitializeComponent();
            _chiTietPhieuNhapService = new ChiTietPhieuNhapService();
            _maPN = maPN;
        }

        private async void ImportForm_Info_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Gọi API để lấy danh sách chi tiết phiếu nhập theo MaPN
                var chiTietPhieuNhaps = await _chiTietPhieuNhapService.GetByMaPNAsync(_maPN);

                // Cập nhật DataGridView
                dGV_chitietphieunhap.Rows.Clear();
                if (chiTietPhieuNhaps.Any() && chiTietPhieuNhaps != null)
                {
                    foreach (var ctpn in chiTietPhieuNhaps)
                    {
                        int rowIndex = dGV_chitietphieunhap.Rows.Add();
                        dGV_chitietphieunhap.Rows[rowIndex].Cells["maPhieuNhap_tb_info"].Value = ctpn.MaChiTietPhieuNhap;
                        dGV_chitietphieunhap.Rows[rowIndex].Cells["soLuong_tb_add"].Value = ctpn.SoLuong;
                        dGV_chitietphieunhap.Rows[rowIndex].Cells["tenNL_tb_info"].Value = ctpn.MaNguyenLieu;
                        dGV_chitietphieunhap.Rows[rowIndex].Cells["donGia_tb_info"].Value = ctpn.DonGiaNhap; // Định dạng số với dấu phân cách hàng nghìn
                        dGV_chitietphieunhap.Rows[rowIndex].Cells["tongTien_tb_info"].Value = ctpn.TongGia;
                    }
                }
                else
                {
                    MessageBox.Show($"Không có chi tiết phiếu nhập nào cho mã phiếu nhập {_maPN}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy dữ liệu: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}