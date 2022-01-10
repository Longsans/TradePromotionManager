using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;

namespace CacKhuyenMaiHoanThanh
{
    public static class ServiceCacKhuyenMaiHoanThanh
    {
        public static string Name { get; set; } = "Cac Khuyen Mai Hoan Thanh";

        static ServiceCacKhuyenMaiHoanThanh()
        {
            PostToConsole("Init");
            MessageBus.MessageBus.MessageSent += Receive;
        }

        public static void Send(string receiver, string func, string json)
        {
            PostToConsole("");
            Message message = new Message();
            message.Sender = MessageBus.MessageBus.CacKhuyenMaiHoanThanhService;
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public static void Receive(string json)
        {
            var msg = Message.Decode(json);

            if (msg == null || msg.Receiver != MessageBus.MessageBus.CacKhuyenMaiHoanThanhService)
                return;

            PostToConsole($"Received Message: {json}");

            switch (msg.FunctionCall)
            {
                default:
                    break;
            }
        }

        public static void PostToConsole(string message)
        {
            Console.WriteLine($"[{Name}]:");

            if (string.IsNullOrEmpty(message))
                return;

            Console.WriteLine(message);
        }
    }
}
