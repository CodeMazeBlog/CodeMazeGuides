using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp
{
    public class DelegateService
    {
        public delegate int DelegateMethod(int a, int b);
        public int DisplayResult(int a, int b)
        {
            return a + b;
        }
    }
}
