using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;

namespace HexagonalArchitecturalPatternInCSharp.Messaging.Publishers;

public class MessagePublisher : IMessagePublisher
{
    public Task PublishMessageAsync(Message message)
    {
        return Task.CompletedTask;
    }
}