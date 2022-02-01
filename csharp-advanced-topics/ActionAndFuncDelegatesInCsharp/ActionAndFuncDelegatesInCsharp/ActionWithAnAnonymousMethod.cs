using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class ActionWithAnAnonymousMethod
    {
        Action<string> printToConsole = delegate (string msg)
        {
            Console.WriteLine(msg);
        };
        public void RunExample()
        {
            printToConsole("Hello");
        }
    }
}
