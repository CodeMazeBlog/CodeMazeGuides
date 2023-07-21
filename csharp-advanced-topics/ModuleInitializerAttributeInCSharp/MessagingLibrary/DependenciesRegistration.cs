using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace MessagingLibrary;

internal static class DependenciesRegistration
{
    internal static ServiceProvider DependenciesProvider { get; private set; }

    [ModuleInitializer]
    [SuppressMessage("Usage", "CA2255:The \'ModuleInitializer\' attribute should not be used in libraries",
        Justification =
            "The consumer of the library is abstracted from this because of usage of Internal Access Modifier." +
            "Only used in this project for dependency registration.")]
    internal static void RegisterDependencies()
    {
        var services = new ServiceCollection();
        services.AddScoped<INotification, Sms>();
        services.AddScoped<INotification, Email>();
        DependenciesProvider = services.BuildServiceProvider();
    }
}