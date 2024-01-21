namespace ActionAndFunctionDelegates
{
    public delegate int MathDelegate(int num1, int num2);
    public delegate void TextDelegate(string str);

    public class Program
    {
        public static int Max(int var1, int var2)
        {
            return var1 > var2 ? var1 : var2;
        }
        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
        public static int DelegateCaller(int var1, int var2, MathDelegate delegateVar)
        {
            return delegateVar(var1, var2);
        }

        static void Main(string[] args)
        {
            var delegate1 = new MathDelegate(Max);
            Console.WriteLine(delegate1(20, 30));

            var delegate2 = new TextDelegate(Print);
            delegate2("I Love Delegates\n");

            Console.WriteLine(DelegateCaller(31, 30, delegate1));

            Console.WriteLine("\nUsing Action and Func delegates :");
            Func<int, int, int> MaxFunc = Max;
            Console.WriteLine(MaxFunc(20, 30));

            Action<string> PrintAction = Print;
            PrintAction("I Love Delegates");
            Console.ReadKey();
        }
    }
}
