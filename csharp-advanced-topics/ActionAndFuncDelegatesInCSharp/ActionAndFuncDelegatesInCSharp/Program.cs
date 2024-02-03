
namespace ActionAndFuncDelegatesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func Examples
            Func<int, int, string> FuncMathOperations = Multiply;
            Console.WriteLine(FuncMathOperations(5, 5));
            FuncMathOperations = Add;
            Console.WriteLine(FuncMathOperations(5, 5));
            FuncMathOperations = Divide;
            Console.WriteLine(FuncMathOperations(5, 5));
            FuncMathOperations = Subtract;
            Console.WriteLine(FuncMathOperations(5, 5));

            //Func Annonymous Implementation
            Func<int, int, string> FuncMathAnonOperations = delegate (int a, int b)
            { return $"Multiplication Result(Anon Delegate) : {a * b}"; };
            Console.WriteLine(FuncMathAnonOperations(5, 5));

            //Func Lamda Implementation
            Func<int, int, string> FuncMathLamdaOperations = (int a, int b) =>
            { return $"Multiplication Result(Lamda Delegate) : {a * b}"; };
            Console.WriteLine(FuncMathLamdaOperations(5, 5));

            //Action Examples
            Action<int, int> ActionMathOperations = PrintMultiplyResult;
            ActionMathOperations(5, 5);

            //Action Annonymous Implementation
            Action<int, int> ActionMathAnonOperations = delegate (int a, int b)
            { Console.WriteLine($"Print my Multiplication Result(Anon Delegate) : {a * b}"); };
            ActionMathAnonOperations(5, 5);

            //Action Lamda Implementation
            Action<int, int> ActionMathLamdaOperations = (int a, int b) =>
            { Console.WriteLine($"Print my Multiplication Result(Lamda Delegate) : {a * b}"); };
            ActionMathLamdaOperations(5, 5);

            //Predicate Examples
            Predicate<int> PredicateCheck = CheckIfAdult;

            bool result = PredicateCheck(12);

            if (result)
            {
                Console.WriteLine("I am not an Adult");
            }
            else
            {
                Console.WriteLine("I am an Adult");
            }

            //Predicate Anonymous Implementation
            Predicate<int> AnonPredicateCheck = delegate (int a)
            {
                return a > 18;
            };

            bool anonResult = AnonPredicateCheck(19);

            if (anonResult)
            {
                Console.WriteLine("I am an Adult");
            }

            //Predicate Lamda Implementation
            Predicate<int> LamdaPredicateCheck = a =>
            {
                return a < 18;
            };

            bool lamdaResult = LamdaPredicateCheck(10);

            if (lamdaResult)
            {
                Console.WriteLine("I am not an Adult");
            }
        }

        static bool CheckIfAdult(int age)
        {
            if (age > 18)
            {
                return true;
            }

            return false;
        }

        static void PrintMultiplyResult(int a, int b)
        {
            Console.WriteLine($"Print my Multiplication Result : {a * b}");
        }

        static string Multiply(int a, int b)
        {
            return $"Multiplication Result : {a * b}";
        }

        static string Add(int a, int b)
        {
            return $"Addition Result : {a + b}";
        }

        static string Divide(int a, int b)
        {
            return $"Division Result : {a / b}";
        }

        static string Subtract(int a, int b)
        {
            return $"Subtraction Result : {a - b}";
        }
    }
}