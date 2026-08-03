namespace MessagingComparisons.Domain.Interfaces;

public interface IMessageHandler
{
    Task Handle(Message message);
}