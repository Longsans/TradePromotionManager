using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;
using CacKhuyenMaiDangChay.Models;

namespace CacKhuyenMaiDangChay
{
    public class ServiceCacKhuyenMaiDangChay
    {
        public static string Name { get; set; } = "Cac Khuyen Mai Dang Chay";
        KhuyenMai km = new KhuyenMai();

        static private ServiceCacKhuyenMaiDangChay? _instance = null;
        static public ServiceCacKhuyenMaiDangChay Instance
        {
            get 
            { 
                if (_instance == null)
                    _instance = new ServiceCacKhuyenMaiDangChay();
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
            Instance = new ServiceCacKhuyenMaiDangChay();
            MessageBus.MessageBus.MessageSent += Receive;
        }

        public void Send(string receiver, string func, string json)
        {
            PostToConsole("");
            Message message = new Message();
            message.Sender = MessageBus.MessageBus.CacKhuyenMaiDangChayService;
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public void Receive(string json)
        {
            var msg = Message.Decode(json);

            if (msg == null || msg.Receiver != MessageBus.MessageBus.CacKhuyenMaiDangChayService)
                return;

            switch (msg.FunctionCall)
            {
                case "POST":
                    PostToConsole("Received Message POST");
                    km = new KhuyenMai(msg.JsonParam);
                    Console.WriteLine(msg.JsonParam);
                    break;
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
