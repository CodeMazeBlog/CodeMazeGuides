namespace ActionAndFuncDelegate.Action
{
    public class ActionDelegateExample
    {
        public static void ActionDelegate()
        {
            Action<int> printArticalNumber = (number) =>
            {
                Console.WriteLine("The article number is: " + number);
            };

            printArticalNumber(10);
        }
    }
}
