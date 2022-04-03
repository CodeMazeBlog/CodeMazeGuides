using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionDelegatesInCsharp.ConsoleApp
{
    delegate string delegate1();

    public class Delegates
    {
        public string UseDelegate(int delegateToRun)
        {
            delegate1 mydelegate;

            if (delegateToRun == 1)
                mydelegate = func1;
            else if (delegateToRun == 2)
                mydelegate = func2;
            else
                throw new Exception("Invalid delegate");

            return mydelegate();
        }

        static string func1() => "func1";

        static string func2() => "func2";


    }
}
