using System.Net.Http.Headers;
using System.Text.Json;
using CodeMazeShop.Integration.Messages;

namespace CodeMazeShop.Services.Payment.Services;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _client;

    public PaymentService(HttpClient client)
    {
        _client = client;
    }
    public async Task<bool> MakePayment(PaymentRequestMessage paymentRequestMessage)
    {
        try
        {
            var dataAsString = JsonSerializer.Serialize(new
            {
                orderId = paymentRequestMessage.OrderId,
                total = paymentRequestMessage.Total,
                cardNumber = paymentRequestMessage.CardNumber,
                cardName = paymentRequestMessage.CardName,
                cardExpiration = paymentRequestMessage.CardExpiration
            });

            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/api/payment", content);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<bool>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch(Exception ex)
        {
            return false;
        }
    }
}
