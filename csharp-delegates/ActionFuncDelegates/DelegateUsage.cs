using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class DelegateUsage
    {
        public static void UseDelegates()
        {
            #region Action  delegates


            Action greetMessage = DelegateMethods.Greet;
            Action<string> greetWithName = DelegateMethods.GreetWithName;

            greetMessage();
            greetWithName("Tanveer");

            #endregion

            #region Func  delegates

            Func<int, int, double> percentageScore = DelegateMethods.PercentageScore;
            Func<string, string, string> getFullname = DelegateMethods.GetFullname;

            double per = percentageScore(100, 70);
            Console.WriteLine($"You got {per}% marks.");

            string name = getFullname("Tanveer", "Hussain");
            Console.WriteLine($"Name: {name}");
            #endregion 
        }
    }
}
