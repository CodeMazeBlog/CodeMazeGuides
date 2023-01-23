using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFunctionConsole.Services
{
    public class Utils
    {
        public static void MethodStarted()
        {
            Console.WriteLine($"The method started | {DateTime.Now}");
        }
    }
}
