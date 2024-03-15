using PayStack.Net;

namespace SecretMgt;

public class PaymentService
{
    private readonly IConfiguration _configuration;
    private readonly string? _key;
    private readonly PayStackApi _paystackApi;

    public PaymentService(IConfiguration configuration)
    {
        _configuration = configuration;
        _key = _configuration["Paystack:ApiKey"];
        _paystackApi = new PayStackApi(_key);
    }

    public TransactionInitializeResponse PayViaPaystack(int orderId, string email)
    {
        var request = new TransactionInitializeRequest();     

        return _paystackApi.Transactions.Initialize(request);
    }

}