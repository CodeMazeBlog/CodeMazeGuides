namespace RateLimitingDotNET8;

public static class ConfigurationSettingsExtension
{
    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterSettings<MyRateLimiterOptions>(configuration);
    }

    private static void RegisterSettings<TSettings>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TSettings : class
    {
        services
            .AddOptions<TSettings>()
            .Bind(configuration.GetSection(typeof(TSettings).Name));
    }
}
