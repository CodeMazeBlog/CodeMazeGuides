
namespace ActionFuncDelegates
{
    public class FuncDelegates
    {
        public static int Add(int x, int y) 
        {
            return (x + y);
        } 

        public static int FuncDelegate() 
        { 
            Func<int, int, int> numbers = Add; 
            var result = numbers(20, 10); //Result: 30
            Console.WriteLine($"Result:{result}");

            return result;
        }

        public static int FuncDelegateWithAnonymous()
        {
            Func<int, int, int> numbers = delegate (int a, int b)
            {
                return a + b;   
            };

            var result = numbers(30, 10); //Result: 40
            Console.WriteLine($"Result:{result}");

            return result;
        }

        public static (int Result, string Output) FuncDelegateWithLambda()
        {
            Func<int, int, int> numbers = (x, y) => x + y;
            var result = numbers(50, 50); // Result: 100
            var output = $"Result: {result}";
            Console.WriteLine(output);

            return (result, output);
        }
    }
}
