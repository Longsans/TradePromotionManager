using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;

namespace PhanTichKhuyenMai
{
    public class ServicePhanTichKhuyenMai
    {
        public static string Name { get; set; } = "Phan Tich Khuyen Mai";

        static private ServicePhanTichKhuyenMai? _instance = null;
        static public ServicePhanTichKhuyenMai Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServicePhanTichKhuyenMai();
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
            Instance = new ServicePhanTichKhuyenMai();
            MessageBus.MessageBus.MessageSent += Receive;
        }

        public void Send(string receiver, string func, string json)
        {
            PostToConsole("");
            Message message = new Message();
            message.Sender = MessageBus.MessageBus.PhanTichKhuyenMaiService;
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public void Receive(string json)
        {
            var msg = Message.Decode(json);

            if (msg == null || msg.Receiver != MessageBus.MessageBus.PhanTichKhuyenMaiService)
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
