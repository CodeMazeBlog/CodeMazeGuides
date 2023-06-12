using Common.Models;

namespace Microservice.ReceiptGeneratorService
{
    public interface IReceiptGenerator
    {
        Task ProcessFailuresAsync(Guid customerId, Guid OrderId, string Message);
        Task GenerateAsync(Guid customerId, Guid OrderId, int amount);
    }
}
