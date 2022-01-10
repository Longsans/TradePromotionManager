using Newtonsoft.Json.Linq;

namespace CuaHang
{
    public class Service
    {
        public static string Name { get; set; } = "CuaHang";

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
                case nameof(TimCuaHang):
                    TimCuaHang(msg.Sender, msg.JsonParam);
                    break;
            }
        }

        public static void TimCuaHang(string sender, string json)
        {
            JObject jsonO = JObject.Parse(json);
            string? id = (string?)jsonO["ID"];
            if (id == null)
                return;

            PostToConsole($"Tim thay cua hang voi ID {id}");
            var cuaHang = CuaHang.Models.CuaHang.Find(id);

            SendMessage(sender, "", cuaHang.Encode());
        }
    }
}