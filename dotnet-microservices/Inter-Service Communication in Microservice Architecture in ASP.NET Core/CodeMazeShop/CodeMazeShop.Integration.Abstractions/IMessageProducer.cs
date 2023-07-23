using System.Threading.Tasks;

namespace CodeMazeShop.Integration.Abstractions;

public interface IMessageProducer<in T>
{
    Task SendMessage(T message);
}
