using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;
using LenKeHoachKhuyenMai.Models;

namespace LenKeHoachKhuyenMai
{
    public class ServiceLenKeHoachKhuyenMai
    {
        public static string Name { get; set; } = "Len Ke Hoach Khuyen Mai";
        KhuyenMai km = new KhuyenMai("{\"thoiGianBatDau\":\"12/12/2021\",\"thoiGianKetThuc\":\"2/2/2022\",\"soLuongMucTieu\":200,\"von\":10000,\"laiSuatMucTieu\":50000}");

        static private ServiceLenKeHoachKhuyenMai? _instance = null;
        static public ServiceLenKeHoachKhuyenMai Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceLenKeHoachKhuyenMai();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public void Init()
        {
            PostToConsole("Init");
            Instance = new ServiceLenKeHoachKhuyenMai();
            MessageBus.MessageBus.MessageSent += Receive;
        }

        public void Send(string receiver, string func, string json)
        {
            PostToConsole("");
            Message message = new Message();
            message.Sender = MessageBus.MessageBus.LenKeHoachKhuyenMaiService;
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public void Receive(string json)
        {
            var msg = Message.Decode(json);

            if (msg == null || msg.Receiver != MessageBus.MessageBus.LenKeHoachKhuyenMaiService)
                return;

            PostToConsole($"Received Message: {json}");

            switch (msg.FunctionCall)
            {
                default:
                    break;
            }
        }

        public void PostToConsole(string message)
        {
            Console.WriteLine($"[{Name}]: {message}");
        }

        public void PostToCacKhuyenMaiDangChayService()
        {
            Send(MessageBus.MessageBus.CacKhuyenMaiDangChayService, MessageBus.MessageBus.Post, km.toJson());
        }
    }
}
