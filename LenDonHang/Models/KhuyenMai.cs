using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenDonHang.Models
{
    internal class KhuyenMai : BaseSerializable
    {
        public string tenKhuyenMai { get; set; }
        public DateTime? thoiGianBatDau { get; set; }
        public DateTime? thoiGianKetThuc { get; set; }
        public string hinhThuc { get; set; }
        public TieuChiKhuyenMai? tieuChi { get; set; }
        public float giamGia { get; set; }
        public TangKem? tangKem { get; set; }

        public KhuyenMai()
        {
            tenKhuyenMai = "null";
            thoiGianBatDau = null;
            thoiGianKetThuc = null;
            hinhThuc = "null";
            tieuChi = null;
            giamGia = 0f;
            tangKem = null;
        }
    }
}
