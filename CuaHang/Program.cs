// See https://aka.ms/new-console-template for more information
Console.WriteLine("[Cua Hang]");

public class Service
{
    public static string Name { get; set; } = "CuaHang";

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
        if (msg?.Reciever == Name)
        {
            Console.WriteLine($"Recieve message from {msg.Sender}");
        }
    }
}