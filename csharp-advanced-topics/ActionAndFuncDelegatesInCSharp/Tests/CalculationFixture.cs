using FuncDelegates;

namespace Tests
{
    public class CalculationFixture
    {
        public Calculation Calculation { get; }

        public CalculationFixture()
        {
            Calculation = new Calculation();
        }
    }
}
