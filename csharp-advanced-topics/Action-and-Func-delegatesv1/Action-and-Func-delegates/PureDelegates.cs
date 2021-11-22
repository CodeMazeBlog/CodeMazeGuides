using System;
namespace ActionAndFuncDelegatesInCsharp
{
    public class PureDelegates
    {
        private delegate string pureDelegate(string s); //delegate <return type> <delegate-name> <parameter list>
        private static string PrintToScreen(string s) { return s; }
        public static void ExecutePureDelegate(string names)
        {
            var _pureDelegate = new pureDelegate(PrintToScreen);
            Console.WriteLine(_pureDelegate(names));
        }
    }
}