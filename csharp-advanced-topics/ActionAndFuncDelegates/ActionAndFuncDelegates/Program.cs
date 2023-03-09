namespace ActionAndFuncDelegates
{
    public class Program
    {
        private static string output = string.Empty;

        public static void PrintStaticNumber() => output = "The input value is: 10";

        public static void PrintInputNumber(int number) => output = $"The input value is: {number}";

        public static int Addition(int num1, int num2) =>  num1 + num2;

        public static string PrintFullName(string firstName, string lastName) => $"Your Name is {firstName} {lastName}";

        static void Main(string[] args)
        {
            Action printStaticNumber = PrintStaticNumber;
            printStaticNumber();

            Console.WriteLine("\n***************** Action<> Delegate Methods ***************\n");
            Console.WriteLine(output);

            Action<int> printInputNumber = PrintInputNumber;
            printInputNumber(20);
            Console.WriteLine(output);

            Func<int, int, int> addition = Addition;
            Func<string, string, string> fullName = PrintFullName;


            Console.WriteLine();
            Console.WriteLine("**************** Func<> Delegate Methods *****************\n");
            int sum = addition(4,5);
            string name = fullName("code", "maze");

            Console.WriteLine("Addition: {0}", sum);
            Console.WriteLine(name);
        }
    }
}