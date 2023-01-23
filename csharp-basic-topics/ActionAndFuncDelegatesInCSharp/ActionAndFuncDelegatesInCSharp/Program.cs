// See https://aka.ms/new-console-template for more information
using System.Drawing;

var printWithColor = PrintWithColor;

printWithColor(ConsoleColor.Blue, "This is an informational message");
printWithColor(ConsoleColor.Yellow, "This is a warning message");
printWithColor(ConsoleColor.Red, "This is an error message");

Console.ReadLine();

static void PrintWithColor(ConsoleColor color, String msg)
{
    Console.ForegroundColor = color;
    Console.WriteLine(msg);
}