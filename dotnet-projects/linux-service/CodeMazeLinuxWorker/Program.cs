using CodeMazeLinuxWorker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSystemd();
builder.Services.AddHostedService<Worker>();

IHost host = builder.Build();
await host.RunAsync();