using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesInCsharp
{
    public class FuncDelegates
    {
        //---------------------SAMPLES OF FUNC DELEGATES ------------------------------
        //Here we defined another action delegate and initialized it to point a method named DisplayText
        //According to action delegate define DisplayText method must get a input parameter of type string and does not return a value
        Func<double, double, double> functionDelegate = new Func<double, double, double>(GetTax);

        //if you define a function delegate with only one argument, you are referencing a method with no inputs and returning a value. The argument is the return type.
        Func<double> maxSalaryFind = () => { return 50000; };

        public void Test()
        {

            //test 1
            var calculatedTax = functionDelegate(3000, 0.18);
            Helper.Log("calculatedTax is :{0}", calculatedTax);

            //test 2
            Helper.Log("Max salary is :" + maxSalaryFind());
        }

        public static double GetTax(double netSalary, double taxRate)
        {
            return (double)(netSalary * taxRate);
        }
    }
}
