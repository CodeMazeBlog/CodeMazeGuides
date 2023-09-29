namespace ActionDelegates
{
    public class ActionHandler
    {
        public static void GetConsoleText()
        {
            Console.WriteLine("Console text printed");
        }

        public static void GetUserDefinedText(string message)
        {
            Console.WriteLine("User Defined Text - " + message);

        }

        public static void GetUserDefinedNumbers(int start, int target)
        {
            Console.Write("User Defined Numbers - ");
            for (int i = start; i <= target; i++)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine();
        }
    }
}
