using ExampleApp;
using ExampleApp.Models;

namespace Tests
{
    public class MyServiceBuilderUnitTest
    {
        [Fact]
        public void WhenUsingActionLamba_ThenNameIsMyCustomService1()
        {
            var builder = new MyServiceBuilder();

            builder.Build(configuration =>
            {
                configuration.Name = "MyCustomService1";
                configuration.IsActive = true;
            });

            var service = builder.Result;

            Assert.Same("MyCustomService1", service?.Configuration.Name);
            Assert.True(service?.Configuration.IsActive);
        }

        [Fact]
        public void WhenUsingActionMethod_ThenNameIsMyCustomService2()
        {
            var builder = new MyServiceBuilder();
            builder.Build(SetupService2);
            var service = builder.Result;

            Assert.Same("MyCustomService2", service?.Configuration.Name);
            Assert.False(service?.Configuration.IsActive);
        }

        [Fact]
        public void WhenUsingActionMixed_ThenNameIsMyCustomService3Prod()
        {
            var builder = new MyServiceBuilder();
            builder.Build(SetupService3);
            var service = builder.Result;

            Assert.Same("MyCustomService3-PROD", service?.Configuration.Name);
            Assert.True(service?.Configuration.IsActive);
        }

        [Fact]
        public void WhenUsingFuncMethod_ThenNameIsMyCustomService4()
        {
            var builder = new MyServiceBuilder();
            builder.Build(SetupService4);
            var service = builder.Result;

            Assert.Same("MyCustomService4", service?.Configuration.Name);
            Assert.True(service?.Configuration.IsActive);
        }

        private static void SetupService2(ServiceConfiguration configuration)
        {
            configuration.Name = "MyCustomService2";
            configuration.IsActive = false;
        }

        private static void SetupService3(ServiceConfiguration configuration, string environment)
        {
            if (environment == "Production")
            {
                configuration.Name = "MyCustomService3-PROD";
            }
            else
            {
                configuration.Name = "MyCustomService3-DEV";
            }

            configuration.IsActive = true;
        }

        private static bool SetupService4(ServiceConfiguration configuration)
        {
            if (DateTime.Today.Year < 2024)
            {
                configuration.Name = "MyCustomService4";
                configuration.IsActive = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}