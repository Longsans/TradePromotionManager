using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace User.Models
{
    [Serializable]
    internal class BaseSerializable
    {
        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public static T? Deserialize<T>(string json) where T : BaseSerializable
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
