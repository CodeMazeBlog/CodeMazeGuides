using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class PureDelegates
    {
        //delegate <return type> <delegate-name> <parameter list>

        private delegate string pureDelegate(string s);
        
        private static string PrintToScreen(string s)
        {
            
            return s;
        }
        public static void ExecutePureDelegate (string names)
        {
            pureDelegate _pureDelegate = new pureDelegate(PrintToScreen);
            Console.WriteLine(_pureDelegate(names));
        }
    }
}
