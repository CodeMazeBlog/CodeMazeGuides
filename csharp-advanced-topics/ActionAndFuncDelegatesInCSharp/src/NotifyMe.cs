using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndFuncInCsharp
{
    public static class NotifyMe
    {
        public static string SendNotification(string message, DateTime notificationTime) => $"Process {message} at: {notificationTime}.";
    }
}
