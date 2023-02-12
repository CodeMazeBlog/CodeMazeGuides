namespace FuncAndActionDelegateInCSharp.StaticClasses
{
    public static class FuncDelegateExample
    {
        public static void Print(int x, int y)
        {
            Func<int, int, int> sum = Sum;
            Func<int, int, int> mutiply = Multiply;
            Console.WriteLine($"Func Delegate Sum result: {sum(x, y)}");
            Console.WriteLine($"Func Delegate Multiply result: {mutiply.Invoke(x, y)}");
        }

        private static int Sum(int x, int y)
        {
            return x + y;
        }

        private static int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
