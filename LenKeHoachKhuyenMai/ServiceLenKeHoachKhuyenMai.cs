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

        public void Init()
        {
            Console.WriteLine("[Len Ke Hoach Khuyen Mai]");
            Console.WriteLine("Init");
            Instance = new ServiceLenKeHoachKhuyenMai();
            MessageBus.MessageBus.MessageSent += Receive;
        }

        public void Send(string receiver, string func, string json)
        {
            Console.WriteLine("[Len Ke Hoach Khuyen Mai]");
            Message message = new Message();
            message.Sender = "LenKeHoachKhuyenMai";
            message.Receiver = receiver;
            message.FunctionCall = func;
            message.JsonParam = json;
            MessageBus.MessageBus.SendMessage(message);
        }

        public void Receive(string json)
        {
            Console.WriteLine("[Len Ke Hoach Khuyen Mai]");
            Console.WriteLine(json);
        }
    }
}
