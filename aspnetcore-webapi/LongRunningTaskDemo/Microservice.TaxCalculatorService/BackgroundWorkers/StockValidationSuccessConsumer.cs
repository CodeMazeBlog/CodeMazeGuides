using System.Text;
using Common.Messaging;
using Common.Models.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Microservice.TaxCalculatorService.BackgroundWorkers
{
    public class StockValidationSuccessConsumer : ConsumerBase, IHostedService
    {
        private readonly IMessageProducer<Tax> _taxProducer;
        private readonly ICalculator _calculator;
        private readonly ILogger<StockValidationSuccessConsumer> _logger;

        public StockValidationSuccessConsumer(ConnectionFactory connectionFactory,
                                              ILogger<RabbitMqClientBase> rabbitMqClientBaseLogger,
                                              ILogger<ConsumerBase> consumerBaseLogger,
                                              IMessageProducer<Tax> taxProducer,
                                              ICalculator calculator,
                                              ILogger<StockValidationSuccessConsumer> logger)
           : base(connectionFactory, rabbitMqClientBaseLogger, consumerBaseLogger)
        {            
            _taxProducer = taxProducer;
            _calculator = calculator;
            _logger = logger;
        }

        protected override async Task OnMessageReceived(object? sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var body = Encoding.UTF8.GetString(@event.Body.ToArray());
                var checkoutItem = JsonConvert.DeserializeObject<CheckoutItem>(body);

                var tax = await _calculator.CalculateTaxAsync(checkoutItem.Request.CustomerId, checkoutItem.Request.LineItems);

                var taxMessage = new Tax
                {
                    OrderId = checkoutItem.OrderId,
                    Request = checkoutItem.Request,
                    TaxAmount = tax
                };

                _taxProducer.SendMessage(taxMessage);
               
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

        protected override string QueueName => "stock-validation-successful";

        public Task StartAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;

        }
    }
}