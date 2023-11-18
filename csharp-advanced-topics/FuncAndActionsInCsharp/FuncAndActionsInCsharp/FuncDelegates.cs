namespace FuncAndActionsInCsharp
{
    public static class FuncDelegates
    {
        public static int GetRandomNumber()
        {
            Func<int> getRandomNumber = () => new Random().Next();
            return getRandomNumber();
        }

        public static int Add(int a, int b)
        {
            Func<int, int, int> add = delegate (int x, int y)
            {
                return x + y;
            };
            return add(a, b);
        }

        public static int Multiply(int a, int b)
        {
            Func<int, int, int> multiply = (x, y) => x * y;
            return multiply(a, b);
        }
    }
}
