using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ActionAndFuncDelegates
{
    class Program
    {

    


            static void Main(string[] args)
        {
            Func<int, int, int> sumDelegate = Delegates.Lib.DelegatesLibrary.AddTwoNumbers;
            Console.WriteLine(sumDelegate(30,12));

            Action<int, int> printNumber = new Action<int, int>(Delegates.Lib.DelegatesLibrary.PrintNumbers);
            printNumber(5, 20);

        }
    }
}
