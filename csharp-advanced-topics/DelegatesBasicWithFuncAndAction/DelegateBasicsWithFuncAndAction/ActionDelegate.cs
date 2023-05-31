namespace DelegateBasicsWithFuncAndAction
{
    public class ActionDelegate
    {
        public static void ActionMethod()
        {
            Action<string> getMessage = PrintMessage;
            getMessage("Code Maze For Action Delegate");
        }

        private static void PrintMessage(string msg)
        {
            Console.WriteLine("Hello " + msg);
        }

    }
}
