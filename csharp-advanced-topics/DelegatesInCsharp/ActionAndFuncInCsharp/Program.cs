using System;

namespace ActionAndFuncInCsharp
{
    internal class Program
    {
        public delegate int BinaryOp(int x, int y);

        private static void Main(string[] args)
        {
            Console.WriteLine("---Delegates---");

            BinaryOp addOp = Add;
            BinaryOp subtractOp = Subtract;
            Console.WriteLine($"Call Add method is using a delegate variable: {addOp(1, 2)}");

            Console.WriteLine($"Call Subtract method is using a delegate variable: {subtractOp(3, 2)}");
            var sum = Operation(4, 2, new[] { addOp, subtractOp });
            Console.WriteLine($"Sum of adding and subtracting 4 and 2 is {sum}");

            Console.WriteLine();
            Console.WriteLine("---Func---");

            Func<int, int, int> addOp2 = Add;
            Func<int, int, int> subtractOp2 = Subtract;
            Console.WriteLine($"Call Add method is using a delegate variable: {addOp2(1, 2)}");
            Console.WriteLine($"Call Subtract method is using a delegate variable: {subtractOp2(3, 2)}");

            sum = Operation2(4, 2, new[] { addOp2, subtractOp2 });
            Console.WriteLine($"Sum of adding and subtracting 4 and 2 is {sum}");

            Console.WriteLine();
            Console.WriteLine("---Func 2---");

            Func<int, int, int> addOp3 = (a, b) => a + b;
            Func<int, int, int> subtractOp3 = (a, b) => a - b;

            Console.WriteLine($"Call Add method is using a delegate variable: {addOp3(1, 2)}");
            Console.WriteLine($"Call Subtract method is using a delegate variable: {subtractOp3(3, 2)}");
            sum = Operation2(4, 2, new[] { addOp3, subtractOp3 }); Console.WriteLine($"Sum of adding and subtracting 4 and 2 is {sum}");
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }

        private static int Subtract(int a, int b)
        {
            return a - b;
        }

        private static int Operation(int a, int b, BinaryOp[] operators)
        {
            int sum = 0;
            foreach (var op in operators) sum += op(a, b);

            return sum;
        }

        private static int Operation2(int a, int b, Func<int, int, int>[] operators)
        {
            int sum = 0;
            foreach (var op in operators) sum += op(a, b);

            return sum;
        }
    }
}