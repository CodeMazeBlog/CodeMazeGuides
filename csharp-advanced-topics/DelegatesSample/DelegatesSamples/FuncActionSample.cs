using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesSampleCode
{
    public class FuncActionSample
    {
        public static bool SampleAction()
        {
            try
            {
                // Use Action<> delegate to point to Multiply method
                var actionTarget = new Action<int, int>(MathOperations.Multiply);
                actionTarget(10, 15);

                var actionTargetSring = new Action<string, int, int>(MathOperations.Multiply);
                actionTargetSring("Welcome!!", 10, 12);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public static int SampleFunc()
        {
            try
            {
                // Use Func<> delegate to point to Add method
                var actionTarget = MathOperations.Add;

                return actionTarget(10, 15);                                
            }
            catch
            {
                return 0;
            }

        }

    }
    
}
