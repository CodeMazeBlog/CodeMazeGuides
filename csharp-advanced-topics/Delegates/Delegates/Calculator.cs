
namespace Delegates
{
    public delegate void CalculationEventHandler(int x, int y);

    public class Calculator
    {

        public event CalculationEventHandler? CalculationPerformed;

        public int Add(int x, int y)
        {
            int result = x + y;
            CalculationPerformed?.Invoke(x, y);
            return result;
        }

        public int Subtract(int x, int y)
        {
            int result = x - y;
            CalculationPerformed?.Invoke(x, y);
            return result;
        }

        public int Multiply(int a,int b)
        {
            Func<int, int, int> multiply = (x, y) => x * y;
            int result = multiply(a, b);
            CalculationPerformed?.Invoke(a, b);
            return result;
        }
    }
}
