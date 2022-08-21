using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_Action_Delegate_Library.Action
{
    public class ActionWithAnnonymousMethod
    {
        public static string Result { get; set; }
        public Action<string, string> concatString = delegate (string a, string b)
        {
            Result = a + b;
        };
    }
}
