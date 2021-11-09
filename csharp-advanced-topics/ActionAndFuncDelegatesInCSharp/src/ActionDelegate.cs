using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndFuncInCsharp
{
    public static class ActionDelegate
    {
        public static void NotifyMeByAction(string message, DateTime notificationTime)
        {
            Console.WriteLine($"Process {message} at: {notificationTime}.");
        }
    }
}
