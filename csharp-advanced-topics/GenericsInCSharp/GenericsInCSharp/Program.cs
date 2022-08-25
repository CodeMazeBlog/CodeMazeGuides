namespace GenericsInCSharp 
{
    class Program 
    {
        delegate T ArithmeticDelegates<T>(T num1, T num2);

        static void Main(string[] args)
        {
            var delegateObj = new GenericDelegates();
            var addition = new ArithmeticDelegates<int>(delegateObj.AdditionFunc);
            var multiplication = new ArithmeticDelegates<int>(delegateObj.MultiplicationFunc);

            var num1 = 5;
            var num2 = 10;

            var printOutput = $"The sum of {num1} and {num2} is {addition(num1, num2)}";
            delegateObj.PrintString(printOutput);

            printOutput = $"The multiplication of {num1} and {num2} is {multiplication(num1, num2)}";
            delegateObj.PrintString(printOutput);
        }
    }
}
