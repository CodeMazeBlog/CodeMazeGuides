namespace FuncAndActionInCSharp
{
    public class Printer
    {
        public Action<string> PrintMessage = (message) => Console.WriteLine(message);
    }
}
