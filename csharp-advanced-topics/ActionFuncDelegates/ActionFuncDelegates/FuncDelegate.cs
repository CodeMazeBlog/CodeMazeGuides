using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class FuncDelegate
    {
        public Func<int, int, int> Sum = (a, b) => a + b;
        public Func<int, int, int> Multiply = (a, b) => a * b;
    }
}
