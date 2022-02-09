using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Lib
{
   public  class DelegatesLibrary
    {
     

            public static int AddTwoNumbers(int a, int b)
            {
                return a + b;

            }

            public static void PrintNumbers(int startPosition, int target)
            {
                for (int i = startPosition; i <= target; i++)

                {
                    Console.WriteLine("0", i);
                }

                Console.WriteLine();
            }

        
    }
}
