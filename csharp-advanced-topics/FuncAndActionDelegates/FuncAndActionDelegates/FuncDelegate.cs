using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncNActionDelegates
{
    public class FuncDelegate
    {
        public int GetFactorial(int factNum)
        {
            int i, fact = 1;

            for (i = 1; i <= factNum; i++)
            {
                fact = fact * i;
            }

            return fact;
        }
    }
}
