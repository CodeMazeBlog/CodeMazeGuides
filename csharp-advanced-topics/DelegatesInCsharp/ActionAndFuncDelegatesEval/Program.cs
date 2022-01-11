using ActionAndFuncDelegatesEval;
using System;

namespace ActionAndFuncDelegatesEval
{
    // multicast delegate in action
    public delegate void ArithemeticDelegate(int arg1, int arg2);

    // step 1: define our delegate that takes a DateTime object and returns the current data as a string
    public delegate string DispalyDateDelegate(DateTime currentTime);
    class Program
    {
        // step 2: declaring a method with the same signature as the delegate
        public static string DisplayDate(DateTime time)
        {
            return $"Time is {time.Date}\n";
        }
        static void Main(string[] args)
        {
            // Here, we're instatitaing the delegate and passing the method to it as an argument
            // We can also set the target method using a lambda expression
            DispalyDateDelegate myDel = new DispalyDateDelegate(DisplayDate);

            // invoking the delegate
            Console.WriteLine(myDel(DateTime.Now));

            Console.WriteLine("========= Multicast delegates in action =========\n");

            ArithemeticDelegate arithDelegate1 = ArithmeticClass.Add;
            ArithemeticDelegate arithDelegate2 = ArithmeticClass.SubStract;
            ArithemeticDelegate arithDelegate3 = ArithmeticClass.Multiply;

            ArithemeticDelegate arithDelegate = arithDelegate1 + arithDelegate2 + arithDelegate3;

            arithDelegate(5, 2);

            // using generic delegates

            Action<int, int> GenericAddDelegate = ArithmeticClass.Add;

            GenericAddDelegate(3, 4);

            // or you can use the Action<T> delegate with an anonymous methiod like this

            Action<int, int> AddDelegate = delegate (int firstNum, int secondNum)
            {
                Console.WriteLine($"The sum of {firstNum} + {secondNum} is {firstNum + secondNum}");
            };

            AddDelegate(5, 6);

            Func<int, int, int> SunstractDelegate = delegate (int firstNum, int secondNum)
            {
                return firstNum - secondNum;
            };

            Console.WriteLine(SunstractDelegate(15, 6));
        }
    }
}