using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MessageBus
{
    [Serializable]
    public class Message
    {
        public string Sender { get; set; } = string.Empty;
        public string Reciever { get; set; } = string.Empty;
        public string FunctionCall { get; set; } = string.Empty;
        public string JsonParam { get; set; } = string.Empty;

        public string Encode()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message? Decode(string json)
        {
            return JsonSerializer.Deserialize<Message>(json);
        }
    }
}
