using System;

namespace FuncAndActionDelegate
{
    public class ActionDelegate
    {
        public void PrintMsg(string message)
        {
            Console.WriteLine(message);
        }
        public void SimpleActionDelegate()
        {
            Action<string> msg = PrintMsg;
            msg("Hello World");
        }
        public void ActionDelegateWithLambda()
        {
            Action<string> msgWithLamda = (message) => Console.WriteLine(message);
            msgWithLamda("Hello World From Lambda Expression");
        }
    }
}
