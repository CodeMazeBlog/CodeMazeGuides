using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates.Console
{
    public static class ActionDelegates
    {
        public static void LogInformation(string info)
        {
            System.Console.WriteLine($"This logs some {info} to the console");
        }
        public static void LogError(string error)
        {
            System.Console.WriteLine($"This logs the {error} to the console");
        }
    }
}
