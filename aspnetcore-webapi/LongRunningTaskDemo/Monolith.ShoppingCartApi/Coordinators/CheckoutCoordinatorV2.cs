using System.Collections.Concurrent;
using Common.Models;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Coordinators
{
    public class CheckoutCoordinatorV2 : ICheckoutCoordinator
    {
        private BlockingCollection<QueueItem> checkoutQueue;        
        private readonly IStockValidator _stockValidator;
        private readonly ITaxCalculator _taxCalculator;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IReceiptGenerator _receiptGenerator;

        public CheckoutCoordinatorV2(IStockValidator stockValidator,
                                     ITaxCalculator taxCalculator,
                                     IPaymentProcessor paymentProcessor,
                                     IReceiptGenerator receiptGenerator)
        {
            _stockValidator = stockValidator;
            _taxCalculator = taxCalculator;
            _paymentProcessor = paymentProcessor;
            _receiptGenerator = receiptGenerator;            
            
            checkoutQueue = CreateCheckoutQueue();
        }

        public Task<CheckoutResponse> ProcessCheckoutAsync(CheckoutRequest request)
        {
            var response = new CheckoutResponse 
            { 
                OrderId = Guid.NewGuid(),
                OrderStatus = OrderStatus.Inprogress,
                Message = "Your order is in progress and you will receive an email with all details once the processing completes."
            };

            var queueItem = new QueueItem
            {
                OrderId = response.OrderId,
                Request = request
            };
            
            checkoutQueue.Add(queueItem);

            return Task.FromResult(response);
        }

        private  BlockingCollection<QueueItem> CreateCheckoutQueue()
        {
            var queue = new BlockingCollection<QueueItem>(new ConcurrentQueue<QueueItem>());            

            Task.Factory.StartNew(async ()=> await ProcessAsync(queue), TaskCreationOptions.LongRunning);

            return  queue;
        }

        private async Task ProcessAsync(BlockingCollection<QueueItem> queue)
        {           
           foreach (var item in queue.GetConsumingEnumerable())
           {
              await ProcessEachQueueItemAsync(item);
           }
        }

        private async Task ProcessEachQueueItemAsync(QueueItem item)
        {
            var response = new CheckoutResponse
            {
                OrderId = item.OrderId
            };

            if (!await _stockValidator.ValidateAsync(item.Request.LineItems))
            {
                response.OrderStatus = OrderStatus.Failure;
                response.Message = "Item not available in stock";
                
                await _receiptGenerator.ProcessFailuresAsync(item.Request.CustomerId, response);

                return;
            }

            var tax = await _taxCalculator.CalculateTaxAsync(item.Request.CustomerId, item.Request.LineItems);
            var amount = item.Request.LineItems.Sum(li => li.Quantity * li.Price) + tax;

            if (!await _paymentProcessor.ProcessAsync(item.Request.CustomerId, item.Request.PaymentInfo, amount))
            {
                response.OrderStatus = OrderStatus.Failure;
                response.Message = "Payment failure";

                await _receiptGenerator.ProcessFailuresAsync(item.Request.CustomerId, response);

                return;
            }

            response.OrderStatus = OrderStatus.Successful;
            response.Message = "Order was successfully placed. You will receive the receipt in email";
            await _receiptGenerator.GenerateAsync(item.Request.CustomerId, response, amount);
        }        
    }
}