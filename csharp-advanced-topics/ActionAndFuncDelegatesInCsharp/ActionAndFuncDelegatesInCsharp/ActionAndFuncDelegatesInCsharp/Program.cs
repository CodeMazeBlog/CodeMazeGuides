using System;

//Aligady@gmail.com
namespace ActionAndFuncDelegatesInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Action delegate in c#
            
            //Action delegate
            Action<string> displayAction = Display;
            displayAction("Hello world!");

            //Action delegate by Anonymous
            Action<string> displayActionAnonymous = delegate (string message)
            {
                Console.WriteLine("Hello world!");
            };
            displayActionAnonymous("Hello world!");
            Console.ReadLine();

            //Action delegate by Lambda expression 
            Action<string> displayActionLambda = message => Console.WriteLine(message);
            displayActionLambda("Hello world!");
            Console.ReadLine();
            #endregion


            #region Func delegate in c#
            //Func delegate
            Func<int, int, int> multiplyFunc = Multiply;
            int result = multiplyFunc(8, 10);
            Console.WriteLine(result);
            Console.ReadLine();

            //Func delegate by Anonymous
            Func<int, int, int> multiplyFuncAnonymous = delegate (int x, int y)
            {
                return x * y;
            };
            int resultAnonymous = multiplyFuncAnonymous(5, 10);
            Console.WriteLine(resultAnonymous);
            Console.ReadLine();

            //Func delegate by Lambda expression 
            Func<int, int, int> multiplyFuncLambda = (x, y) => x * y;
            //Or 
            //Func<int, int, int> multiplyFuncLambda = (x, y) => x * y;
            int resultLambda = multiplyFuncLambda(5, 10);
            Console.WriteLine(resultLambda);
            Console.ReadLine();
            #endregion
        }

        static void Display(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
