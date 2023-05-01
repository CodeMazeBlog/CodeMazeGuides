using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CodeMazeShop.Integration.Abstractions;

public abstract class ConsumerBase : RabbitMqClientBase
{
    protected ConsumerBase(ConnectionFactory connectionFactory,
                           ILogger<RabbitMqClientBase> logger,
                           ILogger<ConsumerBase> consumerLogger,
                           string queueName)
        : base(connectionFactory, logger, queueName)
    {

        try
        {
            var consumer = new AsyncEventingBasicConsumer(Channel);
            consumer.Received += OnMessageReceived;           
            Channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
            //Nice way to debug Channel Exceptions
            //Channel.CallbackException += (chann, args) =>
            //{
            //    //check args.Exception for details
            //    Console.WriteLine(args.Exception);
            //};
        }
        catch (Exception ex)
        {
            consumerLogger.LogCritical(ex, "Error while consuming message");
        }
    }   

    protected abstract Task OnMessageReceived(object sender, BasicDeliverEventArgs @event);

}
