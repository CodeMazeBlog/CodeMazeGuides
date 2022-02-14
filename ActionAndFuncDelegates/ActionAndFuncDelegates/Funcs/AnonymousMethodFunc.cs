using System;

namespace ActionAndFuncDelegates.Funcs
{
    class AnonymousMethodFunc
    {
        public static void Test()
        {
            Func<double, double, double> calculatePowFunc = delegate (double param1, double param2)
            {
                return Math.Pow(param1, param2);
            };

            double powResult = calculatePowFunc(3.0f, 2.0f);
            Console.WriteLine(powResult);
        }
    }
}
