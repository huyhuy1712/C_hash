using MilkTea.Client.Models;
using MilkTea.Client.Services;
using MilkTea.Server.Models;
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
    private readonly DonViTinhService _donViTinhService;

    private ImportForm _parentForm;
    private List<NguyenLieu> _nguyenLieus;
    private List<NhaCungCap> _nhaCungCaps;
    private List<DonViTinh> _donViTinhs;
    private List<TempChiTiet> _tempChiTiets = new List<TempChiTiet>();
    private NhanVien nv;

    private class TempChiTiet
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal TongGia { get; set; }
        public string DonVi { get; set; }
    }

    public PhieuNhap? ResultPhieuNhap { get; private set; }

    public ImportForm_Add(ImportForm parentForm)
    {
        InitializeComponent();
        _phieuNhapService = new PhieuNhapService();
        _chiTietPhieuNhapService = new ChiTietPhieuNhapService();
        _nguyenLieuService = new NguyenLieuService();
        _nhanVienService = new NhanVienService();
        _nhaCungCapService = new NhaCungCapService();
        _donViTinhService = new DonViTinhService();
        _parentForm = parentForm;
    }

    private async void ImportForm_Add_Load(object sender, EventArgs e)
    {
        nv = await _nhanVienService.GetByMaTK(Session.CurrentUser.MaTK);
        // Lấy mã phiếu nhập cuối cùng +1
        var phieuNhaps = await _phieuNhapService.GetPhieuNhapsAsync();
        int maxMaPN = phieuNhaps.Any() ? phieuNhaps.Max(p => p.MaPN) : 0;
        txt_maPN_PN_ADD.Text = (maxMaPN + 1).ToString();

        // Ngày lập phiếu: ngày hiện tại (04/10/2025)
        dt_iPort_ngaylap.Value = DateTime.Now;

        // Người tạo phiếu: mặc định MaNV = 1, lấy tên
        var nhanVien = await _nhanVienService.GetByMaNV(nv.MaNV);
        txt_iPort_nguoitao.Text = nv.TenNV;

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

        // Load đơn vị tính
        _donViTinhs = await _donViTinhService.GetAllAsync();
        cbo_donvitinh_add.DataSource = _donViTinhs;
        cbo_donvitinh_add.DisplayMember = "TenDVT";
        cbo_donvitinh_add.ValueMember = "MaDVT";
    }

    private void btn_Them_PN_ADD_Click(object sender, EventArgs e)
    {
        if (nb_dongia_PN_ADD.Value < 0)
        {
            MessageBox.Show("Đon giá nhập không được bé hơn 0!", "Thiếu thông tin",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nb_dongia_PN_ADD.Focus();
            return;
        }
        if (cbo_HangHoa_PN_ADD.SelectedItem is NguyenLieu selectedNL && nb_soLuong_PN_ADD.Value > 0)
        {
            int soLuongMoi = (int)nb_soLuong_PN_ADD.Value;
            decimal donGiaNhap = nb_dongia_PN_ADD.Value;
            int maNL = selectedNL.MaNL;
            string donViTinh = cbo_donvitinh_add.Text;

            var existingItem = _tempChiTiets.FirstOrDefault(t => t.MaNL == maNL);

            if (existingItem != null)
            {
                existingItem.SoLuong += soLuongMoi;
                existingItem.TongGia = existingItem.SoLuong * existingItem.DonGiaNhap;
            }
            else
            {
                decimal tongGia = soLuongMoi * donGiaNhap;
                _tempChiTiets.Add(new TempChiTiet
                {
                    MaNL = maNL,
                    TenNL = selectedNL.Ten,
                    SoLuong = soLuongMoi,
                    DonGiaNhap = donGiaNhap,
                    TongGia = tongGia,
                    DonVi = donViTinh
                });
            }

            RefreshGrid();
            nb_soLuong_PN_ADD.Value = 0; // Reset số lượng sau khi thêm
            nb_dongia_PN_ADD.Value = 0;
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
        string donViTinh = cbo_donvitinh_add.Text;
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
                TrangThai = 1,
                MaNCC = (int?)cbo_NhaCungCap_PN_ADD.SelectedValue,
                MaNV = nv.MaNV,
                DonViTinh = donViTinh,
                TongTien = _tempChiTiets.Sum(t => t.TongGia),
            };

            int newMaPN = await _phieuNhapService.AddPhieuNhapAsync(pn);

            // Tạo object đầy đủ để trả về
            var fullPhieuNhap = new PhieuNhap
            {
                MaPN = newMaPN,
                NgayNhap = pn.NgayNhap,
                SoLuong = pn.SoLuong,
                TrangThai = 1,
                MaNCC = pn.MaNCC,
                MaNV = pn.MaNV,
                DonViTinh = pn.DonViTinh,
                TongTien = pn.TongTien
            };

            // Lưu chi tiết
            foreach (var temp in _tempChiTiets)
            {
                var ct = new ChiTietPhieuNhap
                {
                    MaPN = newMaPN,
                    MaNguyenLieu = temp.MaNL,
                    SoLuong = temp.SoLuong,
                    DonGiaNhap = temp.DonGiaNhap,
                    TongGia = temp.TongGia,
                    DonViTinh = temp.DonVi
                };
                await _chiTietPhieuNhapService.AddChiTietPhieuNhapAsync(ct);
                await _nguyenLieuService.CongNguyenLieuAsync(temp.MaNL, temp.SoLuong);
                await _nguyenLieuService.CapNhatGiaBanMoiNhatAsync(temp.MaNL, temp.DonGiaNhap);
            }

            ResultPhieuNhap = fullPhieuNhap;

            _tempChiTiets.Clear();
            RefreshGrid();

            MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
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

        string maPhieu = txt_maPN_PN_ADD.Text;
        string ngayNhap = dt_iPort_ngaylap.Text;
        string tenNV = txt_iPort_nguoitao.Text;

        foreach (var item in _tempChiTiets)
        {
            int rowIndex = dGV_HangHoa_PN_ADD.Rows.Add(
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
            // Xác nhận xóa
            var confirmResult = MessageBox.Show(
                "Bạn có chắc muốn xóa nguyên liệu này khỏi phiếu nhập?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Xóa khỏi danh sách tạm
                _tempChiTiets.RemoveAt(e.RowIndex);
                RefreshGrid(); // Cập nhật lại grid
            }
        }
    }

    private void cbo_HangHoa_PN_ADD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbo_HangHoa_PN_ADD.SelectedItem is NguyenLieu nl && nl.GiaBan > 0)
        {
            nb_dongia_PN_ADD.Value = nl.GiaBan;
        }
        else
        {
            nb_dongia_PN_ADD.Value = 0;
        }
    }
}
}
