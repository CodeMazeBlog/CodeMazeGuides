using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public static class CallbackController
    {
        public static IEnumerable<string> CountDown(int count, Func<int, string> func)
        {
            for (var i = 0; i < count; i++)
            {
                yield return func(count - i);
            }
        }

        public static string CalculateMinusOne(int number)
        {
            return number.ToString();
        }
    }
}
