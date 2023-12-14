using PayStack.Net;

namespace SecretMgt;

public class OrderService
{
    private IList<Order> _orders;
    private IConfiguration _configuration;
    private readonly string? _key;
    private PayStackApi _paystackApi;

    public OrderService(IConfiguration configuration)
    {
        _configuration = configuration;
        _key = _configuration["Paystack:APIKey"];
        _paystackApi = new PayStackApi(_key);

        _orders = new List<Order>()
       {
           new Order()
           {
               Product = "Potato chips",
               Cost = 3000
           },
           new Order()
           {
               Product = "Body paint",
               Cost = 100
           },
           new Order()
           {
               Product = "Hair brush",
               Cost = 6
           }
        };

    }

    public TransactionInitializeResponse PayViaPaystack(int orderId, string email)
    {
        var order = _orders[orderId];

        var request = new TransactionInitializeRequest()
        {
            AmountInKobo = (int)order.Cost * 100, //total amount
            Email = email,
            Reference = GenerateRef().ToString(),
            Currency = "NGN",
            CallbackUrl = "https://localhost:7061/swagger/index.html"
        };

        return _paystackApi.Transactions.Initialize(request);
    }

    private static int GenerateRef()
    {
        Random random = new Random((int)DateTime.Now.Ticks);
        return random.Next(100000000, 999999999);
    }
}
