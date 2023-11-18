namespace FuncAndActionsInCsharp
{
    public static class ActionDelegates
    {
        public static void DisplayMessage()
        {
            Action displayMessage = () => Console.WriteLine("Hello, World!");
            displayMessage();
        }

        public static void GreetAnonymous(string message)
        {
            Action<string> greetAnonymous = delegate (string msg)
            {
                Console.WriteLine(msg);
            };
            greetAnonymous(message);
        }

        public static void GreetLambda(string message)
        {
            Action<string> greetLambda = msg => Console.WriteLine(msg);
            greetLambda(message);
        }
    }
}
