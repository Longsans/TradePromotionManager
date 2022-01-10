using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LenDonHang.Models
{
    public class DonHang : BaseCustomSerializable
    {
        public KhachHang khachHang { get; set; }
        public List<ItemGioHang> gioHang { get; set; }
        public ulong tongTien { get; set; }

        public DonHang()
        {
            khachHang = new KhachHang();
            gioHang = new List<ItemGioHang>();
            tongTien = 0;
        }
        public DonHang(string json) : this()
        {
            JObject o = JObject.Parse(json);

            JObject khObj = JObject.FromObject(o[nameof(khachHang)]);
            if (khObj != null)
            {
                khachHang.idKhachHang = (int?)khObj[nameof(KhachHang.idKhachHang)] ?? -1;
                khachHang.tenKhachHang = (string?)khObj[nameof(KhachHang.tenKhachHang)] ?? "null";
                khachHang.soDienThoai = (string?)khObj[nameof(KhachHang.soDienThoai)] ?? "null";
            }

            JArray ghObj = JArray.FromObject(o[nameof(gioHang)]);
            foreach (JObject item in ghObj)
            {
                var matHang = new MatHang()
                {
                    idMatHang = (string?)item[matHangStr][nameof(MatHang.idMatHang)] ?? "null",
                    tenMatHang = (string?)item[matHangStr][nameof(MatHang.tenMatHang)] ?? "null",
                    donGia = (ulong?)item[matHangStr][nameof(MatHang.donGia)] ?? 0,
                };
                gioHang.Add(new ItemGioHang(matHang, (int?)item["soLuong"] ?? 0));
            }
        }

        public override string toJson()
        {
            CalcTongTien();

            JObject json = new JObject
            {
                [nameof(khachHang)] = new JObject
                {
                    [nameof(KhachHang.idKhachHang)] = khachHang.idKhachHang,
                    [nameof(KhachHang.tenKhachHang)] = khachHang.tenKhachHang,
                    [nameof(KhachHang.soDienThoai)] = khachHang.soDienThoai
                },

                [nameof(gioHang)] = new JArray(gioHang.Select(item => item.toJObject())),
                [nameof(tongTien)] = tongTien
            };

            return json.ToString(Formatting.Indented);
        }

        public string SerializeXml()
        {
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stringWriter, this);
                return stringWriter.ToString();
            }
        }

        public static DonHang? DeserializeXml(string xml)
        {
            using (var stringReader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(DonHang));
                return serializer.Deserialize(stringReader) as DonHang;
            }
        }

        public void WriteTo(string path)
        {
            File.WriteAllText(path, SerializeXml());
        }

        public ulong CalcTongTien()
        {
            tongTien = 0;
            foreach (var item in gioHang)
                tongTien += item.thanhTien;

            return tongTien;
        }

        public static string matHangStr = "matHang";
    }
}
