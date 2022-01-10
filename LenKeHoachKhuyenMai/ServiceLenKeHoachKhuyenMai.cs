using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;
using LenKeHoachKhuyenMai.Models;

namespace LenKeHoachKhuyenMai
{
    public static class ServiceLenKeHoachKhuyenMai
    {
        public static string Name { get; set; } = "Len Ke Hoach Khuyen Mai";
        static KhuyenMai km = new KhuyenMai("{\"thoiGianBatDau\":\"12/12/2021\",\"thoiGianKetThuc\":\"2/2/2022\",\"soLuongMucTieu\":200,\"von\":10000,\"laiSuatMucTieu\":50000}");

        static ServiceLenKeHoachKhuyenMai()
        {
            PostToConsole("Init");
            MessageBus.MessageBus.MessageSent += Receive;
        }

        public static void Send(string receiver, string func, string json)
        {
            PostToConsole("");
            Message message = new Message();
            message.Sender = MessageBus.MessageBus.LenKeHoachKhuyenMaiService;
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public static void Receive(string json)
        {
            var msg = Message.Decode(json);

            if (msg == null || msg.Receiver != MessageBus.MessageBus.LenKeHoachKhuyenMaiService)
                return;

            PostToConsole($"Received Message: {json}");

            switch (msg.FunctionCall)
            {
                case "GET REP":
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

        public static void PostToCacKhuyenMaiDangChayService()
        {
            Send(MessageBus.MessageBus.CacKhuyenMaiDangChayService, MessageBus.MessageBus.Post, km.toJson());
        }

        public static void GetHinhThucVaTieuChiKhuyenMaiService()
        {
            //func
        }
    }
}
