using HoaDon;
using Newtonsoft.Json.Linq;

Console.WriteLine("[Hoa Don]");

var json = new JObject();
json["ID"] = "123";

Service.ProcessMessage(new MessageBus.Message
{
    Receiver = "HoaDon",
    Sender = "Testing",
    FunctionCall = "LuuDonHang",
    JsonParam = "{\"ID: \"1234\"}"
}.Encode());