using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class ActionWithLambdaExpression
    {
        Action<string> printToConsoleLambda = (string msg) => Console.WriteLine(msg);
        public void RunExample()
        {
            printToConsoleLambda("Hello");
        }
    }
}
