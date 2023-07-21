namespace FuncAndActionInCSharp
{
    public class Calculator
    {
        public Func<int, int, int> Add = (a, b) => a + b;
        public Func<int, int, int> Subtract = (a, b) => a - b;
    }
}
