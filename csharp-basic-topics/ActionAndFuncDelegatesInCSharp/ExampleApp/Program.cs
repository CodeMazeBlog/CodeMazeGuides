using ExampleApp;
using ExampleApp.Models;

// Example usage 1
var builder1 = new MyServiceBuilder();

builder1.Build(configuration =>
{
    configuration.Name = "MyCustomService1";
    configuration.IsActive = true;
});

var service1 = builder1.Result;

// Example usage 2
var builder2 = new MyServiceBuilder();
builder2.Build(SetupService2);
var service2 = builder2.Result;

// Example usage 3
var builder3 = new MyServiceBuilder();
builder3.Build(SetupService3);
var service3 = builder3.Result;

// Example usage 4
var builder4 = new MyServiceBuilder();
builder4.Build(SetupService4);
var service4 = builder4.Result;

static void SetupService2(ServiceConfiguration configuration)
{
    configuration.Name = "MyCustomService2";
    configuration.IsActive = false;
}

static void SetupService3(ServiceConfiguration configuration, string environment)
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

static bool SetupService4(ServiceConfiguration configuration)
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