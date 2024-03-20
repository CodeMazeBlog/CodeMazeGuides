using BenchmarkDotNet.Running;
using HTMLContentString;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHttpClient();

using var host = builder.Build();

BenchmarkRunner.Run<GetHtmlStringBenchmark>();