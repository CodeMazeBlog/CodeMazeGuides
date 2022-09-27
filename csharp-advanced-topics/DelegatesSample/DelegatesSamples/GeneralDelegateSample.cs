using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesSampleCode
{
    public class GeneralDelegateSample
    {
        public delegate int Operation(int x, int y);
        public static bool Sample()
        {
            try
            {                

                var deleOperation = new Operation(MathOperations.Add);

                deleOperation(100, 100);
                deleOperation = new Operation(MathOperations.Subtract);

                deleOperation(50, 25);

                
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
