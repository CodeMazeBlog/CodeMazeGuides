using System;

namespace ActionAndFuncDelegatesInCsharp
{
    class Program
    {
        public static void DisplayNumber(int x)
        {
            Console.WriteLine(x);
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Action<int> myAction = DisplayNumber;

            myAction(10);
            myAction(300);
            myAction(41);

            Action<int> myLambdaAction = (y) => Console.WriteLine(y);

            myLambdaAction(10);
            myLambdaAction(300);
            myLambdaAction(41);

            
            Func<int, int, int> sum = Add;

            Console.WriteLine(sum(2, 3));
            Console.WriteLine(sum(5, 12));


            Console.ReadKey();
        }
    }
}
