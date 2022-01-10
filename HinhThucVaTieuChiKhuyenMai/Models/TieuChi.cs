using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinhThucVaTieuChiKhuyenMai.Models
{
    [Serializable]
    public class TieuChi : BaseSerializable
    {
        public int id { get; set; }
        public JObject noiDungJson { get; set; } = new JObject();

        public static TieuChi Find(int id)
        {
            return new TieuChi
            {
                id = id,
            };
        }

    }
}
