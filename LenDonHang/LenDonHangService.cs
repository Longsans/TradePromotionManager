using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using MessageBus;
using ClientMessageReceiver;
using LenDonHang.Models;

namespace LenDonHang
{
    internal class LenDonHangService
    {
        private List<LenDonHangReceiver> clients = new List<LenDonHangReceiver>();

        public LenDonHangService()
        {
            //MessageBus.MessageBus.MessageSent += s =>
            //{
            //    Console.WriteLine($"Received data from service:\n{s}");
            //    Message? r = JsonSerializer.Deserialize<Message>(s);
            //    if (r != null)
            //    {
            //        if (r.Sender == MessageBus.MessageBus.CacKhuyenMaiDangChayService
            //            && r.Receiver == MessageBus.MessageBus.LenDonHangService)
            //            client.ReceiveCacKhuyenMaiDangChay(r.JsonParam);
            //    }
            //};
        }

        public void GetCacKhuyenMaiDangChay(DateTime timestamp, LenDonHangReceiver client)
        {
            Console.WriteLine("Received request to get KhuyenMaiDangChay.");
            MessageBus.MessageBus.SendMessage(new Message()
            {
                Sender = MessageBus.MessageBus.LenDonHangService,
                Receiver = MessageBus.MessageBus.CacKhuyenMaiDangChayService,
                FunctionCall = MessageBus.MessageBus.Get,
                JsonParam = JsonSerializer.Serialize(timestamp)
            });
        }
    }
}
