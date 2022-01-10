using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LenDonHang.Models
{
    internal class MatHang : BaseCustomSerializable
    {
        public string idMatHang { get; set; }
        public string tenMatHang { get; set; }
        public ulong donGia { get; set; }
        public Dictionary<string, object> dacDiem { get; set; }

        public MatHang()
        {
            idMatHang = "null";
            tenMatHang = "null";
            donGia = 0;
            dacDiem = new Dictionary<string, object>();
        }
        public MatHang(string json)
        {
            JObject obj = JObject.Parse(json);
            idMatHang = (string?)obj[nameof(idMatHang)] ?? "null";
            tenMatHang = (string?)obj[nameof(tenMatHang)] ?? "null";
            donGia = (ulong?)obj[nameof(donGia)] ?? 0;

            if (obj[nameof(dacDiem)] == null)
                dacDiem = new Dictionary<string, object>();
            else
                dacDiem = JObject.FromObject(obj[nameof(dacDiem)]).ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>();
        }

        public override string toJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
