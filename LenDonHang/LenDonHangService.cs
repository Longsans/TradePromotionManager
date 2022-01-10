using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using MessageBus;
using LenDonHang.Models;

namespace LenDonHang
{
    public static class LenDonHangService
    {
        static LenDonHangService()
        {
            MessageBus.MessageBus.MessageSent += s =>
            {
                Message? r = JsonSerializer.Deserialize<Message>(s);
                if (r != null)
                {
                    if (r.Sender == MessageBus.MessageBus.CacKhuyenMaiDangChayService
                        && r.Receiver == MessageBus.MessageBus.LenDonHangService)
                    {
                        PostToConsole($"Received message from {r.Sender}");
                        // send data to client
                    }
                }
            };
        }

        public static void PostToConsole(string message)
        {
            Console.WriteLine($"[{MessageBus.MessageBus.LenDonHangService}]: \"{message}\"");
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

        public static void CreateDonHang(string dhJson)
        {
            SendMessage(
                MessageBus.MessageBus.LenDonHangService,
                MessageBus.MessageBus.SparkStub,
                "PostDonHang",
                dhJson);
            PostToConsole("DonHang created and sent to Spark stub");

            JObject dhObj = JObject.Parse(dhJson);
            var dir = Path.Combine(
                        Directory.GetParent(
                            Environment.CurrentDirectory)
                                .Parent.Parent.FullName,
                        "HoaDonDienTu");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var path = 
                Path.Combine(
                    dir,
                    $"{DateTime.Now.ToString("hhmmss_yyyymmdd")}" +
                    $"_" +
                    $"{(string)dhObj[nameof(DonHang.khachHang)][nameof(KhachHang.idKhachHang)]}" +
                    $".xml");

            var xml = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(dhJson, "HoaDon");
            xml?.Save(path);
            PostToConsole($"DonHang saved to disk at {path}");
        }

        public static string GetCacKhuyenMaiDangChay(DateTime timestamp)
        {
            SendMessage(
                MessageBus.MessageBus.LenDonHangService,
                MessageBus.MessageBus.CacKhuyenMaiDangChayService,
                "GetDangChayBy",
                JsonSerializer.Serialize(timestamp));

            PostToConsole($"Forwarded call to {MessageBus.MessageBus.CacKhuyenMaiDangChayService}.");
            return new KhuyenMai().Serialize();
        }

        public static string GetKhachHangBySdt(string sdt)
        {
            SendMessage(
                MessageBus.MessageBus.LenDonHangService,
                MessageBus.MessageBus.KhachHangService,
                "GetBySdt",
                sdt);
            PostToConsole($"Forwarded call to {MessageBus.MessageBus.KhachHangService}.");
            return new KhachHang().toJson();
        }

        public static string GetMatHangById(string idMh)
        {
            SendMessage(
                MessageBus.MessageBus.LenDonHangService,
                MessageBus.MessageBus.MatHangService,
                "GetById",
                idMh);
            PostToConsole($"Forwarded call to {MessageBus.MessageBus.MatHangService}.");
            return new MatHang().toJson();
        }
    }
}
