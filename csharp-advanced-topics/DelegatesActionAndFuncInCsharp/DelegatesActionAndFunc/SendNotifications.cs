namespace DelegateFuncAppSample;

public class SendNotifications
{
    public Func<Messages, Action> WhatsApp { get; } = messages => () =>
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.WhatsApp) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending WhatsApp message to {messages.Recipient}: {messages.Message}");
    };

    public Func<Messages, Action> Sms { get; } = messages => () =>
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.Sms) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending SMS to {messages.Recipient}: {messages.Message}");
    };

    public Func<Messages, Action> Email { get; } = messages => () =>
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.Email) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending Email to {messages.Recipient}: {messages.Message}");
    };

    public int[] CountTypes { get; set; } = new[] { 0, 0, 0 };
}