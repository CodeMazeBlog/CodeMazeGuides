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

        public long LastResult { get; internal set; }
        public string? LastLogMessage { get; internal set; }

        public void Sum(int first, int second)
        {
            var result = _sumOperation(first, second);
            var logMessage = "The result is: " + result;
            _logger(logMessage);
            LastResult = result;
            LastLogMessage = logMessage;
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