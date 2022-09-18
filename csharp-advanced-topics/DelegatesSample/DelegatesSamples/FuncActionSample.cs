using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesSampleCode
{
    public class FuncActionSample
    {
        public static bool Sample()
        {
            try
            {
                // Use Action<> delegate to point to Add method
                Action<int, int> actionTarget = new Action<int, int>(MathOperations.Multiply);
                actionTarget(10, 15);
                Action<string, int, int> actionTargetSring = new Action<string, int, int>(MathOperations.Multiply);
                actionTargetSring("Welcome!!", 10, 12);
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
    
}
