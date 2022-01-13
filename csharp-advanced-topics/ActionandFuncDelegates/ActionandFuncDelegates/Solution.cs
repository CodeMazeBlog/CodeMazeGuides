using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionandFuncDelegates
{
    public class Solution
    {
        // Declaring the delegate type
        public delegate int CalculateValue(int x, int y);

        // Initialising the delegate object
        public CalculateValue sumDelegate = new CalculateValue(CalculateSum);
        public static int CalculateSum(int x, int y)
        {
            return x + y;
        }

        public static void PrintCoupleNames(string husbandName, string wifeName)
        {
            Console.WriteLine($"The couples are {husbandName} and {wifeName}");
        }

    }
}
