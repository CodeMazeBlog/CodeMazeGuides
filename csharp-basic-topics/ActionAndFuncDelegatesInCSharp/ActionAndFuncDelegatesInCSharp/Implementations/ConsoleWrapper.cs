// See https://aka.ms/new-console-template for more information
public class ConsoleWrapper : IConsoleWrapper
{
    public void Read()
        => Console.ReadLine();

    public void SetColor(ConsoleColor color) 
        => Console.ForegroundColor = color;

    public void WriteText(string text)
        => Console.WriteLine(text);
}