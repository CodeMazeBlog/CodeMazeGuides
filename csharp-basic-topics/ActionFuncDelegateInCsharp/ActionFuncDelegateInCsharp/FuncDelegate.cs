namespace ActionFuncDelegateInCsharp
{
    public class FuncDelegate
    {
        // Func<> delegate declaration 
        public static Func<int, int, int> AddNumbers = (a, b) =>
        {
            int sum = a + b;
            return sum;
        };
    }
}
