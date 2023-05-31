namespace DelegateBasicsWithFuncAndAction
{
    public class FuncDelegate
    {
        public static void FuncMethod()
        {
            Func<string, string> getMessage = PrintMessage;
            Console.WriteLine(getMessage("Code Maze For Func Delegate"));
        }

        private static string PrintMessage(string msg)
        {
            return "Hello " + msg;
        }

    }
}
