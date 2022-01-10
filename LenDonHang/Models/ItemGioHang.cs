using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LenDonHang.Models
{
    internal class ItemGioHang : BaseCustomSerializable
    {
        public MatHang matHang { get; set; }
        public int soLuong { get; set; }
        public ulong thanhTien { get; set; }

        public ItemGioHang(MatHang mh, int sl)
        {
            matHang = mh;
            soLuong = sl;
            thanhTien = matHang.donGia * (ulong)soLuong;
        }

        public override string toJson()
        {
            return toJObject().ToString();
        }

        public JObject toJObject()
        {
            JObject json = new JObject();

            json[nameof(matHang)] = new JObject
            {
                [nameof(matHang.idMatHang)] = matHang.idMatHang,
                [nameof(matHang.tenMatHang)] = matHang.tenMatHang,
                [nameof(matHang.donGia)] = matHang.donGia
            };

            json[nameof(soLuong)] = soLuong;
            json[nameof(thanhTien)] = thanhTien;

            return json;
        }
    }
}
