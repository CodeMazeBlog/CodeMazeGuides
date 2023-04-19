using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class DelegateMethods
    {
        #region Function Definations

        public static void Greet()
        {
            Console.WriteLine("Hello, how can I help you?");
        }

        public static void GreetWithName(string name)
        {
            Console.WriteLine($"Hello {name}, how can I help you?");
        }

        public static double PercentageScore(int totalMarks, int obtainedMarks)
        {
            return obtainedMarks * 100 / totalMarks;
        }

        public static string GetFullname(string firtsName, string lastame)
        {
            return firtsName + " " + lastame;
        }

        #endregion
    }
}
