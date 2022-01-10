using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HoaDon
{
    public class Service
    {
        public static string Name { get; set; } = "HoaDon";

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
                case nameof(LuuDonHang):
                    LuuDonHang(msg.JsonParam);
                    break;
                case nameof(TimDonHang):
                    TimDonHang(msg.Sender, msg.JsonParam);
                    break;
            }
        }

        public static void LuuDonHang(string json)
        {
            var donHang = JsonSerializer.Deserialize<HoaDon.Models.DonHang>(json);
            if (donHang != null)
            {
                PostToConsole($"Luu don hang {donHang.ID}");
            }
        }
        public static void TimDonHang(string sender, string json)
        {
            var jsonObject = JObject.Parse(json);

            string? id = (string?)jsonObject["ID"];
            if (id == null)
                return;

            var donHang = HoaDon.Models.DonHang.Find(id);
            PostToConsole($"Time thay don hang voi ID: {id}");

            SendMessage(sender, "", donHang.Encode());
        }
    }
}
