# 🛍️ Shop Bán Quần Áo

Ứng dụng quản lý shop bán quần áo được xây dựng bằng **WinForms (.NET Framework)** với giao diện đơn giản, dễ sử dụng, hỗ trợ các chức năng cơ bản trong quản lý bán hàng.

## 🔧 Công Nghệ Sử Dụng

- 🖥️ Windows Forms (WinForms)
- 💾 MySQL (CSDL quan hệ)
- 💻 .NET Framework
- 🧑‍💻 Visual Studio Code / Visual Studio

## ⚙️ Các Chức Năng Chính

### 1. Đăng Nhập
- Kiểm tra thông tin người dùng
- Bảo mật đơn giản

### 2. Quản Lý Sản Phẩm
- Thêm / Sửa / Xóa sản phẩm
- Quản lý theo: tên, size, màu, giá, số lượng tồn kho

### 3. Quản Lý Khách Hàng
- Lưu trữ thông tin khách hàng: họ tên, địa chỉ, số điện thoại
- Hỗ trợ tìm kiếm theo tên hoặc số điện thoại

### 4. Quản Lý Đơn Hàng
- Tạo đơn hàng mới
- Liên kết khách hàng và sản phẩm
- Tính tổng tiền theo sản phẩm

## 🗃️ Cấu Trúc Cơ Sở Dữ Liệu

### Bảng `SanPham`
| ID | Ten     | Size | Mau   | Gia   | SoLuong |
|----|---------|------|-------|-------|---------|

### Bảng `KhachHang`
| ID | TenKhach | DiaChi        | SDT         |
|----|----------|---------------|-------------|

### Bảng `DonHang`
| ID | NgayLap | IDKhachHang |
|----|---------|-------------|
### Bảng `ChiTietDonHang`
| ID | IDDonHang | IDSanPham | SoLuong |
|----|----------|---------------|-------------|

## 💡 Mục Tiêu
- Củng cố kỹ năng lập trình WinForms
- Tích hợp CSDL thực tế (MySQL)
- Xây dựng quy trình CRUD và quản lý đơn hàng

## 🚀 Hướng Dẫn Chạy Dự Án

1. Clone repo:
   ```bash
   git clone https://github.com/itsnayuta/ShopBanQuanAo.git
