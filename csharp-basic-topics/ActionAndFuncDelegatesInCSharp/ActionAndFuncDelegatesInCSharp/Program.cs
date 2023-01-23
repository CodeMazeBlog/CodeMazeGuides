// See https://aka.ms/new-console-template for more information

var dateTimeProvider = new SystemDateTimeProvider();
var consoleWrapper = new ConsoleWrapper();
var delegateImplemenationProvider = new DelegateImplementationProvider(dateTimeProvider, consoleWrapper);
var printWithColor = delegateImplemenationProvider.PrintWithColor;

var printDate1 = printWithColor(ConsoleColor.Blue, "This is an informational message");
Thread.Sleep(5000);
var printDate2 = printWithColor(ConsoleColor.Yellow, "This is a warning message");
Thread.Sleep(5000);
var printDate3 = printWithColor(ConsoleColor.Red, "This is an error message");

consoleWrapper.SetColor(ConsoleColor.White);
consoleWrapper.WriteText("-------------------");
consoleWrapper.WriteText("Returned Timestamps");
consoleWrapper.WriteText("-------------------");
consoleWrapper.WriteText($"{printDate1}");
consoleWrapper.WriteText($"{printDate2}");
consoleWrapper.WriteText($"{printDate3}");

consoleWrapper.Read();
