namespace ActionAndFuncDelegates
{
    public class Program
    {
        public static void PrintStaticText() => Console.WriteLine("Action delegate");

        public static void Print(string message) => Console.WriteLine(message);

        public static int Addition(int num1, int num2) =>  num1 + num2;

        public static string PrintFullName(string firstName, string lastName) => string.Format("Your Name is {0} {1}", firstName, lastName);

        static void Main(string[] args)
        {
            Action printStaticText = PrintStaticText;
            Action<string> printText = Print;

            Func<int, int, int> addition = Addition;
            Func<string, string, string> fullName = PrintFullName;

            Console.WriteLine("\n***************** Action<> Delegate Methods ***************\n");
            printStaticText();
            printText("Hello World!");

            Console.WriteLine();
            Console.WriteLine("**************** Func<> Delegate Methods *****************\n");
            int sum = addition(4,5);
            string name = fullName("code", "maze");

            Console.WriteLine("Addition: {0}", sum);
            Console.WriteLine(name);
        }
    }
}