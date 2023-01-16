using System;

namespace ActionAndFuncDelegateInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Action Delegate 
            ActionDelegates.WriteMessage(x => Console.WriteLine(ActionDelegates.Message), 100);

            // Func Delegate
            var resultFunc = FuncDelegates.PrintNumbersByFormula(number => string.Format("{0:n0}", number), 1000);
            Console.WriteLine(resultFunc);
        }
    }
}