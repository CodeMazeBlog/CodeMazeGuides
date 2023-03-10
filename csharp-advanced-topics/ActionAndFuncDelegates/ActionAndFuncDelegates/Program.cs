namespace ActionAndFuncDelegates
{
    public class Program
    {
        private static string output = string.Empty;

        public static void PrintStaticNumber() => output = "The input value is: 50";

        public static void PrintInputNumber(int number) => output = $"The input value is: {number}";

        public static int Addition(int num1, int num2) =>  num1 + num2;

        public static string PrintFullName(string firstName, string lastName) => $"Your Name is {firstName} {lastName}";

        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 20;
            string firstName = "code";
            string lastName = "maze";

            Console.WriteLine("\n***************** Action<> Delegate Methods ***************\n");
            Console.WriteLine(ActionDelagate());
            Console.WriteLine(ActionDelagateWithArguments(num1));

            Console.WriteLine();
            Console.WriteLine("**************** Func<> Delegate Methods *****************\n");

            Console.WriteLine("Addition: {0}", FunctionDelagate(num1, num2));
            Console.WriteLine(FunctionDelagateWithArguments(firstName, lastName));
        }

        public static string ActionDelagate()
        {
            Action printStaticNumber = PrintStaticNumber;
            printStaticNumber();
            return output;
        }

        public static string ActionDelagateWithArguments(int number)
        {
            Action<int> printInputNumber = PrintInputNumber;
            printInputNumber(number);
            return output;
        }

        public static int FunctionDelagate(int num1, int num2)
        {
            Func<int, int, int> addition = Addition;
            int sum = addition(num1, num2);

            return sum;
        }

        public static string FunctionDelagateWithArguments(string firstName, string lastName)
        {
            Func<string, string, string> fullName = PrintFullName;
            string name = fullName(firstName, lastName);

            return name;
        }
    }
}