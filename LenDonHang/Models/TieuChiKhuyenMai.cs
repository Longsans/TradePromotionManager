using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LenDonHang.Models
{
    internal class TieuChiKhuyenMai : BaseSerializable
    {
        // TPR, BOGO, BOGO%, TangKem
        public MatHang? matHang { get; set; }
        // coupled with matHang: BOGO, BOGO%
        public int soLuong { get; set; }
        
        // TPR, RutTham
        public ulong tongTienDonHang { get; set; }
        
        // TPR, RutTham
        public DateTime? ngaySinhNhatKhachHang { get; set; }

        public TieuChiKhuyenMai()
        {
            matHang = null;
            soLuong = 0;
            tongTienDonHang = 0;
            ngaySinhNhatKhachHang = null;
        }
    }
}
