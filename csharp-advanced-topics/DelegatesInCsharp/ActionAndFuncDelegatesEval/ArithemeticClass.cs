using System;

namespace ActionAndFuncDelegatesEval
{
    public static class ArithemeticClass
    {
        public static void Add(int firstNum, int secondNum)
        {
            Console.WriteLine($"{firstNum} + {secondNum} is: {firstNum + secondNum}\n");
        }

        public static void SubStract(int firstNum, int secondNum)
        {
            Console.WriteLine($"{firstNum} - {secondNum} is: {firstNum - secondNum}\n");
        }

        public static void Multiply(int firstNum, int secondNum)
        {
            Console.WriteLine($"{firstNum} * {secondNum} is: {firstNum * secondNum}\n");
        }
    }
}
