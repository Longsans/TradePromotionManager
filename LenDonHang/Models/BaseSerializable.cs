using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LenDonHang.Models
{
    [Serializable]
    internal class BaseSerializable
    {
        public string Serialize()
        {
            return JsonSerializer.Serialize<object>(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        public static T? Deserialize<T>(string json) where T : BaseSerializable
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
