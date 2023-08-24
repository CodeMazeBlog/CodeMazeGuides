namespace ConditionalDependencyResolution.Message;

public class MessageService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}