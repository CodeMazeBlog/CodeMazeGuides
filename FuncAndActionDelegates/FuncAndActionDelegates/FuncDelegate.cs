using System;

namespace FuncAndActionDelegate
{
    public class FuncDelegate
    {
        public double Sum(int num1, double num2)
        {
            return num1 + num2;
        }
        public double SimpleFuncDelegate()
        {
            Func<int, double, double> addNumbers = Sum;
            double result = addNumbers(10, 10.55);
            return result;
        }
        public int FuncDelegateWithAnonymousMethods()
        {
            Func<int> getValue = delegate ()
            {
                return 10 * 5;
            };
            int resultWithAnonymousMethods = getValue();
            return resultWithAnonymousMethods;
        }
        public double FuncDelegateWithLambda()
        {
            Func<int, double, double> addNumbersWithLamda = (num1, num2) => num1 + num2;
            double resultWithLambda = addNumbersWithLamda(20, 20.55);
            return resultWithLambda;
        }
    }
}
