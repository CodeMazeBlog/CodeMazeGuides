using System;

namespace ActionAndFuncDelegates.Funcs
{
    class OneParameterFunc
    {
        public static void Test()
        {
            Func<int, int> squareFunc = Square;
            int squareResult = squareFunc(2);
            Console.WriteLine(squareResult);
        }

        static int Square(int param1)
        {
            return param1 * param1;
        }
    }
}
