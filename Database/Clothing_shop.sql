CREATE DATABASE IF NOT EXISTS clothing_shop;
USE clothing_shop;

-- Bảng Sản phẩm
CREATE TABLE SanPham (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Ten VARCHAR(255) NOT NULL,
    Size VARCHAR(50),
    Mau VARCHAR(100),
    Gia DECIMAL(10,2) NOT NULL,
    SoLuong INT DEFAULT 0,
    CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdateDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Bảng Khách hàng
CREATE TABLE KhachHang (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Ten VARCHAR(255) NOT NULL,
    DiaChi TEXT,
    SDT VARCHAR(20),
    Email VARCHAR(255),
    CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdateDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Bảng Đơn hàng
CREATE TABLE DonHang (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NgayDat DATETIME DEFAULT CURRENT_TIMESTAMP,
    IDKhachHang INT,
    TongTien DECIMAL(10,2) DEFAULT 0,
    TrangThai VARCHAR(50) DEFAULT 'Chờ xử lý',
    GhiChu TEXT,
    FOREIGN KEY (IDKhachHang) REFERENCES KhachHang(ID)
);

-- Bảng Chi tiết đơn hàng
CREATE TABLE ChiTietDonHang (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    IDDonHang INT,
    IDSanPham INT,
    SoLuong INT NOT NULL,
    GiaBan DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IDDonHang) REFERENCES DonHang(ID),
    FOREIGN KEY (IDSanPham) REFERENCES SanPham(ID)
);

-- Thêm dữ liệu mẫu
INSERT INTO SanPham (Ten, Size, Mau, Gia, SoLuong) VALUES
('Áo thun nam', 'M', 'Xanh', 150000, 50),
('Quần jean nữ', 'L', 'Xanh đen', 300000, 30),
('Áo sơ mi trắng', 'S', 'Trắng', 200000, 25);

INSERT INTO KhachHang (Ten, DiaChi, SDT, Email) VALUES
('Nguyễn Văn A', '123 Đường ABC, TP.HCM', '0901234567', 'nguyenvana@email.com'),
('Trần Thị B', '456 Đường XYZ, Hà Nội', '0987654321', 'tranthib@email.com');