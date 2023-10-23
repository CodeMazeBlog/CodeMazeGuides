namespace ACFuncDelegatesInCSharp
{
    public class MyCustomerFacade
    {
        public void MyUpdateData(Action<string> notifypresentation)
        {
            notifypresentation("New Message from facade");
        }
        public string MyUpdateData(Func<bool, string> notifyPresentationReturnString)
        {
            var returnValue = notifyPresentationReturnString(true);
            Console.WriteLine("My new Customer Facade " + returnValue);
            return returnValue;
        }
    }
}

