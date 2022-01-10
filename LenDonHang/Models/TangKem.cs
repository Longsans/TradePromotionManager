using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenDonHang.Models
{
    internal class TangKem : BaseSerializable
    {
        public MatHang matHang { get; set; }
        public int soLuong { get; set; }

        public TangKem()
        {
            matHang = new MatHang();
            soLuong = 0;
        }
    }
}
