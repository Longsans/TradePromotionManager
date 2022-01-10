using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHang.Models
{
    [Serializable]
    public class CuaHang : BaseSerializable
    {
        public string DiaChi { get; set; } = string.Empty;
        public string Ten { get; set; } = string.Empty;
        public string ID { get; set; } = string.Empty;

        public static CuaHang Find(string id)
        {
            return new CuaHang
            {
               ID = id,
               Ten = "Cua Hang",
               DiaChi = "Dia chi cua hang"
            };
        }
    }
}
