using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using MessageBus;
using LenDonHang.Models;

namespace LenDonHang
{
    public  class LenDonHangService
    {
        public LenDonHangService()
        {
            MessageBus.MessageBus.MessageSent += s =>
            {
                Console.WriteLine($"Received data from service:\n{s}");
                Message? r = JsonSerializer.Deserialize<Message>(s);
                if (r != null)
                {
                    if (r.Sender == MessageBus.MessageBus.CacKhuyenMaiDangChayService
                        && r.Receiver == MessageBus.MessageBus.LenDonHangService)
                    {
                        // send data to client
                    }
                }
            };
        }

        public void GetCacKhuyenMaiDangChay(DateTime timestamp)
        {
            Console.WriteLine("Received request to get KhuyenMaiDangChay.");
            MessageBus.MessageBus.SendMessage(new Message()
            {
                Sender = MessageBus.MessageBus.LenDonHangService,
                Receiver = MessageBus.MessageBus.CacKhuyenMaiDangChayService,
                FunctionCall = "GetDangChay",
                JsonParam = JsonSerializer.Serialize(timestamp)
            });
        }
    }
}
