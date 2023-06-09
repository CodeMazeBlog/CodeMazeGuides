using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public class Methods
    {
        // Define a methods matching the signature of Action delegate
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayRandomNumber()
        {
            Random r = new Random();
            Console.WriteLine(r.Next());
        }

        // Define a methods matching the signature of Func delegate
        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public static string ShowFullName(string firstName, string lastName)
        {
            return string.Format("My Name is {0} {1}", firstName, lastName);
        }
    }
}
