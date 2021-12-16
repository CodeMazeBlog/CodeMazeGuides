class CalculatorController
{
    public static void Main(string[] args)
    {
        var calculator = new Calculator
        {
            Print = n => Console.WriteLine($"*** {n} ***")
        };

        calculator.SetOperation('+');
        calculator.Calculate(4, 2);
        calculator.Print += n => Console.WriteLine("*********");
        calculator.Calculate(-3, 4);
    }

    class Calculator
    {
        public Action<int> Print { get; set; }

        public Func<int, int, int> Operate { get; set; }

        public void SetOperation(char operation)
        {
            switch (operation)
            {
                case '+':
                    Operate = (a, b) => a + b;
                    break;
                case '-':
                    Operate = (a, b) => a - b;
                    break;
                case '*':
                    Operate = (a, b) => a * b;
                    break;
                case '/':
                    Operate = (a, b) => a / b;
                    break;
                default:
                    Operate = (a, b) => -1;
                    break;
            }
        }

        public void Calculate(int a, int b)
        {
            int result = Operate(a, b);
            Print(result);
        }
    }
}