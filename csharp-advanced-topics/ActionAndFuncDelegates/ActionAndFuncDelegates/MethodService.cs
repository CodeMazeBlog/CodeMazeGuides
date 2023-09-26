namespace ActionAndFuncDelegates
{
    public class MethodService
    {
        #region Action Delegates Methods
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
        #endregion

        #region Func Delegates Methods
        public static string GetNamesReturn(string FirstName, string SecondName, string ThirdName)
        {
            return string.Format("{0}-{1}-{2}", 
                                  FirstName,
                                  SecondName,
                                  ThirdName);
        }
        public static int GetRandomNumber()
        { 
            Random r = new();
            return r.Next(1, 100);
        }
        #endregion
    }
}
