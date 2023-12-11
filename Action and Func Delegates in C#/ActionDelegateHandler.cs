using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_and_Func_Delegates_in_C_
{
    public class ActionDelegateHandler
    {
        
        public static Action<string> LogToConsole = message => Console.WriteLine(message);

       
        public static void ActionDelegateExecution()
        {
            LogToConsole("Logging a message to the console.");
        }
    }
}
