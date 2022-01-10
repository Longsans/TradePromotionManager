using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ClientMessageReceiver.Models;

namespace ClientMessageReceiver
{
    public class LenDonHangReceiver
    {
        private List<KhuyenMai>? runningKm;

        public void ReceiveCacKhuyenMaiDangChay(string json)
        {
            runningKm = JsonSerializer.Deserialize<List<KhuyenMai>>(json);
        }
    }
}
