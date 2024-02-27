namespace ResolveIoptionsInsideProgramCs;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ResolveIoptionsInsideProgramCs.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        RegisterAndResolveOptionsThroughServiceImplementationFactoryDelegate(builder);

        var app = builder.Build();

        app.MapControllers();
        app.Run();
    }

    public static IOptions<MySettings> GetSettingsIncorrect(WebApplicationBuilder builder)
    {
        builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));

        var sp = builder.Services.BuildServiceProvider();
        var mySettingsWrapped = sp.GetRequiredService<IOptions<MySettings>>();

        return mySettingsWrapped;
    }

    public static string GetSpecificValue(WebApplicationBuilder builder)
    {
        var value = builder.Configuration.GetValue<string>("MySettings:ImportantSetting");

        return value;
    }

    public static MySettings BindToSettingsModel(WebApplicationBuilder builder)
    {
        var myOptions = new MySettings();

        builder.Configuration.Bind("MySettings", myOptions);

        return myOptions;
    }

    public static IOptions<MySettings> BindToSettingsModelAndWrapInIoptions(WebApplicationBuilder builder)
    {
        var myOptions = new MySettings();

        builder.Configuration.Bind("MySettings", myOptions);
        IOptions<MySettings> myOptionsWrapped = Options.Create(myOptions);

        return myOptionsWrapped;
    }

    public static void RegisterAndResolveOptionsThroughServiceImplementationFactoryDelegate(WebApplicationBuilder builder)
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
