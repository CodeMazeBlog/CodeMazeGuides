// See https://aka.ms/new-console-template for more information
using System.Drawing;

var printWithColor = PrintWithColor;

printWithColor(ConsoleColor.Blue, "This is an informational message");
printWithColor(ConsoleColor.Yellow, "This is a warning message");
printWithColor(ConsoleColor.Red, "This is an error message");

Console.ReadLine();

static DateTime PrintWithColor(ConsoleColor color, String msg)
{
    var logDate = DateTime.UtcNow;
    Console.ForegroundColor = color;
    Console.WriteLine($"{logDate} {msg}");
    return logDate;
}