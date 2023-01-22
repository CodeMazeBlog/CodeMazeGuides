namespace ActionAndFuncDelegates
{
    public class CalculatorWithActionFunc
    {
        private readonly Action<string> _logger;
        private readonly Func<int, int, long> _sumOperation;

        public CalculatorWithActionFunc()
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