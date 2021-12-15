namespace ActionFuncDelegatesInCsharp
{
    public class ActionFuncDelegates
    {
        public static void Welcome(string name)
        {
            Console.WriteLine("Welcome, " + name);
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        public static int MultiplyFuncAnonymous(int x, int y)
        {
            Func<int, int, int> multiplyResultAnonymous = delegate (int a, int b)
            {
                return a * b;
            };
            return multiplyResultAnonymous(x, y);
        }
        public static int MultiplyFuncLambda(int x, int y)
        {
            Func<int, int, int> multiplyResultLambda = (a, b) => a * b;
            return multiplyResultLambda(x, y);
        }

        public static void WelcomeAnonymous(string name)
        {
            Action<string> WelcomeDelegateAnonymous = delegate (string name)
            {
                Console.WriteLine("Welcome, " + name);
            };
            WelcomeDelegateAnonymous(name);
        }
        public static void WelcomeLambda(string name)
        {
            Action<string> WelcomeDelegateLambda = (name) => Console.WriteLine("Welcome, " + name);
            WelcomeDelegateLambda(name);
        }

        static void Main(string[] args)
        {
            #region Action Delegates

            Console.WriteLine("-- Action Delegates Demonstration Start --");
            Console.WriteLine("");

            //Action declaration
            Action<string> WelcomeDelegate = Welcome;
            WelcomeDelegate("John");

            //Action with an Anonymous Method

            WelcomeAnonymous("Alice");

            //Action with lambda expression

            WelcomeLambda("Bob");

            #endregion

            #region Func Delegates

            Console.WriteLine("");
            Console.WriteLine("-- Func Delegates Demonstration Start --");
            Console.WriteLine("");

            //Func declaration
            Func<int, int, int> multiplyResult = Multiply;
            Console.WriteLine($"Multiplication Result: {multiplyResult(8, 9)}");

            //Func with an Anonymous Method

            Console.WriteLine($"Multiplication Result using Anonymous Method: {MultiplyFuncAnonymous(8, 9)}");

            //Func with lambda expression

            Console.WriteLine($"Multiplication Result using lambda expression: {MultiplyFuncLambda(8, 9)}");

            #endregion

        }
    }
}
