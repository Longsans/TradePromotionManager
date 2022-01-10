using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus
{
    public static class MessageBus
    {
        public static event Action<string>? MessageSent;

        public static string LenDonHangService = "LenDonHangService";
        public static string CacKhuyenMaiDangChayService = "CacKhuyenMaiDangChayService";

        public static string CacKhuyenMaiHoanThanhService = "CacKhuyenMaiHoanThanhService";
        public static string LenKeHoachKhuyenMaiService = "LenKeHoachKhuyenMaiService";
        public static string PhanTichKhuyenMaiService = "PhanTichKhuyenMaiService";

        public static string Get = "GET";
        public static string Put = "PUT";
        public static string Post = "POST";
        public static string Delete = "DELETE";

        public static string MatHangService = "MatHangService";
        public static string KhachHangService = "KhachHangService";
        public static string HoaDonService = "HoaDonService";
        public static string UserService = "UserService";
        public static string SparkStub = "SparkStub";

        public static void SendMessage(Message msg)
        {
            Console.WriteLine($"Sending message");
            MessageSent?.Invoke(msg.Encode());
        }
    }
}
