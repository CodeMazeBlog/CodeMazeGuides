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
            Action<string> action = PrintMsg;
            action("Hello World");
        }
        public void ActionDelegateWithAnonymousMethods()
        {
            Action<string> printValue = delegate (string msg)
            {
                Console.WriteLine(msg);
            };
            printValue("Hello World From Anonymous Method");
        }
        public void ActionDelegateWithLambda()
        {
            Action<string> actionWithLamda = (message) => Console.WriteLine(message);
            actionWithLamda("Hello World From Lambda Expression");
        }
    }
}
