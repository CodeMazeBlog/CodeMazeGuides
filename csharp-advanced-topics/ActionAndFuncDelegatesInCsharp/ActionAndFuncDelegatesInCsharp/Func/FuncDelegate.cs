namespace ActionAndFuncDelegatesInCsharp.Func
{
    public class FuncDelegate
    {
        public Func<int, int, int> Func_Sum = (number1, number2) => number1 + number2;

        public int Func_NamedMethod_Example(int Number1, int Number2)
        {
            return Number1 + Number2;
        }
    }
}
