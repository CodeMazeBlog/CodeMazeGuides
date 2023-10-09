using ExampleApp.Models;

namespace ExampleApp
{
    public class MyServiceBuilder
    {
        public MyService? Result { get; private set; }

        public void Build(Action<ServiceConfiguration> predicate)
        {
            var configuration = new ServiceConfiguration();

            predicate?.Invoke(configuration);
            Validate(configuration);
            this.Result = new MyService(configuration);
        }

        public void Build(Action<ServiceConfiguration, string> predicate)
        {
            var configuration = new ServiceConfiguration();

            predicate?.Invoke(configuration, "Production");
            Validate(configuration);
            this.Result = new MyService(configuration);
        }

        public void Build(Func<ServiceConfiguration, bool> predicate)
        {
            var configuration = new ServiceConfiguration();
            var canProceed = predicate?.Invoke(configuration) ?? false;

            if (canProceed)
            {
                Validate(configuration);
                this.Result = new MyService(configuration);
            }
        }

        private static void Validate(ServiceConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(configuration.Name))
            {
                throw new InvalidOperationException("The service name is required.");
            }

            if (configuration.IsActive)
            {
                // ...
            }
        }
    }
}