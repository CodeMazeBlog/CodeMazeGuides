using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionSample
{
    public class FuncMethods
    {
        int _sum = 0;
        int _count = 0;

        public static int Add(int value1, int value2)
        {
            return value1 + value2;
        }

        public int Add(int value)
        {
            _sum += value;
            _count++;
            return _sum;
        }

        public double GetAvg()
        {
            return _count > 0 ? (double)_sum / _count : 0;
        }

        public static void ShowFunctionExamples()
        {

            double Pow(double value1, double value2)
            {
                return Math.Pow(value1, value2);
            }

            //
            //Defines a few Funcs
            //

            Func<double, double, double> localFunc = Pow;
            Func<int, int, int> anonymousAction = delegate (int value1, int value2) { return FuncMethods.Add(value1, value2); };

            FuncMethods funcMethods = new FuncMethods();

            Func<int, int> lambadaFunc = (x) => funcMethods.Add(x);
            Func<double> simpleFunc = funcMethods.GetAvg;

            //
            //Calls defined Funcs
            //

            Console.WriteLine(localFunc(2, 3));
            Console.WriteLine(anonymousAction(2, 3));

            lambadaFunc(2);
            lambadaFunc(3);

            Console.WriteLine(simpleFunc());
        }
    }
}
