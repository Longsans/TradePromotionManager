using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientMessageReceiver.Models
{
    internal class TieuChiKhuyenMai : BaseSerializable
    {
        public MatHang matHang { get; set; }
        public int soLuong { get; set; }
        public ulong tongTienDonHang { get; set; }
        public DateTime? ngaySinhNhatKhachHang { get; set; }

        public TieuChiKhuyenMai()
        {
            matHang = new MatHang();
            soLuong = 0;
            tongTienDonHang = 0;
            ngaySinhNhatKhachHang = null;
        }
    }
}
