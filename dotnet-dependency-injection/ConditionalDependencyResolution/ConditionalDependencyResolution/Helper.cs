using ConditionalDependencyResolution.Alert;
using ConditionalDependencyResolution.Message;
using ConditionalDependencyResolution.Payment;
using ConditionalDependencyResolution.Pricing;
using ConditionalDependencyResolution.Relay;

namespace ConditionalDependencyResolution;

public class Helper
{
    public static IServiceProvider CreateServiceProvider()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();

        return host.Services;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        RegisterMessageService(services);
        RegisterRelayService(services);

        services.AddTransient<SmsAlertService>();
        services.AddTransient<EmailAlertService>();

        services.AddTransient<Func<AlertMode, IAlertService>>(sp =>
        {
            return (mode) => mode switch
            {
                AlertMode.Email => sp.GetService<EmailAlertService>()!,
                AlertMode.Sms => sp.GetService<SmsAlertService>()!,
                _ => throw new NotImplementedException(),
            };
        });

        services.AddTransient<IAlertService, SmsAlertService>();
        services.AddTransient<IAlertService, EmailAlertService>();
        services.AddTransient<IAlertServiceFactory, AlertServiceFactory>();

        services.AddTransient<GatewayOne>();
        services.AddTransient<GatewayTwo>();
        services.AddTransient<IPaymentGatewayAdapter, PaymentGatewayAdapter>();

        services.AddTransient<StandardPricingService>();
        services.AddTransient<PremiumPricingService>();
        services.AddTransient<IPricingService, PricingServiceProxy>();
    }

    private static void RegisterRelayService(IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var sandbox = configuration.GetValue<bool>("Sandbox");

        if (sandbox)
            services.AddTransient<IRelayService, SandboxRelayService>();
        else
            services.AddTransient<IRelayService, LiveRelayService>();
    }

    private static void RegisterMessageService(IServiceCollection services)
    {
#if DEBUG
        services.AddTransient<IMessageService, VerboseMessageService>();
#else
        services.AddTransient<IMessageService, MessageService>();
#endif
    }
}