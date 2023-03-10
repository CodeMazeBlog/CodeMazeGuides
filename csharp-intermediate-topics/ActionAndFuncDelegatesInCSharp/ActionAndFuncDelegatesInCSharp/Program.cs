namespace ActionAndFuncDelegatesInCsharp
{
    public class Program
    {
        public static void WriteToConsole(string text)
        {
            Console.WriteLine(text);
        }

        public static int Sum(int first, int second)
        {
            return first + second;
        }

        public static void Main(string[] args)
        {
            Action<string> writeToConsoleActionNewInstance = new Action<string>(WriteToConsole);
            writeToConsoleActionNewInstance("Invoking Action instantiated with new instance of the delegate.");

            Action<string> writeToConsoleActionAssigning = WriteToConsole;
            writeToConsoleActionAssigning("Invoking Action instantiated by assigning a group method to a delegate type.");

            Action<string> writeToConsoleActionAnonymous = delegate (string text)
            {
                Console.WriteLine(text);
            };
            writeToConsoleActionAnonymous("Invoking Action instantiated by using anonymous method.");

            Action<string> writeToConsoleActionLambda = text => Console.WriteLine(text);
            writeToConsoleActionLambda("Invoking Action instantiated by using lambda expression.");

            var firstNumber = 2;
            var secondNumber = 3;

            Func<int, int, int> sumTwoNumbersFuncNewInstance = new Func<int, int, int>(Sum);
            Console.WriteLine($"Invoking Func instantiated with new instance of the delegate. Sum of {firstNumber} and {secondNumber} is {sumTwoNumbersFuncNewInstance(firstNumber, secondNumber)}.");

            Func<int, int, int> sumTwoNumbersFuncAssigning = Sum;
            Console.WriteLine($"Invoking Func instantiated by assigning a group method to a delegate type. Sum of {firstNumber} and {secondNumber} is {sumTwoNumbersFuncAssigning(firstNumber, secondNumber)}.");

            Func<int, int, int> sumTwoNumbersFuncAnonymous = delegate (int first, int second)
            {
                return Sum(first, second);
            };
            Console.WriteLine($"Invoking Func instantiated by using anonymous method. Sum of {firstNumber} and {secondNumber} is {sumTwoNumbersFuncAnonymous(firstNumber, secondNumber)}.");

            Func<int, int, int> sumTwoNumbersFuncLambda = (first, second) => Sum(first, second);
            Console.WriteLine($"Invoking Func instantiated by using lambda expression. Sum of {firstNumber} and {secondNumber} is {sumTwoNumbersFuncLambda(firstNumber, secondNumber)}.");

            writeToConsoleActionNewInstance.Invoke("Invoking Action with Invoke method.");

            Action<string> writeToConsoleActionMulticasting = WriteToConsole;
            writeToConsoleActionMulticasting += text => Console.WriteLine(text);
            writeToConsoleActionMulticasting("Invoking Action multicast.");
        }
    }
}