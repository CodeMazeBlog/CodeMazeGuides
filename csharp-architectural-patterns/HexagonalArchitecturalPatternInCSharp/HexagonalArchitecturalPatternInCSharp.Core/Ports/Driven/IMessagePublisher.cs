using HexagonalArchitecturalPatternInCSharp.Core.Entities;

namespace HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;

public interface IMessagePublisher
{
    Task PublishMessageAsync(Message message);
}
