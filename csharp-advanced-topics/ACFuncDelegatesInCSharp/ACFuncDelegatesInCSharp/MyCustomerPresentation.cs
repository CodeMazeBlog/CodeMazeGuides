using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACFuncDelegatesInCSharp
{
    public class MyCustomerPresentation
    {
        public void CheckUpdate()
        {
            MyCustomerFacade fc = new MyCustomerFacade();

            //pass callback method for Action delegate
            fc.MyUpdateData(MyNotificationCallBack);

            Console.WriteLine();


            //pass callback method for Func delegate
            fc.MyUpdateData(NewnotificationCallBack);


        }

        public void MyNotificationCallBack(string message)
        {
            Console.WriteLine("Update data object completed from Action Delegates is the  " + message);

        }


        public string NewnotificationCallBack(bool isUpdateSuccess)
        {
            if (isUpdateSuccess)
            {
                Console.WriteLine("Update was successful from Func Delegates");
            }
            else
            {
                Console.WriteLine("Update was not successful from Func Delegates");
            }

            return "verifies that the Func delegates has a string return value";
        }
    }
}
