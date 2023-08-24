namespace ConditionalDependencyResolution.Message;

public class VerboseMessageService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine($"Length: {message.Length}. Time: {DateTime.Now:u}");
    }
}