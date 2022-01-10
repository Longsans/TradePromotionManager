using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenKeHoachKhuyenMai.Models
{
    internal abstract class BaseSerializable
    {
        public BaseSerializable() { }
        public BaseSerializable(string json) { }

        public abstract string toJson();
    }
}
