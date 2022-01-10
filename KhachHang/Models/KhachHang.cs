using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHang.Models
{
    public class KhachHang : BaseSerializable
    {
        public int idKhachHang { get; set; }
        public string tenKhachHang { get; set; } = "Ten khach hang";
        public string soDienThoai { get; set; } = "0969999999";
        public int diemTichLuy { get; set; }

        public static KhachHang FindID(int id)
        {
            return new KhachHang
            {
                idKhachHang = id
            };
        }
    }
}
