namespace ActionAndFuncInCsharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Calculate summation of 10 and 2 with Func and lambda expression:");
            AddFuncWithLambdaExpression();

            Console.WriteLine("Get PI number with Func and lambda expression:");
            GetPiNumberFuncWithLambdaExpression();

            Console.WriteLine("Calculate summation of 10 and 2 with Func and anonymous method:");
            AddFuncWithAnonymousMethod();

            Console.WriteLine("It indicates whether the number 10 is even or not with Func and method group:");
            IsEvenNumberFunWithMethodGroup();

            Console.WriteLine("Display hello world with Action and lambda expression:");
            DisplayHelloWorldActionWithLambdaExpression();

            Console.WriteLine("Display multiply of 3 and 4 with Action and  anonymous method:");
            DisplayResultOfMultiplyActionWithAnonymousMethod();

            Console.WriteLine("Display hello world with Action and method group:");
            DisplayHelloWorldActionWithMethodGroup();
        }

        public static void AddFuncWithLambdaExpression()
        {
            Func<double, double, double> addViaLabmdaExpression = (double a, double b) => a + b;

            var result = addViaLabmdaExpression(10, 2);
            Console.WriteLine($"The result of call: {result}");

            result = addViaLabmdaExpression.Invoke(10, 2);
            Console.WriteLine($"The result of invoke: {result}");
        }

        public static void GetPiNumberFuncWithLambdaExpression()
        {
            Func<double> getPiNumber = () => Math.PI;

            var result = getPiNumber();
            Console.WriteLine(result);
        }

        public static void AddFuncWithAnonymousMethod()
        {
            Func<double, double, double> addViaAnonymousMethod = delegate (double a, double b) { return a + b; };

            var result = addViaAnonymousMethod(10, 2);
            Console.WriteLine(result);
        }

        public static void IsEvenNumberFunWithMethodGroup()
        {
            Func<int, bool> isEvenNumber;
            isEvenNumber = IsEvenNumber;

            var result = isEvenNumber(10);
            Console.WriteLine(result);
        }

        private static bool IsEvenNumber(int a)
        {
            return a % 2 == 0;
        }

        public static void DisplayHelloWorldActionWithLambdaExpression()
        {
            Action displayHelloWorld = () => Console.WriteLine("Hello World!");

            displayHelloWorld();
        }

        public static void DisplayResultOfMultiplyActionWithAnonymousMethod()
        {
            Action<int, double> multiply = delegate (int a, double b) { Console.WriteLine(a * b); };

            multiply(3, 4);
        }

        public static void DisplayHelloWorldActionWithMethodGroup()
        {
            Action displayHelloWorld = DisplayHelloWorld;

            displayHelloWorld();
        }

        public static void DisplayHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
