using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SparkStub.Models
{
    public class KhachHang : BaseSerializable
    {
        public int idKhachHang { get; set; }
        public string tenKhachHang { get; set; }
        public string soDienThoai { get; set; }
        public int diemTichLuy { get; set; }

        public KhachHang()
        {
            idKhachHang = -1;
            tenKhachHang = "null";
            soDienThoai = "null";
            diemTichLuy = 0;
        }
    }
}
