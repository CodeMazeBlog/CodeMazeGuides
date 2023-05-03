using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionandFunc
{
    public class Delegates
    {
        public static void DoAction(Action<int, string> action)
        {
            action(42, "hello");
        }

        public static int DoFunc(Func<int, int, int> func)
        {
            return func(10, 20);
        }
    }
}
