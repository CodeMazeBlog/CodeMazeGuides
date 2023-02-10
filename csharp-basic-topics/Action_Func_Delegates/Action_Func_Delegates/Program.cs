internal class Program
{
    private static void Main(string[] args)
    {
        Action<int, int> multiply = (x, y) => Console.WriteLine(x * y);
        Func<int, int, int> add = (x, y) => x + y;

        void Process(Action<int, int> action) { action(10, 20); }

        int ProcessFunc(Func<int, int, int> func) { return func(10, 20); }
        int result = ProcessFunc(add); //result = 30

    }
}