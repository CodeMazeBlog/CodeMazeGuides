using PayStack.Net;

namespace SecretMgt;

public class PaymentServiceWithPoco
{
    private SecretManager _secretManager;
    private Secrets _secrets;
    private readonly string? _key;
    private PayStackApi _paystackApi;

    public PaymentServiceWithPoco(IConfiguration configuration, SecretManager secretManager)
    {
        _secretManager = secretManager;
        _secrets = _secretManager.GetSecrets;
        _key = _secrets.ApiKey;
        _paystackApi = new PayStackApi(_key);
    }
}
