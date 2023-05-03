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
            // Do some action with the given input parameters
            action(10, "test");
        }

        public static TResult DoFunc<TResult>(Func<int, int, TResult> func)
        {
            // Call the function with some input parameters
            return func(10, 20);
        }
    }
}
