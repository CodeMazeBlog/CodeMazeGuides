using System.Text.Json;
using System.Text;
using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using CodeMazeShop.Services.Payment.Services;

namespace CodeMazeShop.Services.Payment.Workers;

public class PaymentRequestConsumer : ConsumerBase, IHostedService
{
    private readonly IMessageProducer<PaymentUpdateMessage> _paymentUpdateProducer;
    private readonly IServiceProvider _serviceProvider;    
    private readonly ILogger<PaymentRequestConsumer> _logger;

    public PaymentRequestConsumer(ConnectionFactory connectionFactory,
                            ILogger<RabbitMqClientBase> rabbitMqClientBaseLogger,
                            ILogger<ConsumerBase> consumerBaseLogger,
                            IServiceProvider serviceProvider,
                            IConfiguration configuration,
                            IMessageProducer<PaymentUpdateMessage> paymentUpdateProducer,
                            ILogger<PaymentRequestConsumer> logger) :
        base(connectionFactory, 
             rabbitMqClientBaseLogger, 
             consumerBaseLogger, 
             configuration["RabbitMQ:PaymentRequestQueueName"])
    {
        _serviceProvider = serviceProvider;        
        _paymentUpdateProducer = paymentUpdateProducer;
        _logger = logger;
    }

    protected override async Task OnMessageReceived(object? sender, BasicDeliverEventArgs @event)
    {
        try
        {
            var body = Encoding.UTF8.GetString(@event.Body.ToArray());
            var paymentRequestMessage = JsonSerializer.Deserialize<PaymentRequestMessage>(body);

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IPaymentService paymentService =
                    scope.ServiceProvider.GetRequiredService<IPaymentService>();

                await _paymentUpdateProducer.SendMessage(new PaymentUpdateMessage
                {
                    PaymentSuccess = await paymentService.MakePayment(paymentRequestMessage),
                    OrderId = paymentRequestMessage.OrderId,
                });
                
            }

        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Error while retrieving message from queue.");
        }
        finally
        {
            Channel.BasicAck(@event.DeliveryTag, false);
        }
    }   

    public Task StartAsync(CancellationToken cancellationToken)
           => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Dispose();
        return Task.CompletedTask;

    }
}
