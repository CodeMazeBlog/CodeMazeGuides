namespace Common.Messaging
{
    public interface IMessageProducer<in T>
    {
        void SendMessage(T message);
    }
}
