using System;

namespace ShopBanQuanAo.Models
{
    public class SanPham
    {
        public int ID { get; set; }
        public required string Ten { get; set; }
        public required string Size { get; set; }
        public required string Mau { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}