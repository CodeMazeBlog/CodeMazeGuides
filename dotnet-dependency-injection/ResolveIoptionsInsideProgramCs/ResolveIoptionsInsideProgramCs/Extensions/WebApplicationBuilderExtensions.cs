namespace ResolveIoptionsInsideProgramCs.Extensions; 

using Microsoft.Extensions.Options;
using ResolveIoptionsInsideProgramCs.Services;

public static class WebApplicationBuilderExtensions
{
    public static IOptions<MySettings> GetSettingsIncorrect(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));

        var sp = builder.Services.BuildServiceProvider();
        var mySettingsWrapped = sp.GetRequiredService<IOptions<MySettings>>();

        return mySettingsWrapped;
    }

    public static string GetSpecificValue(this WebApplicationBuilder builder)
    {
        var configurationValue = builder.Configuration.GetValue<string>("MySettings:ImportantSetting");

        return configurationValue;
    }

    public static MySettings BindToSettingsModel(this WebApplicationBuilder builder)
    {
        var myOptions = new MySettings();

        builder.Configuration.Bind("MySettings", myOptions);

        return myOptions;
    }

    public static IOptions<MySettings> BindToSettingsModelAndWrapInIoptions(this WebApplicationBuilder builder)
    {
        var myOptions = new MySettings();

        builder.Configuration.Bind("MySettings", myOptions);
        IOptions<MySettings> myOptionsWrapped = Options.Create(myOptions);

        return myOptionsWrapped;
    }

    public static void RegisterAndResolveOptionsThroughServiceImplementationFactoryDelegate(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));

        builder.Services.AddScoped<IBusinessService, BusinessService>(x =>
        {
            var accessor = x.GetRequiredService<IHttpContextAccessor>();
            var tenant = accessor.HttpContext.Request.Headers["tenant"];
            var options = x.GetRequiredService<IOptions<MySettings>>();

            return new BusinessService(options, tenant);
        });
    }
}
