namespace ActionFuncDelegatesInCSharp
{
    public class Delegates
    {
        delegate void WriteMessage(string message);

        static void WriteMessageToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public static void CreateDelegates()
        {
            WriteMessage messageToConsole = WriteMessageToConsole;
            messageToConsole("Hello World!");
        }
    }
}
