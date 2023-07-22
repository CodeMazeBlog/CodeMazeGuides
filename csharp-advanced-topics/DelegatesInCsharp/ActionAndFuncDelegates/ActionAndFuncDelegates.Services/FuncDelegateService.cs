namespace ActionAndFuncDelegates.Services
{
    public class FuncDelegateService
    {
        public Func<int, int, int>? AdditionFunc;
        public Func<int, int, int>? SubtractionFunc;
        public Func<int, int, int>? MultiplicationFunc;
        public Func<int, int, double>? DivisionFunc;

        public Func<double, double>? CalculateTitheFunc { get; set; }


        public int Add(int a, int b)
        {
            return AdditionFunc?.Invoke(a, b) ?? throw new InvalidOperationException("AdditionFunc is not defined.");
        }

        public int Subtract(int a, int b)
        {
            return SubtractionFunc?.Invoke(a, b) ?? throw new InvalidOperationException("SubtractionFunc is not defined.");
        }

        public int Multiply(int a, int b)
        {
            return MultiplicationFunc?.Invoke(a, b) ?? throw new InvalidOperationException("MultiplicationFunc is not defined.");
        }

        public double Divide(int a, int b)
        {
            return DivisionFunc?.Invoke(a, b) ?? throw new InvalidOperationException("DivisionFunc is not defined.");
        }

        public double CalculateTithe(double earnings)
        {
            if (CalculateTitheFunc == null)
            {
                throw new InvalidOperationException("CalculateTitheFunc is not defined.");
            }

            return CalculateTitheFunc(earnings);
        }
    }
}
