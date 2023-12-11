using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_and_Func_Delegates_in_C_
{
    public class FuncDelegateHandler
    {
       
        public static Func<int, int> Square = x => x * x;

       
        public static int FuncDelegateExecution(int input)
        {
            return Square(input);
        }
    }
}
