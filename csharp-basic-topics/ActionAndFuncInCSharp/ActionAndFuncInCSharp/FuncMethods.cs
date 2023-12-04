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

            var result = stringify(42);
            _console.WriteLine(result);
        }

        public void SquareANumber()
        {
            Func<int, int> squarify = Square;

            var result = DoTheFunc(squarify, 2);
            _console.WriteLine(result);
        }

        public void SquareAnotherNumber()
        {
            var result = DoTheFunc(Square, 10);
            _console.WriteLine(result);
        }

        public void CheckANumber()
        {
            Func<int, int, bool> isItGreater = (x, y) => x > y;

            var result = isItGreater(1, 2);
            _console.WriteLine(result);
        }

        private int Square(int x)
        {
            return x * x;
        }

        private TResult DoTheFunc<T, TResult>(Func<T, TResult> funcToDo, T myArg)
        {
            return funcToDo(myArg);
        }
    }
}
