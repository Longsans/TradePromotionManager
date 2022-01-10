using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;

namespace LenKeHoachKhuyenMai
{
    public class ServiceLenKeHoachKhuyenMai
    {
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

        private ServiceLenKeHoachKhuyenMai()
        {

        }

        static public void Init()
        {
            Console.WriteLine("[Len Ke Hoach Khuyen Mai]");
            Console.WriteLine("Init");
            Instance = new ServiceLenKeHoachKhuyenMai();
        }

        static public void Send(string json)
        {
            Console.WriteLine("[Len Ke Hoach Khuyen Mai]");
            Message message = new Message();
            message.Sender = "CacKhuyenMaiDangChay";
            message.Reciever = "LenKeHoachKhuyenMai";
            message.FunctionCall = "Check";
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }
    }
}
