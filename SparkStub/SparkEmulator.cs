using SparkStub.Models;
using MessageBus;

namespace SparkStub
{
    public class SparkEmulator
    {
        static SparkEmulator()
        {
            MessageBus.MessageBus.MessageSent += s =>
            {
                Message msg = Message.Decode(s);
                if (msg == null || msg.Receiver != MessageBus.MessageBus.SparkStub)
                    return;

                if (msg.Sender == MessageBus.MessageBus.HoaDonService)
                {
                    DonHang dh = new DonHang(msg.JsonParam);
                    SendMessage(
                        MessageBus.MessageBus.SparkStub,
                        MessageBus.MessageBus.PhanTichKhuyenMaiService,
                        "",
                        msg.JsonParam);
                    PostToConsole($"Saved information of DonHang with id {dh.id} for analysis.");
                }
            };
        }

        public static void PostToConsole(string message)
        {
            Console.WriteLine($"[{MessageBus.MessageBus.SparkStub}]: \"{message}\"");
        }

        private static void SendMessage(string sender, string receiver, string function, string json)
        {
            MessageBus.MessageBus.SendMessage(new Message()
            {
                Sender = sender,
                Receiver = receiver,
                FunctionCall = function,
                JsonParam = json
            });
        }
    }
}