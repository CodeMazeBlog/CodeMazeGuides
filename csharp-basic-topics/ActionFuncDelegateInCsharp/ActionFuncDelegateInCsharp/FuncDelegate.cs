namespace ActionFuncDelegateInCsharp
{
    public class FuncDelegate
    {
        public static Func<int, int, int> AddNumbers = (a, b) =>
        {
            var sum = a + b;

            return sum;
        };
    }
}
