using Common.Models;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Coordinators
{
    public class CheckoutCoordinatorV1 : ICheckoutCoordinator
    {
        private readonly IStockValidator _stockValidator;
        private readonly ITaxCalculator _taxCalculator;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IReceiptGenerator _receiptGenerator;

        public CheckoutCoordinatorV1(IStockValidator stockValidator,
                                     ITaxCalculator taxCalculator,
                                     IPaymentProcessor paymentProcessor,
                                     IReceiptGenerator receiptGenerator)
        {
            _stockValidator = stockValidator;
            _taxCalculator = taxCalculator;
            _paymentProcessor = paymentProcessor;
            _receiptGenerator = receiptGenerator;
        }

        public async Task<CheckoutResponse> ProcessCheckoutAsync(CheckoutRequest request)
        {
            var response = new CheckoutResponse 
            { 
                OrderId = Guid.NewGuid() 
            };

            if (!await _stockValidator.ValidateAsync(request.LineItems))
            {
                response.OrderStatus = OrderStatus.Failure;
                response.Message = "Item not available in stock";

                await _receiptGenerator.ProcessFailuresAsync(request.CustomerId, response);
                
                return response;
            }

            var tax = await _taxCalculator.CalculateTaxAsync(request.CustomerId, request.LineItems);
            var amount = request.LineItems.Sum(li => li.Quantity * li.Price) + tax;

            if (!await _paymentProcessor.ProcessAsync(request.CustomerId, request.PaymentInfo, amount))
            {
                response.OrderStatus = OrderStatus.Failure;
                response.Message = "Payment failure";
                
                await _receiptGenerator.ProcessFailuresAsync(request.CustomerId, response);
                
                return response;
            }

            response.OrderStatus = OrderStatus.Successful;
            response.Message = "Order was successfully placed. You will receive the receipt in email";
            await _receiptGenerator.GenerateAsync(request.CustomerId, response, amount);

            return response;            
        }
    }
}