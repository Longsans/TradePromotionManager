using Newtonsoft.Json.Linq;
using System.Text.Json;

Console.WriteLine("[Hoa Don]");

var json = new JObject();
json["ID"] = "123";

Service.ProcessMessage(new MessageBus.Message
{
    Reciever = "HoaDon",
    Sender = "Testing",
    FunctionCall = "LuuDonHang",
    JsonParam = "{\"ID\": \"1234\"}"
}.Encode());

public class Service
{
    public static string Name { get; set; } = "HoaDon";

    static Service()
    {
        MessageBus.MessageBus.MessageSent += Service.ProcessMessage;
    }

    public static void SendMessage(string reciever, string callingFunction, string jsonContext)
    {
        MessageBus.MessageBus.SendMessage(new MessageBus.Message
        {
            Reciever = reciever,
            FunctionCall = callingFunction,
            JsonParam = jsonContext,
            Sender = Name
        });
    }
    public static void ProcessMessage(string json)
    {
        var msg = MessageBus.Message.Decode(json);
        if (msg == null || msg.Reciever != Name)
        {
            return;
        }

        Console.WriteLine($"Recieve message from {msg.Sender}");
        switch (msg.FunctionCall)
        {
            case nameof(LuuDonHang):
                LuuDonHang(msg.JsonParam);
                break;
            case nameof(TimDonHang):
                TimDonHang(msg.Sender, msg.JsonParam);
                break;
        }
    }

    public static void LuuDonHang(string json)
    {
        var donHang = JsonSerializer.Deserialize<HoaDon.Models.DonHang>(json);
        if (donHang != null)
        {
            Console.WriteLine($"Luu don hang {donHang.ID}");
        }
    }
    public static void TimDonHang(string sender, string json)
    {
        var jsonObject = JObject.Parse(json);

        string? id = (string?)jsonObject["ID"];
        if (id == null)
            return;

        var donHang = HoaDon.Models.DonHang.Find(id);
        Console.WriteLine($"Time thay don hang voi ID: {id}");
        Console.WriteLine(donHang.Encode());

        SendMessage(sender, "", donHang.Encode());
    }
}