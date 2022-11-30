public class Program
{
    public delegate void StringDelegate(string text);

    private static void Main(string[] args)
    {
        Console.WriteLine("=====Delegates=====");
        StringDelegate stringDelegate = ToUpperCase;
        stringDelegate("this is a test for delegate function");

        WriteOutput("test", stringDelegate);

        static void ToUpperCase(string text) => Console.WriteLine(text.ToUpper());
        static void WriteOutput(string text, StringDelegate stringDelegate)
        {
            Console.WriteLine($"Before: {text}");
            stringDelegate(text);
        }

        Console.WriteLine("=================\n\n");

        Console.WriteLine("=====Func========");
        Func<double, double> square = SquareFunc;
        Console.WriteLine($"square = {square(2)} ");
        Console.WriteLine("Func Lambda expression:");
        Func<double, double> sqr = (double value) => value * value;
        Console.WriteLine($"square from anonymous function = {sqr(2)} ");
        static double SquareFunc(double number) => Math.Pow(number, 2);

        Console.WriteLine("=================\n\n");
        Console.WriteLine("=====Actions=====");
        Action<double> squareAct = Square;
        static void Square(double number) => Console.WriteLine($"square from action = {Math.Pow(number, 2)}");
        Square(4);
        Console.WriteLine("=================");

    }
}

