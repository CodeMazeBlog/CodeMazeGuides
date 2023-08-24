using Common.Models;

namespace Microservice.PaymentProcessingService
{
    public interface IPaymentProcessor
    {
        Task<bool> ProcessAsync(Guid customerId, PaymentInfo paymentInfo, int amount);
    }
}
