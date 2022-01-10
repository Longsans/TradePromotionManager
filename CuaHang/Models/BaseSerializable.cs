using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CuaHang.Models
{
    [Serializable]
    public abstract class BaseSerializable
    {
        public BaseSerializable() { }

        public string Encode()
        {
            return JsonSerializer.Serialize(this);
        }

        public static T? Decode<T>(string json) where T : BaseSerializable
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
