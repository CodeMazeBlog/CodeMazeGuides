namespace ActionAndFuncDelegatesInCSharp
{
    public class Program
    {
        //Example of Action delegate
        public static void PrintMessage()
        {
            Console.WriteLine("Hello, world!");
        }

        static void ExecuteAction(Action action)
        {
            action();
        }

        //Example of Func delegates
        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        static void ExecuteFunc(Func<int, int, int> func)
        {
            int result = func(10, 20);
            Console.WriteLine("Result = " + result);
        }

        static void Main(string[] args)
        {
            ExecuteAction(PrintMessage);
            ExecuteFunc(AddNumbers);
        }
    }
}