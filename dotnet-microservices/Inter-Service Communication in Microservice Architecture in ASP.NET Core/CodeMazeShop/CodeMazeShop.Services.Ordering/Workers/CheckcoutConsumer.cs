using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using AutoMapper;
using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using CodeMazeShop.Services.Ordering.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CodeMazeShop.Services.Ordering.Workers;

public class CheckoutConsumer : ConsumerBase, IHostedService
{
    private readonly IMessageProducer<PaymentRequestMessage> _paymentRequestProducer;
    private readonly IServiceProvider _serviceProvider;  
    private readonly ILogger<CheckoutConsumer> _logger;

    public CheckoutConsumer(ConnectionFactory connectionFactory,
                            ILogger<RabbitMqClientBase> rabbitMqClientBaseLogger,
                            ILogger<ConsumerBase> consumerBaseLogger,
                            IMessageProducer<PaymentRequestMessage> paymentRequestProducer,
                            IServiceProvider serviceProvider,
                            IConfiguration configuration,
                            ILogger<CheckoutConsumer> logger) : 
        base(connectionFactory, 
             rabbitMqClientBaseLogger, 
             consumerBaseLogger, 
             configuration["RabbitMQ:CheckoutQueueName"])
    {
        _paymentRequestProducer= paymentRequestProducer;
       _serviceProvider= serviceProvider;        
        _logger = logger;
    }

    protected override async Task OnMessageReceived(object? sender, BasicDeliverEventArgs @event)
    {
        try
        {
            var body = Encoding.UTF8.GetString(@event.Body.ToArray());
            var cartCheckoutMessage = JsonSerializer.Deserialize<CartCheckoutMessage>(body);

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IOrderCreatorService orderCreatorService =
                    scope.ServiceProvider.GetRequiredService<IOrderCreatorService>();

                var orderId = await orderCreatorService.CreateOrder(cartCheckoutMessage);
                if(orderId != Guid.Empty)
                {
                    await _paymentRequestProducer.SendMessage(new PaymentRequestMessage
                    {
                        OrderId = orderId,
                        CardName = cartCheckoutMessage.CardName,
                        CardExpiration = cartCheckoutMessage.CardExpiration,
                        CardNumber = cartCheckoutMessage.CardNumber,
                        Total = cartCheckoutMessage.OrderTotal
                    });
                }              
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
