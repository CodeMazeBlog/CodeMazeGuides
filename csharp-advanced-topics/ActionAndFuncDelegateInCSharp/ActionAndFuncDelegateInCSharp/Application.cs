using System;

namespace ActionAndFuncDelegateInCSharp
{
    public static class Application
    {
        private static readonly string _paramOne = "Code-Maze";
        private static readonly string _paramTwo = "Delegate";

        private static FuncDelegateStore _funcStore = new FuncDelegateStore();
        private static ActionDelegateStore _actionStore = new ActionDelegateStore();

        public static void Run()
        {

            Console.WriteLine("Practicing Action and Func Delegate!\n");

            var stringLength = _funcStore["CheckStringLength"](_paramOne);
            var stringLengthX2 = _funcStore["MultiplyStringLength"](_paramOne);

            _actionStore["ReverseString"](_paramTwo);
            _actionStore["AppendUnderScore"](_paramTwo);
        }        
    }
}
