
namespace FuncAndActionDelegate
{
    public class Program
    {
        public delegate int Calculate(int firstValue, int secondValue);
        public static int OutputResult = 0;

        public static void Main(string[] args)
        {
            Console.WriteLine("---------- Using Delegate");
            Calculate calculate = Add;
            Console.WriteLine($"  Add: {calculate(3, 4)}");
            calculate += Subtract;
            Console.WriteLine($"  Add and Subtract: {calculate(3,4)}");

            Console.WriteLine("---------- Using Func");
            Func<int, int, int> funcCalculate = Add;
            Console.WriteLine($"  Add using Func: {funcCalculate(3,4)}");
            funcCalculate += Subtract;
            Console.WriteLine($"  Add and Subtract using Func: {funcCalculate(3,4)}");

            Console.WriteLine("---------- Using Action");
            Action<int, int> actionCalculate = AddAction;
            actionCalculate(3, 4);
            actionCalculate += SubtractAction;
            actionCalculate(3, 4);

            OutputResult = 1;
        }

        public static int Add(int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        public static int Subtract(int firstValue, int secondValue)
        {
            return firstValue - secondValue;
        }

        public static void AddAction(int firstValue, int secondValue)
        {
            Console.WriteLine($"  Add using Action: {firstValue + secondValue}");
            OutputResult = firstValue + secondValue;
        }

        public static void SubtractAction(int firstValue, int secondValue)
        {
            Console.WriteLine($"  Subtract using Action: {firstValue - secondValue}");
            OutputResult = firstValue - secondValue;
        }
    }
}