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

        public void Init()
        {
            Console.WriteLine("[Cac Khuyen Mai Dang Chay]");
            Console.WriteLine("Init");
            Instance = new ServiceCacKhuyenMaiDangChay();
            MessageBus.MessageBus.MessageSent += Recieve;
        }

        public void Send(string reciever, string func, string json)
        {
            Console.WriteLine("[Cac Khuyen Mai Dang Chay]");
            Message message = new Message();
            message.Sender = "CacKhuyenMaiDangChay";
            message.Reciever = reciever;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public void Recieve(string json)
        {
            Console.WriteLine("[Cac Khuyen Mai Dang Chay]");
            Console.WriteLine(json);
        }
    }
}
