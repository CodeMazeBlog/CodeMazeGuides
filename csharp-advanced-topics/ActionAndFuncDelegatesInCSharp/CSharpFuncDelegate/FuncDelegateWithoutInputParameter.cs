using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Func_Delegate
{
    public class FuncDelegateWithoutInputParameter
    {
        public double ProcessBmi()
        {
            double height = 175d;
            double weight = 75d;
            double bmi = 0d;
            if (height > 0d && weight > 0d)
            {
                var h = height / 100d;

                bmi = weight / h / h;
            }

            return bmi;
        }
    }
}
