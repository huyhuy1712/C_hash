USE ql_do_uong_db;

-- 1. Loai sản phẩm
INSERT INTO Loai (TenLoai, MoTa) VALUES
('Trà sữa truyền thống', 'Trà sữa cơ bản'),
('Trà sữa matcha', 'Trà sữa vị matcha'),
('Trà sữa socola', 'Trà sữa vị socola'),
('Trà sữa caramel', 'Trà sữa vị caramel'),
('Trà sữa dâu', 'Trà sữa vị dâu'),
('Trà sữa khoai môn', 'Trà sữa vị khoai môn'),
('Trà sữa hạt dẻ', 'Trà sữa vị hạt dẻ'),
('Trà sữa bạc hà', 'Trà sữa vị bạc hà'),
('Trà sữa matcha socola', 'Trà sữa matcha + socola'),
('Trà sữa hoàng kim', 'Trà sữa đặc biệt');

-- 2. SanPham
INSERT INTO SanPham (TenSP, Gia, Anh, SLDuKien, TrangThai, MaLoai) VALUES
('Trà sữa truyền thống', 25000, 'trasua1.jpg', 50, 1, 1),
('Trà sữa matcha', 30000, 'trasua2.jpg', 40, 1, 2),
('Trà sữa socola', 28000, 'trasua3.jpg', 30, 1, 3),
('Trà sữa caramel', 32000, 'trasua4.jpg', 20, 1, 4),
('Trà sữa dâu', 27000, 'trasua5.jpg', 25, 1, 5),
('Trà sữa khoai môn', 30000, 'trasua6.jpg', 15, 1, 6),
('Trà sữa hạt dẻ', 35000, 'trasua7.jpg', 10, 1, 7),
('Trà sữa bạc hà', 33000, 'trasua8.jpg', 12, 1, 8),
('Trà sữa matcha socola', 36000, 'trasua9.jpg', 8, 1, 9),
('Trà sữa hoàng kim', 40000, 'trasua10.jpg', 5, 1, 10);

-- 3. Size
INSERT INTO Size (TenSize, PhuThu) VALUES
('S', 10000),
('M', 15000),
('L', 20000),
('XL', 25000);

-- 4. Quyen
INSERT INTO Quyen (TenQuyen, Mota) VALUES
('Admin', 'Quyền toàn quyền'),
('Nhân viên bán hàng', 'Quyền bán hàng'),
('Nhân viên kho', 'Quyền quản lý kho'),
('Kế toán', 'Quyền xem báo cáo'),
('Quản lý', 'Quyền quản lý tổng');

-- 5. ChucNang
INSERT INTO ChucNang (TenChucNang, MoTa) VALUES
('Quản lý sản phẩm', 'Thêm, sửa, xóa sản phẩm'),
('Quản lý đơn hàng', 'Quản lý đơn hàng bán'),
('Quản lý nhân viên', 'Thêm, sửa nhân viên'),
('Quản lý kho', 'Nhập xuất nguyên liệu'),
('Xem báo cáo', 'Xem doanh thu, chi phí');

-- 6. TaiKhoan
INSERT INTO TaiKhoan (TenTaiKhoan, Anh, TrangThai, MaQuyen) VALUES
('nv_banhang1', '', 1, 2),
('nv_banhang2', '', 1, 2),
('nv_banhang3', '', 1, 2),
('nv_kho1', '', 1, 3),
('nv_kho2', '', 1, 3),
('admin1', '', 1, 1),
('kt1', '', 1, 4),
('ql1', '', 1, 5),
('nv_banhang4', '', 1, 2),
('nv_banhang5', '', 1, 2);

-- 7. Quyen_ChucNang
INSERT INTO Quyen_ChucNang (MaQuyen, MaChucNang) VALUES
(1,1),(1,2),(1,3),(1,4),(1,5),
(2,2),(2,5),
(3,4),
(4,5),
(5,1),(5,2),(5,3),(5,4),(5,5);

