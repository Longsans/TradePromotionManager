using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaDon.Models
{
    [Serializable]
    public class MatHang : BaseSerializable
    {
        public string idMatHang { get; set; } = String.Empty;
        public string tenMatHang { get; set; } = String.Empty;
        public ulong donGia { get; set; }
        public Dictionary<string, object> dacDiem { get; set; } = new Dictionary<string, object>();

        public MatHang()
        {
            idMatHang = Random.Shared.Next(0, 100000000).ToString();
            tenMatHang = "TenMatHang";
            donGia = (ulong)Random.Shared.Next(0, 100) * 1000ul;
        }
    }
}
