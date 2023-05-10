using System;
namespace Delegation
{
    delegate double MathCalculation(float value1, float value2);
    class Program
    {
        static void Main(string[] args)
        {
            //delegate(multicast)
            var mathCalculation1 = new MathCalculation(AddNums);
            var mathCalculation2 = new MathCalculation(DivideNums);
            Console.WriteLine("Addition value is : " + mathCalculation1.Invoke(100, 3));//with invoke keyword/method
            Console.WriteLine("Division value is : " + mathCalculation2(100, 3));//without invoke keyword
            Console.ReadKey();


            //comment above code to test Func and Action delegates
            Action<string> executeActionDelegate = PrintActionDelegate;
            executeActionDelegate("Hey ! I'm Action Delegate");
            Func<float, float, double> executeFuncDelegate = AddNums;
            Console.WriteLine("Output from Func Delegate : " + executeFuncDelegate(100, 3));
            Console.ReadKey();
        }
        public static void PrintActionDelegate(string str)
        {
            Console.WriteLine(str);
        }
        public static double AddNums(float value1, float value2)
        {
            return value1 + value2;
        }
        public static double DivideNums(float value1, float value2)
        {
            return (value1 / value2);
        }

    }
}