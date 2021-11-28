using System;

namespace ActionFuncDelegates
{
    internal class Program
    {
        static double AddNums1(int x, float y, double z)
        {
            return x + y + z;
        }
        static void AddNums2(int x, float y, double z)
        {
            Console.WriteLine(x + y + z);
        }
        static void Main()
        {
            Func<int,float,double,double> func = AddNums1;
            double result = func.Invoke(100, 34.5f, 193.667);
            Console.WriteLine(result);

            Action<int,float,double> action = AddNums2;
            action.Invoke(100, 45.6f, 165.986);
        }
    }
}
