using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TPM.Models
{
    internal class TieuChiKhuyenMai : BaseSerializable
    {
        public MatHang? matHang { get; set; }
        public int soLuong { get; set; }
        public ulong tongTienDonHang { get; set; }
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
