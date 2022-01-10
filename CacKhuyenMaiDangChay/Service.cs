using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;
using CacKhuyenMaiDangChay.Models;

namespace CacKhuyenMaiDangChay
{
    public static class Service
    {
        public static string Name { get; set; } = "Cac Khuyen Mai Dang Chay";
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
            message.Sender = MessageBus.MessageBus.CacKhuyenMaiDangChayService;
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public static void Receive(string json)
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

        public static void PostToConsole(string message)
        {
            Console.WriteLine($"[{Name}]:");

            if (string.IsNullOrEmpty(message))
                return;

            Console.WriteLine(message);
        }

        public static void PostToCacKhuyenMaiHoanThanhService()
        {
            km.soLuongHoaDon = 100;
            km.tongThanhTien = 100000;
            km.laiSuat = (long)(km.tongThanhTien - km.von);
            Send(MessageBus.MessageBus.CacKhuyenMaiHoanThanhService, MessageBus.MessageBus.Post, km.toJson());
        }
    }
}
