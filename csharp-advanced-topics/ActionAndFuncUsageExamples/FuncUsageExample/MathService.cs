
namespace FuncUsageExample
{
    public class MathService : IMathService
    {
        public string PerformOperation(int x, int y, Func<int, int, double> arithmeticOperation)
        {
            var result = arithmeticOperation(x, y);

            var xPercentage = x / result * 100;
            var yPercentage = y / result * 100;

            return $"X: {xPercentage:N2}% and Y: {yPercentage:N2}%";
        }
    }
}
