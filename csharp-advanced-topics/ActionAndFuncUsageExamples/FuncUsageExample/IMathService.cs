
namespace FuncUsageExample
{
    public interface IMathService
    {
        public string PerformOperation(int x, int y, Func<int, int, double> arithmeticOperation);
    }
}
