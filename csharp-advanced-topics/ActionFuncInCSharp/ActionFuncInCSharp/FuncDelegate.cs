using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFuncInCSharp
{
    public static class FuncDelegate
    {
        public static string NotifyMeByFunc(string message, DateTime notificationTime)
        {
            return $"Process {message} at: {notificationTime}.";
        }
    }
}
