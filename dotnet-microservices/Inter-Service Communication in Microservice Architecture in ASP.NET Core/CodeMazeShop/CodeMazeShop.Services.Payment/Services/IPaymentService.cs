using CodeMazeShop.Integration.Messages;

namespace CodeMazeShop.Services.Payment.Services;

public interface IPaymentService
{
    Task<bool> MakePayment(PaymentRequestMessage paymentRequestMessage);
}
