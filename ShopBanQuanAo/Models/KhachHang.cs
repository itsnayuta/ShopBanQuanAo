using System;

namespace ShopBanQuanAo.Models
{
    public class KhachHang
    {
        public int ID { get; set; }
        public required string Ten { get; set; }
        public required string DiaChi { get; set; }
        public required string SDT { get; set; }
        public required string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}