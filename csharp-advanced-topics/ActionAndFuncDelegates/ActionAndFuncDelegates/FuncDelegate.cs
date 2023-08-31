namespace ActionAndFuncDelegates
{
    public class FuncDelegate
    {
        public static void Driver()
        {
            Func<string> firstDelegate = MethodWithStringReturnValueAndNoParameter;
            var firstResult = firstDelegate();
            Console.WriteLine(firstResult);

            Func<int, int, int> secondDelegate = MethodWith2IntsAndReturnAnInt;
            var secondResult = secondDelegate(22, 44);
            Console.WriteLine($"Sum of 2 numbers : {secondResult}");

            Func<bool, string, int> thirdDelegate = MethodWithIntReturnAndBoolAndStringParameter;
            var thirdResult = thirdDelegate(true, "code-maze");
            Console.WriteLine(thirdResult);
        }

        public static string MethodWithStringReturnValueAndNoParameter()
        {
            return "Hello from code-maze";
        }

        public static int MethodWith2IntsAndReturnAnInt(int first, int second)
        {
            return first + second;
        }

        public static int MethodWithIntReturnAndBoolAndStringParameter(bool canReturnLength, string name)
        {
            if (canReturnLength)
                return name.Length;

            return -1;
        }
    }
}
