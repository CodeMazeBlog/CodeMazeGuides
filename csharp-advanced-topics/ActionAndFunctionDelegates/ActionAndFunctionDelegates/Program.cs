namespace ActionAndFunctionDelegates
{
    delegate int MathDelegate(int num1, int num2);
    delegate void TextDelegate(string str);
    class Program
    {
        private static int Max(int var1, int var2) { return var1 > var2 ? var1 : var2; }
        private static void Print(string str) { Console.WriteLine(str); }
        private static int DelegateCaller(int var1, int var2, MathDelegate delegate1) { return delegate1(var1, var2); }
        static void Main(string[] args)
        {
            //delegate instantiation
            var delegate1 = new MathDelegate(Max);
            Console.WriteLine(delegate1(20, 30));//30

            var delegate2 = new TextDelegate(Print);
            delegate2("I Love Delegates\n");

            //delegate as a parameter
            Console.WriteLine(DelegateCaller(31, 30, delegate1));//31

            //Action and Func Delegates
            Console.WriteLine("\nUsing Action and Func delegates :");
            Func<int, int, int> MaxFunc = Max;
            Console.WriteLine(MaxFunc(20, 30));//30

            Action<string> PrintAction = Print;
            PrintAction("I Love Delegates");

            Console.ReadKey();
        }
    }
}
