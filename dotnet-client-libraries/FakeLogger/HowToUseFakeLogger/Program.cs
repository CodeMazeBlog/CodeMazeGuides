using HowToUseFakeLogger;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var logger = loggerFactory.CreateLogger<FileManager>();
var fileManager = new FileManager(logger);

var result = fileManager.ReadFile("test.txt");
Console.WriteLine("Result:" + result);