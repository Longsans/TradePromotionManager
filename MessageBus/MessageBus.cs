using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBus
{
    public class MessageBus
    {
        public event Action<string>? MessageSent;
        
        public void SendMessage(string message)
        {
            MessageSent?.Invoke(message);
        }
    }
}
