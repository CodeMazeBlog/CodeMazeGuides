using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegateInCSharp
{
    public static class ActionDelegates
    {
        public static string Message { get; set; }
        public static void WriteMessage(Action<int> action, int number)
        {
            Message = "Number: " + number;
            action(number);
        }
    }
}
