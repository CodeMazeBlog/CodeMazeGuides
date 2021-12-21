// See https://aka.ms/new-console-template for more information
namespace DelegatesActionFunc
{
    class Program
    {
        public delegate void MyMessage(string message);
        static void Main(string[] args)
        {
            // working for a normal delegate.
            MyMessage Val = Greeting.DisplayMsg;
            Val("Good Morning");

            //Working of an action delegate.
            //declare and use an action delegate here. 
            Action<int, int> val = myMath;
            val(20, 5);

            //Working of a Func Delegate.
            //declare and use a func delegate with 2 input and one out parameter.
            Func<int, int, int> SumDelegate = Sum;
            Console.WriteLine("Func Delegate implemented - Output:" + SumDelegate(10, 20));
            Console.ReadKey();

        }
        //Method to show Action delegate implementation
        public static void myMath(int a, int b)
        {
            Console.WriteLine("Action Delegate implemented - Output:" + (a - b));
        }

        //Method to show Func Delegate implementation
        public static int Sum(int a, int b)
        {
            return a + b;
        }

    }
    //class to show delegate implementation.
    class Greeting
    {
        public static void DisplayMsg(string message)
        {
            Console.WriteLine("This is a greeting through a delegate :" + message);
        }
    }
}
