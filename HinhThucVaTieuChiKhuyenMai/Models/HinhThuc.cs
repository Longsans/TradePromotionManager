using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinhThucVaTieuChiKhuyenMai.Models
{
    [Serializable]
    public class HinhThuc : BaseSerializable
    {
        public string tenHinhThuc { get; set; } = string.Empty;
        public List<TieuChi> tieuChi { get; set; } = new List<TieuChi>();
        public string moTaHinhThuc { get; set; } = string.Empty;

        public static HinhThuc Find(string ten)
        {
            return new HinhThuc
            {
                tenHinhThuc = ten,
                moTaHinhThuc = "Day la mot hinh thuc",
                tieuChi = new List<TieuChi>
                {
                    new TieuChi(),
                    new TieuChi()
                }
            };
        }
    }
}
