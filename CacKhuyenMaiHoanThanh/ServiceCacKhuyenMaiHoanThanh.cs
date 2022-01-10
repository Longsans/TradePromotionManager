using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;

namespace CacKhuyenMaiHoanThanh
{
    public class ServiceCacKhuyenMaiHoanThanh
    {
        public static string Name { get; set; } = "Cac Khuyen Mai Hoan Thanh";

        static private ServiceCacKhuyenMaiHoanThanh? _instance = null;
        static public ServiceCacKhuyenMaiHoanThanh Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceCacKhuyenMaiHoanThanh();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public void Init()
        {
            PostToConsole("Init");
            Instance = new ServiceCacKhuyenMaiHoanThanh();
            MessageBus.MessageBus.MessageSent += Receive;
        }

        public void Send(string receiver, string func, string json)
        {
            PostToConsole("");
            Message message = new Message();
            message.Sender = MessageBus.MessageBus.CacKhuyenMaiHoanThanhService;
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public void Receive(string json)
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

        public void PostToConsole(string message)
        {
            Console.WriteLine($"[{Name}]: {message}");
        }
    }
}
