using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HoaDon.Models
{
    [Serializable]
    public abstract class BaseSerializable
    {
        public BaseSerializable() { }

        public virtual string Encode()
        {
            return JsonSerializer.Serialize(this, this.GetType());
        }

        public static T? Decode<T>(string json) where T : BaseSerializable
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
