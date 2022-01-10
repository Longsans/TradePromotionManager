using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;
using PhanTichKhuyenMai.Models;

namespace PhanTichKhuyenMai
{
    public static class Service
    {
        public static string Name { get; set; } = "Phan Tich Khuyen Mai";
        static KhuyenMai km = new KhuyenMai();

        static Service()
        {
            PostToConsole("Init");
            MessageBus.MessageBus.MessageSent += Receive;
        }

        public static void Send(string receiver, string func, string json)
        {
            PostToConsole("");
            Message message = new Message();
            message.Sender = MessageBus.MessageBus.PhanTichKhuyenMaiService;
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public static void Receive(string json)
        {
            var msg = Message.Decode(json);

            if (msg == null || msg.Receiver != MessageBus.MessageBus.PhanTichKhuyenMaiService)
                return;

            switch (msg.FunctionCall)
            {
                case "GET REP":
                    PostToConsole("Received Message GET REP");
                    km = new KhuyenMai(msg.JsonParam);
                    Console.WriteLine(msg.JsonParam);
                    break;
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

        public static void GetCacKhuyenMaiHoanThanh()
        {
            Send(MessageBus.MessageBus.CacKhuyenMaiHoanThanhService, MessageBus.MessageBus.Get, "");
        }
    }
}
