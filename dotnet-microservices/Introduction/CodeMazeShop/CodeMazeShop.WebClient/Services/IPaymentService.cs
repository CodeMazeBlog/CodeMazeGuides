using CodeMazeShop.DataContracts.Payment;

namespace CodeMazeShop.WebClient.Services;

public interface IPaymentService
{
    Task<bool> MakePayment(Guid orderId, PaymentInfo paymentInfo); 
}
