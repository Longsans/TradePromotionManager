using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBus;

namespace CacKhuyenMaiDangChay
{
    public class ServiceCacKhuyenMaiDangChay
    {
        static private ServiceCacKhuyenMaiDangChay? _instance = null;
        static public ServiceCacKhuyenMaiDangChay Instance
        {
            get 
            { 
                if (_instance == null)
                    _instance = new ServiceCacKhuyenMaiDangChay();
                return _instance; 
            }
            private set
            {
                _instance = value;
            }
        }

        private ServiceCacKhuyenMaiDangChay()
        {
            MessageBus.MessageBus.MessageSent += Receive;
        }

        static public void Init()
        {
            Console.WriteLine("[Cac Khuyen Mai Dang Chay]");
            Console.WriteLine("Init");
            Instance = new ServiceCacKhuyenMaiDangChay();
        }

        static public void Send()
        {
            Console.WriteLine("[Cac Khuyen Mai Dang Chay]");
            Message message = new Message();
            message.Sender = "CacKhuyenMaiDangChay";
            message.Reciever = "LenKeHoachKhuyenMai";
            message.FunctionCall = "";
        }

        static public void Receive(string json)
        {
            Console.WriteLine("[Cac Khuyen Mai Dang Chay]");
            Console.WriteLine(json);
        }
    }
}
