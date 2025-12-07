using MilkTea.Client.Models;
using MilkTea.Client.Services;
using MilkTea.Server.Models;
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
    public partial class ImportForm_Update : Form
    {
        private readonly PhieuNhapService _phieuNhapService;
        private readonly ChiTietPhieuNhapService _chiTietPhieuNhapService;
        private readonly NguyenLieuService _nguyenLieuService;
        private readonly NhanVienService _nhanVienService;
        private readonly NhaCungCapService _nhaCungCapService;
        private readonly DonViTinhService _donViTinhService;

        private List<NguyenLieu> _nguyenLieus;
        private List<NhaCungCap> _nhaCungCaps;
        private List<DonViTinh> _donViTinhs;

        private List<TempChiTiet> _tempChiTiets = new List<TempChiTiet>();
        private NhanVien _currentNV;
        private int _maPN; // Mã phiếu nhập đang sửa

        private class TempChiTiet
        {
            public int MaNL { get; set; }
            public string TenNL { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGiaNhap { get; set; }
            public decimal TongGia => SoLuong * DonGiaNhap;
            public string DonVi { get; set; }
            public int? OriginalSoLuong { get; set; } // Để tính chênh lệch tồn kho
        }
        public ImportForm_Update(int maPN)
        {
            InitializeComponent();

            _maPN = maPN;

            _phieuNhapService = new PhieuNhapService();
            _chiTietPhieuNhapService = new ChiTietPhieuNhapService();
            _nguyenLieuService = new NguyenLieuService();
            _nhanVienService = new NhanVienService();
            _nhaCungCapService = new NhaCungCapService();
            _donViTinhService = new DonViTinhService();
        }

        private async void ImportForm_Update_Load(object sender, EventArgs e)
        {
            try
            {
                // Load nhân viên hiện tại
                _currentNV = await _nhanVienService.GetByMaTK(Session.CurrentUser.MaTK);


                // Load dữ liệu combo box
                await LoadCombosAsync();

                // Load dữ liệu phiếu nhập cần sửa
                await LoadPhieuNhapAsync(_maPN);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async Task LoadCombosAsync()
        {
            _nhaCungCaps = await _nhaCungCapService.GetNhaCungCapAsync();
            cbo_NhaCungCap_PN_ADD.DataSource = _nhaCungCaps;
            cbo_NhaCungCap_PN_ADD.DisplayMember = "TenNCC";
            cbo_NhaCungCap_PN_ADD.ValueMember = "MaNCC";

            _nguyenLieus = await _nguyenLieuService.GetAll();
            cbo_HangHoa_PN_ADD.DataSource = _nguyenLieus;
            cbo_HangHoa_PN_ADD.DisplayMember = "Ten";
            cbo_HangHoa_PN_ADD.ValueMember = "MaNL";

            _donViTinhs = await _donViTinhService.GetAllAsync();
            cbo_donvitinh_add.DataSource = _donViTinhs;
            cbo_donvitinh_add.DisplayMember = "TenDVT";
            cbo_donvitinh_add.ValueMember = "MaDVT";
        }

        private async Task LoadPhieuNhapAsync(int maPN)
        {
            var phieuNhap = await _phieuNhapService.GetPhieuNhapByIdAsync(maPN); // Bạn cần thêm method này nếu chưa có
            if (phieuNhap == null || phieuNhap.TrangThai != 1)
            {
                MessageBox.Show("Phiếu nhập không tồn tại hoặc đã bị xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Header
            txt_maPN_PN_ADD.Text = phieuNhap.MaPN.ToString();
            dt_iPort_ngaylap.Value = phieuNhap.NgayNhap ?? DateTime.Now;
            txt_iPort_nguoitao.Text = _currentNV.TenNV;
            if (phieuNhap.MaNCC.HasValue)
                cbo_NhaCungCap_PN_ADD.SelectedValue = phieuNhap.MaNCC.Value;

            // Chi tiết
            var chiTiets = await _chiTietPhieuNhapService.GetByMaPNAsync(maPN);
            _tempChiTiets.Clear();

            foreach (var ct in chiTiets)
            {
                var nl = _nguyenLieus.FirstOrDefault(x => x.MaNL == ct.MaNguyenLieu);
                _tempChiTiets.Add(new TempChiTiet
                {
                    MaNL = ct.MaNguyenLieu,
                    TenNL = nl?.Ten ?? "Không xác định",
                    SoLuong = ct.SoLuong,
                    DonGiaNhap = ct.DonGiaNhap,
                    DonVi = ct.DonViTinh,
                    OriginalSoLuong = ct.SoLuong
                });
            }

            RefreshGrid();
        }

        private void btn_Them_PN_ADD_Click(object sender, EventArgs e)
        {
            if (nb_dongia_PN_ADD.Value <= 0)
            {
                MessageBox.Show("Đơn giá nhập phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(cbo_HangHoa_PN_ADD.SelectedItem is NguyenLieu selectedNL) || nb_soLuong_PN_ADD.Value <= 0)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu và nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNL = selectedNL.MaNL;
            var existing = _tempChiTiets.FirstOrDefault(t => t.MaNL == maNL);

            if (existing != null)
            {
                existing.SoLuong += (int)nb_soLuong_PN_ADD.Value;
            }
            else
            {
                _tempChiTiets.Add(new TempChiTiet
                {
                    MaNL = maNL,
                    TenNL = selectedNL.Ten,
                    SoLuong = (int)nb_soLuong_PN_ADD.Value,
                    DonGiaNhap = nb_dongia_PN_ADD.Value,
                    DonVi = cbo_donvitinh_add.Text,
                    OriginalSoLuong = 0
                });
            }

            RefreshGrid();
            nb_soLuong_PN_ADD.Value = 1;
            nb_dongia_PN_ADD.Value = 0;
        }

        private async void btn_Luu_Iport_add_Click(object sender, EventArgs e)
        {
            if (_tempChiTiets.Count == 0)
            {
                MessageBox.Show("Chưa có nguyên liệu nào để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var updatedPhieuNhap = new PhieuNhap
                {
                    MaPN = _maPN,
                    NgayNhap = dt_iPort_ngaylap.Value.Date,
                    SoLuong = _tempChiTiets.Sum(t => t.SoLuong),
                    TrangThai = 2,
                    MaNCC = cbo_NhaCungCap_PN_ADD.SelectedValue as int?,
                    MaNV = _currentNV?.MaNV,
                    DonViTinh = cbo_donvitinh_add.Text,
                    TongTien = _tempChiTiets.Sum(t => t.TongGia),
                };

                bool success = await _phieuNhapService.UpdatePhieuNhapAsync(updatedPhieuNhap);
                if (!success)
                {
                    MessageBox.Show("Cập nhật phiếu nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var phieuCu = await _phieuNhapService.GetPhieuNhapByIdAsync(_maPN);
                bool daTungXacNhan = phieuCu.TrangThai == 1;
                await _chiTietPhieuNhapService.DeleteByMaPNAsync(_maPN);

                foreach (var item in _tempChiTiets)
                {
                    var ct = new ChiTietPhieuNhap
                    {
                        MaPN = _maPN,
                        MaNguyenLieu = item.MaNL,
                        SoLuong = item.SoLuong,
                        DonGiaNhap = item.DonGiaNhap,
                        TongGia = item.TongGia,
                        DonViTinh = item.DonVi
                    };
                    await _chiTietPhieuNhapService.AddChiTietPhieuNhapAsync(ct);

                    if (daTungXacNhan)
                    {
                        int diff = item.SoLuong - (item.OriginalSoLuong ?? 0);
                        if (diff != 0)
                        {
                            if (diff > 0)
                                await _nguyenLieuService.CongNguyenLieuAsync(item.MaNL, diff);
                            else
                                await _nguyenLieuService.TruNguyenLieuAsync(item.MaNL, -diff);
                        }
                    }

                    if (daTungXacNhan)
                    {
                        await _nguyenLieuService.CapNhatGiaBanMoiNhatAsync(item.MaNL, item.DonGiaNhap);
                    }
                }

                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            dGV_HangHoa_PN_ADD.Rows.Clear();
            string maPhieu = txt_maPN_PN_ADD.Text;
            string ngayNhap = dt_iPort_ngaylap.Text;
            string tenNV = txt_iPort_nguoitao.Text;

            foreach (var item in _tempChiTiets)
            {
                dGV_HangHoa_PN_ADD.Rows.Add(
                    maPhieu,
                    ngayNhap,
                    item.TenNL,
                    item.SoLuong,
                    tenNV,
                    item.TongGia,
                    item.DonVi
                );
            }
        }

        private void dGV_HangHoa_PN_ADD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dGV_HangHoa_PN_ADD.Columns["xoa_tb_add"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Xóa nguyên liệu này khỏi phiếu nhập?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _tempChiTiets.RemoveAt(e.RowIndex);
                    RefreshGrid();
                }
            }
        }

        private void cbo_HangHoa_PN_ADD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_HangHoa_PN_ADD.SelectedItem is NguyenLieu nl && nl.GiaBan > 0)
            {
                nb_dongia_PN_ADD.Value = nl.GiaBan;
            }
        }

        private void btn_Thoat_iPort_add_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
