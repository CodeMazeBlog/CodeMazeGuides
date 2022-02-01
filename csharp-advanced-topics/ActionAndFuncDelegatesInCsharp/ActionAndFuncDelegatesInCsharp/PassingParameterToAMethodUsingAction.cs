using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class PassingParameterToAMethodUsingAction
    {
        void print(string msg)
        {
            Console.WriteLine(msg);
        }
        public void RunExample()
        {
            Action<string> printAction = print;
            printAction("A message.");
        }
    }
}
