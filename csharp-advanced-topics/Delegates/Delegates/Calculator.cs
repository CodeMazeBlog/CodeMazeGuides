
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
    }
}
