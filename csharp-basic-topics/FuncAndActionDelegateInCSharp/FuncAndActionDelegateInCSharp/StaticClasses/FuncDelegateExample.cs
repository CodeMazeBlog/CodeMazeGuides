namespace FuncAndActionDelegateInCSharp.StaticClasses
{
    public static class FuncDelegateExample
    {
        public static void Print(int x, int y)
        {
            IntOperations sum = Sum;
            IntOperations mutiply = Multiply;
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

        public delegate int IntOperations(int x, int y);
    }
}
