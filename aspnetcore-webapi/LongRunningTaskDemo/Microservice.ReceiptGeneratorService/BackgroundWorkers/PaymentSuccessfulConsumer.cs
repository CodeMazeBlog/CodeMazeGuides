using System.Text;
using Common.Messaging;
using Common.Models.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Microservice.ReceiptGeneratorService.BackgroundWorkers
{
    public class PaymentSuccessfulConsumer : ConsumerBase, IHostedService
    {
        private readonly IReceiptGenerator _generator;
        private readonly ILogger<PaymentSuccessfulConsumer> _logger;

        public PaymentSuccessfulConsumer(ConnectionFactory connectionFactory,
                                         ILogger<RabbitMqClientBase> rabbitMqClientBaseLogger,
                                         ILogger<ConsumerBase> consumerBaseLogger,
                                         IReceiptGenerator generator,
                                         ILogger<PaymentSuccessfulConsumer> logger)
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
                var successMessage = JsonConvert.DeserializeObject<PaymentSuccess>(body);

                await _generator.GenerateAsync(successMessage.Request.CustomerId, successMessage.OrderId, successMessage.Amount);

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

        protected override string QueueName => "payment-successful";

        public Task StartAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;

        }
    }
}
