namespace ActionAndFuncDelegates
{
    public delegate void Log(string message);

    public delegate long Sum(int firstNumber, int secondNumber);

    public class Calculator
    {
        private readonly Log _logger;
        private readonly Sum _sumOperation;

        public Calculator()
        {
            _logger = InternalLogger;
            _sumOperation = InternalSumOperation;
        }

        public void Sum(int first, int second)
        {
            var result = _sumOperation(first, second);
            _logger("The result is: " + result);
        }

        private void InternalLogger(string message)
        {
            Console.WriteLine(message);
        }

        private long InternalSumOperation(int a, int b)
        {
            return a + b;
        }
    }
}