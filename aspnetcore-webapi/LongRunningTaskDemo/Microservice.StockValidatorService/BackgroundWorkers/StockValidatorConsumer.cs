using System.Text;
using Common.Messaging;
using RabbitMQ.Client;
using Common.Models.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace Microservice.StockValidatorService.BackgroundWorkers
{
    public class StockValidatorConsumer : ConsumerBase, IHostedService
    {
        private readonly IMessageProducer<Failure> _failureProducer;
        private readonly IMessageProducer<CheckoutItem> _successProducer;
        private readonly IValidator _validator;
        private readonly ILogger<StockValidatorConsumer> _logger;

        public StockValidatorConsumer(ConnectionFactory connectionFactory, 
                                      ILogger<RabbitMqClientBase> rabbitMqClientBaseLogger,
                                      ILogger<ConsumerBase> consumerBaseLogger,
                                      IMessageProducer<Failure> failureProducer,
                                      IMessageProducer<CheckoutItem> successProducer,
                                      IValidator validator,
                                      ILogger<StockValidatorConsumer> logger)
            : base(connectionFactory, rabbitMqClientBaseLogger, consumerBaseLogger)
        {
            _failureProducer = failureProducer;
            _successProducer = successProducer;
            _validator = validator;
            _logger = logger;
        }

        protected override async Task OnMessageReceived(object? sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var body = Encoding.UTF8.GetString(@event.Body.ToArray());
                var checkoutItem = JsonConvert.DeserializeObject<CheckoutItem>(body);

                if (await _validator.ValidateAsync(checkoutItem.Request.LineItems))
                {
                    _successProducer.SendMessage(checkoutItem);
                    return;
                }

                var failureMessage = new Failure
                {
                    CustomerId = checkoutItem.Request.CustomerId,
                    OrderId = checkoutItem.OrderId,
                    Message = "Item not available in stock",
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

        protected override string QueueName => "stock-validator";

        public Task StartAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;

        }
    }
}