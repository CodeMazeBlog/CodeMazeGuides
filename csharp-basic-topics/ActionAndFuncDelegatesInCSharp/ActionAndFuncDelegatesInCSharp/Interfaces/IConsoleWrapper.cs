// See https://aka.ms/new-console-template for more information
public interface IConsoleWrapper
{
    void SetColor(ConsoleColor color);
    void WriteText(string text);
    void Read();
}
