namespace ActionFuncDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Action  delegates
            // Declare an Action delegate instance
            Action greetMessage = Greet;
            Action<string> greetWithName = GreetWithName;
            // Invoke the delegate
            greetMessage();
            greetWithName("Tanveer");
            #endregion

            #region Func  delegates
            // Declare a Func delegate instance
            Func<int, int, double> percentageScore = PercentageScore;
            Func<string, string, string> getFullname = GetFullname;
            // Invoke the delegate
            double per = percentageScore(100, 70);
            Console.WriteLine($"You got {per}% marks.");
            string name = getFullname("Tanveer", "Hussain");
            Console.WriteLine($"Name: {name}");
            #endregion 
        }

        #region Function Definations
        static void Greet()
        {
            Console.WriteLine("Hello, how can I help you?");
        }
        static void GreetWithName(string name)
        {
            Console.WriteLine($"Hello {name}, how can I help you?");
        }
        static double PercentageScore(int totalMarks, int obtainedMarks)
        {
            return obtainedMarks * 100 / totalMarks;
        }
        static string GetFullname(string firtsName, string lastame)
        {
            return firtsName + " " + lastame;
        }
        #endregion
    }
}