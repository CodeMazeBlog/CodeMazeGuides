using System;

namespace ActionFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Action delegate with named method PrintSomething
            Action<int> myActionDelegate = new Action<int>(PrintSomething);
            myActionDelegate(567);
           // myActionDelegate.Invoke(567);

            // Func delegate with named method AddNumbers
            Func<int, int, int> myFuncDelegate = new Func<int, int, int>(AddNumbers);
            Console.WriteLine("Func Delegate: " + myFuncDelegate(5, 79));

            // Func delegate with anonymous method
            Func<int, int, int> myFuncDelegate2 = (param1, param2) => {
                return param1 + param2;
            };

            // Invoking Func delegate
            Console.WriteLine("Func Delegate: " + myFuncDelegate(577, 659));
            Console.WriteLine("Func Delegate with Lambda expression: " + myFuncDelegate2(65, 823));

            Console.ReadLine();
        }

        static void PrintSomething(int i)
        {
            Console.WriteLine("Action Delegte: " + i);
        }

        static int AddNumbers(int i, int j)
        {
            return i + j;
        }
    }

}
