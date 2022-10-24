using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Services;

public interface IPaymentService
{
    Task<bool> MakePayment(Guid orderId, PaymentInfo paymentInfo); 
}
