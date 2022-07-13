namespace ActionAndFuncDelegates
{
    public class FuncDelegates
    {
        public Func<bool> SimpleFuncDelegate { get; set; }
        public Func<decimal, decimal, decimal> DecimalFuncDelegate { get; set; }

        public FuncDelegates()
        {
            SimpleFuncDelegate = () => false;
            DecimalFuncDelegate = (decimal num1, decimal num2) =>
            {
                return num1 + num2;
            };
        }
    }
}
