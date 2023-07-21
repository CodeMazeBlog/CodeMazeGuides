namespace FuncAndActionInCSharp
{
    public class Printer
    {
        public Action<string> PrintMessage = (message) => Console.WriteLine(message);
        public Action<string, string> PrintTwoMessages = (message1, message2) => Console.WriteLine($"{message1} {message2}");
    }
}
