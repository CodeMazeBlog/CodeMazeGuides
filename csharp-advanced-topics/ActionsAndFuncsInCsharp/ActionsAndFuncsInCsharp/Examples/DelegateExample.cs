namespace ActionsAndFuncsInCsharp.Examples
{
    public class DelegateExample
    {
        private delegate void LogMessage(string message);

        private void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void RunExample()
        {
            LogMessage logger = LogToConsole;

            logger("Hello World");
        }
    }

}
