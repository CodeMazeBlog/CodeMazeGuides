using Common.Models;
using Monolith.ShoppingCartApi.Services;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.BackgroundWorkers
{
    public class ChannelBackgroundWorker : BackgroundService
    {
        private readonly ICheckoutProcessingChannel _checkoutProcessingChannel;
        private readonly IStockValidator _stockValidator;
        private readonly ITaxCalculator _taxCalculator;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IReceiptGenerator _receiptGenerator;

        public ChannelBackgroundWorker(IStockValidator stockValidator,
                                       ITaxCalculator taxCalculator,
                                       IPaymentProcessor paymentProcessor,
                                       IReceiptGenerator receiptGenerator,
                                       ICheckoutProcessingChannel checkoutProcessingChannel)
        {
            _stockValidator = stockValidator;
            _taxCalculator = taxCalculator;
            _paymentProcessor = paymentProcessor;
            _receiptGenerator = receiptGenerator;
            _checkoutProcessingChannel = checkoutProcessingChannel;
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _checkoutProcessingChannel.TryCompleteWriter();
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var item in _checkoutProcessingChannel.ReadAllAsync(stoppingToken))
            { 
                await ProcessItemAsync(item);
            }
        }

        private async Task ProcessItemAsync(QueueItem item)
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
