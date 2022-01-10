using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinhThucVaTieuChiKhuyenMai
{
    public class Service
    {
        public static string Name { get; set; } = "HinhThucVaTieuChi";

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
                case nameof(TimHinhThuc):
                    TimHinhThuc(msg.Sender, json);
                    break;
            }
        }

        public static void TimHinhThuc(string sender, string json)
        {
            JObject jsonO = JObject.Parse(json);
            string? ten = (string?)jsonO["HinhThuc"];
            if (ten == null)
                return;

            PostToConsole($"Tim thay hinh thuc {ten}");
            var hinhThuc = HinhThucVaTieuChiKhuyenMai.Models.HinhThuc.Find(ten).Encode();

            SendMessage(sender, "", hinhThuc);
        }
    }
}
