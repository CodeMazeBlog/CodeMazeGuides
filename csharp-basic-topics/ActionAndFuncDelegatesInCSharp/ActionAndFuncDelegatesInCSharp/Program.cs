// See https://aka.ms/new-console-template for more information
using System.Drawing;

var printWithColor = PrintWithColor;

var printDate1 = printWithColor(ConsoleColor.Blue, "This is an informational message");
Thread.Sleep(5000);
var printDate2 = printWithColor(ConsoleColor.Yellow, "This is a warning message");
Thread.Sleep(5000);
var printDate3 = printWithColor(ConsoleColor.Red, "This is an error message");

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("-------------------");
Console.WriteLine("Returned Timestamps");
Console.WriteLine("-------------------");
Console.WriteLine(printDate1);
Console.WriteLine(printDate2);
Console.WriteLine(printDate3);

Console.ReadLine();

static DateTime PrintWithColor(ConsoleColor color, String msg)
{
    var logDate = DateTime.UtcNow;
    Console.ForegroundColor = color;
    Console.WriteLine($"{logDate} {msg}");
    return logDate;
}