-- 8. NhanVien
INSERT INTO NhanVien (TenNV, SDT, MaTK) VALUES
('Nguyen Van A','0901234561',1),
('Nguyen Van B','0901234562',2),
('Nguyen Van C','0901234563',3),
('Tran Thi D','0901234564',4),
('Le Van E','0901234565',5),
('Pham Thi F','0901234566',6),
('Nguyen Van G','0901234567',7),
('Tran Thi H','0901234568',8),
('Le Van I','0901234569',9),
('Pham Thi K','0901234570',10);

-- 9. Buzzer
INSERT INTO Buzzer (SoHieu, TrangThai) VALUES
('BZ01',1),('BZ02',1),('BZ03',1),('BZ04',1),('BZ05',1),
('BZ06',1),('BZ07',1),('BZ08',1),('BZ09',1),('BZ10',1);

-- 10. DonHang
INSERT INTO DonHang (MaNV, NgayLap, GioLap, TrangThai, MaBuzzer, PhuongThucThanhToan, TongGia) VALUES
(1,'2025-09-27','09:00:00',1,1,1,50000),
(2,'2025-09-27','10:15:00',1,2,1,30000),
(3,'2025-09-27','11:30:00',1,3,1,84000),
(4,'2025-09-27','12:45:00',1,4,1,25000),
(5,'2025-09-27','14:00:00',1,5,1,64000),
(6,'2025-09-27','15:30:00',1,6,1,30000),
(7,'2025-09-27','16:45:00',1,7,1,35000);

-- 11. ChiTietDonHang
INSERT INTO ChiTietDonHang (MaDH, MaSP, MaSize, SoLuong, GiaVon, TongGia) VALUES
(1,1,2,2,25000,50000),
(2,2,2,1,30000,30000),
(3,3,3,3,28000,84000),
(4,1,1,1,25000,25000),
(5,4,2,2,32000,64000),
(6,2,3,1,30000,30000),
(7,5,2,1,35000,35000);

-- 12. NguyenLieu
INSERT INTO NguyenLieu (SoLuong, Ten, GiaBan) VALUES
(1000, 'Trà đen', 5000.00),
(800, 'Trà xanh', 6000.00),
(500, 'Sữa đặc', 10000.00),
(300, 'Đường', 2000.00),
(200, 'Trân châu đen', 15000.00),
(150, 'Trân châu trắng', 16000.00),
(100, 'Pudding', 12000.00),
(50, 'Thạch dừa', 10000.00),
(400, 'Đá viên', 1000.00),
(250, 'Matcha bột', 20000.00);

-- 13. PhieuNhap
INSERT INTO PhieuNhap (NgayNhap, SoLuong, MaNV, TongTien) VALUES
('2025-09-01',50,1,500000),
('2025-09-02',30,2,300000),
('2025-09-03',40,3,400000),
('2025-09-04',25,4,250000),
('2025-09-05',60,5,600000),
('2025-09-06',35,6,350000),
('2025-09-07',45,7,450000),
('2025-09-08',20,8,200000),
('2025-09-09',55,9,550000),
('2025-09-10',50,10,500000);

-- 14. ChiTietPhieuNhap
INSERT INTO ChiTietPhieuNhap (MaPN, SoLuong, MaNguyenLieu, DonGiaNhap, TongGia) VALUES
(1,20,1,5000,100000),
(1,30,2,4000,120000),
(2,15,3,6000,90000),
(2,15,4,5000,75000),
(3,25,1,5000,125000),
(3,15,5,7000,105000),
(4,10,2,4000,40000),
(5,30,3,6000,180000),
(6,20,4,5000,100000),
(7,25,5,7000,175000);

