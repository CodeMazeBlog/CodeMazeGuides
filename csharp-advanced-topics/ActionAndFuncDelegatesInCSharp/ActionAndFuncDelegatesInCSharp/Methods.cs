using System;
using System.ComponentModel;

namespace ActionAndFuncDelegatesInCSharp
{
    public static class Methods
    {
        public static double GetProcessResult(double value, Func<double, double> func)
        {
            //Common processing logic
            Console.WriteLine("Processing input {0}", value);
            return func(value);
        }

    }
}

