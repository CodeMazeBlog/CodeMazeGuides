using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public static class AsyncController
    {
        public static async Task<int> DoubleAsync(int number)
        {
            await Task.Delay(1000);
            return number * 2;
        }
    }
}
