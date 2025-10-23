using MilkTea.Client.Models;
using MilkTea.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Import
{
    public partial class ImportForm_Add : Form
    {
        private readonly PhieuNhapService _phieuNhapService;
        private readonly ChiTietPhieuNhapService _chiTietPhieuNhapService;
        private readonly NguyenLieuService _nguyenLieuService;
        private readonly NhanVienService _nhanVienService;
        private readonly NhaCungCapService _nhaCungCapService;

        private ImportForm _parentForm;
        private List<NguyenLieu> _nguyenLieus;
        private List<NhaCungCap> _nhaCungCaps;
        private List<TempChiTiet> _tempChiTiets = new List<TempChiTiet>();

        private class TempChiTiet
        {
            public int MaNL { get; set; }
            public string TenNL { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGiaNhap { get; set; }
            public decimal TongGia { get; set; }
        }


        public ImportForm_Add(ImportForm parentForm)
        {
            InitializeComponent();
            _phieuNhapService = new PhieuNhapService();
            _chiTietPhieuNhapService = new ChiTietPhieuNhapService();
            _nguyenLieuService = new NguyenLieuService();
            _nhanVienService = new NhanVienService();
            _nhaCungCapService = new NhaCungCapService();
            _parentForm = parentForm;
        }

        private async void ImportForm_Add_Load(object sender, EventArgs e)
        {
            // Lấy mã phiếu nhập cuối cùng +1
            var phieuNhaps = await _phieuNhapService.GetPhieuNhapsAsync();
            int maxMaPN = phieuNhaps.Any() ? phieuNhaps.Max(p => p.MaPN) : 0;
            txt_maPN_PN_ADD.Text = (maxMaPN + 1).ToString();

            // Ngày lập phiếu: ngày hiện tại (04/10/2025)
            dt_iPort_ngaylap.Text = DateTime.Now.ToString("MM/dd/yyyy");

            // Người tạo phiếu: mặc định MaNV = 1, lấy tên
            var nhanVien = await _nhanVienService.GetByMaNV(1);
            txt_iPort_nguoitao.Text = nhanVien?.TenNV ?? "Nguyễn Văn A";

            // Nhà cung cấp
            _nhaCungCaps = await _nhaCungCapService.GetNhaCungCapAsync();
            cbo_NhaCungCap_PN_ADD.DataSource = _nhaCungCaps;
            cbo_NhaCungCap_PN_ADD.DisplayMember = "TenNCC";
            cbo_NhaCungCap_PN_ADD.ValueMember = "MaNCC";

            // Load danh sách nguyên liệu vào comboBox_ChonHangHoa
            _nguyenLieus = await _nguyenLieuService.GetAll();
            cbo_HangHoa_PN_ADD.DataSource = _nguyenLieus;
            cbo_HangHoa_PN_ADD.DisplayMember = "Ten";
            cbo_HangHoa_PN_ADD.ValueMember = "MaNL";
        }

        private void btn_Them_PN_ADD_Click(object sender, EventArgs e)
        {
            if (cbo_HangHoa_PN_ADD.SelectedItem is NguyenLieu selectedNL && nb_soLuong_PN_ADD.Value > 0)
            {
                int soLuong = (int)nb_soLuong_PN_ADD.Value;
                decimal donGiaNhap = selectedNL.GiaBan;
                decimal tongGia = soLuong * donGiaNhap;

                _tempChiTiets.Add(new TempChiTiet
                {
                    MaNL = selectedNL.MaNL,
                    TenNL = selectedNL.Ten,
                    SoLuong = soLuong,
                    DonGiaNhap = donGiaNhap,
                    TongGia = tongGia
                });

                RefreshGrid();
                nb_soLuong_PN_ADD.Value = 0;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa và nhập số lượng lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Xoa_PN_ADD_Click(object sender, EventArgs e)
        {
            if (dGV_HangHoa_PN_ADD.SelectedRows.Count > 0)
            {
                int selectedIndex = dGV_HangHoa_PN_ADD.SelectedRows[0].Index;
                _tempChiTiets.RemoveAt(selectedIndex);
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btn_Luu_Iport_add_Click(object sender, EventArgs e)
        {
            if (_tempChiTiets.Count == 0)
            {
                MessageBox.Show("Không có chi tiết nào để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pn = new PhieuNhap
                {
                    NgayNhap = DateTime.Parse(dt_iPort_ngaylap.Text),
                    SoLuong = _tempChiTiets.Sum(t => t.SoLuong),
                    MaNCC = (int?)cbo_NhaCungCap_PN_ADD.SelectedValue,
                    MaNV = 1,
                    TongTien = _tempChiTiets.Sum(t => t.TongGia)
                };

                int newMaPN = await _phieuNhapService.AddPhieuNhapAsync(pn);

                foreach (var temp in _tempChiTiets)
                {
                    var ct = new ChiTietPhieuNhap
                    {
                        MaPN = newMaPN,
                        MaNguyenLieu = temp.MaNL,
                        SoLuong = temp.SoLuong,
                        DonGiaNhap = temp.DonGiaNhap,
                        TongGia = temp.TongGia
                    };
                    await _chiTietPhieuNhapService.AddChiTietPhieuNhapAsync(ct);
                    await _nguyenLieuService.CongNguyenLieuAsync(temp.MaNL, temp.SoLuong);
                }
                // Reset danh sách sau khi lưu thành công
                _tempChiTiets.Clear();
                RefreshGrid();

                // Thông báo và làm mới form cha (ImportForm)
                MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _parentForm.LoadPhieuNhaps(); // Gọi lại phương thức load dữ liệu
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Thoat_iPort_add_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void RefreshGrid()
        {
            dGV_HangHoa_PN_ADD.Rows.Clear();
            string maPhieu = Convert.ToString(txt_maPN_PN_ADD.Text);
            string ngayNhap = dt_iPort_ngaylap.Text;
            string tenNV = txt_iPort_nguoitao.Text;

            foreach (var item in _tempChiTiets)
            {
                dGV_HangHoa_PN_ADD.Rows.Add(maPhieu, ngayNhap, item.TenNL, item.SoLuong, tenNV, item.TongGia);
            }
        }
    }
}
