using System.Text;
using System.Text.Json;
using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using CodeMazeShop.Services.Ordering.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CodeMazeShop.Services.Ordering.Workers
{
    public class PaymentUpdateConsumer : ConsumerBase, IHostedService
    {
        private readonly IServiceProvider _serviceProvider;       
        private readonly ILogger<PaymentUpdateConsumer> _logger;

        public PaymentUpdateConsumer(ConnectionFactory connectionFactory,
                                ILogger<RabbitMqClientBase> rabbitMqClientBaseLogger,
                                ILogger<ConsumerBase> consumerBaseLogger,                               
                                IServiceProvider serviceProvider,
                                IConfiguration configuration,
                                ILogger<PaymentUpdateConsumer> logger) :
            base(connectionFactory, rabbitMqClientBaseLogger, consumerBaseLogger, configuration["RabbitMQ:PaymentUpdateQueueName"])
        {           
            _serviceProvider = serviceProvider;            
            _logger = logger;
        }

        protected override async Task OnMessageReceived(object? sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var body = Encoding.UTF8.GetString(@event.Body.ToArray());
                var paymentUpdateMessage = JsonSerializer.Deserialize<PaymentUpdateMessage>(body);

                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    IOrderRepository orderRepository =
                        scope.ServiceProvider.GetRequiredService<IOrderRepository>();

                    await orderRepository.UpdateOrderStatus(paymentUpdateMessage.OrderId.ToString(), paymentUpdateMessage.PaymentSuccess);                  
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
}
