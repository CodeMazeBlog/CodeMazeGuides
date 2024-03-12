using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Action_Delegate
{
    public class GenericActionDelegate
    {
        public void ProcessBmi(double height, double weight)
        {
            double bmi = 0d;
            if (height > 0d && weight > 0d)
            {
                var h = height / 100d;

                bmi = weight / h / h;
            }

            Console.WriteLine($"The BMI is : {bmi:N}.");
        }
        
        //public Action<double, double> doWorkAction = ProcessBmi;
    }
}
