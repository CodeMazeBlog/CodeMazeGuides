using Common.Messaging;
using Common.Models.Messages;

namespace Microservice.ShoppingCartApi.BackgroundWorkers
{
    public class CheckoutBackgroundWorker : BackgroundService
    {
        private readonly IMessageProducer<CheckoutItem> _producer;
        private readonly ICheckoutProcessor _checkoutProcessor;

        public CheckoutBackgroundWorker(IMessageProducer<CheckoutItem> producer,
                                        ICheckoutProcessor checkoutProcessor)
        {
            _producer = producer;
            _checkoutProcessor = checkoutProcessor;
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Factory.StartNew(() =>  Process(stoppingToken), TaskCreationOptions.LongRunning);     
            
        }

        private void Process(CancellationToken stoppingToken)
        {
            foreach (var item in _checkoutProcessor.CheckoutQueue.GetConsumingEnumerable(stoppingToken))
            {
                _producer.SendMessage(item);
            }
        }
    }
}