namespace ActionAndFuncDelegatesInCsharp.Func
{
    public class FuncDelegate
    {
        public Func<int, int, int> Sum = (number1, number2) => number1 + number2;

        public int SumTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
