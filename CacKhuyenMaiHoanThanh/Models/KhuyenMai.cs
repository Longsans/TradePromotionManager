using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CacKhuyenMaiHoanThanh.Models
{
    internal class KhuyenMai : BaseSerializable
    {
        public DateTime thoiGianBatDau { get; set; }
        public DateTime thoiGianKetThuc { get; set; }
        public uint soLuongHoaDon { get; set; }
        public uint soLuongMucTieu { get; set; }
        public ulong von { get; set; }
        public ulong tongThanhTien { get; set; }
        public long laiSuat { get; set; }
        public long laiSuatMucTieu { get; set; }
        //Hinh thuc va tieu chi

        public KhuyenMai()
        {
            thoiGianBatDau = DateTime.Now;
            thoiGianKetThuc = DateTime.Now;
            soLuongHoaDon = 0;
            soLuongMucTieu = 0;
            von = 0;
            tongThanhTien = 0;
            laiSuat = 0;
            laiSuatMucTieu = 0;
        }

        public KhuyenMai(string json)
        {
            JObject @object = JObject.Parse(json);
            thoiGianBatDau = (DateTime?)@object[nameof(thoiGianBatDau)] ?? DateTime.Now;
            thoiGianKetThuc = (DateTime?)@object[nameof(thoiGianKetThuc)] ?? DateTime.Now;
            soLuongHoaDon = (uint?)@object[nameof(soLuongHoaDon)] ?? 0;
            soLuongMucTieu = (uint?)@object[nameof(soLuongMucTieu)] ?? 0;
            von = (ulong?)@object[nameof(von)] ?? 0;
            tongThanhTien = (ulong?)@object[nameof(tongThanhTien)] ?? 0;
            laiSuat = (long)(tongThanhTien - von);
            laiSuatMucTieu = (long?)@object[nameof(laiSuatMucTieu)] ?? 0;
        }

        public override string toJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
