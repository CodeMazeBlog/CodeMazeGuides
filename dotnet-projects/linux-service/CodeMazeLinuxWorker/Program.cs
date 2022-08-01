using CodeMazeLinuxWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSystemd()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
