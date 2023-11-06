namespace ActionFuncDelegatesInCSharp
{
    public class Delegates
    {
        delegate void WriteMessage(string message);

        static void WriteMessageToConsole(string message)
        {
            Console.Write(message + Environment.NewLine);
        }

        public static void CreateDelegates()
        {
            WriteMessage messageToConsole = WriteMessageToConsole;
            messageToConsole("Hello World!");
        }
    }
}
