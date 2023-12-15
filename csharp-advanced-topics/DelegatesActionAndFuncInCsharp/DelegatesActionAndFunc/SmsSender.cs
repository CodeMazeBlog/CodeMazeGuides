namespace DelegateFuncAppSample;

public class SmsSender
{
    public void Send(Messages messages)
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.Sms) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending SMS to {messages.Recipient}: {messages.Message}");
    }
}