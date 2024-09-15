using System.Reflection;
using log4net;
using log4net.Config;
using LoggingInCSharp;

var log = LogManager.GetLogger(typeof(Program));
var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

log.Info("Application Started");

int addResult = Calculator.Add(5, 3);
Console.WriteLine($"Result of 5 + 3 = {addResult}");

int subtractResult = Calculator.Subtract(5, 10);
Console.WriteLine($"Result of 5 - 10 = {subtractResult}");

int multiplyResult = Calculator.Multiply(4, 6);
Console.WriteLine($"Result of 4 * 6 = {multiplyResult}");

try
{
    int divideResult = Calculator.Divide(10, 2);
    Console.WriteLine($"Result of 10 / 2 = {divideResult}");

    Calculator.Divide(5, 0);
}
catch (DivideByZeroException ex)
{
    log.Fatal("A critical error occurred during division", ex);
    Console.WriteLine($"Caught exception: {ex.Message}");
}

log.Info("Application Ended");
