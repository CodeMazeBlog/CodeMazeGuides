using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMaze_ActionFunc
{
    class Program
    {
      
        static void Main(string[] args)
        {
        }

        //in a class context
        static Action AditionDelegate = new Action(Addition); //can be invoked anywhere within this class

        Action<int, int> AditionDelegateWithParameters = new Action<int, int>(Addition); //can be invoked anywhere within this class

        static Func<double, double> GetInterestRate = amount => amount * 0.15; //accessible within this class

        //define custom delegate
        delegate double  GetInterestRateCustomDelegate (double amount);

        //create instance of custom delegate and implement delegate method option
        static GetInterestRateCustomDelegate getInterestRateCustomDelegate
               = new GetInterestRateCustomDelegate(
                   delegate (double amount)
                   {
                       return amount * 0.15;
                   });

        //using pointer (lambda expression option instead of creating instance of custom delegate
       static  GetInterestRateCustomDelegate getInterestRateCustomDelegatePointer = amount => amount * 0.15;

        //methods for delegate
        static void Addition(int a, int b) { Console.WriteLine(a + b); }
        static void Addition() { Console.WriteLine("Hello addition"); }

        //in a method context. Defined and implemented within a method
        static void ExecuteDelegateAndFunc()
        {
            Action aditionDelegate = new Action(Addition);
           aditionDelegate.Invoke();

            Func<double, double> getInterestRate = amount => amount * 0.15;

            double amountForInterestRateCalculation = 1000;
            Console.WriteLine( getInterestRate(amountForInterestRateCalculation));

        }
 
        static void ExecuteDelegateByName()
        {
            Action aditionDelegate = new Action(Addition);
            aditionDelegate();

        }
        static void ExecuteDelegateByInvoke()
        {
            Action aditionDelegate = new Action(Addition);
            aditionDelegate.Invoke();

        }
        static void ExecuteDelegateWithParamenters()
        {
            Action<int, int> aditionDelegateWithParameters = new Action<int, int>(Addition);  
            aditionDelegateWithParameters.Invoke(4, 4); 

        }
     
       

        //call or execute created instance of custom delegate
        static void ExecuteInstantiatedCustomDelegate()
        {
            double amount = 1000;
            double rateAmount = getInterestRateCustomDelegate(amount);
            Console.WriteLine($" 15% interest of {amount} from custom delegate instantiated is {rateAmount}");

        }
        //call or execute custom delegate pointer
        static void ExecuteCustomDelegatePointer()
        {
            double amount = 1000;
            double rateAmount = getInterestRateCustomDelegatePointer(amount);
            Console.WriteLine($" 15% interest of {amount} from custom delegate pointer is {rateAmount}");

        }
    }
}
