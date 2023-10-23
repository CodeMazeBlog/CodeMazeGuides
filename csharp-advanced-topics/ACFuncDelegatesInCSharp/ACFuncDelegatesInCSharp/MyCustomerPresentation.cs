namespace ACFuncDelegatesInCSharp
{
    public class MyCustomerPresentation
    {
        public void CheckUpdate()
        {
            var fc = new MyCustomerFacade();
            fc.MyUpdateData(MyNotificationCallBack);
            Console.WriteLine();
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
