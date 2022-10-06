namespace ActionAndFuncInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionWithNoParams();
            ActionWithParams();
            FuncWithNoParams();
            FuncWithParams();
        }

        static void ActionWithNoParams()
        {
            Action actionWithNoParams = () =>
            {
                Console.WriteLine("We're in the action with no params");

            };

            actionWithNoParams();
        }

        static void ActionWithParams()
        {
            Action<int, int, string> printNumbersWithMessage = (int num1, int num2, string message) =>
            {
                Console.WriteLine($"{message} - Number 1: {num1} - Number 2: {num2}");
            };

            printNumbersWithMessage.Invoke(4, 8, "Foo");
            printNumbersWithMessage(5, 11, "Bar");
        }

        static void FuncWithNoParams()
        {
            Func<bool> randomTrueOrFalse = () =>
            {
                var rand = new Random();
                return rand.Next() % 2 == 0;
            };

            var result = randomTrueOrFalse();
            Console.WriteLine(result);
        }

        static void FuncWithParams()
        {
            Func<int, int, bool> isSumOver10 = (int num1, int num2) =>
            {
                return (num1 + num2) > 10;
            };

            bool result = isSumOver10(5, 6);
            Console.WriteLine(result);
        }
    }
}