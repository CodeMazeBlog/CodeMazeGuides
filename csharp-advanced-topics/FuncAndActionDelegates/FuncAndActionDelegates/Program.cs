using FuncNActionDelegates;

namespace FuncAndActionDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var delF = new FuncDelegate();
            var param = 3;
            // Func Delegate
            Func<int, int> funcFact = delF.GetFactorial;
            var result = funcFact(param); ;
            Console.WriteLine($"Factorial of {param} is {result}");

            //Anonymous Func Delegate
            Func<int, int, int> fCalulate = (x, y) => { return x * y; };
            var productResult = fCalulate(7, 23);
            Console.WriteLine($"The multiplication result is {productResult}");


            // Anonymous Action Delegate
            Action<string> aCharLen = str => { Console.WriteLine($"Length of {str} is {str.Length}"); };

            aCharLen.Invoke("qwerty");

            var actionF = new ActionDelegate();
            // Action Delegate
            Action<int> aPrime = actionF.PrintResult;

            aPrime.Invoke(11);

        }
    }
}
