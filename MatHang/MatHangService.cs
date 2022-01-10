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

        public static void CreateMatHang(string idMh, string tenMh, ulong donGia, params KeyValuePair<string, object>[] dacDiem)
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

        public static string EditMatHang(string idMh, params KeyValuePair<string, object>[] editedProps)
        {
            MatHangModel mh = MatHangModel.GetById(idMh);
            Type mhType = mh.GetType();
            try
            {
                foreach (var prop in editedProps)
                {
                    mhType.GetProperty(prop.Key).SetValue(mh, prop.Value);
                }
            }
            catch (Exception ex)
            {
                PostToConsole($"Edit failed! Error: {ex.Message}");
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
