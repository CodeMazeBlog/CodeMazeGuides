using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegate
{
    // step 1: define our delegate that takes a DateTime object and returns the current data as a string
    public delegate string DisplayDateDelegate(DateTime currentTime);
    class Program
    {
        // step 2: declaring a method with the same signature as the delegate
        public static string DisplayDate(DateTime time)
        {
            return $"Time is {time.ToString("MM/dd/yyyy")}";
        }
        static void Main(string[] args)
        {
            // Here, we're instatitaing the delegate and passing the method to it as an argument
            // We can also set the target method using a lambda expression
            DisplayDateDelegate myDel = new DisplayDateDelegate(DisplayDate);
            // invoking the delegate
            Console.WriteLine(myDel(DateTime.Now));
            Console.ReadKey();

            // using generic delegates
            Training arithmetic = new Training();
            Action<string> GenericAddDelegate = arithmetic.SayHello;
            GenericAddDelegate.Invoke("Ben");

            Func<int, int, int> AddNum = arithmetic.Add;
            Console.WriteLine(AddNum.Invoke(6, 7));

            // You can use the Action<T> delegate with an anonymous methiod like this
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
