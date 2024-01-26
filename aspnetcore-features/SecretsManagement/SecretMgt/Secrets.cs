namespace SecretMgt
{
    public class Secrets
    {
        public string ApiKey { get; set; }
    }

    public class SecretManager
    {
        private IConfiguration _configuration;
        private readonly string? _key;

        public Secrets GetSecrets
        {
            get
            {
                return new Secrets
                {
                    ApiKey = _key
                };
            }
        }

        public SecretManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = _configuration["Paystack:ApiKey"];
        }
    }
}
