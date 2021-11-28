using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncInCsharp
{
    public class CountMethods
    {
        public static int Count(string s)
        {
            return s.Length;
        }
        public static void PrintCount(string s)
        {
            Console.WriteLine(s.Length);
        }


    }
}
