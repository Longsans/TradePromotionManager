using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatHang.Models
{
    // Active record
    internal class MatHangModel : BaseSerializable
    {
        public string idMatHang { get; set; }
        public string tenMatHang { get; set; }
        public ulong donGia { get; set; }
        public Dictionary<string, object> dacDiem { get; set; }

        public MatHangModel()
        {
            idMatHang = "null";
            tenMatHang = "null";
            donGia = 0;
            dacDiem = new Dictionary<string, object>();
        }

        public static MatHangModel GetById(string id)
        {
            return new MatHangModel()
            {
                idMatHang = id,
                tenMatHang = "bleach",
                donGia = 100000,
                dacDiem = new Dictionary<string, object>()
                {
                    {"dungTich", 1 },
                    {"donVi", "L" }
                }
            };
        }

        public static List<MatHangModel> GetByTenMatHang(string tenMatHang)
        {
            return new List<MatHangModel>()
            {
                new MatHangModel()
                {
                    idMatHang = "abcd",
                    tenMatHang = tenMatHang,
                    donGia = 100000
                },
                new MatHangModel()
                {
                    idMatHang = "defg",
                    tenMatHang = tenMatHang,
                    donGia = 157000
                }
            };
        }

        public void Insert()
        {
            // insert this instance to db
        }

        public void Update()
        {
            // update current state of model to db
        }
    }
}
