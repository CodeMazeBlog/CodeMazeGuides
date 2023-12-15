namespace DelegateFuncAppSample;

public class EmailSender
{
    public void Send(Messages messages)
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.Email) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending Email to {messages.Recipient}: {messages.Message}");
    }
}