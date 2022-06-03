using Common.Models;

namespace Microservice.ReceiptGeneratorService
{
    public class ReceiptGenerator : IReceiptGenerator
    {
        private readonly ILogger _logger;
        public ReceiptGenerator(ILogger<ReceiptGenerator> logger)
        {
            _logger = logger;
        }

        public async Task GenerateAsync(Guid customerId,Guid orderId, int amount)
        {
            //Simulate Receipt generation and save in the database
            await Task.Delay(1000);
            _logger.LogInformation("Receipt Generated and Order Status persisted in DB.");

            //Simulate sending of email with receipt through a third party SMTP service
            await Task.Delay(1000);
            _logger.LogInformation("Email is sent with Order Status and receipt.");
        }

        public async Task ProcessFailuresAsync(Guid customerId, Guid orderId, string message)
        {
            //Simulate failure save in the database
            await Task.Delay(1000);
            _logger.LogInformation("Failure Order Status and reason persisted in DB.");

            //Simulate sending of email with failure reason through a third party SMTP service
            await Task.Delay(1000);
            _logger.LogInformation("Email is sent with Order Status and failure reason.");
        }
    }
}
