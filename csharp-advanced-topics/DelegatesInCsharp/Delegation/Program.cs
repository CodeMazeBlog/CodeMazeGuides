using System;

namespace Delegation
{
    public class Program
    {
        delegate double MathCalculation(float value1, float value2);
        static void Main(string[] args)
        {
            var methods=new GenericMethods();
            var mathCalculation1 = new MathCalculation(methods.Addition);
            var mathCalculation2 = new MathCalculation(methods.Multiplication);
            Console.WriteLine("Addition value is : " + mathCalculation1.Invoke(100, 3));//with invoke keyword/method
            Console.WriteLine("Division value is : " + mathCalculation2(100, 3));//without invoke keyword
            Console.ReadKey();


            //comment above code to test Func and Action delegates
            Action<string> executeActionDelegate = methods.PrintString;
            executeActionDelegate("Hey ! I'm Action Delegate");
            Func<float, float, double> executeFuncDelegate = methods.Addition;
            Console.WriteLine("Output from Func Delegate : " + executeFuncDelegate(100, 3));
            Console.ReadKey();            
        }
    }
}
