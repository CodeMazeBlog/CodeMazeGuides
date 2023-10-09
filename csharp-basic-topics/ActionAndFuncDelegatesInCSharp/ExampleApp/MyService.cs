using ExampleApp.Models;

namespace ExampleApp
{
    public class MyService
    {
        public ServiceConfiguration Configuration { get; }

        public MyService(ServiceConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string? GetName()
        {
            return this.Configuration.Name;
        }
    }
}