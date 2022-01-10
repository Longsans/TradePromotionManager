using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MessageBus;
using MatHang.Models;

namespace MatHang
{
    public static class MatHangService
    {
        public static string GetById(string idMatHang)
        {
            return MatHangModel.GetById(idMatHang).Serialize();
        }

        public static void CreateMatHang(string idMh, string tenMh, ulong donGia, Dictionary<string, object> dacDiem)
        {
            MatHangModel mh = new MatHangModel()
            {
                idMatHang = idMh,
                tenMatHang = tenMh,
                donGia = donGia,
                dacDiem = new Dictionary<string, object>(dacDiem)
            };
            
            try
            {
                mh.Insert();
                PostToConsole("Insert MatHang successful.");
            }
            catch (Exception ex)
            {
                PostToConsole($"Insert failed! Error: {ex.Message}");
            }
        }

        public static string EditMatHang(string idMh, Dictionary<string, object> editedProps)
        {
            MatHangModel mh = MatHangModel.GetById(idMh);
            foreach (var prop in editedProps)
            {
                if (mh.dacDiem.ContainsKey(prop.Key))
                    mh.dacDiem[prop.Key] = prop.Value;
                else 
                    mh.dacDiem.Add(prop.Key, prop.Value);
            }
            
            return mh.Serialize();
        }

        public static void PostToConsole(string message)
        {
            Console.WriteLine($"[{MessageBus.MessageBus.MatHangService}]: \"{message}\"");
        }

        static MatHangService()
        {
            MessageBus.MessageBus.MessageSent += s =>
            {
                Message? mes = Message.Decode(s);
                if (mes != null)
                {
                    if (mes.Sender == MessageBus.MessageBus.LenDonHangService
                        && mes.Receiver == MessageBus.MessageBus.MatHangService)
                        PostToConsole($"Received message from LenDonHang: {mes.JsonParam}");
                }
            };
        }
    }
}
