namespace CodeMaze.Integration.Abstractions;

public interface IMessageProducer<in T>
{
    Task SendMessage(T message);
}
