namespace ActionAndFuncInCSharp
{
    public class FuncMethods
    {
        private readonly IConsole _console;

        public FuncMethods(IConsole console)
        {
            _console = console;
        }

        public void PrintANumber()
        {
            Func<int, string> stringify = x => x.ToString();

            string result = stringify(42);
            _console.WriteLine(result); // prints "42" to the console
        }

        public void SquareANumber()
        {
            Func<int, int> squarify = Square;

            int result = DoTheFunc(squarify, 2);
            _console.WriteLine(result); // prints "4" to the console
        }

        public void SquareAnotherNumber()
        {
            int result = DoTheFunc(Square, 10);
            _console.WriteLine(result); // prints "100" to the console
        }

        public void CheckANumber()
        {
            Func<int, int, bool> isItGreater = (x, y) => x > y;

            bool result = isItGreater(1, 2);
            _console.WriteLine(result); // prints "False" to the console
        }

        private static int Square(int x)
        {
            return x * x;
        }

        private static TResult DoTheFunc<T, TResult>(Func<T, TResult> funcToDo, T myArg)
        {
            return funcToDo(myArg);
        }
    }
}
