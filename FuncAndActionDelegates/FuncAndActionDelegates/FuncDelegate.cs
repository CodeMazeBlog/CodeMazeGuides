using System;

namespace FuncAndActionDelegate
{
    public class FuncDelegate
    {
        public float Sum(int num1, float num2)
        {
            return num1 + num2;
        }
        public float SimpleFuncDelegate()
        {
            Func<int, float, float> addNumbers = Sum;
            float result = addNumbers(10, 10);
            return result;
        }

        public float FuncDelegateWithLambda()
        {
            Func<int, float, float> addNumbersWithLamda = (num1, num2) => num1 + num2;
            float resultWithlambda = addNumbersWithLamda(10, 10);
            return resultWithlambda;
        }
    }
}
