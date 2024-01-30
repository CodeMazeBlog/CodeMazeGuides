namespace ActionAndFuncInCsharp
{
    public class ActionAndFuncInCSharp
    {
        public static Action<int, int> AddNumbersDelegate = (a,b) =>
        {
            var sum = a + b;

            Console.WriteLine($"Sum of {a} and {b} is {sum}");
        };

        public static Func<int, int> SquareDelegate = (num) => num * num;

        public static void Main()
        {
            Action<int, int> addNumbers = AddNumbersDelegate;
            addNumbers(5, 7);

            Func<int, int> square = SquareDelegate;
            var result = square(4);

            Console.WriteLine($"Square of 4 is {result}");
        }
    }
}
