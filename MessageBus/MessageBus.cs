using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus
{
    public static class MessageBus
    {
        public static event Action<string>? MessageSent;

        public static void SendMessage(string message)
        {
            MessageSent?.Invoke(message);
        }
    }
}
