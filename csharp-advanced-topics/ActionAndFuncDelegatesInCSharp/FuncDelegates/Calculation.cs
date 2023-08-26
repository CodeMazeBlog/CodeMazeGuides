namespace FuncDelegates
{
    public class Calculation
    {
        public int Calculate(Func<int, int, int> operation)
        {
            return operation(20, 10);
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
