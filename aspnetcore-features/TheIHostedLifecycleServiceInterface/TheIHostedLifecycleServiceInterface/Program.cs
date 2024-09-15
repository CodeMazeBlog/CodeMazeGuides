using TheIHostedLifecycleServiceInterface.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<HostOptions>(options =>
{
    options.ServicesStartConcurrently = true;
    options.ServicesStopConcurrently = true;
});

builder.Services.AddHostedService<HostedServiceA>();
builder.Services.AddHostedService<HostedServiceB>();

var app = builder.Build();

app.Run();