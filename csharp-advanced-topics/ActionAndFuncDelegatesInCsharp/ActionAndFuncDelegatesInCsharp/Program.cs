namespace ActionAndFuncDelegatesInCsharp
{
   public class Program
    {
        public static void Add(int a, int b)
        {
            int result = a + b;

            Console.WriteLine($"Addition Result: {result}");
        }
        public static int Multiply(int a, int b)
        {
            int result = a * b;

            return result;
        }
        static void Main(string[] args)
        {
            Action addDelegate = () => Add(5, 3);
            addDelegate(); // Output: Addition Result: 8

            Func<int, int, int> multiplyDelegate = Multiply;
            int multiplicationResult = multiplyDelegate(4, 6);

            Console.WriteLine($"Multiplication Result: {multiplicationResult}"); // Output: Multiplication Result: 24
        }
    }
}