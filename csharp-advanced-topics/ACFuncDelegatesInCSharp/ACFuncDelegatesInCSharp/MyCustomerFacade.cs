using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACFuncDelegatesInCSharp
{
    public class MyCustomerFacade
    {

        //The Action delegate would hold the reference to the call back method
        public void MyUpdateData(Action<string> notifypresentation)
        {

            notifypresentation("New Message from facade");

        }


        //The Func delegate would hold the reference to the callback method
        public string MyUpdateData(Func<bool, string> notifyPresentationReturnString)
        {
            var returnValue = notifyPresentationReturnString(true);

            Console.WriteLine("My new Customer Facade " + returnValue);

            return returnValue;
        }
    }
}
