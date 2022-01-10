using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaDon.Models
{
    [Serializable]
    public class DonHang : BaseSerializable 
    {
        public string ID { get; set; }
        public string idKhachHang { get; set; } = String.Empty;
        public List<MatHang> gioHang { get; set; } = new List<MatHang>();
        public ulong tongTien { get; set; }

        public DonHang()
        {
            ID = Random.Shared.Next(0, 100000000).ToString();
            gioHang = new List<MatHang>
            {
                new MatHang(),
                new MatHang(),
                new MatHang(),
            };
        }

        public static DonHang Find(string id)
        {
            return new DonHang
            {
                ID = id,
            };
        }
    }
}
