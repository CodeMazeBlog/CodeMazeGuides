using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class ActionDelegate
    {
        public Action<string> DisplayMessage= (input) => Console.WriteLine(input);
        public Action<string, string> DisplayMessages = (input1, input2) => Console.WriteLine(input1 + input2);
    }
}
