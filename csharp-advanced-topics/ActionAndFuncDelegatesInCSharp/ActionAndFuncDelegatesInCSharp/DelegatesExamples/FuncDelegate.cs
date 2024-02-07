namespace ActionAndFuncDelegatesInCSharp.DelegatesExamples
{
    public class FuncDelegate
    {
        public void Execute(Operation op)
        {
            Func<int, int, string>? FuncMathOperations;
            switch (op)
            {
                case Operation.Sum:
                    FuncMathOperations = Add;
                    Console.WriteLine(FuncMathOperations(5, 5));
                    break;
                case Operation.Subtract:
                    FuncMathOperations = Subtract;
                    Console.WriteLine(FuncMathOperations(5, 5));
                    break;
                case Operation.Multiply:
                    FuncMathOperations = Multiply;
                    Console.WriteLine(FuncMathOperations(5, 5));
                    break;
                case Operation.Divide:
                    FuncMathOperations = Divide;
                    Console.WriteLine(FuncMathOperations(5, 5));
                    break;
                default:
                    break;
            }

            //Anonymous Function Implementation
            Func<int, int, string> FuncMathAnonOperations = delegate (int a, int b)
            {
                return $"Multiplication Result(Anon Delegate) : {a * b}";
            };

            Console.WriteLine(FuncMathAnonOperations(5, 5));

            //Lambda Implementation
            Func<int, int, string> FuncMathLamdaOperations = (int a, int b) =>
            {
                return $"Multiplication Result(Lamda Delegate) : {a * b}";
            };

            Console.WriteLine(FuncMathLamdaOperations(5, 5));
        }

        public enum Operation
        {
            Sum,
            Multiply,
            Divide,
            Subtract
        }

        public string Multiply(int a, int b)
        {
            return $"Multiplication Result : {a * b}";
        }

        public string Add(int a, int b)
        {
            return $"Addition Result : {a + b}";
        }

        public string Divide(int a, int b)
        {
            return $"Division Result : {a / b}";
        }

        public string Subtract(int a, int b)
        {
            return $"Subtraction Result : {a - b}";
        }
    }
}