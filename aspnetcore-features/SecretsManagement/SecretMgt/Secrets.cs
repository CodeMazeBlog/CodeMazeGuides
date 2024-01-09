namespace SecretMgt
{
    public class Secrets
    {
        public string ApiKey { get; set; }
    }

    public class SecretManager
    {
        IConfiguration _configuration;
        readonly string? _key;

        public SecretManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = _configuration["Paystack:ApiKey"];
        }

        public Secrets GetSecrets()
        {
            Secrets secrets = new Secrets()
            {
                ApiKey = _key
            };

            return secrets;
        }
    }
}
