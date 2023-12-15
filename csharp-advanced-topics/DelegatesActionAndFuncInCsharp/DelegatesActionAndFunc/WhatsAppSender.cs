namespace DelegateFuncAppSample;

public class WhatsAppSender
{
    public void Send(Messages messages)
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.WhatsApp) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending WhatsApp message to {messages.Recipient}: {messages.Message}");
    }
}