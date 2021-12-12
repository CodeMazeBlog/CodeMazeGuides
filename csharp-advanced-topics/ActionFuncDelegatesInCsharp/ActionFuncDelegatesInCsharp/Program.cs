namespace ActionFuncDelegatesInCsharp
{
    class Program
    {
        static void Welcome(string name)
        {
            Console.WriteLine("Inside Welcome Function");
            Console.WriteLine("Welcome, " + name);
        }
        static int Multiply(int a, int b)
        {
            return a * b;
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
            Action<string> WelcomeDelegateAnonymous = delegate (string name)
            {
                Console.WriteLine("Inside Anonymous Method");
                Console.WriteLine("Welcome, " + name);
            };
            WelcomeDelegateAnonymous("Alice");

            //Action with lambda expression
            Action<string> WelcomeDelegateLambda = (name) =>
            {
                Console.WriteLine("Inside lambda expression");
                Console.WriteLine("Welcome, " + name);
            };
            WelcomeDelegateLambda("Bob");
            
            #endregion

            #region Func Delegates
            
            Console.WriteLine("");
            Console.WriteLine("-- Func Delegates Demonstration Start --");
            Console.WriteLine("");
            
            //Func declaration
            Func<int, int, int> multiplyResult = Multiply;
            Console.WriteLine($"Multiplication Result: {multiplyResult(8, 9)}");

            //Func with an Anonymous Method
            Func<int, int, int> multiplyResultAnonymous = delegate (int a, int b)
              {
                  return a * b;
              };
            Console.WriteLine($"Multiplication Result using Anonymous Method: {multiplyResultAnonymous(8, 9)}");

            //Func with lambda expression
            Func<int, int, int> multiplyResultLambda = (a, b) => a * b;
            Console.WriteLine($"Multiplication Result using lambda expression: {multiplyResultLambda(8, 9)}");
            
            #endregion

        }
    }
}
