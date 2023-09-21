using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_and_Func_Delegate
{
    public delegate int CalculateDelegate(int a, int b);

    public static class DelegateMethod
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
