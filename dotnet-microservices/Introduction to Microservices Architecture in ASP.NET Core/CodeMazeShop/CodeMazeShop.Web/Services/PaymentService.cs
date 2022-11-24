using System.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Services;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _client;

    public PaymentService(HttpClient client)
    {
        _client = client;
    }

    public async Task<bool> MakePayment(Guid orderId, PaymentInfo paymentInfo)
    {
        var dataAsString = JsonSerializer.Serialize(new
        {
            orderId = orderId,
            Total = paymentInfo.Total
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
}
