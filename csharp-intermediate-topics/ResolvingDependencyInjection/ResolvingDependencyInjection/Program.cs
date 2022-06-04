using ResolvingDependencyInjection;

var builder = CreateHostBuilder(args);

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });

var app = builder.Build();

app.Run();
