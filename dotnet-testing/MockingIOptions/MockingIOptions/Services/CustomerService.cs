using Microsoft.Extensions.Options;
using MockingIOptions.Configuration;

namespace MockingIOptions.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DatabaseConfiguration _configuration;

        public CustomerService(IOptions<DatabaseConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        public string GetConnectionString() => _configuration.ConnectionString;
    }
}
