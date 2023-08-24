using FactoryPatternInDependencyInjection.Devices;
using FactoryPatternInDependencyInjection.LabelGen;
using FactoryPatternInDependencyInjection.Relay;
using FactoryPatternInDependencyInjection.Recorder;
using FactoryPatternInDependencyInjection.Devices.Smart;

namespace FactoryPatternInDependencyInjection;

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
        services.AddOptions<LabelGenOptions>().BindConfiguration("LabelGenOptions");

        services.AddSingleton<LabelGenService>(serviceProvider =>
        {
            var options = serviceProvider
                .GetService<IOptions<LabelGenOptions>>()!.Value;

            return new LabelGenService(
                options.Prefix,
                options.Suffix);
        });

        services.AddSingleton<LabelGenServiceFactory>();

        services.AddTransient<DeviceFactory>();
        services.AddTransient<IDeviceFactory, DeviceFactory>();
        services.AddTransient<IDeviceFactory, SmartDeviceFactory>();
        services.AddTransient<MasterDeviceFactory>();

        services.AddTransient<IRelayService, SandboxRelayService>();
        services.AddTransient<IRelayService, LiveRelayService>();
        services.AddTransient<IRelayService, OfflineRelayService>();
        services.AddTransient<RelayServiceFactory>();

        services.AddTransient<RecorderServiceFactory>();
    }
}