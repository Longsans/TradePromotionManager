using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LenDonHang.Models
{
    internal class KhachHang : BaseSerializable
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
        public KhachHang(string json)
        {
            JObject o = JObject.Parse(json);
            idKhachHang = (int?)o[nameof(idKhachHang)] ?? -1;
            tenKhachHang = (string?)o[nameof(tenKhachHang)] ?? "null";
            soDienThoai = (string?)o[nameof(soDienThoai)] ?? "null";
            diemTichLuy = (int?)o[nameof(diemTichLuy)] ?? 0;
        }

        public override string toJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
