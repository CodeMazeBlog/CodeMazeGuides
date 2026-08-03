namespace RateLimitingDotNET8;

public static class ConfigurationSettingsExtension
{
    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterSettings<FixedOptions>(configuration);
        services.RegisterSettings<SlidingWindowOptions>(configuration);
        services.RegisterSettings<TokenBucketOptions>(configuration);
        services.RegisterSettings<ConcurrencyOptions>(configuration);
        services.RegisterSettings<AuthorizedOptions>(configuration);
        services.RegisterSettings<UnauthorizedOptions>(configuration);
        services.RegisterSettings<ChainedFirstOptions>(configuration);
        services.RegisterSettings<ChainedSecondOptions>(configuration);
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
