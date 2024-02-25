namespace ActionAndFunctionDelegates
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Action and Func Delegates in C#

            /*-ACTION DELEGATES-*/

            //Action delegate without parameters
            Action action1 = () => Console.WriteLine("Action Without Parameters");

            //Action delegate with parameters
            Action<string, int> action2 = (a, b) => Console.WriteLine($"Action with parameters: {a} and int parameter {b}");

            //Invoking the Action Delegate without parameters
            action1();

            //Invoking the Action Delegate with Parameters
            action2("string Parameter a", 1);


            /*-FUNC DELEGATES-*/

            //Func delegate without parameters
            Func<string> func1 = () => "Func Without Parameters";

            //Func delegates with parameters
            Func<string, int, string> func2 = (a, b) => $"{a} is {b} years Old";
            Func<int, int, int> func3 = (a, b) => a + b;

            //Invoking the func delegate without parameters
            string func1Result = func1();
            Console.WriteLine(func1Result);

            //Invoking func delegates with parameters
            string func2Result = func2("Jane", 20);
            Console.WriteLine(func2Result);

            int func3Result = func3(2, 3);
            Console.WriteLine($"Result: {func3Result}");
        }
    }
}