using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegateInCSharp
{
    public static class FuncDelegates
    {
        public static string PrintNumbersByFormula(Func<int, string> formula, int input)
        {
            return formula(input);
        }
    }
}
