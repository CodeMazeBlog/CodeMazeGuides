namespace Action_and_Func_delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> PrintNumber = ConsolePrintNumber;
            PrintNumber(2);
        }
        private static void ConsolePrintNumber(int num1)
        {
            Console.WriteLine(num1);
        }
    }
}