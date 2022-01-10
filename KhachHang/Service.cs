using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace KhachHang
{
    public static class Service
    {
        public static string Name { get; set; } = "Khach Hang";

        static Service()
        {
            MessageBus.MessageBus.MessageSent += Service.ProcessMessage;
        }

        public static void PostToConsole(string message)
        {
            Console.WriteLine($"[{Name}]: \"{message}\"");
        }

        public static void SendMessage(string reciever, string callingFunction, string jsonContext)
        {
            MessageBus.MessageBus.SendMessage(new MessageBus.Message
            {
                Receiver = reciever,
                FunctionCall = callingFunction,
                JsonParam = jsonContext,
                Sender = Name
            });
        }
        public static void ProcessMessage(string json)
        {
            var msg = MessageBus.Message.Decode(json);
            if (msg == null || msg.Receiver != Name)
            {
                return;
            }

            PostToConsole($"Recieve message from {msg.Sender}");
            switch (msg.FunctionCall)
            {
                case nameof(TimKhachHang):
                    TimKhachHang(msg.Sender, msg.JsonParam);
                    break;
            }
        }

        public static void TimKhachHang(string sender, string param)
        {
            JObject jsonObj = JObject.Parse(param);
            int? id = (int?)jsonObj[nameof(KhachHang.Models.KhachHang.idKhachHang)];
            if (!id.HasValue)
            {
                return;
            }

            PostToConsole($"Tim thay khach hang voi ID {id}");

            var khachHang = KhachHang.Models.KhachHang.FindID(id.Value);
            SendMessage(sender, "", khachHang.Encode());
        }
    }
}
