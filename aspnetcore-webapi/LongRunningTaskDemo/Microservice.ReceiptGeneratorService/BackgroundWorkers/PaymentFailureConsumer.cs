using System.Text;
using Common.Messaging;
using Common.Models.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Microservice.ReceiptGeneratorService.BackgroundWorkers
{
    public class PaymentFailureConsumer : ConsumerBase, IHostedService 
    {
        private readonly IReceiptGenerator _generator;
        private readonly ILogger<PaymentFailureConsumer> _logger;

        public PaymentFailureConsumer(ConnectionFactory connectionFactory,
                                              ILogger<RabbitMqClientBase> rabbitMqClientBaseLogger,
                                              ILogger<ConsumerBase> consumerBaseLogger,
                                              IReceiptGenerator generator,
                                              ILogger<PaymentFailureConsumer> logger)
           : base(connectionFactory, rabbitMqClientBaseLogger, consumerBaseLogger)
        {
            _generator = generator;
            _logger = logger;
        }

        protected override async Task OnMessageReceived(object? sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var body = Encoding.UTF8.GetString(@event.Body.ToArray());
                var failureMessage = JsonConvert.DeserializeObject<Failure>(body);

                await _generator.ProcessFailuresAsync(failureMessage.CustomerId, failureMessage.OrderId, failureMessage.Message);

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

        protected override string QueueName => "payment-failure";

        public Task StartAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;

        }
    }
}
