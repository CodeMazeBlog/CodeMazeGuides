using System.Text;
using Common.Messaging;
using Common.Models.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Microservice.PaymentProcessingService.BackgroundWorkers
{
    public class TaxConsumer : ConsumerBase, IHostedService
    {
        private readonly IMessageProducer<Failure> _failureProducer;
        private readonly IMessageProducer<PaymentSuccess> _successProducer;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ILogger<TaxConsumer> _logger;

        public TaxConsumer(ConnectionFactory connectionFactory,
                           ILogger<RabbitMqClientBase> rabbitMqClientBaseLogger,
                           ILogger<ConsumerBase> consumerBaseLogger,
                           IMessageProducer<Failure> failureProducer,
                           IMessageProducer<PaymentSuccess> successProducer,
                           IPaymentProcessor paymentProcessor,
                           ILogger<TaxConsumer> logger)
            : base(connectionFactory, rabbitMqClientBaseLogger, consumerBaseLogger)
        {
            _failureProducer = failureProducer;
            _successProducer = successProducer;
            _paymentProcessor = paymentProcessor;
            _logger = logger;
        }

        protected override async Task OnMessageReceived(object? sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var body = Encoding.UTF8.GetString(@event.Body.ToArray());
                var taxMessage = JsonConvert.DeserializeObject<Tax>(body);
                
                var amount = taxMessage.Request.LineItems.Sum(li => li.Quantity * li.Price) + taxMessage.TaxAmount;
                
                if (await _paymentProcessor.ProcessAsync(taxMessage.Request.CustomerId, taxMessage.Request.PaymentInfo, amount))
                {
                    var paymentSuccessMessage = new PaymentSuccess
                    {
                        OrderId = taxMessage.OrderId,
                        Request = taxMessage.Request,
                        Amount = amount
                    };
                    _successProducer.SendMessage(paymentSuccessMessage);
                    return;
                }

                var failureMessage = new Failure
                {
                    CustomerId = taxMessage.Request.CustomerId,
                    OrderId = taxMessage.OrderId,
                    Message = "Payment failure",
                    Source = typeof(Program).Assembly.GetName().Name ?? string.Empty
                };

                _failureProducer.SendMessage(failureMessage);
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

        protected override string QueueName => "tax";

        public Task StartAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }
    }
}