-- 15. CTKhuyenMai
INSERT INTO CTKhuyenMai (TenCTKhuyenMai, MoTa, NgayBatDau, NgayKetThuc, PhanTramKhuyenMai, TrangThai) VALUES
('KM Mua 1 tặng 1','Khuyến mãi 1', '2025-09-01','2025-09-30',50,1),
('KM Giảm 10%','Khuyến mãi 2', '2025-09-01','2025-09-30',10,1),
('KM Giảm 20%','Khuyến mãi 3', '2025-09-05','2025-09-30',20,1),
('KM Cuối tuần','Khuyến mãi 4', '2025-09-06','2025-09-30',15,1),
('KM Combo','Khuyến mãi 5', '2025-09-07','2025-09-30',25,1),
('KM Sáng sớm','Khuyến mãi 6', '2025-09-01','2025-09-30',5,1),
('KM Chiều','Khuyến mãi 7', '2025-09-01','2025-09-30',12,1),
('KM Giảm 5k','Khuyến mãi 8', '2025-09-10','2025-09-30',5,1),
('KM Mùa hè','Khuyến mãi 9', '2025-06-01','2025-09-30',10,1),
('KM Sinh nhật','Khuyến mãi 10', '2025-09-15','2025-09-30',30,1);

-- 16. sanpham_khuyenmai
INSERT INTO sanpham_khuyenmai (MaSP, MaCTKhuyenMai) VALUES
(1,1),(2,2),(3,3),(4,4),(5,5),
(6,6),(7,7),(8,8),(9,9),(10,10);

-- 17. CongThuc
INSERT INTO CongThuc (Ten, MaSP, Mota) VALUES
('Công thức 1',1,'Trà sữa truyền thống'),
('Công thức 2',2,'Trà sữa matcha'),
('Công thức 3',3,'Trà sữa socola'),
('Công thức 4',4,'Trà sữa caramel'),
('Công thức 5',5,'Trà sữa dâu'),
('Công thức 6',6,'Trà sữa khoai môn'),
('Công thức 7',7,'Trà sữa hạt dẻ'),
('Công thức 8',8,'Trà sữa bạc hà'),
('Công thức 9',9,'Trà sữa matcha socola'),
('Công thức 10',10,'Trà sữa hoàng kim');

-- 18. ChiTietCongThuc
INSERT INTO ChiTietCongThuc (MaCT, MaNL, SL) VALUES
(1,1,20),(1,3,10),
(2,2,25),(2,10,5),
(3,1,15),(3,5,5),
(4,1,10),(4,4,5),
(5,2,5),(5,6,3),
(6,2,10),(6,7,5),
(7,1,10),(7,8,5),
(8,2,5),(8,4,5),
(9,2,5),(9,5,5),
(10,1,10),(10,3,10);

-- 19. DoanhThu
INSERT INTO DoanhThu (Ngay, Thang, Nam, Gio, SLBan, MaSP, MaLoai, MaKM, MaSize, TongDoanhThu) VALUES
(27,9,2025,'09:00:00',2,1,1,1,2,50000),
(27,9,2025,'10:15:00',1,2,2,2,2,30000),
(27,9,2025,'11:30:00',3,3,3,3,3,84000),
(27,9,2025,'12:45:00',1,1,1,4,1,25000),
(27,9,2025,'14:00:00',2,4,4,5,2,64000),
(27,9,2025,'15:30:00',1,2,2,6,3,30000),
(27,9,2025,'16:45:00',1,5,5,7,2,35000),
(26,9,2025,'17:00:00',2,6,6,8,2,60000),
(26,9,2025,'18:00:00',1,7,7,9,3,85000),
(26,9,2025,'19:00:00',1,8,8,10,2,40000);

-- 20. ChiPhi
INSERT INTO ChiPhi (Ngay, Thang, Nam, MaSP, MaLoai, MaKM, TongChiPhiSP, TongChiPhiNL) VALUES
(27,9,2025,1,1,1,80000,50000),
(27,9,2025,2,2,2,75000,30000),
(27,9,2025,3,3,3,120000,84000),
(27,9,2025,4,4,4,60000,25000),
(27,9,2025,5,5,5,90000,64000),
(27,9,2025,6,6,6,70000,30000),
(27,9,2025,7,7,7,85000,35000),
(26,9,2025,8,8,8,95000,60000),
(26,9,2025,9,9,9,140000,90000),
(26,9,2025,10,10,10,40000,25000);

