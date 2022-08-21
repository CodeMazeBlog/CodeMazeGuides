using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_Action_Delegate_Library.Action
{
    public class ActionWithSimpleMethod
    {
        public int result { set; get; }
        public void Subtract(int a, int b, int c)
        {
            result = a - b - c;
        }

        public Action<int, int, int> calculateSubtraction;
    }
}
