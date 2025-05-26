using System;

namespace ShopBanQuanAo.Models
{
    public class DonHang
    {
        public int ID { get; set; }
        public DateTime NgayDat { get; set; }
        public int IDKhachHang { get; set; }
        public required string TenKhachHang { get; set; }
        public decimal TongTien { get; set; }
        public required string TrangThai { get; set; }
        public required string GhiChu { get; set; }
    }
}